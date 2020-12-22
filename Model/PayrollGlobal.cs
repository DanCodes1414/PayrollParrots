namespace PayrollParrots.Model
{
    public class Payroll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Month { get; set; }
        public string PCB { get; set; }
        public string EPFMain { get; set; }
        public string SOCSO { get; set; }
        public string EIS { get; set; }
        public string GrossSalary { get; set; }
        public string NetSalary { get; set; }
        public string EmployerEIS { get; set; }
        public string EmployerSOCSO { get; set; }
        public string EmployerEPF { get; set; }
        public Payroll()
        {
        }
    }
}
