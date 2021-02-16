namespace PayrollParrots.Model
{
    public class PayrollAccount
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PayrollAccount()
        {
        }
        public PayrollAccount(string ID, string companyname, string email, string password)   
        {
            Id = ID;
            CompanyName = companyname;
            Email = email;
            Password = password;
        }
        public PayrollAccount(string Password) 
        {
            this.Password = Password;
        }
    }
}