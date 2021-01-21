using System.Collections.Generic;

namespace PayrollParrots.Model
{
    public class IsApplicableToMTD
    {
        public IsApplicableToMTD(Dictionary<string, double> AllItemsDictionary)
        {
            CurrentMonthRemuneration = AllItemsDictionary["CurrentMonthRemuneration"];
            BIK = AllItemsDictionary["BIK"];
            VOLA = AllItemsDictionary["VOLA"];
            Bonus = AllItemsDictionary["Bonus"];
            Arrears = AllItemsDictionary["Arrears"];
            Commission = AllItemsDictionary["Commission"];
            OthersNotSubjectToEPF = AllItemsDictionary["OthersNotSubjectToEPF"];
            OthersNotSubjectToSOCSOAndEIS = AllItemsDictionary["OthersNotSubjectToSOCSOAndEIS"];
            OthersSubjectToEPFAndSOCSOAndEIS = AllItemsDictionary["OthersSubjectToEPFAndSOCSOAndEIS"];
            LifeStyleRelief = AllItemsDictionary["LifeStyleRelief"];
            SportsRelief = AllItemsDictionary["SportsRelief"];
            LifeInsurance = AllItemsDictionary["LifeInsurance"];
            SupportingEquipment = AllItemsDictionary["SupportingEquipment"];
            EducationFeesForSelf = AllItemsDictionary["EducationFeesForSelf"];
            MedicalExamination = AllItemsDictionary["MedicalExamination"];
            MedicalVaccination = AllItemsDictionary["MedicalVaccination"];
            MedicalDisease = AllItemsDictionary["MedicalDisease"];
            SSPN = AllItemsDictionary["SSPN"];
            PRS = AllItemsDictionary["PRS"];
            KindergartenAndChildCareFees = AllItemsDictionary["KindergartenAndChildCareFees"];
            BreastFeedingEquipment = AllItemsDictionary["BreastFeedingEquipment"];
            AlimonyToFormerWife = AllItemsDictionary["AlimonyToFormerWife"];
            EducationAndMedicalInsurance = AllItemsDictionary["EducationAndMedicalInsurance"];
            FatherRelief = AllItemsDictionary["FatherRelief"];
            MotherRelief = AllItemsDictionary["MotherRelief"];
            MedicalExpenseForParents = AllItemsDictionary["MedicalExpenseForParents"];
            DomesticTourismExpenditure = AllItemsDictionary["DomesticTourismExpenditure"];
            ZakatByEmployee = AllItemsDictionary["ZakatByEmployee"];
            ZakatViaPayroll = AllItemsDictionary["ZakatViaPayroll"];
            DepartureLevy = AllItemsDictionary["DepartureLevy"];
            PreviousMonthsRemuneration = AllItemsDictionary["PreviousMonthsRemuneration"];
            PreviousBIK = AllItemsDictionary["PreviousBIK"];
            PreviousVOLA = AllItemsDictionary["PreviousVOLA"];
            PreviousLifeStyleRelief = AllItemsDictionary["PreviousLifeStyleRelief"];
            PreviousSportsRelief = AllItemsDictionary["PreviousSportsRelief"];
            PreviousLifeInsurance = AllItemsDictionary["PreviousLifeInsurance"];
            PreviousSupportingEquipment = AllItemsDictionary["PreviousSupportingEquipment"];
            PreviousEducationFeesForSelf = AllItemsDictionary["PreviousEducationFeesForSelf"];
            PreviousMedicalExamination = AllItemsDictionary["PreviousMedicalExamination"];
            PreviousMedicalVaccination = AllItemsDictionary["PreviousMedicalVaccination"];
            PreviousMedicalDisease = AllItemsDictionary["PreviousMedicalDisease"];
            PreviousSSPN = AllItemsDictionary["PreviousSSPN"];
            PreviousPRS = AllItemsDictionary["PreviousPRS"];
            PreviousKindergartenAndChildCareFees = AllItemsDictionary["PreviousKindergartenAndChildCareFees"];
            PreviousBreastFeedingEquipment = AllItemsDictionary["PreviousBreastFeedingEquipment"];
            PreviousAlimonyToFormerWife = AllItemsDictionary["PreviousAlimonyToFormerWife"];
            PreviousEducationAndMedicalInsurance = AllItemsDictionary["PreviousEducationAndMedicalInsurance"];
            PreviousFatherRelief = AllItemsDictionary["PreviousFatherRelief"];
            PreviousMotherRelief = AllItemsDictionary["PreviousMotherRelief"];
            PreviousMedicalExpenseForParents = AllItemsDictionary["PreviousMedicalExpenseForParents"];
            PreviousDomesticTourismExpenditure = AllItemsDictionary["PreviousDomesticTourismExpenditure"];
            PreviousZakatByEmployee = AllItemsDictionary["PreviousZakatByEmployee"];
            PreviousZakatViaPayroll = AllItemsDictionary["PreviousZakatViaPayroll"];
            PreviousDepartureLevy = AllItemsDictionary["PreviousDepartureLevy"];

            TotalDeductions = LifeStyleRelief + SportsRelief + LifeInsurance + SupportingEquipment + EducationFeesForSelf + MedicalExamination + MedicalVaccination + MedicalDisease + SSPN + PRS + KindergartenAndChildCareFees + BreastFeedingEquipment + AlimonyToFormerWife + EducationAndMedicalInsurance + FatherRelief + MotherRelief + MedicalExpenseForParents + DomesticTourismExpenditure;
            PreviousTotalDeductions = PreviousLifeStyleRelief + PreviousSportsRelief + PreviousLifeInsurance + PreviousSupportingEquipment + PreviousEducationFeesForSelf + PreviousMedicalExamination + PreviousMedicalVaccination + PreviousMedicalDisease + PreviousSSPN + PreviousPRS + PreviousKindergartenAndChildCareFees + PreviousBreastFeedingEquipment + PreviousAlimonyToFormerWife + PreviousEducationAndMedicalInsurance + PreviousFatherRelief + PreviousMotherRelief + PreviousMedicalExpenseForParents + PreviousDomesticTourismExpenditure;
        }

