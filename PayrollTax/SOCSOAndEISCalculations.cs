using System;
using PayrollParrots.Model;
using System.Collections.Generic;

namespace PayrollParrots.PayrollTax
{
    public class SOCSOAndEISCalculations : IsApplicableToSOCSOAndEIS
    {
        readonly IsApplicableToSOCSOAndEIS isApplicableToSOCSOAndEIS;
        public SOCSOAndEISCalculations(Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems) : base(NormalRemunerationItems, AdditionalRemunerationItems)
        {
            isApplicableToSOCSOAndEIS = new IsApplicableToSOCSOAndEIS(NormalRemunerationItems, AdditionalRemunerationItems);
        }

        public const double EmployeeMaxAgeForEPFContribution = 60;
        public double EmployeeSOCSOCalculation(int _employeeAge)
        {
            double _SOCSOContribution;

            double SOCSOWage = isApplicableToSOCSOAndEIS.WageSOCSOAndEIS;

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
                else if (SOCSOWage > 300 && SOCSOWage <= 4000)
                {
                    double socso = 1.25;
                    for (int wage = 350; wage <= 4000; wage += 100)
                    {
                        socso += 0.5;
                        if ((((Math.Floor((SOCSOWage - 0.01) * 0.01) * 100) + (Math.Ceiling(SOCSOWage * 0.01) * 100)) * 0.5) == wage)
                        {
                            return socso;
                        }
                    }
                    _SOCSOContribution = socso;
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

        public double EmployerSOCSOCalculation(int _employeeAge)
        {
            double employerSOCSO;
            double SOCSOWage = isApplicableToSOCSOAndEIS.WageSOCSOAndEIS;

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
                else if (SOCSOWage > 300 && SOCSOWage <= 4000)
                {
                    double correctsocso = 0;
                    for (int wage = 350; wage <= 4000; wage += 100)
                    {
                        double unroundedsocso = wage * 1.75 * 0.01;
                        correctsocso = ((Math.Floor(unroundedsocso * 10) * 0.1) + (Math.Ceiling(unroundedsocso * 10) * 0.1)) * 0.5;
                        if ((((Math.Floor((SOCSOWage - 0.01) * 0.01) * 100) + (Math.Ceiling(SOCSOWage * 0.01) * 100)) * 0.5) == wage)
                        {
                            return correctsocso;
                        }
                    }
                    employerSOCSO = correctsocso;
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
                else if (SOCSOWage > 300 && SOCSOWage <= 4000)
                {
                    double socso = 0;
                    for (int wage = 350; wage <= 4000; wage += 100)
                    {
                        socso = Math.Round(wage * 1.25 * 0.01, 1);
                        if ((((Math.Floor((SOCSOWage - 0.01) * 0.01) * 100) + (Math.Ceiling(SOCSOWage * 0.01) * 100)) * 0.5) == wage)
                        {
                            return socso;
                        }
                    }
                    employerSOCSO = socso;
                }
                else
                {
                    employerSOCSO = 49.40;
                }
            }
            return employerSOCSO;
        }

        public double EISCalculation(int _employeeAge)
        {
            double EIS;
            double WageEIS = isApplicableToSOCSOAndEIS.WageSOCSOAndEIS;

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
