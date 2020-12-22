using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using PayrollParrots.Model;
using PayrollParrots.Helper;
using NL.DionSegijn.Konfetti;
using Newtonsoft.Json;

namespace PayrollParrots
{
    //#fix
    [Activity(Label = "PayrollFinalCalculation")]
    public class PayrollFinalCalculation : Activity
    {
        public Payroll payroll;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_final_calculation);
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
            double _previousLifeStyleRelief = Intent.GetDoubleExtra("previousLifeStyleRelief", 0.00);
            double _previousSOCSOContribution = Intent.GetDoubleExtra("previousSOCSOContribution", 0.00);
            double _previousLifeInsurance = Intent.GetDoubleExtra("previousLifeInsurance", 0.00);
            double _previousBasicEquipment = Intent.GetDoubleExtra("previousBasicEquipment", 0.00);
            double _previousEducationYourSelf = Intent.GetDoubleExtra("previousEducationYourSelf", 0.00);
            double _previousMedicalExamintion = Intent.GetDoubleExtra("previousMedicalExamintion", 0.00);
            double _previousMedicalDisease = Intent.GetDoubleExtra("previousMedicalDisease", 0.00);
            double _previousSmallKidEducation = Intent.GetDoubleExtra("previousSmallKidEducation", 0.00);
            double _previousBreastFeedingEquipment = Intent.GetDoubleExtra("previousBreastFeedingEquipment", 0.00);
            double _previousAlimonyFormerWife = Intent.GetDoubleExtra("previousAlimonyFormerWife", 0.00);
            double _previousEMInsurance = Intent.GetDoubleExtra("previousEMInsurance", 0.00);
            double _previousFatherRelief = Intent.GetDoubleExtra("previousFatherRelief", 0.00);
            double _previousMotherRelief = Intent.GetDoubleExtra("previousMotherRelief", 0.00);
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
            KonfettiView konfettiView = (KonfettiView)FindViewById(Resource.Id.viewKonfetti);
            konfettiView
            .Build()
            .AddColors(Color.Yellow, Color.Green, Color.Magenta, Color.Blue, Color.Lavender, Color.LightCyan)
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
            double _EPFContributionC = Math.Min(4000 - _previousEPFContribution, _EPFContribution);
            double _EPFAdditionalContributionC = Math.Min(4000 - _previousEPFContribution - _EPFContribution, _EPFAdditionalContribution);
            //Y
            double Y = _previousMonthsRemuneration + _previousVOLA + _previousBIK;
            //K
            double K = _previousEPFContribution;
            //∑(Y-K)
            double Y_K = Y - K;
            //Y1
            double Y1 = _currentMonthRemuneration + _VOLA + _BIK;
            //K1
            double K1 = _EPFContributionC;
            //Yt
            double Yt = _bonus + _arrears + _commission + _othersEPFNO + _others + _OthersEISNO;
            //Kt
            double Kt = _EPFAdditionalContributionC;
            //n
            int n = _monthsRemaining;
            double Y2;
            //Y2
            Y2 = Y1;
            //K2
            double K2;
            if (n != 0)
            {
                K2 = Math.Floor((Math.Min(K1, (4000 - K - K1) / n)) * 100) * 0.01;
            }
            else
            {
                K2 = 0;
            }
            //D
            double D = 9000.00;
            //FamilyDeductions
            double SDSQC = _totalFamilyDeductions;
            //PreviousDeductions
            double LP = _previousLifeStyleRelief + _previousSOCSOContribution + _previousLifeInsurance + _previousBasicEquipment + _previousEducationYourSelf + _previousMedicalExamintion + _previousMedicalDisease + _previousSmallKidEducation + _previousBreastFeedingEquipment + _previousAlimonyFormerWife + _previousEMInsurance + _previousFatherRelief + _previousMotherRelief + _previousMapaRelief + _previousSSPN + _previousPRS;
            //CurrentMonthDeduction
            double LP1 = _lifeStyleRelief + _SOCSOContribution + _lifeInsurance + _basicEquipment + _educationYourSelf + _medicalExamintion + _medicalDisease + _smallKidEducation + _breastFeedingEquipment + _alimonyFormerWife + _EMInsurance + _fatherRelief + _motherRelief + _mapaRelief + _SSPN + _PRS;
            //P
            double P = Math.Floor((Y_K + (Y1-K1) + ((Y2 - K2) * n) - D - SDSQC - LP - LP1) * 100) * 0.01;

