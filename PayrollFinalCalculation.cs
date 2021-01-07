using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using PayrollParrots.Model;
using PayrollParrots.Helper;
using NL.DionSegijn.Konfetti;
using Newtonsoft.Json;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollFinalCalculation")]
    public class PayrollFinalCalculation : Activity
    {
        public const double EmployeeMaxAgeForEPFContribution = 60;
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly TaxCalculation taxCalculation = new TaxCalculation();
        public Payroll payroll;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_final_calculation);
            int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
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
            double _zakatByEmployee = Intent.GetDoubleExtra("zakatByEmployee", 0.00);
            double _zakatByPayroll = Intent.GetDoubleExtra("zakatByPayroll", 0.00);
            double _departureLevy = Intent.GetDoubleExtra("departureLevy", 0.00);
            double _previousMonthsRemuneration = Intent.GetDoubleExtra("previousMonthsRemuneration", 0.00);
            double _previousEPFContribution = Intent.GetDoubleExtra("previousEPFContribution", 0.00);
            double _previousBIK = Intent.GetDoubleExtra("previousBIK", 0.00);
            double _previousVOLA = Intent.GetDoubleExtra("previousVOLA", 0.00);
            double _MTDPrevious = Intent.GetDoubleExtra("MTDPrevious", 0.00);
            double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
            double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
            double spouseNoIncomeDeduction = Intent.GetDoubleExtra("spouseNoIncomeDeduction", 0.00);
            double _previousZakatByEmployee = Intent.GetDoubleExtra("previousZakatByEmployee", 0.00);
            double _previousZakatByPayroll = Intent.GetDoubleExtra("previousZakatByPayroll", 0.00);
            double _previousDepartureLevy = Intent.GetDoubleExtra("previousDepartureLevy", 0.00);
            double _OthersEISNO = Intent.GetDoubleExtra("othersNoEIS", 0.00);
            double _mapaRelief = Intent.GetDoubleExtra("mapaRelief", 0.00);
            double _previousMapaRelief = Intent.GetDoubleExtra("previousMapaRelief", 0.00);
            double _SSPN = Intent.GetDoubleExtra("SSPN", 0.00);
            double _previousSSPN = Intent.GetDoubleExtra("previousSSPN", 0.00);
            double _PRS = Intent.GetDoubleExtra("PRS", 0.00);
            double _previousPRS = Intent.GetDoubleExtra("previousPRS", 0.00);
            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
            string _employeeName = Intent.GetStringExtra("employeeName");

            EditText name = FindViewById<EditText>(Resource.Id.name);
            EditText finalPCB = FindViewById<EditText>(Resource.Id.finalPCB);
            EditText finalEPF = FindViewById<EditText>(Resource.Id.finalEPF);
            EditText finalSOCSO = FindViewById<EditText>(Resource.Id.finalSOCSO);
            EditText finalEIS = FindViewById<EditText>(Resource.Id.finalEIS);
            EditText grossSalary = FindViewById<EditText>(Resource.Id.grossSalary);
            EditText netSalary = FindViewById<EditText>(Resource.Id.netSalary);
            EditText employerEPFView = FindViewById<EditText>(Resource.Id.employerEPF);
            EditText employerSOCSOView = FindViewById<EditText>(Resource.Id.employerSOCSO);
            EditText employerEISView = FindViewById<EditText>(Resource.Id.employerEIS);

            //confettti
            KonfettiView konfettiView = (KonfettiView)FindViewById(Resource.Id.viewKonfetti);
            konfettiView
            .Build()
            .AddColors(Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple)
            .SetDirection(0.0, 359.0)
            .SetSpeed(5f, 10f)
            .SetFadeOutEnabled(true)
            .SetTimeToLive(4000L)
            .StreamFor(400, 4000L);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 6), () =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    konfettiView.Visibility = ViewStates.Gone;
                });
                return false;
            });

            int n = _monthsRemaining;

            //EIS Calculation
            double WageEIS = _currentMonthRemuneration + _commission + _arrears + _others + _othersEPFNO;

            double EIS = taxCalculation.EISCalculation(WageEIS, _employeeAge);
            double employerEIS = EIS;

            //MTD Calculation
            double RoundedMTD = taxCalculation.PCBCalculation(_monthsRemaining, _currentMonthRemuneration, _BIK, _VOLA, _totalFamilyDeductions,
            _bonus, _arrears, _commission, _othersEPFNO, _others, _lifeStyleRelief, _sportsRelief, _SOCSOContribution,
            _lifeInsurance, _basicEquipment, _educationYourSelf, _medicalExamination, _medicalVaccination, _medicalDisease, _smallKidEducation,
            _breastFeedingEquipment, _alimonyFormerWife, _EMInsurance, _fatherRelief, _motherRelief, _domesticTourismExpenditure, _previousLifeStyleRelief,
            _previousSportsRelief, _previousSOCSOContribution, _previousLifeInsurance, _previousBasicEquipment, _previousEducationYourSelf,
            _previousMedicalExamination, _previousMedicalVaccination, _previousMedicalDisease, _previousSmallKidEducation, _previousBreastFeedingEquipment,
            _previousAlimonyFormerWife, _previousEMInsurance, _previousFatherRelief, _previousMotherRelief, _previousDomesticTourismExpenditure, spouseNoIncomeDeduction,
            _zakatByEmployee, _zakatByPayroll, _departureLevy, _previousMonthsRemuneration, _previousEPFContribution,
            _previousBIK, _previousVOLA, _MTDPrevious, _EPFContribution, _EPFAdditionalContribution, _previousZakatByEmployee,
            _previousZakatByPayroll, _previousDepartureLevy, _OthersEISNO, _mapaRelief, _previousMapaRelief, _SSPN,
            _previousSSPN, _PRS, _previousPRS);

            //Gross Salary
            double GrossSalary = WageEIS + _bonus + _OthersEISNO;

            //Net Salary
            double NetSalary = GrossSalary - _SOCSOContribution - _EPFAdditionalContribution - _EPFContribution - EIS - _zakatByPayroll - RoundedMTD;

            //EPF
            double EPF = _EPFContribution + _EPFAdditionalContribution;

            double additionalRemuneration = _bonus + _commission + _OthersEISNO + _others + _arrears;
            double additionalRemunerationWithoutBonus = _commission + _OthersEISNO + _others + _arrears;

            //employer EPF
            double employerEPF = taxCalculation.EmployerEPFCalculation(_employeeAge, _currentMonthRemuneration, additionalRemuneration, additionalRemunerationWithoutBonus);

            //Employer SOCSO
            double SOCSOWage = _currentMonthRemuneration + _arrears + _commission + _othersEPFNO + _others;
            double employerSOCSO = taxCalculation.EmployerSOCSOCalculation(SOCSOWage, _employeeAge);

            //print to layout
            name.Text = $"Name: {_employeeName}";
            name.SetTextColor(Color.Red);
            finalPCB.Text = $"PCB: {RoundedMTD:N2}";
            finalPCB.SetTextColor(Color.Orange);
            finalEPF.Text = $"EPF: {EPF:N2}";
            finalEPF.SetTextColor(Color.Gold);
            finalSOCSO.Text = $"SOCSO: {_SOCSOContribution:N2}";
            finalSOCSO.SetTextColor(Color.Green);
            finalEIS.Text = $"EIS: {EIS:N2}";
            finalEIS.SetTextColor(Color.Blue);
            grossSalary.Text = $"Gross Salary: {GrossSalary:N2}";
            grossSalary.SetTextColor(Color.Indigo);
            netSalary.Text = $"Net Salary: {NetSalary:N2}";
            netSalary.SetTextColor(Color.Violet);
            employerEPFView.Text = $"Employer EPF: {employerEPF:N2}";
            employerSOCSOView.Text = $"Employer SOCSO: {employerSOCSO:N2}";
            employerEISView.Text = $"Employer EIS: {employerEIS:N2}";

            payroll = new Payroll
            {
                Name = _employeeName.ToString(),
                Age = _employeeAge.ToString(),
                PCB = RoundedMTD.ToString(),
                EPFMain = EPF.ToString(),
                SOCSO = _SOCSOContribution.ToString(),
                EIS = EIS.ToString(),
                GrossSalary = GrossSalary.ToString(),
                NetSalary = NetSalary.ToString(),
                EmployerEPF = employerEPF.ToString(),
                EmployerSOCSO = employerSOCSO.ToString(),
                EmployerEIS = employerEIS.ToString()
            };
            if (n == 11)
            {
                payroll.Month = Months.January.ToString();
            }
            else if (n == 10)
            {
                payroll.Month = Months.Febuary.ToString();
            }
            else if (n == 9)
            {
                payroll.Month = Months.March.ToString();
            }
            else if (n == 8)
            {
                payroll.Month = Months.April.ToString();
            }
            else if (n == 7)
            {
                payroll.Month = Months.May.ToString();
            }
            else if (n == 6)
            {
                payroll.Month = Months.June.ToString();
            }
            else if (n == 5)
            {
                payroll.Month = Months.July.ToString();
            }
            else if (n == 4)
            {
                payroll.Month = Months.August.ToString();
            }
            else if (n == 3)
            {
                payroll.Month = Months.September.ToString();
            }
            else if (n == 2)
            {
                payroll.Month = Months.October.ToString();
            }
            else if (n == 1)
            {
                payroll.Month = Months.November.ToString();
            }
            else if (n == 0)
            {
                payroll.Month = Months.December.ToString();
            }

            Button _saveDetails = FindViewById<Button>(Resource.Id.saveDetails);

            _saveDetails.Click += (sender, e) => {
                soundPlayer.PlaySound_ButtonClick(this);
                //save to database
                PayrollHelper.InsertPayrollData(this, payroll);
                var payrollData = new Intent(this, typeof(MainActivity));
                payrollData.PutExtra("payroll", JsonConvert.SerializeObject(payroll));
                StartActivity(payrollData);
            };
        }
    }
}
