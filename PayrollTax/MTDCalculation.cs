using System;
using System.Collections.Generic;
using PayrollParrots.Model;

namespace PayrollParrots
{
    public class MTDCalculations : IsApplicableToMTD
    {
        readonly IsApplicableToMTD isApplicableToMTD;
        public MTDCalculations(Dictionary<string, double> AllItemsDictionary) : base(AllItemsDictionary)
        {
            isApplicableToMTD = new IsApplicableToMTD(AllItemsDictionary);
        }

        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double SpouseNoIncomeDeduction = 4000;
        public const double MTDMinimumAmmountToNotGoToZero = 10;
        public const double SpouseNoIncomeRebate = -800;
        public const double SpouseGetIncomeRebate = -400;
        public const double SpouseNoIncomeRebate20To35K = -650;
        public const double SpouseGetIncomeRebate20To35K = -250;

        public double MTDCalculation(PayrollFamilyDeductions FamilyDeductionItems, int _monthsRemaining, double _SOCSOContribution, double _previousSOCSOContribution,
            double _previousEPFContribution, double _MTDPrevious, double _EPFContribution, double _EPFAdditionalContribution)
        {
            int n = _monthsRemaining;

            double P = PAndPAddCalculation(FamilyDeductionItems, n, _SOCSOContribution, _previousSOCSOContribution, _previousEPFContribution, _EPFContribution, _EPFAdditionalContribution, true);

            double Z = isApplicableToMTD.PreviousZakatByEmployee + isApplicableToMTD.PreviousZakatViaPayroll + isApplicableToMTD.PreviousDepartureLevy;
            double X = _MTDPrevious;

            (double M, double R, double B) = MRBCalculation(P, FamilyDeductionItems);

            double CurrentMonthMTD = Math.Floor((((P - M) * R) + B - (Z + X)) / (n + 1) * 100) * 0.01;
            if (CurrentMonthMTD < MTDMinimumAmmountToNotGoToZero)
            {
                CurrentMonthMTD = 0;
            }
            double NetMTD = CurrentMonthMTD - isApplicableToMTD.ZakatByEmployee - isApplicableToMTD.ZakatViaPayroll - isApplicableToMTD.DepartureLevy;

            if (NetMTD < 0.00)
            {
                NetMTD = 0;
            }

            double YearlyMTD = X + (CurrentMonthMTD * (n + 1));

            double PAdd = PAndPAddCalculation(FamilyDeductionItems, n, _SOCSOContribution, _previousSOCSOContribution, _previousEPFContribution, _EPFContribution, _EPFAdditionalContribution, false);

            (double Madd, double Radd, double Badd) = MRBCalculation(PAdd, FamilyDeductionItems);

            double CS = Math.Floor(((PAdd - Madd) * Radd + Badd) * 100) * 0.01;
            if (P < 35001.00 && FamilyDeductionItems.SpouseNotGettingIncome == SpouseNoIncomeDeduction)
            {
                CS += SpouseNoIncomeRebate;
            }
            else if (P < 35001.00)
            {
                CS += SpouseGetIncomeRebate;
            }
            else
            {
            }

            if (CS < 0)
            {
                CS = 0;
            }

            double additionalRemunerationMTD = CS - YearlyMTD - Z;

            if (additionalRemunerationMTD < MTDMinimumAmmountToNotGoToZero)
            {
                additionalRemunerationMTD = 0;
            }

            double MTD = additionalRemunerationMTD + NetMTD;

            if (MTD < 0)
            {
                MTD = 0;
            }

            double RoundedMTD = Math.Ceiling(MTD * 20) * 0.05;
            return RoundedMTD;
        }

