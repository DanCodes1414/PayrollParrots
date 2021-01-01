﻿using System;
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
        public const string NameText = "Name: ";
        public const string AgeText = "Age: ";
        public const string PCBText = "PCB: ";
        public const string EPFText = "EPF: ";
        public const string SOCSOText = "SOCSO: ";
        public const string EISText = "EIS: ";
        public const string GrossSalaryText = "Gross Salary: ";
        public const string NetSalaryText = "Net Salary: ";
        public const string EmployerEPFText = "Employer EPF: ";
        public const string EmployerSOCSOText = "Employer SOCSO: ";
        public const string EmployerEISText = "Employer EIS: ";
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

            name2.Text = NameText + payroll.Name;
            name2.SetTextColor(Color.Red);
            age2.Text = AgeText + payroll.Age;
            age2.SetTextColor(Color.Orange);
            finalPCB2.Text = PCBText + payroll.PCB;
            finalPCB2.SetTextColor(Color.Gold);
            finalEPF2.Text = EPFText + payroll.EPFMain;
            finalEPF2.SetTextColor(Color.Green);
            finalSOCSO2.Text = SOCSOText + payroll.SOCSO;
            finalSOCSO2.SetTextColor(Color.Blue);
            finalEIS2.Text = EISText + payroll.EIS;
            finalEIS2.SetTextColor(Color.Indigo);
            grossSalary2.Text = GrossSalaryText + payroll.GrossSalary;
            grossSalary2.SetTextColor(Color.Violet);
            netSalary2.Text = NetSalaryText + payroll.NetSalary;
            netSalary2.SetTextColor(Color.Goldenrod);
            employerEPF2.Text = EmployerEPFText + payroll.EmployerEPF;
            employerSOCSO2.Text = EmployerSOCSOText + payroll.EmployerSOCSO;
            employerEIS2.Text = EmployerEISText + payroll.EmployerEIS;

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
