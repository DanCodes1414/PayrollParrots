namespace PayrollParrots.Model
{
    public class PayrollFamilyDeductions
    {
        public double SpouseNotGettingIncome { get; set; }
        public double DisabledSpouse { get; set; }
        public double DisabledIndividual { get; set; }
        public double KidsUnder18 { get; set; }
        public double Over18InHigherEducation { get; set; }
        public double DisabledKids { get; set; }
        public double DisabledKidsinHigherEducation { get; set; }
        public double KidsUnder18Split { get; set; }
        public double Over18InHigherEducationSplit { get; set; }
        public double DisabledKidsSplit { get; set; }
        public double DisabledKidsinHigherEducationSplit { get; set; }
        public double TotalFamilyDeductions { get; set; }

        public PayrollFamilyDeductions()
        {
        }
    }
}