        public double CurrentMonthRemuneration;
        public double BIK;
        public double VOLA;
        public double Bonus;
        public double Arrears;
        public double Commission;
        public double OthersNotSubjectToEPF;
        public double OthersNotSubjectToSOCSOAndEIS;
        public double OthersSubjectToEPFAndSOCSOAndEIS;
        public double LifeStyleRelief;
        public double SportsRelief;
        public double LifeInsurance;
        public double SupportingEquipment;
        public double EducationFeesForSelf;
        public double MedicalExamination;
        public double MedicalVaccination;
        public double MedicalDisease;
        public double SSPN;
        public double PRS;
        public double KindergartenAndChildCareFees;
        public double BreastFeedingEquipment;
        public double AlimonyToFormerWife;
        public double EducationAndMedicalInsurance;
        public double FatherRelief;
        public double MotherRelief;
        public double MedicalExpenseForParents;
        public double DomesticTourismExpenditure;
        public double ZakatByEmployee;
        public double ZakatViaPayroll;
        public double DepartureLevy;
        public double PreviousMonthsRemuneration;
        public double PreviousBIK;
        public double PreviousVOLA;
        public double PreviousLifeStyleRelief;
        public double PreviousSportsRelief;
        public double PreviousLifeInsurance;
        public double PreviousSupportingEquipment;
        public double PreviousEducationFeesForSelf;
        public double PreviousMedicalExamination;
        public double PreviousMedicalVaccination;
        public double PreviousMedicalDisease;
        public double PreviousSSPN;
        public double PreviousPRS;
        public double PreviousKindergartenAndChildCareFees;
        public double PreviousBreastFeedingEquipment;
        public double PreviousAlimonyToFormerWife;
        public double PreviousEducationAndMedicalInsurance;
        public double PreviousFatherRelief;
        public double PreviousMotherRelief;
        public double PreviousMedicalExpenseForParents;
        public double PreviousDomesticTourismExpenditure;
        public double PreviousZakatByEmployee;
        public double PreviousZakatViaPayroll;
        public double PreviousDepartureLevy;
        public double TotalDeductions;
        public double PreviousTotalDeductions;
    }


    public class IsApplicableToEPF
    {
        public IsApplicableToEPF(PayrollItems payrollItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            CurrentMonthRemuneration = payrollItems.CurrentMonthRemuneration;
            Bonus = AdditionalRemunerationItems["Bonus"];
            Arrears = AdditionalRemunerationItems["Arrears"];
            Commission = AdditionalRemunerationItems["Commission"];
            OthersNotSubjectToSOCSOAndEIS = AdditionalRemunerationItems["OthersNotSubjectToSOCSOAndEIS"];
            OthersSubjectToEPFAndSOCSOAndEIS = AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"];
            TotalAdditionalRemuneration = Bonus + Arrears + Commission + OthersNotSubjectToSOCSOAndEIS + OthersSubjectToEPFAndSOCSOAndEIS;
            AdditionalRemunerationWithoutBonus = Arrears + Commission + OthersNotSubjectToSOCSOAndEIS + OthersSubjectToEPFAndSOCSOAndEIS;
            WageEPF = CurrentMonthRemuneration + Arrears + Commission + Bonus + OthersNotSubjectToSOCSOAndEIS + OthersSubjectToEPFAndSOCSOAndEIS;
        }
        public double CurrentMonthRemuneration;
        public double Bonus;
        public double Arrears;
        public double Commission;
        public double OthersNotSubjectToSOCSOAndEIS;
        public double OthersSubjectToEPFAndSOCSOAndEIS;
        public double TotalAdditionalRemuneration;
        public double AdditionalRemunerationWithoutBonus;
        public double WageEPF;
    }

    public class IsApplicableToSOCSOAndEIS
    {
        public IsApplicableToSOCSOAndEIS(Dictionary<string, double> NormalRemunerationItems, Dictionary<string, double> AdditionalRemunerationItems)
        {
            CurrentMonthRemuneration = NormalRemunerationItems["CurrentMonthRemuneration"];
            Commission = AdditionalRemunerationItems["Commission"];
            OthersNotSubjectToEPF = AdditionalRemunerationItems["OthersNotSubjectToEPF"];
            OthersSubjectToEPFAndSOCSOAndEIS = AdditionalRemunerationItems["OthersSubjectToEPFAndSOCSOAndEIS"];
            WageSOCSOAndEIS = CurrentMonthRemuneration + Arrears + Commission + OthersNotSubjectToEPF + OthersSubjectToEPFAndSOCSOAndEIS;
        }
        public double CurrentMonthRemuneration;
        public double Arrears;
        public double Commission;
        public double OthersNotSubjectToEPF;
        public double OthersSubjectToEPFAndSOCSOAndEIS;
        public double WageSOCSOAndEIS;
    }
}