            int M;
            double R;
            int B;
            if (P < 5001)
            {
                M = 0;
                R = 0;
                B = 0;
            }
            else if (P >= 5001 && P < 20001)
            {
                M = 5000;
                R = 0.01;
                if (spouseNoIncomeDeduction == 4000)
                {
                    B = -800;
                }
                else
                {
                    B = -400;
                }
            }
            else if (P >= 20001 && P < 35001)
            {
                M = 20000;
                R = 0.03;
                if (spouseNoIncomeDeduction == 4000)
                {
                    B = -650;
                }
                else
                {
                    B = -250;
                }
            }
            else if (P >= 35001 && P < 50001)
            {
                M = 35000;
                R = 0.08;
                B = 600;
            }
            else if (P >= 50001 && P < 70001)
            {
                M = 50000;
                R = 0.14;
                B = 1800;
            }
            else if (P >= 70001 && P < 100001)
            {
                M = 70000;
                R = 0.21;
                B = 4600;
            }
            else if (P >= 100001 && P < 250001)
            {
                M = 100000;
                R = 0.24;
                B = 10900;
            }
            else if (P >= 250001 && P < 400001)
            {
                M = 250000;
                R = 0.245;
                B = 46900;
            }
            else if (P >= 400001 && P < 600001)
            {
                M = 400000;
                R = 0.25;
                B = 83650;
            }
            else if (P >= 600001 && P < 1000001)
            {
                M = 600000;
                R = 0.26;
                B = 133650;
            }
            else if (P >= 1000001 && P < 2000001)
            {
                M = 1000000;
                R = 0.28;
                B = 237650;
            }
            else
            {
                M = 2000000;
                R = 0.30;
                B = 517650;
            }
            double Z = _previousZakatByEmployee + _previousZakatByPayroll + _previousDepartureLevy;
            double X = _MTDPrevious;
            if (P < 0.00)
            {
                P = 0;
            }

            double CurrentMonthMTD = Math.Floor((((P-M) * R) + B - (Z + X)) / (n + 1) * 100) * 0.01;
            if (CurrentMonthMTD < 10.00)
            {
                CurrentMonthMTD = 0;
            }
            double NetMTD = CurrentMonthMTD - _zakatByEmployee - _zakatByPayroll - _departureLevy;

            if (NetMTD < 0.00)
            {
                NetMTD = 0;
            }

            double YearlyMTD = X + (CurrentMonthMTD * (n + 1));

            K2 = Math.Floor((Math.Min(K1, (4000 - K - K1 - Kt) / n)) * 100) * 0.01;

            double PAdd = Math.Floor((Y_K + (Y1 - K1) + ((Y2 - K2) * n) + (Yt - Kt) - D - SDSQC - LP - LP1) * 100) * 0.01;

