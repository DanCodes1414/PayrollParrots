using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using PayrollParrots.UsedManyTimes;
using PayrollParrots.Model;
using PayrollParrots.PayrollTax;
using Newtonsoft.Json;

namespace PayrollParrots
{
    [Activity(Label = "PayrollCurrentMonth")]
    public class PayrollCurrentMonth : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly PayrollItems payrollItems = new PayrollItems();
        PayrollCategory payrollCategory;
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double EPFNinePercentRate = 0.09;
        public const double EPFElevenPercentRate = 0.11;
        double _EPFRate = 0.11;
        double _EPFContribution;
        int _employeeAge;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_current_month);
            //EPF rate
            RadioButton EPFRate9 = FindViewById<RadioButton>(Resource.Id.radio9rate);
            EPFRate9.CheckedChange += (sender, e) =>
            {
                double _EPFRate = EPFRate_CheckedChanged(sender, e);
                (_EPFContribution, payrollItems.CurrentMonthRemuneration) = EPFRateCheckedChanged_CalculateEPF(sender, _EPFRate);
            };
            RadioButton EPFRate11 = FindViewById<RadioButton>(Resource.Id.radio11rate);
            EPFRate11.CheckedChange += (sender, e) =>
            {
                double _EPFRate = EPFRate_CheckedChanged(sender, e);
                (_EPFContribution, payrollItems.CurrentMonthRemuneration) = EPFRateCheckedChanged_CalculateEPF(sender, _EPFRate);
            };

            //currentmonthremu
            EditText currentMonthRemuneration_ = FindViewById<EditText>(Resource.Id.currentMonthRemuneration);
            currentMonthRemuneration_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            currentMonthRemuneration_.AfterTextChanged += (sender, args) =>
            {
                (_EPFContribution, payrollItems.CurrentMonthRemuneration) = CurrentMonthRemunerationTextChanged_CalculateEPF(sender, _EPFRate);
            };

            //BIK
            EditText BIK_ = FindViewById<EditText>(Resource.Id.BIK);
            BIK_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.BIK = editTextToDouble.EditText_AfterTextChanged(BIK_);
            };

            //VOLA
            EditText VOLA_ = FindViewById<EditText>(Resource.Id.VOLA);
            VOLA_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.VOLA = editTextToDouble.EditText_AfterTextChanged(VOLA_);
            };

            Button _secondContinue = FindViewById<Button>(Resource.Id.continuePayroll2);
            _secondContinue.Click += (sender, e) =>
            {
                soundPlayer.PlaySound_ButtonClick(this);

                PayrollCategory payrollCategory = new PayrollCategory(payrollItems);

                var FamilyDeductionItems = JsonConvert.DeserializeObject<PayrollFamilyDeductions>(Intent.GetStringExtra("FamilyDeductionCategory"));
                string _employeeName = Intent.GetStringExtra("employeeName");
                int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                string email = Intent.GetStringExtra("email");

                Intent intent = new Intent(this, typeof(PayrollAdditionalCurrentMonth));
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("EPFRate", _EPFRate);
                intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(payrollCategory.NormalRemuneration));
                intent.PutExtra("BIK", JsonConvert.SerializeObject(payrollCategory.BenefitInKind));
                intent.PutExtra("VOLA", JsonConvert.SerializeObject(payrollCategory.ValueOfLivingAccomodation));

                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("monthsRemaining", _monthsRemaining);
                intent.PutExtra("email", email);
                StartActivity(intent);
            };
        }

        //change epfrate
        private double EPFRate_CheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (e.IsChecked)
            {
                switch (radioButton.Id)
                {
                    case Resource.Id.radio9rate:
                        _EPFRate = 0.09;
                        break;
                    case Resource.Id.radio11rate:
                        _EPFRate = 0.11;
                        break;
                }
            }
            return _EPFRate;
        }

        public (double, double) CurrentMonthRemunerationTextChanged_CalculateEPF(object sender, double _EPFRate)
        {
            EditText editText = sender as EditText;
            _employeeAge = Intent.GetIntExtra("employeeAge", 0);

            switch (editText.Id)
            {
                case Resource.Id.currentMonthRemuneration:
                    if (NumberChecks.IsZero(editText.Length()))
                    {
                        editText.Text.Equals("");
                        payrollItems.CurrentMonthRemuneration = 0.00;
                        double _EPFContribution = 0.00;
                        return (_EPFContribution, payrollItems.CurrentMonthRemuneration);
                    }
                    else
                    {
                        payrollCategory = new PayrollCategory(payrollItems);
                        payrollItems.CurrentMonthRemuneration = double.Parse(editText.Text);
                        EPFCalculations EPFCalculations = new EPFCalculations(payrollItems, payrollCategory.AdditionalRemuneration);
                        _EPFContribution = EPFCalculations.EmployeeEPFCalculation(_employeeAge, _EPFRate);
                        return (_EPFContribution, payrollItems.CurrentMonthRemuneration);
                    }
            }
            return (_EPFContribution, payrollItems.CurrentMonthRemuneration);
        }

        //In case user types normal remuneration then changes epf rate
        public (double, double) EPFRateCheckedChanged_CalculateEPF(object sender, double _EPFRate)
        {
            RadioButton radioButton = sender as RadioButton;
            _employeeAge = Intent.GetIntExtra("employeeAge", 0);

            switch (radioButton.Id)
            {
                case Resource.Id.radio11rate:
                    payrollCategory = new PayrollCategory(payrollItems);
                    EPFCalculations EPFCalculations = new EPFCalculations(payrollItems, payrollCategory.AdditionalRemuneration);
                    _EPFContribution = EPFCalculations.EmployeeEPFCalculation(_employeeAge, _EPFRate);
                    return (_EPFContribution, payrollItems.CurrentMonthRemuneration);
            }
            return (_EPFContribution, payrollItems.CurrentMonthRemuneration);
        }
    }
}