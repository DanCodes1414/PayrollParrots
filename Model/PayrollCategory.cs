using System.Collections.Generic;

namespace PayrollParrots.Model
{
    public class PayrollCategory
    {
        public PayrollCategory()
        {
            Deductions = new Dictionary<string, double>();

            NormalRemuneration = new Dictionary<string, double>();

            AdditionalRemuneration = new Dictionary<string, double>();

            Rebates = new Dictionary<string, double>();

            BenefitInKind = new Dictionary<string, double>();

            ValueOfLivingAccomodation = new Dictionary<string, double>();

            PreviousDeductions = new Dictionary<string, double>();

            PreviousRemuneration = new Dictionary<string, double>();

            PreviousRebates = new Dictionary<string, double>();

            PreviousBenefitInKind = new Dictionary<string, double>();

            PreviousValueOfLivingAccomodation = new Dictionary<string, double>();
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