            if (Yt == 0.00)
            {
                PAdd = 0;
            }
            int Madd;
            double Radd;
            int Badd;
            if (PAdd < 5001)
            {
                Madd = 0;
                Radd = 0;
                Badd = 0;
            }
            else if (PAdd >= 5001 && PAdd < 20001)
            {
                Madd = 5000;
                Radd = 0.01;
                if (spouseNoIncomeDeduction == 4000)
                {
                    Badd = -800;
                }
                else
                {
                    Badd = -400;
                }
            }
            else if (PAdd >= 20001 && PAdd < 35001)
            {
                Madd = 20000;
                Radd = 0.03;
                if (spouseNoIncomeDeduction == 4000)
                {
                    Badd = -650;
                }
                else
                {
                    Badd = -250;
                }
            }
            else if (PAdd >= 35001 && PAdd < 50001)
            {
                Madd = 35000;
                Radd = 0.08;
                Badd = 600;
            }
            else if (PAdd >= 50001 && PAdd < 70001)
            {
                Madd = 50000;
                Radd = 0.14;
                Badd = 1800;
            }
            else if (PAdd >= 70001 && PAdd < 100001)
            {
                Madd = 70000;
                Radd = 0.21;
                Badd = 4600;
            }
            else if (PAdd >= 100001 && PAdd < 250001)
            {
                Madd = 100000;
                Radd = 0.24;
                Badd = 10900;
            }
            else if (PAdd >= 250001 && PAdd < 400001)
            {
                Madd = 250000;
                Radd = 0.245;
                Badd = 46900;
            }
            else if (PAdd >= 400001 && PAdd < 600001)
            {
                Madd = 400000;
                Radd = 0.25;
                Badd = 83650;
            }
            else if (PAdd >= 600001 && PAdd < 1000001)
            {
                Madd = 600000;
                Radd = 0.26;
                Badd = 133650;
            }
            else if (PAdd >= 1000001 && PAdd < 2000001)
            {
                Madd = 1000000;
                Radd = 0.28;
                Badd = 237650;
            }
            else
            {
                Madd = 2000000;
                Radd = 0.3;
                Badd = 517650;
            }

            double CS = Math.Floor(((PAdd - Madd) * Radd + Badd) * 100) * 0.01;
            if(P < 35001.00 && spouseNoIncomeDeduction == 4000)
            {
                CS -= 800;
            }
            else if (P < 35001.00)
            {
                CS -= 400;
            }
            else
            {
            }

            if (CS < 0)
            {
                CS = 0;
            }

            double ARMTD = CS - YearlyMTD - Z;

            if (ARMTD < 10.00)
            {
                ARMTD = 0;
            }

            double MTD = ARMTD + NetMTD;

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

