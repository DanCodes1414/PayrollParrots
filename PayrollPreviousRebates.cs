using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using PayrollParrots.Model;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollPreviousRebates")]
    public class PayrollPreviousRebates : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly PayrollCategory payrollCategory = new PayrollCategory();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_previous_rebates);

            //previousZakatByEmployee
            EditText previousZakatByEmployee_ = FindViewById<EditText>(Resource.Id.previousZakatByEmployee);
            previousZakatByEmployee_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousZakatByEmployee = editTextToDouble.EditText_AfterTextChanged(previousZakatByEmployee_);
            };

            //previousZakatByPayroll
            EditText previousZakatByPayroll_ = FindViewById<EditText>(Resource.Id.previousZakatByPayroll);
            previousZakatByPayroll_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousZakatViaPayroll = editTextToDouble.EditText_AfterTextChanged(previousZakatByPayroll_);
            };

            //previousDepartureLevy
            EditText previousDepartureLevy_ = FindViewById<EditText>(Resource.Id.previousDepartureLevy);
            previousDepartureLevy_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousDepartureLevy = editTextToDouble.EditText_AfterTextChanged(previousDepartureLevy_);
            };

            Button _eighthContinue = FindViewById<Button>(Resource.Id.continuePayroll8);
            _eighthContinue.Click += (sender, e) =>
            {
                payrollCategory.PreviousRebates["PreviousZakatByEmployee"] = payrollItems.PreviousZakatByEmployee;
                payrollCategory.PreviousRebates["PreviousZakatViaPayroll"] = payrollItems.PreviousZakatViaPayroll;
                payrollCategory.PreviousRebates["PreviousDepartureLevy"] = payrollItems.PreviousDepartureLevy;

                soundPlayer.PlaySound_ButtonClick(this);

                var FamilyDeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("FamilyDeductionItems"));
                var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
                var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
                var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));
                var AdditionalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("AdditionalRemuneration"));
                var DeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Deductions"));
                var RebateItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Rebates"));
                var PreviousRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousRemuneration"));
                var PreviousBIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousBIK"));
                var PreviousVOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousVOLA"));
                var PreviousDeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousDeductions"));

                double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
                double _previousSOCSOContribution = Intent.GetDoubleExtra("previousSOCSOContribution", 0.00);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                double _previousEPFContribution = Intent.GetDoubleExtra("previousEPFContribution", 0.00);
                double _MTDPrevious = Intent.GetDoubleExtra("MTDPrevious", 0.00);
                double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                string _employeeName = Intent.GetStringExtra("employeeName");

                Intent intent = new Intent(this, typeof(PayrollFinalCalculation));
                intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(NormalRemunerationItems));
                intent.PutExtra("BIK", JsonConvert.SerializeObject(BIKItems));
                intent.PutExtra("VOLA", JsonConvert.SerializeObject(VOLAItems));
                intent.PutExtra("AdditionalRemuneration", JsonConvert.SerializeObject(AdditionalRemunerationItems));
                intent.PutExtra("Deductions", JsonConvert.SerializeObject(DeductionItems));
                intent.PutExtra("Rebates", JsonConvert.SerializeObject(RebateItems));
                intent.PutExtra("PreviousRemuneration", JsonConvert.SerializeObject(PreviousRemunerationItems));
                intent.PutExtra("PreviousBIK", JsonConvert.SerializeObject(PreviousBIKItems));
                intent.PutExtra("PreviousVOLA", JsonConvert.SerializeObject(PreviousVOLAItems));
                intent.PutExtra("PreviousDeductions", JsonConvert.SerializeObject(PreviousDeductionItems));
                intent.PutExtra("PreviousRebates", JsonConvert.SerializeObject(payrollCategory.PreviousRebates));

                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("previousSOCSOContribution", _previousSOCSOContribution);
                intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("previousEPFContribution", _previousEPFContribution);
                intent.PutExtra("MTDPrevious", _MTDPrevious);
                intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                intent.PutExtra("monthsRemaining", _monthsRemaining);
                StartActivity(intent);
            };
        }
    }
}
