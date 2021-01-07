using System;
namespace PayrollParrots
{
    public class TaxCalculation
    {
        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double SpouseNoIncomeDeduction = 4000;
        public const double MTDMinimumAmmountToNotGoToZero = 10;
        public const double SpouseNoIncomeRebate = -800;
        public const double SpouseGetIncomeRebate = -400;
        public const double SpouseNoIncomeRebate20To35K = -650;
        public const double SpouseGetIncomeRebate20To35K = -250;
        public const double EPFNinePercentRate = 0.09;
        public const double EPFElevenPercentRate = 0.11;

        public double PCBCalculation(int _monthsRemaining, double _currentMonthRemuneration, double _BIK, double _VOLA, double _totalFamilyDeductions,
            double _bonus, double _arrears, double _commission, double _othersEPFNO, double _others, double _lifeStyleRelief, double _sportsRelief, double _SOCSOContribution,
            double _lifeInsurance, double _basicEquipment, double _educationYourSelf, double _medicalExamination, double _medicalVaccination, double _medicalDisease, double _smallKidEducation,
            double _breastFeedingEquipment, double _alimonyFormerWife, double _EMInsurance, double _fatherRelief, double _motherRelief, double _domesticTourismExpenditure, double _previousLifeStyleRelief,
            double _previousSportsRelief, double _previousSOCSOContribution, double _previousLifeInsurance, double _previousBasicEquipment, double _previousEducationYourSelf,
            double _previousMedicalExamination, double _previousMedicalVaccination, double _previousMedicalDisease, double _previousSmallKidEducation, double _previousBreastFeedingEquipment,
            double _previousAlimonyFormerWife, double _previousEMInsurance, double _previousFatherRelief, double _previousMotherRelief, double _previousDomesticTourismExpenditure, double spouseNoIncomeDeduction,
            double _zakatByEmployee, double _zakatByPayroll, double _departureLevy, double _previousMonthsRemuneration, double _previousEPFContribution,
            double _previousBIK, double _previousVOLA, double _MTDPrevious, double _EPFContribution, double _EPFAdditionalContribution, double _previousZakatByEmployee,
            double _previousZakatByPayroll, double _previousDepartureLevy, double _OthersEISNO, double _mapaRelief, double _previousMapaRelief, double _SSPN,
            double _previousSSPN, double _PRS, double _previousPRS)
        {
            double _CheckingEPFContributionOverLimit = Math.Min(4000 - _previousEPFContribution, _EPFContribution);
            double _CheckingEPFAdditionalContributionOverLimit = Math.Min(4000 - _previousEPFContribution - _EPFContribution, _EPFAdditionalContribution);
            //Y
            double Y = _previousMonthsRemuneration + _previousVOLA + _previousBIK;
            //K
            double K = _previousEPFContribution;
            //∑(Y-K)
            double Y_K = Y - K;
            //Y1
            double Y1 = _currentMonthRemuneration + _VOLA + _BIK;
            //K1
            double K1 = _CheckingEPFContributionOverLimit;
            //Yt
            double Yt = _bonus + _arrears + _commission + _othersEPFNO + _others + _OthersEISNO;
            //Kt
            double Kt = _CheckingEPFAdditionalContributionOverLimit;
            //n
            int n = _monthsRemaining;
            double Y2;
            //Y2
            Y2 = Y1;
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
            double SDSQC = _totalFamilyDeductions;
            //PreviousDeductions
            double LP = _previousLifeStyleRelief + _previousSportsRelief + _previousSOCSOContribution + _previousLifeInsurance + _previousBasicEquipment + _previousEducationYourSelf + _previousMedicalExamination + _previousMedicalVaccination + _previousMedicalDisease + _previousSmallKidEducation + _previousBreastFeedingEquipment + _previousAlimonyFormerWife + _previousEMInsurance + _previousFatherRelief + _previousMotherRelief + _previousMapaRelief + _previousSSPN + _previousPRS + _previousDomesticTourismExpenditure;
            //CurrentMonthDeduction
            double LP1 = _lifeStyleRelief + _sportsRelief + _SOCSOContribution + _lifeInsurance + _basicEquipment + _educationYourSelf + _medicalExamination + _medicalVaccination + _medicalDisease + _smallKidEducation + _breastFeedingEquipment + _alimonyFormerWife + _EMInsurance + _fatherRelief + _motherRelief + _mapaRelief + _SSPN + _PRS + _domesticTourismExpenditure;
            //P
            double P = Math.Floor((Y_K + (Y1 - K1) + ((Y2 - K2) * n) - D - SDSQC - LP - LP1) * 100) * 0.01;

            double M;
            double R;
            double B;
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
                if (spouseNoIncomeDeduction == SpouseNoIncomeDeduction)
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
                if (spouseNoIncomeDeduction == SpouseNoIncomeDeduction)
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
            double Z = _previousZakatByEmployee + _previousZakatByPayroll + _previousDepartureLevy;
            double X = _MTDPrevious;
            if (P < 0.00)
            {
                P = 0;
            }

            double CurrentMonthMTD = Math.Floor((((P - M) * R) + B - (Z + X)) / (n + 1) * 100) * 0.01;
            if (CurrentMonthMTD < MTDMinimumAmmountToNotGoToZero)
            {
                CurrentMonthMTD = 0;
            }
            double NetMTD = CurrentMonthMTD - _zakatByEmployee - _zakatByPayroll - _departureLevy;

            if (NetMTD < 0.00)
            {
                NetMTD = 0;
            }

            double YearlyMTD = X + (CurrentMonthMTD * (n + 1));

            K2 = Math.Floor(Math.Min(K1, (4000 - K - K1 - Kt) / n) * 100) * 0.01;

            double PAdd = Math.Floor((Y_K + (Y1 - K1) + ((Y2 - K2) * n) + (Yt - Kt) - D - SDSQC - LP - LP1) * 100) * 0.01;

            if (Yt == 0.00)
            {
                PAdd = 0;
            }
            double Madd;
            double Radd;
            double Badd;
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
                if (spouseNoIncomeDeduction == SpouseNoIncomeDeduction)
                {
                    Badd = SpouseNoIncomeRebate;
                }
                else
                {
                    Badd = SpouseGetIncomeRebate;
                }
            }
            else if (PAdd >= 20001 && PAdd < 35001)
            {
                Madd = 20000;
                Radd = 0.03;
                if (spouseNoIncomeDeduction == SpouseNoIncomeDeduction)
                {
                    Badd = SpouseNoIncomeRebate20To35K;
                }
                else
                {
                    Badd = SpouseGetIncomeRebate20To35K;
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
                Radd = 0.13;
                Badd = 1800;
            }
            else if (PAdd >= 70001 && PAdd < 100001)
            {
                Madd = 70000;
                Radd = 0.21;
                Badd = 4400;
            }
            else if (PAdd >= 100001 && PAdd < 250001)
            {
                Madd = 100000;
                Radd = 0.24;
                Badd = 10700;
            }
            else if (PAdd >= 250001 && PAdd < 400001)
            {
                Madd = 250000;
                Radd = 0.245;
                Badd = 46700;
            }
            else if (PAdd >= 400001 && PAdd < 600001)
            {
                Madd = 400000;
                Radd = 0.25;
                Badd = 83450;
            }
            else if (PAdd >= 600001 && PAdd < 1000001)
            {
                Madd = 600000;
                Radd = 0.26;
                Badd = 133450;
            }
            else if (PAdd >= 1000001 && PAdd < 2000001)
            {
                Madd = 1000000;
                Radd = 0.28;
                Badd = 237450;
            }
            else
            {
                Madd = 2000000;
                Radd = 0.3;
                Badd = 517450;
            }

            double CS = Math.Floor(((PAdd - Madd) * Radd + Badd) * 100) * 0.01;
            if (P < 35001.00 && spouseNoIncomeDeduction == SpouseNoIncomeDeduction)
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

        public double EmployeeEPFCalculation(int _employeeAge, double _EPFRate, double _currentMonthRemuneration)
        {
            double _EPFContribution = 0.00;
            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                if (_EPFRate == EPFElevenPercentRate)
                {
                    if (_currentMonthRemuneration <= 20)
                    {
                        if (_currentMonthRemuneration <= 10)
                        {
                            _EPFContribution = 0.00;
                            return _EPFContribution;
                        }
                        else if (_currentMonthRemuneration > 10 && _currentMonthRemuneration <= 20)
                        {
                            _EPFContribution = 3.00;
                            return _EPFContribution;
                        }
                    }
                    else if (_currentMonthRemuneration > 20 && _currentMonthRemuneration <= 5000)
                    {
                        double EPFWage1 = Math.Ceiling(_currentMonthRemuneration * 0.05) * 20;
                        _EPFContribution = Math.Ceiling(EPFWage1 * _EPFRate);
                        return _EPFContribution;
                    }
                    else if (_currentMonthRemuneration > 5000 && _currentMonthRemuneration <= 20000)
                    {
                        double EPFWage2 = Math.Ceiling(_currentMonthRemuneration * 0.01) * 100;
                        _EPFContribution = Math.Ceiling(EPFWage2 * _EPFRate);
                        return _EPFContribution;
                    }
                    else
                    {
                        _EPFContribution = Math.Ceiling(_currentMonthRemuneration * _EPFRate);
                        return _EPFContribution;
                    }
                }
                else if (_EPFRate == EPFNinePercentRate)
                {
                    if (_currentMonthRemuneration <= 20)
                    {
                        if (_currentMonthRemuneration <= 10)
                        {
                            _EPFContribution = 0.00;
                            return _EPFContribution;
                        }
                        else if (_currentMonthRemuneration > 10 && _currentMonthRemuneration <= 20)
                        {
                            _EPFContribution = 2.00;
                            return _EPFContribution;
                        }
                    }
                    else if (_currentMonthRemuneration > 20 && _currentMonthRemuneration <= 5000)
                    {
                        double EPFWage1 = Math.Ceiling(_currentMonthRemuneration * 0.05) * 20;
                        _EPFContribution = Math.Ceiling(EPFWage1 * _EPFRate);
                        return _EPFContribution;
                    }
                    else if (_currentMonthRemuneration > 5000 && _currentMonthRemuneration <= 20000)
                    {
                        double EPFWage2 = Math.Ceiling(_currentMonthRemuneration * 0.01) * 100;
                        _EPFContribution = Math.Ceiling(EPFWage2 * _EPFRate);
                        return _EPFContribution;
                    }
                    else
                    {
                        _EPFContribution = Math.Ceiling(_currentMonthRemuneration * _EPFRate);
                        return _EPFContribution;
                    }
                }
            }
            else
            {
                _EPFContribution = 0;
                return _EPFContribution;
            }
            return _EPFContribution;
        }