            double EIS = 0;
            double WageEIS = _currentMonthRemuneration + _commission + _arrears + _others + _othersEPFNO;
            if (WageEIS <= 30)
            {
                EIS = 0.05;
            }
            else if (WageEIS > 30 && WageEIS <= 50)
            {
                EIS = 0.10;
            }
            else if (WageEIS > 50 && WageEIS <= 70)
            {
                EIS = 0.15;
            }
            else if (WageEIS > 70 && WageEIS <= 100)
            {
                EIS = 0.20;
            }
            else if (WageEIS > 100 && WageEIS <= 140)
            {
                EIS = 0.25;
            }
            else if (WageEIS > 140 && WageEIS <= 200)
            {
                EIS = 0.35;
            }
            else if (WageEIS > 200 && WageEIS <= 300)
            {
                EIS = 0.50;
            }
            else if (WageEIS > 300 && WageEIS <= 400)
            {
                EIS = 0.70;
            }
            else if (WageEIS > 400 && WageEIS <= 500)
            {
                EIS = 0.90;
            }
            else if (WageEIS > 500 && WageEIS <= 600)
            {
                EIS = 1.10;
            }
            else if (WageEIS > 600 && WageEIS <= 700)
            {
                EIS = 1.30;
            }
            else if (WageEIS > 700 && WageEIS <= 800)
            {
                EIS = 1.50;
            }
            else if (WageEIS > 800 && WageEIS <= 900)
            {
                EIS = 1.70;
            }
            else if (WageEIS > 900 && WageEIS <= 1000)
            {
                EIS = 1.90;
            }
            else if (WageEIS > 1000 && WageEIS <= 1100)
            {
                EIS = 2.10;
            }
            else if (WageEIS > 1100 && WageEIS <= 1200)
            {
                EIS = 2.30;
            }
            else if (WageEIS > 1200 && WageEIS <= 1300)
            {
                EIS = 2.50;
            }
            else if (WageEIS > 1300 && WageEIS <= 1400)
            {
                EIS = 2.70;
            }
            else if (WageEIS > 1400 && WageEIS <= 1500)
            {
                EIS = 2.90;
            }
            else if (WageEIS > 1500 && WageEIS <= 1600)
            {
                EIS = 3.10;
            }
            else if (WageEIS > 1600 && WageEIS <= 1700)
            {
                EIS = 3.30;
            }
            else if (WageEIS > 1700 && WageEIS <= 1800)
            {
                EIS = 3.50;
            }
            else if (WageEIS > 1800 && WageEIS <= 1900)
            {
                EIS = 3.70;
            }
            else if (WageEIS > 1900 && WageEIS <= 2000)
            {
                EIS = 3.90;
            }
            else if (WageEIS > 2000 && WageEIS <= 2100)
            {
                EIS = 4.10;
            }
            else if (WageEIS > 2100 && WageEIS <= 2200)
            {
                EIS = 4.30;
            }
            else if (WageEIS > 2200 && WageEIS <= 2300)
            {
                EIS = 4.50;
            }
            else if (WageEIS > 2300 && WageEIS <= 2400)
            {
                EIS = 4.70;
            }
            else if (WageEIS > 2400 && WageEIS <= 2500)
            {
                EIS = 4.90;
            }
            else if (WageEIS > 2500 && WageEIS <= 2600)
            {
                EIS = 5.10;
            }
            else if (WageEIS > 2600 && WageEIS <= 2700)
            {
                EIS = 5.30;
            }
            else if (WageEIS > 2700 && WageEIS <= 2800)
            {
                EIS = 5.50;
            }
            else if (WageEIS > 2800 && WageEIS <= 2900)
            {
                EIS = 5.70;
            }
            else if (WageEIS > 2900 && WageEIS <= 3000)
            {
                EIS = 5.90;
            }
            else if (WageEIS > 3000 && WageEIS <= 3100)
            {
                EIS = 6.10;
            }
            else if (WageEIS > 3100 && WageEIS <= 3200)
            {
                EIS = 6.30;
            }
            else if (WageEIS > 3200 && WageEIS <= 3300)
            {
                EIS = 6.50;
            }
            else if (WageEIS > 3300 && WageEIS <= 3400)
            {
                EIS = 6.70;
            }
            else if (WageEIS > 3400 && WageEIS <= 3500)
            {
                EIS = 6.90;
            }
            else if (WageEIS > 3500 && WageEIS <= 3600)
            {
                EIS = 7.10;
            }
            else if (WageEIS > 3600 && WageEIS <= 3700)
            {
                EIS = 7.30;
            }
            else if (WageEIS > 3700 && WageEIS <= 3800)
            {
                EIS = 7.50;
            }
            else if (WageEIS > 3800 && WageEIS <= 3900)
            {
                EIS = 7.70;
            }
            else if (WageEIS > 3900 && WageEIS <= 4000)
            {
                EIS = 7.90;
            }
            else
            {
                EIS = 7.90;
            }

            if (_employeeAge >= 60)
            {
                EIS = 0;
            }

            if (MTD < 0)
            {
                MTD = 0;
            }

