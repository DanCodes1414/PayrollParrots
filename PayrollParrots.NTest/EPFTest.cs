using System.Collections.Generic;
using NUnit.Framework;
using PayrollParrots.Model;
using PayrollParrots.PayrollTax;

namespace PayrollParrots.NTest
{
    [TestFixture()]
    public class EPFTest
    {
        readonly PayrollItems payrollItems = new PayrollItems();
        EPFCalculations EPFCalculations;

        int _employeeAge;
        double _EPFRate;
        double _EPFContribution;

        Dictionary<string, double> AdditionalRemunerationItems;

        [SetUp]
        public void SetUp()
        {
            _employeeAge = 28;
            _EPFRate = 0.11;
            _EPFContribution = 2200;
            double _currentMonthRemuneration = 3000;

            //additional remuneration
            double _bonus = 1000; double _arrears = 1500; double _commission = 200;
            double _othersEPFNO = 0; double _others = 0; double _OthersEISNO = 0;
            AdditionalRemunerationItems = new Dictionary<string, double>
            {
                {"Bonus", _bonus},
                {"Arrears", _arrears},
                {"Commission", _commission},
                {"OthersNotSubjectToEPF", _othersEPFNO},
                {"OthersNotSubjectToSOCSOAndEIS", _OthersEISNO},
                {"OthersSubjectToEPFAndSOCSOAndEIS", _others}
            };

            payrollItems.CurrentMonthRemuneration = _currentMonthRemuneration;
            EPFCalculations = new EPFCalculations(payrollItems, AdditionalRemunerationItems);
        }

        [Test()]
        [Category("EPF")]
        public void EmployeeEPFTest()
        {
            double EPF = EPFCalculations.EmployeeEPFCalculation(_employeeAge, _EPFRate);

            Assert.AreEqual(10, EPF);
        }

        [Test()]
        [Category("EPF")]
        public void EmployeeAdditionalEPFTest()
        {
            double AdditionalEPF = EPFCalculations.EmployeeEPFAdditionalCalculation(_employeeAge, _EPFRate, _EPFContribution);

            Assert.AreEqual(0, AdditionalEPF);
        }

        [Test()]
        [Category("EPF")]
        public void EmployerEPFTest()
        {
            double EmployerEPF = EPFCalculations.EmployerEPFCalculation(_employeeAge);

            Assert.AreEqual(0, EmployerEPF);
        }
    }
}
