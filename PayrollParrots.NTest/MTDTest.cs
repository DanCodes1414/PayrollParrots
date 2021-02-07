using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PayrollParrots.Model;

namespace PayrollParrots.NTest
{
    [TestFixture()]
    public class MTDTests
    {
        readonly PayrollFamilyDeductions payrollFamily = new PayrollFamilyDeductions();
        MTDCalculations MTDCalculations;

        int _monthsRemaining;
        double _EPFContribution;
        double _previousEPFContribution;
        double _previousSOCSOContribution;
        double _EPFAdditionalContribution;
        double _SOCSOContribution;
        double _MTDPrevious;
        double P;

        Dictionary<string, double> NormalRemunerationItems;
        Dictionary<string, double> VOLAItems;
        Dictionary<string, double> BIKItems;
        Dictionary<string, double> AdditionalRemunerationItems;
        Dictionary<string, double> DeductionItems;
        Dictionary<string, double> RebateItems;
        Dictionary<string, double> PreviousRemunerationItems;
        Dictionary<string, double> PreviousVOLAItems;
        Dictionary<string, double> PreviousBIKItems;
        Dictionary<string, double> PreviousDeductionItems;
        Dictionary<string, double> PreviousRebateItems;

        [SetUp]
        public void SetUp()
        {

            _monthsRemaining = 7;
            P = 0;

            //current month remuneration
            double _currentMonthRemuneration = 6200; double _BIK = 0; double _VOLA = 0; _EPFContribution = 0;
            NormalRemunerationItems = new Dictionary<string, double>
            {
                {"CurrentMonthRemuneration", _currentMonthRemuneration}
            };
            BIKItems = new Dictionary<string, double>
            {
                {"BIK", _BIK}
            };
            VOLAItems = new Dictionary<string, double>
            {
                {"VOLA", _VOLA}
            };

            //familydeductions
            double _kidsU18 = 0; double _over18inHE = 0; double _disabledChildren = 0; double _disabledChildreninHE = 0;
            double _kidsU18split = 0; double _over18inHEsplit = 0; double _disabledChildrensplit = 0; double _disabledChildreninHEsplit = 0;
            double disabledDeduction = 0; double disabledSpouseDeduction = 0;
            double spouseNoIncomeDeduction = 4000;
            double totalFamilyDeductions = (_kidsU18 * 2000) + (_over18inHE * 8000) + (_disabledChildren * 6000) + (_disabledChildreninHE * 14000) + (_kidsU18split * 1000) + (_over18inHEsplit * 4000) + (_disabledChildrensplit * 3000) + (_disabledChildreninHEsplit * 7000) + disabledDeduction + disabledSpouseDeduction + spouseNoIncomeDeduction;

            payrollFamily.SpouseNotGettingIncome = spouseNoIncomeDeduction;
            payrollFamily.TotalFamilyDeductions = totalFamilyDeductions;

            //additional remuneration
            double _bonus = 200; double _arrears = 0; double _commission = 0; double _othersEPFNO = 0; double _others = 0; double _OthersEISNO = 0; _EPFAdditionalContribution = 0;
            AdditionalRemunerationItems = new Dictionary<string, double>
            {
                {"Bonus", _bonus},
                {"Arrears", _arrears},
                {"Commission", _commission},
                {"OthersNotSubjectToEPF", _othersEPFNO},
                {"OthersNotSubjectToSOCSOAndEIS", _OthersEISNO},
                {"OthersSubjectToEPFAndSOCSOAndEIS", _others}
            };

            //deductions
            double _lifeStyleRelief = 0; double _sportsRelief = 0; _SOCSOContribution = 0; double _lifeInsurance = 0; double _basicEquipment = 200; double _educationYourSelf = 0;
            double _medicalExamination = 0; double _medicalVaccination = 0; double _medicalDisease = 0; double _smallKidEducation = 0; double _breastFeedingEquipment = 0;
            double _alimonyFormerWife = 0; double _EMInsurance = 0; double _fatherRelief = 0; double _motherRelief = 0; double _mapaRelief = 0; double _SSPN = 0; double _PRS = 0; double _domesticTourismExpenditure = 0;
            DeductionItems = new Dictionary<string, double>
            {
                {"LifeStyleRelief", _lifeStyleRelief},
                {"SportsRelief", _sportsRelief},
                {"LifeInsurance", _lifeInsurance},
                {"SupportingEquipment", _basicEquipment},
                {"EducationFeesForSelf", _educationYourSelf},
                {"MedicalExamination", _medicalExamination},
                {"MedicalVaccination", _medicalVaccination},
                {"MedicalDisease", _medicalDisease},
                {"KindergartenAndChildCareFees", _smallKidEducation},
                {"BreastFeedingEquipment", _breastFeedingEquipment},
                {"AlimonyToFormerWife", _alimonyFormerWife},
                {"EducationAndMedicalInsurance", _EMInsurance},
                {"FatherRelief", _fatherRelief},
                {"MotherRelief", _motherRelief},
                {"MedicalExpenseForParents", _mapaRelief},
                {"SSPN", _SSPN},
                {"PRS", _PRS},
                {"DomesticTourismExpenditure", _domesticTourismExpenditure}
            };

            //previous deductions
            double _previousLifeStyleRelief = 0; double _previousSportsRelief = 0; _previousSOCSOContribution = 0; double _previousLifeInsurance = 0;
            double _previousBasicEquipment = 0; double _previousEducationYourSelf = 0; double _previousMedicalExamination = 0; double _previousMedicalVaccination = 0;
            double _previousMedicalDisease = 0; double _previousSmallKidEducation = 0; double _previousBreastFeedingEquipment = 0; double _previousAlimonyFormerWife = 0;
            double _previousEMInsurance = 0; double _previousFatherRelief = 0; double _previousMotherRelief = 0; double _previousDomesticTourismExpenditure = 0; double _previousMapaRelief = 0; double _previousSSPN = 0; double _previousPRS = 0;
            PreviousDeductionItems = new Dictionary<string, double>
            {
                {"PreviousLifeStyleRelief", _previousLifeStyleRelief},
                {"PreviousSportsRelief", _previousSportsRelief},
                {"PreviousLifeInsurance", _previousLifeInsurance},
                {"PreviousSupportingEquipment", _previousBasicEquipment},
                {"PreviousEducationFeesForSelf", _previousEducationYourSelf},
                {"PreviousMedicalExamination", _previousMedicalExamination},
                {"PreviousMedicalVaccination", _previousMedicalVaccination},
                {"PreviousMedicalDisease", _previousMedicalDisease},
                {"PreviousKindergartenAndChildCareFees", _previousSmallKidEducation},
                {"PreviousBreastFeedingEquipment", _previousBreastFeedingEquipment},
                {"PreviousAlimonyToFormerWife", _previousAlimonyFormerWife},
                {"PreviousEducationAndMedicalInsurance", _previousEMInsurance},
                {"PreviousFatherRelief", _previousFatherRelief},
                {"PreviousMotherRelief", _previousMotherRelief},
                {"PreviousMedicalExpenseForParents", _previousMapaRelief},
                {"PreviousSSPN", _previousSSPN},
                {"PreviousPRS", _previousPRS},
                {"PreviousDomesticTourismExpenditure", _previousDomesticTourismExpenditure}
            };

            //zakat and levy
            double _zakatByEmployee = 0; double _zakatByPayroll = 0; double _departureLevy = 0;
            RebateItems = new Dictionary<string, double>
            {
                {"ZakatByEmployee", _zakatByEmployee},
                {"ZakatViaPayroll", _zakatByPayroll},
                {"DepartureLevy", _departureLevy}
            };

            //previous month remuneration
            double _previousMonthsRemuneration = 0; _previousEPFContribution = 0; double _previousBIK = 0; double _previousVOLA = 0; _MTDPrevious = 0;
            PreviousRemunerationItems = new Dictionary<string, double>
            {
                {"PreviousMonthsRemuneration", _previousMonthsRemuneration}
            };
            PreviousBIKItems = new Dictionary<string, double>
            {
                {"PreviousBIK", _previousBIK}
            };
            PreviousVOLAItems = new Dictionary<string, double>
            {
                {"PreviousVOLA", _previousVOLA}
            };

            //previous zakat and levy
            double _previousZakatByEmployee = 0; double _previousZakatByPayroll = 0; double _previousDepartureLevy = 0;
            PreviousRebateItems = new Dictionary<string, double>
            {
                {"PreviousZakatByEmployee", _previousZakatByEmployee},
                {"PreviousZakatViaPayroll", _previousZakatByPayroll},
                {"PreviousDepartureLevy", _previousDepartureLevy}
            };

            var DictionaryContainingAllItems = NormalRemunerationItems.Union(BIKItems).Union(VOLAItems).Union(AdditionalRemunerationItems).Union(DeductionItems).Union(RebateItems).Union(PreviousRemunerationItems).Union(PreviousBIKItems).Union(PreviousVOLAItems).Union(PreviousDeductionItems).Union(PreviousRebateItems).ToDictionary(k => k.Key, v => v.Value);
            MTDCalculations = new MTDCalculations(DictionaryContainingAllItems);
        }


