using System;
using PayrollParrots.Model;
using System.Collections.Generic;

namespace PayrollParrots.PayrollTax
{
    public class EPFCalculations : IsApplicableToEPF
    {
        readonly IsApplicableToEPF isApplicableToEPF;
        public EPFCalculations(PayrollItems payrollItems, Dictionary<string, double> AdditionalRemunerationItems) :base(payrollItems, AdditionalRemunerationItems)
        {
            isApplicableToEPF = new IsApplicableToEPF(payrollItems, AdditionalRemunerationItems);
        }

        public const double EmployeeMaxAgeForEPFContribution = 60;
        public const double EPFNinePercentRate = 0.09;
        public const double EPFElevenPercentRate = 0.11;

        public double EmployeeEPFCalculation(int _employeeAge, double _EPFRate)
        {
            double currentMonthRemuneration = isApplicableToEPF.CurrentMonthRemuneration;
            double _EPFContribution = 0.00;
            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                if (_EPFRate == EPFElevenPercentRate)
                {
                    if (currentMonthRemuneration <= 20)
                    {
                        if (currentMonthRemuneration <= 10)
                        {
                            _EPFContribution = 0.00;
                            return _EPFContribution;
                        }
                        else if (currentMonthRemuneration > 10 && currentMonthRemuneration <= 20)
                        {
                            _EPFContribution = 3.00;
                            return _EPFContribution;
                        }
                    }
                    else if (currentMonthRemuneration > 20 && currentMonthRemuneration <= 5000)
                    {
                        double EPFWage1 = Math.Ceiling(currentMonthRemuneration * 0.05) * 20;
                        _EPFContribution = Math.Ceiling(EPFWage1 * _EPFRate);
                        return _EPFContribution;
                    }
                    else if (currentMonthRemuneration > 5000 && currentMonthRemuneration <= 20000)
                    {
                        double EPFWage2 = Math.Ceiling(currentMonthRemuneration * 0.01) * 100;
                        _EPFContribution = Math.Ceiling(EPFWage2 * _EPFRate);
                        return _EPFContribution;
                    }
                    else
                    {
                        _EPFContribution = Math.Ceiling(currentMonthRemuneration * _EPFRate);
                        return _EPFContribution;
                    }
                }
                else if (_EPFRate == EPFNinePercentRate)
                {
                    if (currentMonthRemuneration <= 20)
                    {
                        if (currentMonthRemuneration <= 10)
                        {
                            _EPFContribution = 0.00;
                            return _EPFContribution;
                        }
                        else if (currentMonthRemuneration > 10 && currentMonthRemuneration <= 20)
                        {
                            _EPFContribution = 2.00;
                            return _EPFContribution;
                        }
                    }
                    else if (currentMonthRemuneration > 20 && currentMonthRemuneration <= 5000)
                    {
                        double EPFWage1 = Math.Ceiling(currentMonthRemuneration * 0.05) * 20;
                        _EPFContribution = Math.Ceiling(EPFWage1 * _EPFRate);
                        return _EPFContribution;
                    }
                    else if (currentMonthRemuneration > 5000 && currentMonthRemuneration <= 20000)
                    {
                        double EPFWage2 = Math.Ceiling(currentMonthRemuneration * 0.01) * 100;
                        _EPFContribution = Math.Ceiling(EPFWage2 * _EPFRate);
                        return _EPFContribution;
                    }
                    else
                    {
                        _EPFContribution = Math.Ceiling(currentMonthRemuneration * _EPFRate);
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

        public double EmployeeEPFAdditionalCalculation(double _employeeAge, double _EPFRate, double _EPFContribution)
        {
            double _EPFAdditionalContribution = 0.00;

            double currentMonthNetRemuneration = isApplicableToEPF.WageEPF;
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

        public double EmployerEPFCalculation(int _employeeAge)
        {
            double employerEPF = 0;
            double employerEPFRate;

            double additionalRemuneration = isApplicableToEPF.TotalAdditionalRemuneration;
            double remunerationWithoutBonus = isApplicableToEPF.RemunerationWithoutBonus;
            double currentMonthNetRemuneration = isApplicableToEPF.WageEPF;

            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                employerEPFRate = 0.13;
                if (currentMonthNetRemuneration <= 20)
                {
                    if (currentMonthNetRemuneration <= 10)
                    {
                        employerEPF = 0.00;
                    }
                    else if (currentMonthNetRemuneration > 10 && currentMonthNetRemuneration <= 20)
                    {
                        employerEPF = 3.00;
                    }
                }
                else if (currentMonthNetRemuneration > 20 && currentMonthNetRemuneration <= 5000)
                {
                    double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.05) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (remunerationWithoutBonus <= 5000 && currentMonthNetRemuneration > 5000)
                {
                    double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (currentMonthNetRemuneration > 5000 && currentMonthNetRemuneration <= 20000)
                {
                    employerEPFRate = 0.12;
                    double EPFWage2 = Math.Ceiling(currentMonthNetRemuneration * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * employerEPFRate);
                }
                else
                {
                    employerEPFRate = 0.12;
                    employerEPF = Math.Ceiling(currentMonthNetRemuneration * employerEPFRate);
                }
            }
            else
            {
                employerEPFRate = 0.04;
                if (currentMonthNetRemuneration <= 20)
                {
                    if (currentMonthNetRemuneration <= 10)
                    {
                        employerEPF = 0.00;
                    }
                    else if (currentMonthNetRemuneration > 10 && currentMonthNetRemuneration <= 20)
                    {
                        employerEPF = 1.00;
                    }
                }
                else if (currentMonthNetRemuneration > 20 && currentMonthNetRemuneration <= 5000)
                {
                    double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.05) * 20;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (remunerationWithoutBonus <= 5000 && additionalRemuneration > 5000)
                {
                    double EPFWage1 = Math.Ceiling(currentMonthNetRemuneration * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage1 * employerEPFRate);
                }
                else if (currentMonthNetRemuneration > 5000 && currentMonthNetRemuneration <= 20000)
                {
                    double EPFWage2 = Math.Ceiling(currentMonthNetRemuneration * 0.01) * 100;
                    employerEPF = Math.Ceiling(EPFWage2 * employerEPFRate);
                }
                else
                {
                    employerEPF = Math.Ceiling(currentMonthNetRemuneration * employerEPFRate);
                }
            }
            return employerEPF;
        }
    }
}
