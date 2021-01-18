using System;
using System.Collections.Generic;

namespace PayrollParrots.PayrollTax
{
    public class EPFCalculations
    {
        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double EPFNinePercentRate = 0.09;
        public const double EPFElevenPercentRate = 0.11;

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

        public double EmployeeEPFAdditionalCalculation(double _employeeAge, double _EPFRate, double _EPFContribution, Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            double _EPFAdditionalContribution = 0.00;

            double currentMonthRemuneration = NormalRemunerationItems["CurrentMonthRemuneration"];
            double additionalRemuneration = AdditionalRemunerationItems["Bonus"] + AdditionalRemunerationItems["Commission"] + AdditionalRemunerationItems["OthersNotSubjectToSOCSOAndEIS"] + AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"] + AdditionalRemunerationItems["Arrears"];
            double currentMonthNetRemuneration = currentMonthRemuneration + additionalRemuneration;
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

        public double EmployerEPFCalculation(int _employeeAge, Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            double employerEPF = 0;
            double employerEPFRate;

            double normalRemuneration = NormalRemunerationItems["CurrentMonthRemuneration"];
            double additionalRemuneration = AdditionalRemunerationItems["Bonus"] + AdditionalRemunerationItems["Commission"] + AdditionalRemunerationItems["Arrears"] + AdditionalRemunerationItems["OthersNotSubjectToSOCSOAndEIS"] + AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"];
            double additionalRemunerationWithoutBonus = AdditionalRemunerationItems["Commission"] + AdditionalRemunerationItems["Arrears"] + AdditionalRemunerationItems["OthersNotSubjectToSOCSOAndEIS"] + AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"];

            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                employerEPFRate = 0.13;
                if ((normalRemuneration + additionalRemuneration) <= 20)
                {
                    if ((normalRemuneration + additionalRemuneration) <= 10)
                    {
                        employerEPF = 0.00;
                    }
                    else if ((normalRemuneration + additionalRemuneration) > 10 && (normalRemuneration + additionalRemuneration) <= 20)
                    {
                        employerEPF = 3.00;
                    }
                }
                else if ((normalRemuneration + additionalRemuneration) > 20 && (normalRemuneration + additionalRemuneration) <= 5000)
                {
                    double EPFWage1 = Math.Ceiling((normalRemuneration + additionalRemuneration) * 0.05) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (additionalRemunerationWithoutBonus <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = Math.Ceiling((normalRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if ((normalRemuneration + additionalRemuneration) > 5000 && (normalRemuneration + additionalRemuneration) <= 20000)
                {
                    employerEPFRate = 0.12;
                    double EPFWage2 = Math.Ceiling((normalRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * employerEPFRate);
                }
                else
                {
                    employerEPFRate = 0.12;
                    employerEPF = Math.Ceiling((normalRemuneration + additionalRemuneration) * employerEPFRate);
                }
            }
            else
            {
                employerEPFRate = 0.04;
                if ((normalRemuneration + additionalRemuneration) <= 20)
                {
                    if ((normalRemuneration + additionalRemuneration) <= 10)
                    {
                        employerEPF = 0.00;
                    }
                    else if ((normalRemuneration + additionalRemuneration) > 10 && (normalRemuneration + additionalRemuneration) <= 20)
                    {
                        employerEPF = 1.00;
                    }
                }
                else if ((normalRemuneration + additionalRemuneration) > 20 && (normalRemuneration + additionalRemuneration) <= 5000)
                {
                    double EPFWage1 = Math.Ceiling((normalRemuneration + additionalRemuneration) * 0.05) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (additionalRemunerationWithoutBonus <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = Math.Ceiling((normalRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if ((normalRemuneration + additionalRemuneration) > 5000 && (normalRemuneration + additionalRemuneration) <= 20000)
                {
                    double EPFWage2 = Math.Ceiling((normalRemuneration + additionalRemuneration) * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * employerEPFRate);
                }
                else
                {
                    employerEPF = Math.Ceiling((normalRemuneration + additionalRemuneration) * employerEPFRate);
                }
            }
            return employerEPF;
        }
    }
}