        public double PAndPAddCalculation(PayrollFamilyDeductions FamilyDeductionItems,
            int n, double _SOCSOContribution, double _previousSOCSOContribution,
            double _previousEPFContribution, double _EPFContribution, double _EPFAdditionalContribution, bool POrPAdd)
        {
            double P;

            double _CheckingEPFContributionOverLimit = Math.Min(4000 - _previousEPFContribution, _EPFContribution);
            double _CheckingEPFAdditionalContributionOverLimit = Math.Min(4000 - _previousEPFContribution - _EPFContribution, _EPFAdditionalContribution);

            //Y
            double Y = isApplicableToMTD.PreviousMonthsRemuneration + isApplicableToMTD.PreviousVOLA + isApplicableToMTD.PreviousBIK;
            //K
            double K = _previousEPFContribution;
            //∑(Y-K)
            double Y_K = Y - K;
            //Y1
            double Y1 = isApplicableToMTD.CurrentMonthRemuneration + isApplicableToMTD.VOLA + isApplicableToMTD.BIK;
            //K1
            double K1 = _CheckingEPFContributionOverLimit;
            //Yt
            double Yt = isApplicableToMTD.Bonus + isApplicableToMTD.Commission + isApplicableToMTD.OthersNotSubjectToSOCSOAndEIS + isApplicableToMTD.OthersSubjectToEPFAndSOCSOAndEIS + isApplicableToMTD.OthersNotSubjectToEPF + isApplicableToMTD.Arrears;
            //Kt
            double Kt = _CheckingEPFAdditionalContributionOverLimit;
            //Y2
            double Y2 = Y1;
            //K2
            double K2;
            if (n != 0)
            {
                K2 = Math.Floor(Math.Min(K1, (4000 - K - K1) / n) * 100) * 0.01;
            }
            else
            {
                K2 = 0;
            }
            //D
            double D = 9000.00;
            //FamilyDeductions
            double SDSQC = FamilyDeductionItems.TotalFamilyDeductions;
            //PreviousDeductions
            double LP = isApplicableToMTD.PreviousTotalDeductions + _previousSOCSOContribution;
            //CurrentMonthDeduction
            double LP1 = isApplicableToMTD.TotalDeductions + _SOCSOContribution;
            switch (POrPAdd)
            {
                case true:
                    P = Math.Floor((Y_K + (Y1 - K1) + ((Y2 - K2) * n) - D - SDSQC - LP - LP1) * 100) * 0.01;
                    if (P < 0.00)
                    {
                        P = 0;
                    }
                    return P;
                case false:
                    K2 = Math.Floor(Math.Min(K1, (4000 - K - K1 - Kt) / n) * 100) * 0.01;
                    P = Math.Floor((Y_K + (Y1 - K1) + ((Y2 - K2) * n) + (Yt - Kt) - D - SDSQC - LP - LP1) * 100) * 0.01;
                    if (Yt == 0.00)
                    {
                        P = 0;
                    }
                    return P;
            }
        }

        public (double, double, double) MRBCalculation(double P, PayrollFamilyDeductions FamilyDeductionItems)
        {
            double M;
            double R;
            double B;

            double SpouseNotGettingIncome = FamilyDeductionItems.SpouseNotGettingIncome;
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
                if (SpouseNotGettingIncome == SpouseNoIncomeDeduction)
                {
                    B = SpouseNoIncomeRebate;
                }
                else
                {
                    B = SpouseGetIncomeRebate;
                }
            }
            else if (P >= 20001 && P < 35001)
            {
                M = 20000;
                R = 0.03;
                if (SpouseNotGettingIncome == SpouseNoIncomeDeduction)
                {
                    B = SpouseNoIncomeRebate20To35K;
                }
                else
                {
                    B = SpouseGetIncomeRebate20To35K;
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
                R = 0.13;
                B = 1800;
            }
            else if (P >= 70001 && P < 100001)
            {
                M = 70000;
                R = 0.21;
                B = 4400;
            }
            else if (P >= 100001 && P < 250001)
            {
                M = 100000;
                R = 0.24;
                B = 10700;
            }
            else if (P >= 250001 && P < 400001)
            {
                M = 250000;
                R = 0.245;
                B = 46700;
            }
            else if (P >= 400001 && P < 600001)
            {
                M = 400000;
                R = 0.25;
                B = 83450;
            }
            else if (P >= 600001 && P < 1000001)
            {
                M = 600000;
                R = 0.26;
                B = 133450;
            }
            else if (P >= 1000001 && P < 2000001)
            {
                M = 1000000;
                R = 0.28;
                B = 237450;
            }
            else
            {
                M = 2000000;
                R = 0.30;
                B = 517450;
            }
            return (M, R, B);
        }
    }
}
