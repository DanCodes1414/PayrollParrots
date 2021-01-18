using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using static Android.Widget.TextView;
using PayrollParrots.UsedManyTimes;
using PayrollParrots.Model;
using PayrollParrots.PayrollTax;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayrollParrots
{
    [Activity(Label = "PayrollCurrentMonth")]
    public class PayrollCurrentMonth : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly EPFCalculations EPFCalculations = new EPFCalculations();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly PayrollCategory payrollCategory = new PayrollCategory();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double EPFNinePercentRate = 0.09;
        public const double EPFElevenPercentRate = 0.11;
        double _EPFRate = 0.11;
        double _currentMonthRemuneration = 0.00;
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
            };
            RadioButton EPFRate11 = FindViewById<RadioButton>(Resource.Id.radio11rate);
            EPFRate11.CheckedChange += (sender, e) =>
            {
                double _EPFRate = EPFRate_CheckedChanged(sender, e);
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

                payrollCategory.NormalRemuneration["CurrentMonthRemuneration"] = payrollItems.CurrentMonthRemuneration;
                payrollCategory.BenefitInKind["BIK"] = payrollItems.BIK;
                payrollCategory.ValueOfLivingAccomodation["VOLA"] = payrollItems.VOLA;

                var FamilyDeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("FamilyDeductionCategory"));
                string _employeeName = Intent.GetStringExtra("employeeName");
                int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);

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
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                        _currentMonthRemuneration = 0.00;
                        double _EPFContribution = 0.00;
                        return (_EPFContribution, _currentMonthRemuneration);
                    }
                    else
                    {
                        _currentMonthRemuneration = double.Parse(editText.Text);
                        _EPFContribution = EPFCalculations.EmployeeEPFCalculation(_employeeAge, _EPFRate, _currentMonthRemuneration);
                        return (_EPFContribution, _currentMonthRemuneration);
                    }
            }
            return (_EPFContribution, _currentMonthRemuneration);
        }
    }
}