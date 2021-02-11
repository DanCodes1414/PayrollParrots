using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using PayrollParrots.Model;
using Newtonsoft.Json;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollReview")]
    public class PayrollReview : Activity
    {
        Payroll payroll;
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        public const string NameText = "Name:";
        public const string AgeText = "Age:";
        public const string PCBText = "PCB:";
        public const string EPFText = "EPF:";
        public const string SOCSOText = "SOCSO:";
        public const string EISText = "EIS:";
        public const string GrossSalaryText = "Gross Salary:";
        public const string NetSalaryText = "Net Salary:";
        public const string EmployerEPFText = "Employer EPF:";
        public const string EmployerSOCSOText = "Employer SOCSO:";
        public const string EmployerEISText = "Employer EIS:";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_review);
            payroll = JsonConvert.DeserializeObject<Payroll>(Intent.GetStringExtra("payroll"));
            EditText name = FindViewById<EditText>(Resource.Id.name2);
            EditText age = FindViewById<EditText>(Resource.Id.age2);
            EditText finalPCB = FindViewById<EditText>(Resource.Id.finalPCB2);
            EditText finalEPF = FindViewById<EditText>(Resource.Id.finalEPF2);
            EditText finalSOCSO = FindViewById<EditText>(Resource.Id.finalSOCSO2);
            EditText finalEIS = FindViewById<EditText>(Resource.Id.finalEIS2);
            EditText grossSalary = FindViewById<EditText>(Resource.Id.grossSalary2);
            EditText netSalary = FindViewById<EditText>(Resource.Id.netSalary2);
            EditText employerEPF = FindViewById<EditText>(Resource.Id.employerEPF2);
            EditText employerSOCSO = FindViewById<EditText>(Resource.Id.employerSOCSO2);
            EditText employerEIS = FindViewById<EditText>(Resource.Id.employerEIS2);

            name.Text = $"{NameText} {payroll.Name}";
            name.SetTextColor(Color.Red);
            age.Text = $"{AgeText} {payroll.Age}";
            age.SetTextColor(Color.Orange);
            finalPCB.Text = $"{PCBText} {payroll.PCB:N2}";
            finalPCB.SetTextColor(Color.Gold);
            finalEPF.Text = $"{EPFText} {payroll.EPFMain:N2}";
            finalEPF.SetTextColor(Color.Green);
            finalSOCSO.Text = $"{SOCSOText} {payroll.SOCSO:N2}";
            finalSOCSO.SetTextColor(Color.Blue);
            finalEIS.Text = $"{EISText} {payroll.EIS:N2}";
            finalEIS.SetTextColor(Color.Indigo);
            grossSalary.Text = $"{GrossSalaryText} {payroll.GrossSalary:N2}";
            grossSalary.SetTextColor(Color.Violet);
            netSalary.Text = $"{NetSalaryText} {payroll.NetSalary:N2}";
            netSalary.SetTextColor(Color.Goldenrod);
            employerEPF.Text = $"{EmployerEPFText} {payroll.EmployerEPF:N2}";
            employerSOCSO.Text = $"{EmployerSOCSOText} {payroll.EmployerSOCSO:N2}";
            employerEIS.Text = $"{EmployerEISText} {payroll.EmployerEIS:N2}";

            Button _reviewBack = FindViewById<Button>(Resource.Id.reviewBack);

            _reviewBack.Click += (sender, e) => {
                soundPlayer.PlaySound_ButtonClick(this);
                var payrollReview = new Intent(this, typeof(MainActivity));
                StartActivity(payrollReview);
            };
        }
    }
}