        public double EmployeeEPFAdditionalCalculation(double _employeeAge, double _EPFRate, double currentMonthNetRemuneration, double _EPFContribution)
        {
            double _EPFAdditionalContribution = 0.00;
            double _EPFContribution2;
            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                if (_EPFRate == EPFElevenPercentRate)
                {
                    if (currentMonthNetRemuneration <= 20)
                    {
                        if (currentMonthNetRemuneration <= 10)
                        {
                            _EPFAdditionalContribution = 0;
                            return _EPFAdditionalContribution;
                        }
                        else if (currentMonthNetRemuneration > 10 && currentMonthNetRemuneration <= 20)
                        {
                            _EPFContribution2 = 3.00;
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                            return _EPFAdditionalContribution;
                        }
                    }
                    else if (currentMonthNetRemuneration > 20 && currentMonthNetRemuneration <= 5000)
                    {
                        double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.05) * 20;
                        _EPFContribution2 = Math.Ceiling(EPFWage1 * _EPFRate);
                        _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        return _EPFAdditionalContribution;
                    }
                    else if (currentMonthNetRemuneration > 5000 && currentMonthNetRemuneration <= 20000)
                    {
                        double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.01) * 100;
                        _EPFContribution2 = Math.Ceiling(EPFWage1 * _EPFRate);
                        _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        return _EPFAdditionalContribution;
                    }
                    else
                    {
                        _EPFContribution2 = Math.Ceiling(currentMonthNetRemuneration * _EPFRate);
                        _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        return _EPFAdditionalContribution;
                    }
                }
                if (_EPFRate == EPFNinePercentRate)
                {
                    if (currentMonthNetRemuneration <= 20)
                    {
                        if (currentMonthNetRemuneration <= 10)
                        {
                            _EPFAdditionalContribution = 0;
                            return _EPFAdditionalContribution;
                        }
                        else if (currentMonthNetRemuneration > 10 && currentMonthNetRemuneration <= 20)
                        {
                            _EPFContribution2 = 2.00;
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                            return _EPFAdditionalContribution;
                        }
                    }
                    else if (currentMonthNetRemuneration > 20 && currentMonthNetRemuneration <= 5000)
                    {
                        double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.05) * 20;
                        _EPFContribution2 = Math.Ceiling(EPFWage1 * _EPFRate);
                        _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        return _EPFAdditionalContribution;
                    }
                    else if (currentMonthNetRemuneration > 5000 && currentMonthNetRemuneration <= 20000)
                    {
                        double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.01) * 100;
                        _EPFContribution2 = Math.Ceiling(EPFWage1 * _EPFRate);
                        _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        return _EPFAdditionalContribution;
                    }
                    else
                    {
                        _EPFContribution2 = Math.Ceiling(currentMonthNetRemuneration * _EPFRate);
                        _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        return _EPFAdditionalContribution;
                    }
                }
            }
            else
            {
                _EPFAdditionalContribution = 0;
                return _EPFAdditionalContribution;
            }
            return _EPFAdditionalContribution;
        }

        public double EmployeeSOCSOCalculation(int _employeeAge, double SOCSOWage)
        {
            double _SOCSOContribution;
            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                if (SOCSOWage <= 30)
                {
                    _SOCSOContribution = 0.10;
                }
                else if (SOCSOWage > 30 && SOCSOWage <= 50)
                {
                    _SOCSOContribution = 0.30;
                }
                else if (SOCSOWage > 50 && SOCSOWage <= 70)
                {
                    _SOCSOContribution = 0.30;
                }
                else if (SOCSOWage > 70 && SOCSOWage <= 100)
                {
                    _SOCSOContribution = 0.40;
                }
                else if (SOCSOWage > 100 && SOCSOWage <= 140)
                {
                    _SOCSOContribution = 0.60;
                }
                else if (SOCSOWage > 140 && SOCSOWage <= 200)
                {
                    _SOCSOContribution = 0.85;
                }
                else if (SOCSOWage > 200 && SOCSOWage <= 300)
                {
                    _SOCSOContribution = 1.25;
                }
                else if (SOCSOWage > 300 && SOCSOWage <= 400)
                {
                    _SOCSOContribution = 1.75;
                }
                else if (SOCSOWage > 400 && SOCSOWage <= 500)
                {
                    _SOCSOContribution = 2.25;
                }
                else if (SOCSOWage > 500 && SOCSOWage <= 600)
                {
                    _SOCSOContribution = 2.75;
                }
                else if (SOCSOWage > 600 && SOCSOWage <= 700)
                {
                    _SOCSOContribution = 3.25;
                }
                else if (SOCSOWage > 700 && SOCSOWage <= 800)
                {
                    _SOCSOContribution = 3.75;
                }
                else if (SOCSOWage > 800 && SOCSOWage <= 900)
                {
                    _SOCSOContribution = 4.25;
                }
                else if (SOCSOWage > 900 && SOCSOWage <= 1000)
                {
                    _SOCSOContribution = 4.75;
                }
                else if (SOCSOWage > 1000 && SOCSOWage <= 1100)
                {
                    _SOCSOContribution = 5.25;
                }
                else if (SOCSOWage > 1100 && SOCSOWage <= 1200)
                {
                    _SOCSOContribution = 5.75;
                }
                else if (SOCSOWage > 1200 && SOCSOWage <= 1300)
                {
                    _SOCSOContribution = 6.25;
                }
                else if (SOCSOWage > 1300 && SOCSOWage <= 1400)
                {
                    _SOCSOContribution = 6.75;
                }
                else if (SOCSOWage > 1400 && SOCSOWage <= 1500)
                {
                    _SOCSOContribution = 7.25;
                }
                else if (SOCSOWage > 1500 && SOCSOWage <= 1600)
                {
                    _SOCSOContribution = 7.75;
                }
                else if (SOCSOWage > 1600 && SOCSOWage <= 1700)
                {
                    _SOCSOContribution = 8.25;
                }
                else if (SOCSOWage > 1700 && SOCSOWage <= 1800)
                {
                    _SOCSOContribution = 8.75;
                }
                else if (SOCSOWage > 1800 && SOCSOWage <= 1900)
                {
                    _SOCSOContribution = 9.25;
                }
                else if (SOCSOWage > 1900 && SOCSOWage <= 2000)
                {
                    _SOCSOContribution = 9.75;
                }
                else if (SOCSOWage > 2000 && SOCSOWage <= 2100)
                {
                    _SOCSOContribution = 10.25;
                }
                else if (SOCSOWage > 2100 && SOCSOWage <= 2200)
                {
                    _SOCSOContribution = 10.75;
                }
                else if (SOCSOWage > 2200 && SOCSOWage <= 2300)
                {
                    _SOCSOContribution = 11.25;
                }
                else if (SOCSOWage > 2300 && SOCSOWage <= 2400)
                {
                    _SOCSOContribution = 11.75;
                }
                else if (SOCSOWage > 2400 && SOCSOWage <= 2500)
                {
                    _SOCSOContribution = 12.25;
                }
                else if (SOCSOWage > 2500 && SOCSOWage <= 2600)
                {
                    _SOCSOContribution = 12.75;
                }
                else if (SOCSOWage > 2600 && SOCSOWage <= 2700)
                {
                    _SOCSOContribution = 13.25;
                }
                else if (SOCSOWage > 2700 && SOCSOWage <= 2800)
                {
                    _SOCSOContribution = 13.75;
                }
                else if (SOCSOWage > 2800 && SOCSOWage <= 2900)
                {
                    _SOCSOContribution = 14.25;
                }
                else if (SOCSOWage > 2900 && SOCSOWage <= 3000)
                {
                    _SOCSOContribution = 14.75;
                }
                else if (SOCSOWage > 3000 && SOCSOWage <= 3100)
                {
                    _SOCSOContribution = 15.25;
                }
                else if (SOCSOWage > 3100 && SOCSOWage <= 3200)
                {
                    _SOCSOContribution = 15.75;
                }
                else if (SOCSOWage > 3200 && SOCSOWage <= 3300)
                {
                    _SOCSOContribution = 16.25;
                }
                else if (SOCSOWage > 3300 && SOCSOWage <= 3400)
                {
                    _SOCSOContribution = 16.75;
                }
                else if (SOCSOWage > 3400 && SOCSOWage <= 3500)
                {
                    _SOCSOContribution = 17.25;
                }
                else if (SOCSOWage > 3500 && SOCSOWage <= 3600)
                {
                    _SOCSOContribution = 17.75;
                }
                else if (SOCSOWage > 3600 && SOCSOWage <= 3700)
                {
                    _SOCSOContribution = 18.25;
                }
                else if (SOCSOWage > 3700 && SOCSOWage <= 3800)
                {
                    _SOCSOContribution = 18.75;
                }
                else if (SOCSOWage > 3800 && SOCSOWage <= 3900)
                {
                    _SOCSOContribution = 19.25;
                }
                else if (SOCSOWage > 3900 && SOCSOWage <= 4000)
                {
                    _SOCSOContribution = 19.75;
                }
                else
                {
                    _SOCSOContribution = 19.75;
                }
            }
            else
            {
                _SOCSOContribution = 0;
            }
            return _SOCSOContribution;
        }

        public double EmployerEPFCalculation(int _employeeAge, double _currentMonthRemuneration, double additionalRemuneration, double additionalRemunerationWithoutBonus)
        {
            double employerEPF = 0;
            double employerEPFRate;

            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                employerEPFRate = 0.13;
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
                    double EPFWage1 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.05) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (additionalRemunerationWithoutBonus <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if ((_currentMonthRemuneration + additionalRemuneration) > 5000 && (_currentMonthRemuneration + additionalRemuneration) <= 20000)
                {
                    employerEPFRate = 0.12;
                    double EPFWage2 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * employerEPFRate);
                }
                else
                {
                    employerEPFRate = 0.12;
                    employerEPF = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * employerEPFRate);
                }
            }
            else
            {
                employerEPFRate = 0.04;
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
                    double EPFWage1 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.05) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (additionalRemunerationWithoutBonus <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if ((_currentMonthRemuneration + additionalRemuneration) > 5000 && (_currentMonthRemuneration + additionalRemuneration) <= 20000)
                {
                    double EPFWage2 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * employerEPFRate);
                }
                else
                {
                    employerEPF = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * employerEPFRate);
                }
            }
            return employerEPF;
        }

        public double EmployerSOCSOCalculation(double SOCSOWage, int _employeeAge)
        {
            double employerSOCSO;
            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
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
            return employerSOCSO;
        }

        public double EISCalculation(double WageEIS, int _employeeAge)
        {
            double EIS;
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

            if (_employeeAge >= EmployeeMaxAgeForEPFContribution)
            {
                EIS = 0;
            }
            return EIS;
        }
    }
}
