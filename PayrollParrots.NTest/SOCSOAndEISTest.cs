using System.Collections.Generic;
using NUnit.Framework;
using PayrollParrots.PayrollTax;

namespace PayrollParrots.NTest
{
    [TestFixture()]
    public class SOCSOAndEISTest
    {
        SOCSOAndEISCalculations SOCSOAndEISCalculations;
        int _employeeAge;

        Dictionary<string, double> NormalRemunerationItems;
        Dictionary<string, double> AdditionalRemunerationItems;

        [SetUp]
        public void SetUp()
        {
            _employeeAge = 73;

            //current month remuneration
            double _currentMonthRemuneration = 0;
            NormalRemunerationItems = new Dictionary<string, double>
            {
                {"CurrentMonthRemuneration", _currentMonthRemuneration}
            };

            //additional remuneration
            double _bonus = 1000; double _arrears = 1000; double _commission = 1000;
            double _othersEPFNO = 1000; double _others = 0; double _OthersEISNO = 1000;
            AdditionalRemunerationItems = new Dictionary<string, double>
            {
                {"Bonus", _bonus},
                {"Arrears", _arrears},
                {"Commission", _commission},
                {"OthersNotSubjectToEPF", _othersEPFNO},
                {"OthersNotSubjectToSOCSOAndEIS", _OthersEISNO},
                {"OthersSubjectToEPFAndSOCSOAndEIS", _others}
            };

            SOCSOAndEISCalculations = new SOCSOAndEISCalculations(NormalRemunerationItems, AdditionalRemunerationItems);
        }

        [Test()]
        [Category("SOCSO")]
        public void EmployeeSOCSOTest()
        {
            double SOCSO = SOCSOAndEISCalculations.EmployeeSOCSOCalculation(_employeeAge);

            Assert.AreEqual(0, SOCSO);
        }

        [Test()]
        [Category("SOCSO")]
        public void EmployerSOCSOTest()
        {
            double EmployerSOCSO = SOCSOAndEISCalculations.EmployerSOCSOCalculation(_employeeAge);

            Assert.AreEqual(0, EmployerSOCSO);
        }

        [Test()]
        [Category("EIS")]
        public void EISTest()
        {
            double EIS = SOCSOAndEISCalculations.EISCalculation(_employeeAge);

            Assert.AreEqual(7.90, EIS);
        }
    }
}
