using System;
using System.Collections.Generic;

namespace PayrollParrots.PayrollTax
{
    public class SOCSOAndEISCalculations
    {
        public const double EmployeeMaxAgeForEPFContribution = 60;
        public double EmployeeSOCSOCalculation(int _employeeAge, Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            double _SOCSOContribution;

            double SOCSOWage = NormalRemunerationItems["CurrentMonthRemuneration"] + AdditionalRemunerationItems["Arrears"] + AdditionalRemunerationItems["Commission"] + AdditionalRemunerationItems["OthersNotSubjectToEPF"] + AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"];

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

        public double EmployerSOCSOCalculation(int _employeeAge, Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            double employerSOCSO;
            double SOCSOWage = NormalRemunerationItems["CurrentMonthRemuneration"] + AdditionalRemunerationItems["Commission"] + AdditionalRemunerationItems["Arrears"] + AdditionalRemunerationItems["OthersNotSubjectToEPF"] + AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"];

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

        public double EISCalculation(int _employeeAge, Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            double EIS;
            double WageEIS = NormalRemunerationItems["CurrentMonthRemuneration"] + AdditionalRemunerationItems["Commission"] + AdditionalRemunerationItems["Arrears"] + AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"] + AdditionalRemunerationItems["OthersNotSubjectToEPF"];

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
            else if (WageEIS > 300 && WageEIS <= 4000)
            {
                double eis = 0.5;
                for (int wage = 350; wage <= 4000; wage += 100)
                {
                    eis += 0.2;
                    if ((((Math.Floor((WageEIS - 0.01) * 0.01) * 100) + (Math.Ceiling(WageEIS * 0.01) * 100)) * 0.5) == wage)
                    {
                        return eis;
                    }
                }
                EIS = eis;
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
