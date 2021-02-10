using System.Collections.Generic;

namespace PayrollParrots.Model
{
    public class PayrollCategory
    {
        public PayrollCategory(PayrollItems payrollItems)
        {
            Deductions = new Dictionary<string, double>
            {
                ["LifeStyleRelief"] = payrollItems.LifeStyleRelief,
                ["SportsRelief"] = payrollItems.SportsRelief,
                ["LifeInsurance"] = payrollItems.LifeInsurance,
                ["SupportingEquipment"] = payrollItems.SupportingEquipment,
                ["EducationFeesForSelf"] = payrollItems.EducationFeesForSelf,
                ["MedicalExamination"] = payrollItems.MedicalExamination,
                ["MedicalVaccination"] = payrollItems.MedicalVaccination,
                ["MedicalDisease"] = payrollItems.MedicalDisease,
                ["SSPN"] = payrollItems.SSPN,
                ["PRS"] = payrollItems.PRS,
                ["KindergartenAndChildCareFees"] = payrollItems.KindergartenAndChildCareFees,
                ["BreastFeedingEquipment"] = payrollItems.BreastFeedingEquipment,
                ["AlimonyToFormerWife"] = payrollItems.AlimonyToFormerWife,
                ["EducationAndMedicalInsurance"] = payrollItems.EducationAndMedicalInsurance,
                ["FatherRelief"] = payrollItems.FatherRelief,
                ["MotherRelief"] = payrollItems.MotherRelief,
                ["MedicalExpenseForParents"] = payrollItems.MedicalExpenseForParents,
                ["DomesticTourismExpenditure"] = payrollItems.DomesticTourismExpenditure,
            };

            NormalRemuneration = new Dictionary<string, double>
            {
                ["CurrentMonthRemuneration"] = payrollItems.CurrentMonthRemuneration
            };

            AdditionalRemuneration = new Dictionary<string, double>
            {
                ["Bonus"] = payrollItems.Bonus,
                ["Arrears"] = payrollItems.Arrears,
                ["Commission"] = payrollItems.Commission,
                ["OthersNotSubjectToEPF"] = payrollItems.OthersNotSubjectToEPF,
                ["OthersNotSubjectToSOCSOAndEIS"] = payrollItems.OthersNotSubjectToSOCSOAndEIS,
                ["OthersSubjectToEPFAndSOCSOAndEIS"] = payrollItems.OthersSubjectToEPFAndSOCSOAndEIS
            };

            Rebates = new Dictionary<string, double>
            {
                ["ZakatByEmployee"] = payrollItems.ZakatByEmployee,
                ["ZakatViaPayroll"] = payrollItems.ZakatViaPayroll,
                ["DepartureLevy"] = payrollItems.DepartureLevy
            };

            BenefitInKind = new Dictionary<string, double>
            {
                ["BIK"] = payrollItems.BIK
            };

            ValueOfLivingAccomodation = new Dictionary<string, double>
            {
                ["VOLA"] = payrollItems.VOLA
            };

            PreviousDeductions = new Dictionary<string, double>
            {
                ["PreviousLifeStyleRelief"] = payrollItems.PreviousLifeStyleRelief,
                ["PreviousSportsRelief"] = payrollItems.PreviousSportsRelief,
                ["PreviousLifeInsurance"] = payrollItems.PreviousLifeInsurance,
                ["PreviousSupportingEquipment"] = payrollItems.PreviousSupportingEquipment,
                ["PreviousEducationFeesForSelf"] = payrollItems.PreviousEducationFeesForSelf,
                ["PreviousMedicalExamination"] = payrollItems.PreviousMedicalExamination,
                ["PreviousMedicalVaccination"] = payrollItems.PreviousMedicalVaccination,
                ["PreviousMedicalDisease"] = payrollItems.PreviousMedicalDisease,
                ["PreviousSSPN"] = payrollItems.PreviousSSPN,
                ["PreviousPRS"] = payrollItems.PreviousPRS,
                ["PreviousKindergartenAndChildCareFees"] = payrollItems.PreviousKindergartenAndChildCareFees,
                ["PreviousBreastFeedingEquipment"] = payrollItems.PreviousBreastFeedingEquipment,
                ["PreviousAlimonyToFormerWife"] = payrollItems.PreviousAlimonyToFormerWife,
                ["PreviousEducationAndMedicalInsurance"] = payrollItems.PreviousEducationAndMedicalInsurance,
                ["PreviousFatherRelief"] = payrollItems.PreviousFatherRelief,
                ["PreviousMotherRelief"] = payrollItems.PreviousMotherRelief,
                ["PreviousMedicalExpenseForParents"] = payrollItems.PreviousMedicalExpenseForParents,
                ["PreviousDomesticTourismExpenditure"] = payrollItems.PreviousDomesticTourismExpenditure,
            };

            PreviousRemuneration = new Dictionary<string, double>
            {
                ["PreviousMonthsRemuneration"] = payrollItems.PreviousMonthsRemuneration
            };

            PreviousRebates = new Dictionary<string, double>
            {
                ["PreviousZakatByEmployee"] = payrollItems.PreviousZakatByEmployee,
                ["PreviousZakatViaPayroll"] = payrollItems.PreviousZakatViaPayroll,
                ["PreviousDepartureLevy"] = payrollItems.PreviousDepartureLevy
            };

            PreviousBenefitInKind = new Dictionary<string, double>
            {
                ["PreviousBIK"] = payrollItems.PreviousBIK
            };

            PreviousValueOfLivingAccomodation = new Dictionary<string, double>
            {
                ["PreviousVOLA"] = payrollItems.PreviousVOLA
            };
        }

        public Dictionary<string, double> Deductions { get; set; }
        public Dictionary<string, double> NormalRemuneration { get; set; }
        public Dictionary<string, double> AdditionalRemuneration { get; set; }
        public Dictionary<string, double> Rebates { get; set; }
        public Dictionary<string, double> BenefitInKind { get; set; }
        public Dictionary<string, double> ValueOfLivingAccomodation { get; set; }

        public Dictionary<string, double> PreviousDeductions { get; set; }
        public Dictionary<string, double> PreviousRemuneration { get; set; }
        public Dictionary<string, double> PreviousRebates { get; set; }
        public Dictionary<string, double> PreviousBenefitInKind { get; set; }
        public Dictionary<string, double> PreviousValueOfLivingAccomodation { get; set; }
    }
}