        [Test()]
        [Category("MTD")]
        public void MTDTest()
        {
            var RoundedMTD = MTDCalculations.MTDCalculation(payrollFamily, _monthsRemaining,
                                                            _SOCSOContribution, _previousSOCSOContribution,
                                                            _previousEPFContribution, _MTDPrevious,
                                                            _EPFContribution, _EPFAdditionalContribution);

            Assert.AreEqual(0, RoundedMTD);
        }

        [Test()]
        [Category("MTD")]
        public void PTest()
        {
            var P = MTDCalculations.PAndPAddCalculation(payrollFamily, _monthsRemaining,
                                                        _SOCSOContribution, _previousSOCSOContribution,
                                                        _previousEPFContribution, _EPFContribution,
                                                        _EPFAdditionalContribution, true);

            Assert.AreEqual(0, P);
        }

        [Test()]
        [Category("MTD")]
        public void PAddTest()
        {
            var PAdd = MTDCalculations.PAndPAddCalculation(payrollFamily, _monthsRemaining,
                                                           _SOCSOContribution, _previousSOCSOContribution,
                                                           _previousEPFContribution, _EPFContribution,
                                                           _EPFAdditionalContribution, false);

            Assert.AreEqual(0, PAdd);
        }

        [Test()]
        [Category("MTD")]
        public void MTest()
        {
            (double M, _, _) = MTDCalculations.MRBCalculation(P, payrollFamily);

            Assert.AreEqual(1, M);
        }

        [Test()]
        [Category("MTD")]
        public void RTest()
        {
            (_, double R, _) = MTDCalculations.MRBCalculation(P, payrollFamily);

            Assert.AreEqual(1, R);
        }

        [Test()]
        [Category("MTD")]
        public void BTest()
        {
            (_, _, double B) = MTDCalculations.MRBCalculation(P, payrollFamily);

            Assert.AreEqual(1, B);
        }
    }
}
