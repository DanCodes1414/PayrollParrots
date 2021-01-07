using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    //#fix
    [Activity(Label = "PayrollPreviousRebates")]
    public class PayrollPreviousRebates : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_previous_rebates);
            //previousZakatByEmployee
            EditText previousZakatByEmployee_ = FindViewById<EditText>(Resource.Id.previousZakatByEmployee);
            previousZakatByEmployee_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousZakatByEmployee = 0.00;
            previousZakatByEmployee_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousZakatByEmployee_.Text, out _previousZakatByEmployee);
            };
            //previousZakatByPayroll
            EditText previousZakatByPayroll_ = FindViewById<EditText>(Resource.Id.previousZakatByPayroll);
            previousZakatByPayroll_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousZakatByPayroll = 0.00;
            previousZakatByPayroll_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousZakatByPayroll_.Text, out _previousZakatByPayroll);
            };
            //previousDepartureLevy
            EditText previousDepartureLevy_ = FindViewById<EditText>(Resource.Id.previousDepartureLevy);
            previousDepartureLevy_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousDepartureLevy = 0.00;
            previousDepartureLevy_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousDepartureLevy_.Text, out _previousDepartureLevy);
            };

            Button _eighthContinue = FindViewById<Button>(Resource.Id.continuePayroll8);
            _eighthContinue.Click += (sender, e) =>
            {
                soundPlayer.PlaySound_ButtonClick(this);

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
                double _medicalExamination = Intent.GetDoubleExtra("medicalExamination", 0.00);
                double _medicalDisease = Intent.GetDoubleExtra("medicalDisease", 0.00);
                double _smallKidEducation = Intent.GetDoubleExtra("smallKidEducation", 0.00);
                double _breastFeedingEquipment = Intent.GetDoubleExtra("breastFeedingEquipment", 0.00);
                double _alimonyFormerWife = Intent.GetDoubleExtra("alimonyFormerWife", 0.00);
                double _EMInsurance = Intent.GetDoubleExtra("EMInsurance", 0.00);
                double _fatherRelief = Intent.GetDoubleExtra("fatherRelief", 0.00);
                double _motherRelief = Intent.GetDoubleExtra("motherRelief", 0.00);
                double _sportsRelief = Intent.GetDoubleExtra("sportsRelief", 0.00);
                double _medicalVaccination = Intent.GetDoubleExtra("medicalVaccination", 0.00);
                double _domesticTourismExpenditure = Intent.GetDoubleExtra("domesticTourismExpenditure", 0.00);
                double _previousLifeStyleRelief = Intent.GetDoubleExtra("previousLifeStyleRelief", 0.00);
                double _previousSOCSOContribution = Intent.GetDoubleExtra("previousSOCSOContribution", 0.00);
                double _previousLifeInsurance = Intent.GetDoubleExtra("previousLifeInsurance", 0.00);
                double _previousBasicEquipment = Intent.GetDoubleExtra("previousBasicEquipment", 0.00);
                double _previousEducationYourSelf = Intent.GetDoubleExtra("previousEducationYourSelf", 0.00);
                double _previousMedicalExamination = Intent.GetDoubleExtra("previousMedicalExamination", 0.00);
                double _previousMedicalDisease = Intent.GetDoubleExtra("previousMedicalDisease", 0.00);
                double _previousSmallKidEducation = Intent.GetDoubleExtra("previousSmallKidEducation", 0.00);
                double _previousBreastFeedingEquipment = Intent.GetDoubleExtra("previousBreastFeedingEquipment", 0.00);
                double _previousAlimonyFormerWife = Intent.GetDoubleExtra("previousAlimonyFormerWife", 0.00);
                double _previousEMInsurance = Intent.GetDoubleExtra("previousEMInsurance", 0.00);
                double _previousFatherRelief = Intent.GetDoubleExtra("previousFatherRelief", 0.00);
                double _previousMotherRelief = Intent.GetDoubleExtra("previousMotherRelief", 0.00);
                double _previousSportsRelief = Intent.GetDoubleExtra("previousSportsRelief", 0.00);
                double _previousMedicalVaccination = Intent.GetDoubleExtra("previousMedicalVaccination", 0.00);
                double _previousDomesticTourismExpenditure = Intent.GetDoubleExtra("previousDomesticTourismExpenditure", 0.00);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                double _zakatByEmployee = Intent.GetDoubleExtra("zakatByEmployee", 0.00);
                double _zakatByPayroll = Intent.GetDoubleExtra("zakatByPayroll", 0.00);
                double _departureLevy = Intent.GetDoubleExtra("departureLevy", 0.00);
                double _totalDeductions = Intent.GetDoubleExtra("totalDeductions", 0.00);
                double _previousMonthsRemuneration = Intent.GetDoubleExtra("previousMonthsRemuneration", 0.00);
                double _previousEPFContribution = Intent.GetDoubleExtra("previousEPFContribution", 0.00);
                double _previousBIK = Intent.GetDoubleExtra("previousBIK", 0.00);
                double _previousVOLA = Intent.GetDoubleExtra("previousVOLA", 0.00);
                double _MTDPrevious = Intent.GetDoubleExtra("MTDPrevious", 0.00);
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
                double _previousMapaRelief = Intent.GetDoubleExtra("previousMapaRelief", 0.00);
                double _SSPN = Intent.GetDoubleExtra("SSPN", 0.00);
                double _previousSSPN = Intent.GetDoubleExtra("previousSSPN", 0.00);
                double _PRS = Intent.GetDoubleExtra("PRS", 0.00);
                double _previousPRS = Intent.GetDoubleExtra("previousPRS", 0.00);
                int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                string _employeeName = Intent.GetStringExtra("employeeName");
                Intent intent = new Intent(this, typeof(PayrollFinalCalculation));
                intent.PutExtra("previousZakatByEmployee", _previousZakatByEmployee);
                intent.PutExtra("previousZakatByPayroll", _previousZakatByPayroll);
                intent.PutExtra("previousDepartureLevy", _previousDepartureLevy);

                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("previousPRS", _previousPRS);
                intent.PutExtra("PRS", _PRS);
                intent.PutExtra("previousSSPN", _previousSSPN);
                intent.PutExtra("SSPN", _SSPN);
                intent.PutExtra("previousMapaRelief", _previousMapaRelief);
                intent.PutExtra("othersEISNO", _OthersEISNO);
                intent.PutExtra("previousLifeStyleRelief", _previousLifeStyleRelief);
                intent.PutExtra("previousSOCSOContribution", _previousSOCSOContribution);
                intent.PutExtra("previousLifeInsurance", _previousLifeInsurance);
                intent.PutExtra("previousBasicEquipment", _previousBasicEquipment);
                intent.PutExtra("previousEducationYourSelf", _previousEducationYourSelf);
                intent.PutExtra("previousMedicalExamintion", _previousMedicalExamination);
                intent.PutExtra("previousMedicalDisease", _previousMedicalDisease);
                intent.PutExtra("previousSmallKidEducation", _previousSmallKidEducation);
                intent.PutExtra("previousBreastFeedingEquipment", _previousBreastFeedingEquipment);
                intent.PutExtra("previousAlimonyFormerWife", _previousAlimonyFormerWife);
                intent.PutExtra("previousEMInsurance", _previousEMInsurance);
                intent.PutExtra("previousFatherRelief", _previousFatherRelief);
                intent.PutExtra("previousMotherRelief", _previousMotherRelief);
                intent.PutExtra("previousSportsRelief", _previousSportsRelief);
                intent.PutExtra("previousMedicalVaccination", _previousMedicalVaccination);
                intent.PutExtra("previousDomesticTourismExpenditure", _previousDomesticTourismExpenditure);
                intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("previousMonthsRemuneration", _previousMonthsRemuneration);
                intent.PutExtra("previousEPFContribution", _previousEPFContribution);
                intent.PutExtra("previousBIK", _previousBIK);
                intent.PutExtra("previousVOLA", _previousVOLA);
                intent.PutExtra("MTDPrevious", _MTDPrevious);
                intent.PutExtra("zakatByEmployee", _zakatByEmployee);
                intent.PutExtra("zakatByPayroll", _zakatByPayroll);
                intent.PutExtra("departureLevy", _departureLevy);
                intent.PutExtra("lifeStyleRelief", _lifeStyleRelief);
                intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                intent.PutExtra("lifeInsurance", _lifeInsurance);
                intent.PutExtra("basicEquipment", _basicEquipment);
                intent.PutExtra("educationYourSelf", _educationYourSelf);
                intent.PutExtra("medicalExamintion", _medicalExamination);
                intent.PutExtra("medicalDisease", _medicalDisease);
                intent.PutExtra("smallKidEducation", _smallKidEducation);
                intent.PutExtra("breastFeedingEquipment", _breastFeedingEquipment);
                intent.PutExtra("alimonyFormerWife", _alimonyFormerWife);
                intent.PutExtra("EMInsurance", _EMInsurance);
                intent.PutExtra("fatherRelief", _fatherRelief);
                intent.PutExtra("motherRelief", _motherRelief);
                intent.PutExtra("sportsRelief", _sportsRelief);
                intent.PutExtra("medicalVaccination", _medicalVaccination);
                intent.PutExtra("domesticTourismExpenditure", _domesticTourismExpenditure);
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
            };
        }
    }
}
