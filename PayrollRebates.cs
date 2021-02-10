using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using PayrollParrots.UsedManyTimes;
using PayrollParrots.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayrollParrots
{
    [Activity(Label = "PayrollRebates")]
    public class PayrollRebates : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_rebates);

            //ZakatByEmployee
            EditText zakatByEmployee_ = FindViewById<EditText>(Resource.Id.zakatByEmployee);
            zakatByEmployee_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.ZakatByEmployee = editTextToDouble.EditText_AfterTextChanged(zakatByEmployee_);
            };

            //ZakatByPayroll
            EditText zakatByPayroll_ = FindViewById<EditText>(Resource.Id.zakatByPayroll);
            zakatByPayroll_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.ZakatViaPayroll = editTextToDouble.EditText_AfterTextChanged(zakatByPayroll_);
            };

            //DepartureLevy
            EditText departureLevy_ = FindViewById<EditText>(Resource.Id.departureLevy);
            departureLevy_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.DepartureLevy = editTextToDouble.EditText_AfterTextChanged(departureLevy_);
            };

            Button _fifthContinue = FindViewById<Button>(Resource.Id.continuePayroll5);
            _fifthContinue.Click += (sender, e) =>
            {
                soundPlayer.PlaySound_ButtonClick(this);

                PayrollCategory payrollCategory = new PayrollCategory(payrollItems);

                var FamilyDeductionItems = JsonConvert.DeserializeObject<PayrollFamilyDeductions>(Intent.GetStringExtra("FamilyDeductionItems"));
                var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
                var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
                var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));
                var AdditionalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("AdditionalRemuneration"));
                var DeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Deductions"));

                double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                string _employeeName = Intent.GetStringExtra("employeeName");
                string email = Intent.GetStringExtra("email");

                Intent intent = new Intent(this, typeof(PayrollPreviousMonths));
                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                intent.PutExtra("monthsRemaining", _monthsRemaining);
                intent.PutExtra("email", email);

                intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(NormalRemunerationItems));
                intent.PutExtra("BIK", JsonConvert.SerializeObject(BIKItems));
                intent.PutExtra("VOLA", JsonConvert.SerializeObject(VOLAItems));
                intent.PutExtra("AdditionalRemuneration", JsonConvert.SerializeObject(AdditionalRemunerationItems));
                intent.PutExtra("Deductions", JsonConvert.SerializeObject(DeductionItems));
                intent.PutExtra("Rebates", JsonConvert.SerializeObject(payrollCategory.Rebates));
                StartActivity(intent);
            };
        }
    }
}
