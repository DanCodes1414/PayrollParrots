using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using PayrollParrots.Model;
using Newtonsoft.Json;

namespace PayrollParrots
{
    [Activity(Label = "PayrollReview")]
    public class PayrollReview : Activity
    {
        Payroll payroll;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_review);
            payroll = JsonConvert.DeserializeObject<Payroll>(Intent.GetStringExtra("payroll"));
            EditText name2 = FindViewById<EditText>(Resource.Id.name2);
            EditText age2 = FindViewById<EditText>(Resource.Id.age2);
            EditText finalPCB2 = FindViewById<EditText>(Resource.Id.finalPCB2);
            EditText finalEPF2 = FindViewById<EditText>(Resource.Id.finalEPF2);
            EditText finalSOCSO2 = FindViewById<EditText>(Resource.Id.finalSOCSO2);
            EditText finalEIS2 = FindViewById<EditText>(Resource.Id.finalEIS2);
            EditText grossSalary2 = FindViewById<EditText>(Resource.Id.grossSalary2);
            EditText netSalary2 = FindViewById<EditText>(Resource.Id.netSalary2);
            EditText employerEPF2 = FindViewById<EditText>(Resource.Id.employerEPF2);
            EditText employerSOCSO2 = FindViewById<EditText>(Resource.Id.employerSOCSO2);
            EditText employerEIS2 = FindViewById<EditText>(Resource.Id.employerEIS2);

            name2.Text = "Name: " + payroll.Name;
            name2.SetTextColor(Color.Red);
            age2.Text = "Age: " + payroll.Age;
            age2.SetTextColor(Color.Orange);
            finalPCB2.Text = "PCB: " + payroll.PCB;
            finalPCB2.SetTextColor(Color.Gold);
            finalEPF2.Text = "EPF: " + payroll.EPFMain;
            finalEPF2.SetTextColor(Color.Green);
            finalSOCSO2.Text = "SOCSO: " + payroll.SOCSO;
            finalSOCSO2.SetTextColor(Color.Blue);
            finalEIS2.Text = "EIS: " + payroll.EIS;
            finalEIS2.SetTextColor(Color.Indigo);
            grossSalary2.Text = "Gross Salary: " + payroll.GrossSalary;
            grossSalary2.SetTextColor(Color.Violet);
            netSalary2.Text = "Net Salary: " + payroll.NetSalary;
            netSalary2.SetTextColor(Color.Goldenrod);
            employerEPF2.Text = "Employer EPF:" + payroll.EmployerEPF;
            employerSOCSO2.Text = "Employer SOCSO:" + payroll.EmployerSOCSO;
            employerEIS2.Text = "Employer EIS:" + payroll.EmployerEIS;

            Button _reviewBack = FindViewById<Button>(Resource.Id.reviewBack);

            _reviewBack.Click += (sender, e) => {
                PlayButton_Click(sender, e);
                var payrollReview = new Intent(this, typeof(MainActivity));
                StartActivity(payrollReview);
            };

            //button-click sound
            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }

        }
    }
}
