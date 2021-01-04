using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Text;
using Android.Widget;

namespace PayrollParrots
{
    //#fix
    [Activity(Label = "PayrollPreviousMonths")]
    public class PayrollPreviousMonths : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_previous_months);
            //PreviousMonthsRemuneration
            EditText previousMonthsRemuneration_ = FindViewById<EditText>(Resource.Id.previousMonthsRemuneration);
            previousMonthsRemuneration_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousMonthsRemuneration = 0.00;
            previousMonthsRemuneration_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMonthsRemuneration_.Text, out _previousMonthsRemuneration);
            };
            //PreviousEPFContribution
            EditText previousEPFContribution_ = FindViewById<EditText>(Resource.Id.previousEPFContribution);
            previousEPFContribution_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousEPFContribution = 0.00;
            previousEPFContribution_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousEPFContribution_.Text, out _previousEPFContribution);
                Validate(_previousEPFContribution, 4000, previousEPFContribution_);
            };
            //PreviousBIK
            EditText previousBIK_ = FindViewById<EditText>(Resource.Id.previousBIK);
            previousBIK_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousBIK = 0.00;
            previousBIK_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousBIK_.Text, out _previousBIK);
            };
            //PreviousVOLA
            EditText previousVOLA_ = FindViewById<EditText>(Resource.Id.previousVOLA);
            previousVOLA_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousVOLA = 0.00;
            previousVOLA_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousVOLA_.Text, out _previousVOLA);
            };
            //MTDPrevious
            EditText MTDPrevious_ = FindViewById<EditText>(Resource.Id.MTDPrevious);
            MTDPrevious_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _MTDPrevious = 0.00;
            MTDPrevious_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(MTDPrevious_.Text, out _MTDPrevious);
            };

            Button _sixthContinue = FindViewById<Button>(Resource.Id.continuePayroll6);
            _sixthContinue.Click += (sender, e) =>
            {
                if (Validate(_previousEPFContribution, 4000, previousEPFContribution_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Please make sure EPF is below RM4000", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    PlayButton_Click(sender, e);
                    double _currentMonthRemuneration = Intent.GetDoubleExtra("currentMonthRemuneration", 0.00);
                    double _BIK = Intent.GetDoubleExtra("BIK", 0.00);
                    double _VOLA = Intent.GetDoubleExtra("VOLA", 0.00);
                    double _totalFamilyDeductions = Intent.GetDoubleExtra("totalFamilyDeductions", 0.00);
                    double _bonus = Intent.GetDoubleExtra("bonus", 0.00);
                    double _arrears = Intent.GetDoubleExtra("arrears", 0.00);
                    double _commission = Intent.GetDoubleExtra("commission", 0.00);
                    double _othersEPFNO = Intent.GetDoubleExtra("othersNoEPF", 0.00);
                    double _others = Intent.GetDoubleExtra("others", 0.00);
                    double _lifeStyleRelief = Intent.GetDoubleExtra("lifeStyleRelief", 0.00);
                    double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
                    double _lifeInsurance = Intent.GetDoubleExtra("lifeInsurance", 0.00);
                    double _basicEquipment = Intent.GetDoubleExtra("basicEquipment", 0.00);
                    double _educationYourSelf = Intent.GetDoubleExtra("educationYourSelf", 0.00);
                    double _medicalExamintion = Intent.GetDoubleExtra("medicalExamintion", 0.00);
                    double _medicalDisease = Intent.GetDoubleExtra("medicalDisease", 0.00);
                    double _smallKidEducation = Intent.GetDoubleExtra("smallKidEducation", 0.00);
                    double _breastFeedingEquipment = Intent.GetDoubleExtra("breastFeedingEquipment", 0.00);
                    double _alimonyFormerWife = Intent.GetDoubleExtra("alimonyFormerWife", 0.00);
                    double _EMInsurance = Intent.GetDoubleExtra("EMInsurance", 0.00);
                    double _fatherRelief = Intent.GetDoubleExtra("fatherRelief", 0.00);
                    double _motherRelief = Intent.GetDoubleExtra("motherRelief", 0.00);
                    int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                    double _zakatByEmployee = Intent.GetDoubleExtra("zakatByEmployee", 0.00);
                    double _zakatByPayroll = Intent.GetDoubleExtra("zakatByPayroll", 0.00);
                    double _departureLevy = Intent.GetDoubleExtra("departureLevy", 0.00);
                    double _totalDeductions = Intent.GetDoubleExtra("totalDeductions", 0.00);
                    double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                    double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                    double _kidsU18 = Intent.GetDoubleExtra("kidsU18", 0.00);
                    double _over18inHE = Intent.GetDoubleExtra("over18inHE", 0.00);
                    double _disabledChildren = Intent.GetDoubleExtra("disabledChildren", 0.00);
                    double _disabledChildreninHE = Intent.GetDoubleExtra("disabledChildreninHE", 0.00);
                    double disabledDeduction = Intent.GetDoubleExtra("disabledDeduction", 0.00);
                    double disabledSpouseDeduction = Intent.GetDoubleExtra("disabledSpouseDeduction", 0.00);
                    double spouseNoIncomeDeduction = Intent.GetDoubleExtra("spouseNoIncomeDeduction", 0.00);
                    double _OthersEISNO = Intent.GetDoubleExtra("othersNoEIS", 0.00);
                    double _mapaRelief = Intent.GetDoubleExtra("mapaRelief", 0.00);
                    double _SSPN = Intent.GetDoubleExtra("SSPN", 0.00);
                    double _PRS = Intent.GetDoubleExtra("PRS", 0.00);
                    int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                    string _employeeName = Intent.GetStringExtra("employeeName");
                    Intent intent = new Intent(this, typeof(PayrollPreviousDeductions));
                    intent.PutExtra("previousMonthsRemuneration", _previousMonthsRemuneration);
                    intent.PutExtra("previousEPFContribution", _previousEPFContribution);
                    intent.PutExtra("previousBIK", _previousBIK);
                    intent.PutExtra("previousVOLA", _previousVOLA);
                    intent.PutExtra("MTDPrevious", _MTDPrevious);

                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("PRS", _PRS);
                    intent.PutExtra("SSPN", _SSPN);
                    intent.PutExtra("othersEISNO", _OthersEISNO);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("zakatByEmployee", _zakatByEmployee);
                    intent.PutExtra("zakatByPayroll", _zakatByPayroll);
                    intent.PutExtra("departureLevy", _departureLevy);
                    intent.PutExtra("lifeStyleRelief", _lifeStyleRelief);
                    intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                    intent.PutExtra("lifeInsurance", _lifeInsurance);
                    intent.PutExtra("basicEquipment", _basicEquipment);
                    intent.PutExtra("educationYourSelf", _educationYourSelf);
                    intent.PutExtra("medicalExamintion", _medicalExamintion);
                    intent.PutExtra("medicalDisease", _medicalDisease);
                    intent.PutExtra("smallKidEducation", _smallKidEducation);
                    intent.PutExtra("breastFeedingEquipment", _breastFeedingEquipment);
                    intent.PutExtra("alimonyFormerWife", _alimonyFormerWife);
                    intent.PutExtra("EMInsurance", _EMInsurance);
                    intent.PutExtra("fatherRelief", _fatherRelief);
                    intent.PutExtra("motherRelief", _motherRelief);
                    intent.PutExtra("bonus", _bonus);
                    intent.PutExtra("arrears", _arrears);
                    intent.PutExtra("commission", _commission);
                    intent.PutExtra("othersEPFNO", _othersEPFNO);
                    intent.PutExtra("Others", _others);
                    intent.PutExtra("currentMonthRemuneration", _currentMonthRemuneration);
                    intent.PutExtra("BIK", _BIK);
                    intent.PutExtra("VOLA", _VOLA);
                    intent.PutExtra("totalFamilyDeductions", _totalFamilyDeductions);
                    intent.PutExtra("monthsRemaining", _monthsRemaining);
                    intent.PutExtra("totalDeductions", _totalDeductions);
                    intent.PutExtra("kidsU18", _kidsU18);
                    intent.PutExtra("over18inHE", _over18inHE);
                    intent.PutExtra("disabledChildren", _disabledChildren);
                    intent.PutExtra("disabledChildreninHE", _disabledChildreninHE);
                    intent.PutExtra("disabledDeduction", disabledDeduction);
                    intent.PutExtra("disabledSpouseDeduction", disabledSpouseDeduction);
                    intent.PutExtra("spouseNoIncomeDeduction", spouseNoIncomeDeduction);
                    intent.PutExtra("mapaRelief", _mapaRelief);
                    StartActivity(intent);
                }
            };

            //button-click sound
            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }

        //check that total epf less than 4000
        bool Validate(double name, double value, EditText editText)
        {
            if (name > value)
            {
                editText.Error = "EPF for previous months remuneration cannot be greater than " + value;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
