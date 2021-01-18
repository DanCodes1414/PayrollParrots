using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using PayrollParrots.Model;
using PayrollParrots.PayrollTax;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollAdditionalCurrentMonth")]
    public class PayrollAdditionalCurrentMonth : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly EPFCalculations EPFCalculations = new EPFCalculations();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly PayrollCategory payrollCategory = new PayrollCategory();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double EPFNinePercentRate = 0.09;
        public const double EPFElevenPercentRate = 0.11;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_additional_current_month);

            //Bonus
            EditText bonus_ = FindViewById<EditText>(Resource.Id.bonus);
            bonus_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.Bonus = editTextToDouble.EditText_AfterTextChanged(bonus_);
            };

            //Arrears
            EditText arrears_ = FindViewById<EditText>(Resource.Id.arrears);
            arrears_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.Arrears = editTextToDouble.EditText_AfterTextChanged(arrears_);
            };

            //Commission
            EditText commission_ = FindViewById<EditText>(Resource.Id.commission);
            commission_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.Commission = editTextToDouble.EditText_AfterTextChanged(commission_);
            };

            //Other EPF not subject
            EditText OthersEPFNO_ = FindViewById<EditText>(Resource.Id.OthersEPFNO);
            OthersEPFNO_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.OthersNotSubjectToEPF = editTextToDouble.EditText_AfterTextChanged(OthersEPFNO_);
            };

            //Other EIS not subject
            EditText OthersEISNO_ = FindViewById<EditText>(Resource.Id.OthersEISNO);
            OthersEISNO_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.OthersNotSubjectToSOCSOAndEIS = editTextToDouble.EditText_AfterTextChanged(OthersEISNO_);
            };

            //Others
            EditText others_ = FindViewById<EditText>(Resource.Id.others);
            others_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.OthersSubjectToEPFAndSOCSOAndEIS = editTextToDouble.EditText_AfterTextChanged(others_);
            };

            var FamilyDeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("FamilyDeductionItems"));
            var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
            var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
            var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));

            Button _thirdContinue = FindViewById<Button>(Resource.Id.continuePayroll3);
            _thirdContinue.Click += (sender, e) =>
            {
                soundPlayer.PlaySound_ButtonClick(this);

                payrollCategory.AdditionalRemuneration["Bonus"] = payrollItems.Bonus;
                payrollCategory.AdditionalRemuneration["Arrears"] = payrollItems.Arrears;
                payrollCategory.AdditionalRemuneration["Commission"] = payrollItems.Commission;
                payrollCategory.AdditionalRemuneration["OthersNotSubjectToEPF"] = payrollItems.OthersNotSubjectToEPF;
                payrollCategory.AdditionalRemuneration["OthersNotSubjectToSOCSOAndEIS"] = payrollItems.OthersNotSubjectToSOCSOAndEIS;
                payrollCategory.AdditionalRemuneration["OthersSubjectToEPFAndSOCSOAndEIS"] = payrollItems.OthersSubjectToEPFAndSOCSOAndEIS;

                double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                double _EPFRate = Intent.GetDoubleExtra("EPFRate", 0.11);
                int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                string _employeeName = Intent.GetStringExtra("employeeName");
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);

                //additional EPF
                double _EPFAdditionalContribution = EPFCalculations.EmployeeEPFAdditionalCalculation(_employeeAge, _EPFRate, _EPFContribution, NormalRemunerationItems, payrollCategory.AdditionalRemuneration);

                Intent intent = new Intent(this, typeof(PayrollDeductions));
                intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("monthsRemaining", _monthsRemaining);

                intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(NormalRemunerationItems));
                intent.PutExtra("BIK", JsonConvert.SerializeObject(BIKItems));
                intent.PutExtra("VOLA", JsonConvert.SerializeObject(VOLAItems));
                intent.PutExtra("AdditionalRemuneration", JsonConvert.SerializeObject(payrollCategory.AdditionalRemuneration));
                StartActivity(intent);
            };
        }
    }
}
