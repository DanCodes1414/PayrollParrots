using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using PayrollParrots.Model;
using PayrollParrots.Helper;
using NL.DionSegijn.Konfetti;
using Newtonsoft.Json;
using PayrollParrots.PayrollTax;
using PayrollParrots.UsedManyTimes;
using System.Collections.Generic;
using System.Linq;

namespace PayrollParrots
{
    [Activity(Label = "PayrollFinalCalculation")]
    public class PayrollFinalCalculation : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        MTDCalculations MTDCalculations;
        readonly PayrollItems payrollItems = new PayrollItems();
        EPFCalculations EPFCalculations;
        SOCSOAndEISCalculations SOCSOAndEISCalculations;
        public Payroll payroll;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_final_calculation);

            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
            string _employeeName = Intent.GetStringExtra("employeeName");
            int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);

            double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
            double _previousSOCSOContribution = Intent.GetDoubleExtra("previousSOCSOContribution", 0.00);
            double _previousEPFContribution = Intent.GetDoubleExtra("previousEPFContribution", 0.00);
            double _MTDPrevious = Intent.GetDoubleExtra("MTDPrevious", 0.00);
            double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
            double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);

            var FamilyDeductionItems = JsonConvert.DeserializeObject<PayrollFamilyDeductions>(Intent.GetStringExtra("FamilyDeductionItems"));
            var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
            var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
            var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));
            var AdditionalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("AdditionalRemuneration"));
            var DeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Deductions"));
            var RebateItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Rebates"));
            var PreviousRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousRemuneration"));
            var PreviousBIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousBIK"));
            var PreviousVOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousVOLA"));
            var PreviousDeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousDeductions"));
            var PreviousRebateItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousRebates"));

            var DictionaryContainingAllItems = NormalRemunerationItems.Union(BIKItems).Union(VOLAItems).Union(AdditionalRemunerationItems).Union(DeductionItems).Union(RebateItems).Union(PreviousRemunerationItems).Union(PreviousBIKItems).Union(PreviousVOLAItems).Union(PreviousDeductionItems).Union(PreviousRebateItems).ToDictionary(k => k.Key, v => v.Value);

            EditText name = FindViewById<EditText>(Resource.Id.name);
            EditText finalPCB = FindViewById<EditText>(Resource.Id.finalPCB);
            EditText finalEPF = FindViewById<EditText>(Resource.Id.finalEPF);
            EditText finalSOCSO = FindViewById<EditText>(Resource.Id.finalSOCSO);
            EditText finalEIS = FindViewById<EditText>(Resource.Id.finalEIS);
            EditText grossSalary = FindViewById<EditText>(Resource.Id.grossSalary);
            EditText netSalary = FindViewById<EditText>(Resource.Id.netSalary);
            EditText employerEPFView = FindViewById<EditText>(Resource.Id.employerEPF);
            EditText employerSOCSOView = FindViewById<EditText>(Resource.Id.employerSOCSO);
            EditText employerEISView = FindViewById<EditText>(Resource.Id.employerEIS);

            //confettti
            KonfettiView konfettiView = (KonfettiView)FindViewById(Resource.Id.viewKonfetti);
            konfettiView
            .Build()
            .AddColors(Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple)
            .SetDirection(0.0, 359.0)
            .SetSpeed(5f, 10f)
            .SetFadeOutEnabled(true)
            .SetTimeToLive(4000L)
            .StreamFor(400, 4000L);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 6), () =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    konfettiView.Visibility = ViewStates.Gone;
                });
                return false;
            });

            int n = _monthsRemaining;

            SOCSOAndEISCalculations = new SOCSOAndEISCalculations(NormalRemunerationItems, AdditionalRemunerationItems);

            //EIS Calculation
            double EIS = SOCSOAndEISCalculations.EISCalculation(_employeeAge);
            double employerEIS = EIS;

            //MTD Calculation
            MTDCalculations = new MTDCalculations(DictionaryContainingAllItems);
            double RoundedMTD = MTDCalculations.MTDCalculation(FamilyDeductionItems, _monthsRemaining, _SOCSOContribution, _previousSOCSOContribution,
                _previousEPFContribution, _MTDPrevious, _EPFContribution, _EPFAdditionalContribution);

            //EPF
            double EPF = _EPFContribution + _EPFAdditionalContribution;

            //Gross Salary
            double GrossSalary = NormalRemunerationItems["CurrentMonthRemuneration"] + AdditionalRemunerationItems.Sum(x => x.Value);

            //Net Salary
            double NetSalary = GrossSalary - _SOCSOContribution - EPF - EIS - RebateItems["ZakatViaPayroll"] - RoundedMTD;

            //employer EPF
            payrollItems.CurrentMonthRemuneration = NormalRemunerationItems["CurrentMonthRemuneration"];
            EPFCalculations = new EPFCalculations(payrollItems, AdditionalRemunerationItems);
            double employerEPF = EPFCalculations.EmployerEPFCalculation(_employeeAge);

            //Employer SOCSO
            double employerSOCSO = SOCSOAndEISCalculations.EmployerSOCSOCalculation(_employeeAge);

            //print to layout
            name.Text = $"Name: {_employeeName}";
            name.SetTextColor(Color.Red);
            finalPCB.Text = $"PCB: {RoundedMTD:N2}";
            finalPCB.SetTextColor(Color.Orange);
            finalEPF.Text = $"EPF: {EPF:N2}";
            finalEPF.SetTextColor(Color.Gold);
            finalSOCSO.Text = $"SOCSO: {_SOCSOContribution:N2}";
            finalSOCSO.SetTextColor(Color.Green);
            finalEIS.Text = $"EIS: {EIS:N2}";
            finalEIS.SetTextColor(Color.Blue);
            grossSalary.Text = $"Gross Salary: {GrossSalary:N2}";
            grossSalary.SetTextColor(Color.Indigo);
            netSalary.Text = $"Net Salary: {NetSalary:N2}";
            netSalary.SetTextColor(Color.Violet);
            employerEPFView.Text = $"Employer EPF: {employerEPF:N2}";
            employerSOCSOView.Text = $"Employer SOCSO: {employerSOCSO:N2}";
            employerEISView.Text = $"Employer EIS: {employerEIS:N2}";

            payroll = new Payroll
            {
                Name = _employeeName.ToString(),
                Age = _employeeAge.ToString(),
                PCB = RoundedMTD.ToString(),
                EPFMain = EPF.ToString(),
                SOCSO = _SOCSOContribution.ToString(),
                EIS = EIS.ToString(),
                GrossSalary = GrossSalary.ToString(),
                NetSalary = NetSalary.ToString(),
                EmployerEPF = employerEPF.ToString(),
                EmployerSOCSO = employerSOCSO.ToString(),
                EmployerEIS = employerEIS.ToString()
            };
            if (n == 11)
            {
                payroll.Month = Months.January.ToString();
            }
            else if (n == 10)
            {
                payroll.Month = Months.Febuary.ToString();
            }
            else if (n == 9)
            {
                payroll.Month = Months.March.ToString();
            }
            else if (n == 8)
            {
                payroll.Month = Months.April.ToString();
            }
            else if (n == 7)
            {
                payroll.Month = Months.May.ToString();
            }
            else if (n == 6)
            {
                payroll.Month = Months.June.ToString();
            }
            else if (n == 5)
            {
                payroll.Month = Months.July.ToString();
            }
            else if (n == 4)
            {
                payroll.Month = Months.August.ToString();
            }
            else if (n == 3)
            {
                payroll.Month = Months.September.ToString();
            }
            else if (n == 2)
            {
                payroll.Month = Months.October.ToString();
            }
            else if (n == 1)
            {
                payroll.Month = Months.November.ToString();
            }
            else if (n == 0)
            {
                payroll.Month = Months.December.ToString();
            }

            Button _saveDetails = FindViewById<Button>(Resource.Id.saveDetails);

            _saveDetails.Click += (sender, e) => {
                soundPlayer.PlaySound_ButtonClick(this);
                //save to database
                PayrollHelper.InsertPayrollData(this, payroll);
                var payrollData = new Intent(this, typeof(MainActivity));
                payrollData.PutExtra("payroll", JsonConvert.SerializeObject(payroll));
                StartActivity(payrollData);
            };
        }
    }
}