            double RoundedMTD = Math.Ceiling(MTD * 20) * 0.05;
            double GrossSalary = WageEIS + _bonus + _OthersEISNO;
            double NetSalary = GrossSalary - _SOCSOContribution - _EPFAdditionalContribution - _EPFContribution - EIS - _zakatByPayroll - RoundedMTD;
            double EPF = _EPFContribution + _EPFAdditionalContribution;
            double employerEPF = 0.00;
            double employerSOCSO = 0.00;
            double employerEIS = EIS;
            double additionalRemuneration = _bonus + _commission + _OthersEISNO + _others + _arrears;
            double addRemu = _commission + _OthersEISNO + _others + _arrears;
            if (_employeeAge < 60)
            {
                if ((_currentMonthRemuneration + additionalRemuneration) <= 20)
                {
                    if ((_currentMonthRemuneration + additionalRemuneration) <= 10)
                    {
                        employerEPF = 0.00;
                    }
                    else if ((_currentMonthRemuneration + additionalRemuneration) > 10 && (_currentMonthRemuneration + additionalRemuneration) <= 20)
                    {
                        employerEPF = 3.00;
                    }
                }
                else if ((_currentMonthRemuneration + additionalRemuneration) > 20 && (_currentMonthRemuneration + additionalRemuneration) <= 5000)
                {
                    double EPFWage1 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.05)) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * 0.13);
                }
                else if (addRemu <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01)) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * 0.13);
                }
                else if ((_currentMonthRemuneration + additionalRemuneration) > 5000 && (_currentMonthRemuneration + additionalRemuneration) <= 20000)
                {
                    double EPFWage2 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01)) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * 0.12);
                }
                else
                {
                    employerEPF = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.12);
                }
            }
            else
            {
                if ((_currentMonthRemuneration + additionalRemuneration) <= 20)
                {
                    if ((_currentMonthRemuneration + additionalRemuneration) <= 10)
                    {
                        employerEPF = 0.00;
                    }
                    else if ((_currentMonthRemuneration + additionalRemuneration) > 10 && (_currentMonthRemuneration + additionalRemuneration) <= 20)
                    {
                        employerEPF = 1.00;
                    }
                }
                else if ((_currentMonthRemuneration + additionalRemuneration) > 20 && (_currentMonthRemuneration + additionalRemuneration) <= 5000)
                {
                    double EPFWage1 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.05)) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * 0.04);
                }
                else if (addRemu <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01)) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * 0.04);
                }
                else if ((_currentMonthRemuneration + additionalRemuneration) > 5000 && (_currentMonthRemuneration + additionalRemuneration) <= 20000)
                {
                    double EPFWage2 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01)) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * 0.04);
                }
                else
                {
                    employerEPF = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.04);
                }
            }

            double SOCSOWage = _currentMonthRemuneration + _arrears + _commission + _othersEPFNO + _others;
            if (_employeeAge < 60)
            {
                if (SOCSOWage <= 30)
                {
                    employerSOCSO = 0.40;
                }
                else if (SOCSOWage > 30 && SOCSOWage <= 50)
                {
                    employerSOCSO = 0.70;
                }
                else if (SOCSOWage > 50 && SOCSOWage <= 70)
                {
                    employerSOCSO = 1.10;
                }
                else if (SOCSOWage > 70 && SOCSOWage <= 100)
                {
                    employerSOCSO = 1.50;
                }
                else if (SOCSOWage > 100 && SOCSOWage <= 140)
                {
                    employerSOCSO = 2.10;
                }
                else if (SOCSOWage > 140 && SOCSOWage <= 200)
                {
                    employerSOCSO = 2.95;
                }
                else if (SOCSOWage > 200 && SOCSOWage <= 300)
                {
                    employerSOCSO = 4.35;
                }
                else if (SOCSOWage > 300 && SOCSOWage <= 400)
                {
                    employerSOCSO = 6.15;
                }
                else if (SOCSOWage > 400 && SOCSOWage <= 500)
                {
                    employerSOCSO = 7.85;
                }
                else if (SOCSOWage > 500 && SOCSOWage <= 600)
                {
                    employerSOCSO = 9.65;
                }
                else if (SOCSOWage > 600 && SOCSOWage <= 700)
                {
                    employerSOCSO = 11.35;
                }
                else if (SOCSOWage > 700 && SOCSOWage <= 800)
                {
                    employerSOCSO = 13.15;
                }
                else if (SOCSOWage > 800 && SOCSOWage <= 900)
                {
                    employerSOCSO = 14.85;
                }
                else if (SOCSOWage > 900 && SOCSOWage <= 1000)
                {
                    employerSOCSO = 16.65;
                }
                else if (SOCSOWage > 1000 && SOCSOWage <= 1100)
                {
                    employerSOCSO = 18.35;
                }
                else if (SOCSOWage > 1100 && SOCSOWage <= 1200)
                {
                    employerSOCSO = 20.15;
                }
                else if (SOCSOWage > 1200 && SOCSOWage <= 1300)
                {
                    employerSOCSO = 21.85;
                }
                else if (SOCSOWage > 1300 && SOCSOWage <= 1400)
                {
                    employerSOCSO = 23.65;
                }
                else if (SOCSOWage > 1400 && SOCSOWage <= 1500)
                {
                    employerSOCSO = 25.35;
                }
                else if (SOCSOWage > 1500 && SOCSOWage <= 1600)
                {
                    employerSOCSO = 27.15;
                }
                else if (SOCSOWage > 1600 && SOCSOWage <= 1700)
                {
                    employerSOCSO = 28.85;
                }
                else if (SOCSOWage > 1700 && SOCSOWage <= 1800)
                {
                    employerSOCSO = 30.65;
                }
                else if (SOCSOWage > 1800 && SOCSOWage <= 1900)
                {
                    employerSOCSO = 32.35;
                }
                else if (SOCSOWage > 1900 && SOCSOWage <= 2000)
                {
                    employerSOCSO = 34.15;
                }
                else if (SOCSOWage > 2000 && SOCSOWage <= 2100)
                {
                    employerSOCSO = 35.85;
                }
                else if (SOCSOWage > 2100 && SOCSOWage <= 2200)
                {
                    employerSOCSO = 37.65;
                }
                else if (SOCSOWage > 2200 && SOCSOWage <= 2300)
                {
                    employerSOCSO = 39.35;
                }
                else if (SOCSOWage > 2300 && SOCSOWage <= 2400)
                {
                    employerSOCSO = 41.15;
                }
                else if (SOCSOWage > 2400 && SOCSOWage <= 2500)
                {
                    employerSOCSO = 42.85;
                }
                else if (SOCSOWage > 2500 && SOCSOWage <= 2600)
                {
                    employerSOCSO = 44.65;
                }
                else if (SOCSOWage > 2600 && SOCSOWage <= 2700)
                {
                    employerSOCSO = 46.35;
                }
                else if (SOCSOWage > 2700 && SOCSOWage <= 2800)
                {
                    employerSOCSO = 48.15;
                }
                else if (SOCSOWage > 2800 && SOCSOWage <= 2900)
                {
                    employerSOCSO = 49.85;
                }
                else if (SOCSOWage > 2900 && SOCSOWage <= 3000)
                {
                    employerSOCSO = 51.65;
                }
                else if (SOCSOWage > 3000 && SOCSOWage <= 3100)
                {
                    employerSOCSO = 53.35;
                }
                else if (SOCSOWage > 3100 && SOCSOWage <= 3200)
                {
                    employerSOCSO = 55.15;
                }
                else if (SOCSOWage > 3200 && SOCSOWage <= 3300)
                {
                    employerSOCSO = 56.85;
                }
                else if (SOCSOWage > 3300 && SOCSOWage <= 3400)
                {
                    employerSOCSO = 58.65;
                }
                else if (SOCSOWage > 3400 && SOCSOWage <= 3500)
                {
                    employerSOCSO = 60.35;
                }
                else if (SOCSOWage > 3500 && SOCSOWage <= 3600)
                {
                    employerSOCSO = 62.15;
                }
                else if (SOCSOWage > 3600 && SOCSOWage <= 3700)
                {
                    employerSOCSO = 63.85;
                }
                else if (SOCSOWage > 3700 && SOCSOWage <= 3800)
                {
                    employerSOCSO = 65.65;
                }
                else if (SOCSOWage > 3800 && SOCSOWage <= 3900)
                {
                    employerSOCSO = 67.35;
                }
                else if (SOCSOWage > 3900 && SOCSOWage <= 4000)
                {
                    employerSOCSO = 69.05;
                }
                else
                {
                    employerSOCSO = 69.05;
                }
            }
            else
            {
                if (SOCSOWage <= 30)
                {
                    employerSOCSO = 0.30;
                }
                else if (SOCSOWage > 30 && SOCSOWage <= 50)
                {
                    employerSOCSO = 0.50;
                }
                else if (SOCSOWage > 50 && SOCSOWage <= 70)
                {
                    employerSOCSO = 0.80;
                }
                else if (SOCSOWage > 70 && SOCSOWage <= 100)
                {
                    employerSOCSO = 1.10;
                }
                else if (SOCSOWage > 100 && SOCSOWage <= 140)
                {
                    employerSOCSO = 1.50;
                }
                else if (SOCSOWage > 140 && SOCSOWage <= 200)
                {
                    employerSOCSO = 2.10;
                }
                else if (SOCSOWage > 200 && SOCSOWage <= 300)
                {
                    employerSOCSO = 3.10;
                }
                else if (SOCSOWage > 300 && SOCSOWage <= 400)
                {
                    employerSOCSO = 4.40;
                }
                else if (SOCSOWage > 400 && SOCSOWage <= 500)
                {
                    employerSOCSO = 5.60;
                }
                else if (SOCSOWage > 500 && SOCSOWage <= 600)
                {
                    employerSOCSO = 6.90;
                }
                else if (SOCSOWage > 600 && SOCSOWage <= 700)
                {
                    employerSOCSO = 8.10;
                }
                else if (SOCSOWage > 700 && SOCSOWage <= 800)
                {
                    employerSOCSO = 9.40;
                }
                else if (SOCSOWage > 800 && SOCSOWage <= 900)
                {
                    employerSOCSO = 10.60;
                }
                else if (SOCSOWage > 900 && SOCSOWage <= 1000)
                {
                    employerSOCSO = 11.90;
                }
                else if (SOCSOWage > 1000 && SOCSOWage <= 1100)
                {
                    employerSOCSO = 13.10;
                }
                else if (SOCSOWage > 1100 && SOCSOWage <= 1200)
                {
                    employerSOCSO = 14.40;
                }
                else if (SOCSOWage > 1200 && SOCSOWage <= 1300)
                {
                    employerSOCSO = 15.60;
                }
                else if (SOCSOWage > 1300 && SOCSOWage <= 1400)
                {
                    employerSOCSO = 16.90;
                }
                else if (SOCSOWage > 1400 && SOCSOWage <= 1500)
                {
                    employerSOCSO = 18.10;
                }
                else if (SOCSOWage > 1500 && SOCSOWage <= 1600)
                {
                    employerSOCSO = 19.40;
                }
                else if (SOCSOWage > 1600 && SOCSOWage <= 1700)
                {
                    employerSOCSO = 20.60;
                }
                else if (SOCSOWage > 1700 && SOCSOWage <= 1800)
                {
                    employerSOCSO = 21.90;
                }
                else if (SOCSOWage > 1800 && SOCSOWage <= 1900)
                {
                    employerSOCSO = 23.10;
                }
                else if (SOCSOWage > 1900 && SOCSOWage <= 2000)
                {
                    employerSOCSO = 24.40;
                }
                else if (SOCSOWage > 2000 && SOCSOWage <= 2100)
                {
                    employerSOCSO = 25.60;
                }
                else if (SOCSOWage > 2100 && SOCSOWage <= 2200)
                {
                    employerSOCSO = 26.90;
                }
                else if (SOCSOWage > 2200 && SOCSOWage <= 2300)
                {
                    employerSOCSO = 28.10;
                }
                else if (SOCSOWage > 2300 && SOCSOWage <= 2400)
                {
                    employerSOCSO = 29.40;
                }
                else if (SOCSOWage > 2400 && SOCSOWage <= 2500)
                {
                    employerSOCSO = 30.60;
                }
                else if (SOCSOWage > 2500 && SOCSOWage <= 2600)
                {
                    employerSOCSO = 31.90;
                }
                else if (SOCSOWage > 2600 && SOCSOWage <= 2700)
                {
                    employerSOCSO = 33.10;
                }
                else if (SOCSOWage > 2700 && SOCSOWage <= 2800)
                {
                    employerSOCSO = 34.40;
                }
                else if (SOCSOWage > 2800 && SOCSOWage <= 2900)
                {
                    employerSOCSO = 35.60;
                }
                else if (SOCSOWage > 2900 && SOCSOWage <= 3000)
                {
                    employerSOCSO = 36.90;
                }
                else if (SOCSOWage > 3000 && SOCSOWage <= 3100)
                {
                    employerSOCSO = 38.10;
                }
                else if (SOCSOWage > 3100 && SOCSOWage <= 3200)
                {
                    employerSOCSO = 39.40;
                }
                else if (SOCSOWage > 3200 && SOCSOWage <= 3300)
                {
                    employerSOCSO = 40.60;
                }
                else if (SOCSOWage > 3300 && SOCSOWage <= 3400)
                {
                    employerSOCSO = 41.90;
                }
                else if (SOCSOWage > 3400 && SOCSOWage <= 3500)
                {
                    employerSOCSO = 43.10;
                }
                else if (SOCSOWage > 3500 && SOCSOWage <= 3600)
                {
                    employerSOCSO = 44.40;
                }
                else if (SOCSOWage > 3600 && SOCSOWage <= 3700)
                {
                    employerSOCSO = 45.60;
                }
                else if (SOCSOWage > 3700 && SOCSOWage <= 3800)
                {
                    employerSOCSO = 46.90;
                }
                else if (SOCSOWage > 3800 && SOCSOWage <= 3900)
                {
                    employerSOCSO = 48.10;
                }
                else if (SOCSOWage > 3900 && SOCSOWage <= 4000)
                {
                    employerSOCSO = 49.40;
                }
                else
                {
                    employerSOCSO = 49.40;
                }
            }

            name.Text = "Name: " + _employeeName;
            name.SetTextColor(Color.Red);
            finalPCB.Text = "PCB: " + RoundedMTD;
            finalPCB.SetTextColor(Color.Orange);
            finalEPF.Text = "EPF: " + EPF;
            finalEPF.SetTextColor(Color.Yellow);
            finalSOCSO.Text = "SOCSO: " + _SOCSOContribution;
            finalSOCSO.SetTextColor(Color.Green);
            finalEIS.Text = "EIS: " + EIS;
            finalEIS.SetTextColor(Color.Blue);
            grossSalary.Text = "Gross Salary: " + GrossSalary;
            grossSalary.SetTextColor(Color.Indigo);
            netSalary.Text = "Net Salary: " + NetSalary;
            netSalary.SetTextColor(Color.Violet);
            employerEPFView.Text = "Employer EPF:" + employerEPF;
            employerSOCSOView.Text = "Employer SOCSO:" + employerSOCSO;
            employerEISView.Text = "Employer EIS:" + employerEIS;

            payroll = new Payroll();
            payroll.Name = _employeeName.ToString();
            if (n == 11)
            {
                payroll.Month = "January";
            }
            else if (n == 10)
            {
                payroll.Month = "Febuary";
            }
            else if (n == 9)
            {
                payroll.Month = "March";
            }
            else if (n == 8)
            {
                payroll.Month = "April";
            }
            else if (n == 7)
            {
                payroll.Month = "May";
            }
            else if (n == 6)
            {
                payroll.Month = "June";
            }
            else if (n == 5)
            {
                payroll.Month = "July";
            }
            else if (n == 4)
            {
                payroll.Month = "August";
            }
            else if (n == 3)
            {
                payroll.Month = "September";
            }
            else if (n == 2)
            {
                payroll.Month = "October";
            }
            else if (n == 1)
            {
                payroll.Month = "November";
            }
            else if (n == 0)
            {
                payroll.Month = "December";
            }

            payroll.Age = _employeeAge.ToString();
            payroll.PCB = RoundedMTD.ToString();
            payroll.EPFMain = EPF.ToString();
            payroll.SOCSO = _SOCSOContribution.ToString();
            payroll.EIS = EIS.ToString();
            payroll.GrossSalary = GrossSalary.ToString();
            payroll.NetSalary = NetSalary.ToString();
            payroll.EmployerEPF = employerEPF.ToString();
            payroll.EmployerSOCSO = employerSOCSO.ToString();
            payroll.EmployerEIS = employerEIS.ToString();

            PayrollHelper.InsertPayrollData(this, payroll);
            Button _saveDetails = FindViewById<Button>(Resource.Id.saveDetails);

            _saveDetails.Click += PlayButton_Click;
            _saveDetails.Click += (sender, e) => {
                var payrollData = new Intent(this, typeof(MainActivity));
                payrollData.PutExtra("payroll", JsonConvert.SerializeObject(payroll));
                StartActivity(payrollData);
            };

            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }
    }
}