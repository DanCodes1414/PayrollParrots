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
    [Activity(Label = "PayrollPreviousMonths")]
    public class PayrollPreviousMonths : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly PayrollCategory payrollCategory = new PayrollCategory();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        readonly ValidatingDeductions validatingDeductions = new ValidatingDeductions();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_previous_months);

            //PreviousMonthsRemuneration
            EditText previousMonthsRemuneration_ = FindViewById<EditText>(Resource.Id.previousMonthsRemuneration);
            previousMonthsRemuneration_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousMonthsRemuneration = editTextToDouble.EditText_AfterTextChanged(previousMonthsRemuneration_);
            };

            //PreviousEPFContribution
            EditText previousEPFContribution_ = FindViewById<EditText>(Resource.Id.previousEPFContribution);
            double _previousEPFContribution = 0.00;
            previousEPFContribution_.AfterTextChanged += (sender, args) =>
            {
                _previousEPFContribution = editTextToDouble.EditTextDeductions_AfterTextChanged(previousEPFContribution_, 4000);
            };

            //PreviousBIK
            EditText previousBIK_ = FindViewById<EditText>(Resource.Id.previousBIK);
            previousBIK_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousBIK = editTextToDouble.EditText_AfterTextChanged(previousBIK_);
            };

            //PreviousVOLA
            EditText previousVOLA_ = FindViewById<EditText>(Resource.Id.previousVOLA);
            previousVOLA_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.VOLA = editTextToDouble.EditText_AfterTextChanged(previousVOLA_);
            };

            //MTDPrevious
            EditText MTDPrevious_ = FindViewById<EditText>(Resource.Id.MTDPrevious);
            double _MTDPrevious = 0.00;
            MTDPrevious_.AfterTextChanged += (sender, args) =>
            {
                _MTDPrevious = editTextToDouble.EditText_AfterTextChanged(MTDPrevious_);
            };

            Button _sixthContinue = FindViewById<Button>(Resource.Id.continuePayroll6);
            _sixthContinue.Click += (sender, e) =>
            {
                if (validatingDeductions.ValidateDeductionInputsLowerThanLimit(_previousEPFContribution, 4000, previousEPFContribution_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Please make sure EPF is below RM4000", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    payrollCategory.PreviousRemuneration["PreviousMonthsRemuneration"] = payrollItems.PreviousMonthsRemuneration;
                    payrollCategory.PreviousBenefitInKind["PreviousBIK"] = payrollItems.PreviousBIK;
                    payrollCategory.PreviousValueOfLivingAccomodation["PreviousVOLA"] = payrollItems.PreviousVOLA;

                    soundPlayer.PlaySound_ButtonClick(this);

                    var FamilyDeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("FamilyDeductionItems"));
                    var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
                    var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
                    var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));
                    var AdditionalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("AdditionalRemuneration"));
                    var DeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Deductions"));
                    var RebateItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Rebates"));

                    double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
                    int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                    double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                    double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                    int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                    string _employeeName = Intent.GetStringExtra("employeeName");

                    Intent intent = new Intent(this, typeof(PayrollPreviousDeductions));
                    intent.PutExtra("previousEPFContribution", _previousEPFContribution);
                    intent.PutExtra("MTDPrevious", _MTDPrevious);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                    intent.PutExtra("monthsRemaining", _monthsRemaining);
                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);

                    intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                    intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(NormalRemunerationItems));
                    intent.PutExtra("BIK", JsonConvert.SerializeObject(BIKItems));
                    intent.PutExtra("VOLA", JsonConvert.SerializeObject(VOLAItems));
                    intent.PutExtra("AdditionalRemuneration", JsonConvert.SerializeObject(AdditionalRemunerationItems));
                    intent.PutExtra("Deductions", JsonConvert.SerializeObject(DeductionItems));
                    intent.PutExtra("Rebates", JsonConvert.SerializeObject(RebateItems));
                    intent.PutExtra("PreviousRemuneration", JsonConvert.SerializeObject(payrollCategory.PreviousRemuneration));
                    intent.PutExtra("PreviousBIK", JsonConvert.SerializeObject(payrollCategory.PreviousBenefitInKind));
                    intent.PutExtra("PreviousVOLA", JsonConvert.SerializeObject(payrollCategory.PreviousValueOfLivingAccomodation));
                    StartActivity(intent);
                }
            };
        }
    }
}
