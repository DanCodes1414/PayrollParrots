using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Text;
using PayrollParrots.UsedManyTimes;
using PayrollParrots.Model;
using Newtonsoft.Json;
using System.Globalization;

namespace PayrollParrots
{
    [Activity(Label = "PayrollFamily")]
    public class PayrollFamily : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly PayrollFamilyDeductions payrollFamilyDeductions = new PayrollFamilyDeductions();
        private int monthsRemaining;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_family);

            //name
            EditText employeeName_ = FindViewById<EditText>(Resource.Id.employeeName);
            string _employeeName = "";
            employeeName_.AfterTextChanged += (sender, e) =>
            {
                _employeeName = employeeName_.Text;
            };

            //age
            EditText employeeAge_ = FindViewById<EditText>(Resource.Id.employeeAge);
            int _employeeAge = 0;
            employeeAge_.AfterTextChanged += (sender, e) =>
            {
                int.TryParse(employeeAge_.Text, out _employeeAge);
            };

            //payroll month
            Spinner spinnerMonth = FindViewById<Spinner>(Resource.Id.monthSpinner);
            var adapterMonth = ArrayAdapter.CreateFromResource(this, Resource.Array.month_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterMonth.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerMonth.Adapter = adapterMonth;

            //month today
            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;
            monthsRemaining = 12 - monthToday;

            spinnerMonth.SetSelection(monthToday - 1);
            spinnerMonth.ItemSelected += (sender, e) =>
            {
                MonthSelctedNotCurrentMonth(sender, e);
                monthsRemaining = SpinnerMonth_ItemSelected(sender, e);
            };

            //marital status
            Spinner spinnerMaritalStatus = FindViewById<Spinner>(Resource.Id.statusSpinner);
            var adapterMaritalStatus = ArrayAdapter.CreateFromResource(this, Resource.Array.status_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterMaritalStatus.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerMaritalStatus.Adapter = adapterMaritalStatus;
            spinnerMaritalStatus.ItemSelected += SpinnerMaritalStatus_ItemSelected;

            //disabled
            RadioButton disabledTrue = FindViewById<RadioButton>(Resource.Id.radioDisabledTrue);
            disabledTrue.CheckedChange += SpouseAndSelfDisabled_RadioCheckedChanged;
            RadioButton disabledFalse = FindViewById<RadioButton>(Resource.Id.radioDisabledFalse);
            disabledFalse.CheckedChange += SpouseAndSelfDisabled_RadioCheckedChanged;

            //spouse disabled
            EditText errorView = FindViewById<EditText>(Resource.Id.erroreditview);
            RadioButton spouseDisabledTrue = FindViewById<RadioButton>(Resource.Id.radioSpouseDisabledTrue);
            spouseDisabledTrue.CheckedChange += SpouseAndSelfDisabled_RadioCheckedChanged;
            RadioButton spouseDisabledFalse = FindViewById<RadioButton>(Resource.Id.radioSpouseDisabledFalse);
            spouseDisabledFalse.CheckedChange += SpouseAndSelfDisabled_RadioCheckedChanged;
            spouseDisabledTrue.Click += (sender, e) =>
            {
                disabledSpouseCanCheck();
            };
            spouseDisabledFalse.Click += (sender, e) =>
            {
                disabledSpouseCanCheck();
            };

            //kidsunder18 or in education 2000
            EditText kidsU18 = FindViewById<EditText>(Resource.Id.u18kids);
            kidsU18.TextChanged += NumberOfKids_TextChanged;

            //over 18 HE 8000
            EditText over18inHE = FindViewById<EditText>(Resource.Id.over18inHE);
            over18inHE.TextChanged += NumberOfKids_TextChanged;

            //disabled 6000
            EditText disabledChildren = FindViewById<EditText>(Resource.Id.disabledChildren);
            disabledChildren.TextChanged += NumberOfKids_TextChanged;

            //disabled HE 14000
            EditText disabledChildreninHE = FindViewById<EditText>(Resource.Id.disabledChildreninHE);
            disabledChildreninHE.TextChanged += NumberOfKids_TextChanged;

            //kidsunder18 or in education 1000
            EditText kidsU18split = FindViewById<EditText>(Resource.Id.u18kidssplit);
            kidsU18split.TextChanged += NumberOfKids_TextChanged;

            //over 18 HE 4000
            EditText over18inHEsplit = FindViewById<EditText>(Resource.Id.over18inHEsplit);
            over18inHEsplit.TextChanged += NumberOfKids_TextChanged;

            //disabled 3000
            EditText disabledChildrensplit = FindViewById<EditText>(Resource.Id.disabledChildrensplit);
            disabledChildrensplit.TextChanged += NumberOfKids_TextChanged;

            //disabled HE 7000
            EditText disabledChildreninHEsplit = FindViewById<EditText>(Resource.Id.disabledChildreninHEsplit);
            disabledChildreninHEsplit.TextChanged += NumberOfKids_TextChanged;

            Button _firstContinue = FindViewById<Button>(Resource.Id.continuePayroll1);

            _firstContinue.Click += (sender, e) =>
            {
                if (disabledSpouseCanCheck() == false)
                {
                    Toast toast = Toast.MakeText(this, "Check the error above", ToastLength.Short);
                    toast.Show();
                }
                else if (_employeeName == "" | _employeeAge <= 0)
                {
                    Toast toast = Toast.MakeText(this, "Please input your name and age", ToastLength.Long);
                    toast.Show();
                }
                else
                {
                    payrollFamilyDeductions.TotalFamilyDeductions = (payrollFamilyDeductions.KidsUnder18 * 2000) + (payrollFamilyDeductions.Over18InHigherEducation * 8000) + (payrollFamilyDeductions.DisabledKids * 6000) + (payrollFamilyDeductions.DisabledKidsinHigherEducation * 14000) + (payrollFamilyDeductions.KidsUnder18Split * 1000) + (payrollFamilyDeductions.Over18InHigherEducationSplit * 4000) + (payrollFamilyDeductions.DisabledKidsSplit * 3000) + (payrollFamilyDeductions.DisabledKidsinHigherEducationSplit * 7000) + payrollFamilyDeductions.DisabledIndividual + payrollFamilyDeductions.DisabledSpouse + payrollFamilyDeductions.SpouseNotGettingIncome;
                    string email = Intent.GetStringExtra("email");

                    soundPlayer.PlaySound_ButtonClick(this);

                    Intent intent = new Intent(this, typeof(PayrollCurrentMonth));
                    intent.PutExtra("FamilyDeductionCategory", JsonConvert.SerializeObject(payrollFamilyDeductions));
                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("monthsRemaining", monthsRemaining);
                    intent.PutExtra("email", email);
                    StartActivity(intent);
                }
            };

            //check if user can check disbled spouse as yes
            bool disabledSpouseCanCheck()
            {
                if ((spinnerMaritalStatus.SelectedItem.ToString() == "Single" | spinnerMaritalStatus.SelectedItem.ToString() == "Divorce/Widower/Widow") && (spouseDisabledTrue.Checked == true))
                {
                    errorView.Error = "You don't have a spouse!";
                    return false;
                }
                else if (spinnerMaritalStatus.SelectedItem.ToString() == "Married and spouse working" && (spouseDisabledTrue.Checked == true))
                {
                    errorView.Error = "Deduction for disabled spouse only applicable if your spouse is not working";
                    return false;
                }
                else
                {
                    errorView.Error = null;
                    return true;
                }
            }
        }

        private void SpinnerMaritalStatus_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if (((Spinner)sender).SelectedItem.ToString() == "Married and spouse not working")
            {
                payrollFamilyDeductions.SpouseNotGettingIncome = 4000.00;
            }
            else
            {
                payrollFamilyDeductions.SpouseNotGettingIncome = 0.00;
            }
        }

        private void SpouseAndSelfDisabled_RadioCheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (e.IsChecked)
            {
                switch (radioButton.Id)
                {
                    case Resource.Id.radioDisabledTrue:
                        payrollFamilyDeductions.DisabledIndividual = 6000.00;
                        break;
                    case Resource.Id.radioSpouseDisabledTrue:
                        payrollFamilyDeductions.DisabledSpouse = 5000.00;
                        break;
                    case Resource.Id.radioDisabledFalse:
                        payrollFamilyDeductions.DisabledIndividual = 0.00;
                        break;
                    case Resource.Id.radioSpouseDisabledFalse:
                        payrollFamilyDeductions.DisabledSpouse = 0.00;
                        break;
                    default:
                        break;
                }
            }
        }

        public void NumberOfKids_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditText editText = sender as EditText;
            if (editText.Length() == 0)
            {
                editText.Text.Equals("");
            }
            else
            {
                switch (editText.Id)
                {
                    case Resource.Id.u18kids:
                        payrollFamilyDeductions.KidsUnder18 = int.Parse(editText.Text);
                        break;
                    case Resource.Id.over18inHE:
                        payrollFamilyDeductions.Over18InHigherEducation = int.Parse(editText.Text);
                        break;
                    case Resource.Id.disabledChildren:
                        payrollFamilyDeductions.DisabledKids = int.Parse(editText.Text);
                        break;
                    case Resource.Id.disabledChildreninHE:
                        payrollFamilyDeductions.DisabledKidsinHigherEducation = int.Parse(editText.Text);
                        break;
                    case Resource.Id.u18kidssplit:
                        payrollFamilyDeductions.KidsUnder18Split = int.Parse(editText.Text);
                        break;
                    case Resource.Id.over18inHEsplit:
                        payrollFamilyDeductions.Over18InHigherEducationSplit = int.Parse(editText.Text);
                        break;
                    case Resource.Id.disabledChildrensplit:
                        payrollFamilyDeductions.DisabledKidsSplit = int.Parse(editText.Text);
                        break;
                    case Resource.Id.disabledChildreninHEsplit:
                        payrollFamilyDeductions.DisabledKidsinHigherEducationSplit = int.Parse(editText.Text);
                        break;
                    default:
                        break;
                }
            }
        }

        private int SpinnerMonth_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            monthsRemaining = 11 - (int)((Spinner)sender).SelectedItemId;
            return monthsRemaining;
        }

        //alert pop-up for if another month selected from spinner
        private void MonthSelctedNotCurrentMonth(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;

            MonthChanged_AlertPopUp(sender, ((Spinner)sender).SelectedItem.ToString(), monthToday);
        }

        private void MonthChanged_AlertPopUp(object sender, string month, int monthToday)
        {
            static string MonthAlertTitle(string month)
            {
                string ItIsNot = "It is not " + month + "!";
                return ItIsNot;
            }

            int MonthSelectedInNumberFormat = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;

            const string AlertMessage = "Are you sure you want to change the month?";
            string ItIsNot = MonthAlertTitle(month);

            switch (MonthSelectedInNumberFormat == monthToday)
            {
                case false:
                    AlertDialog.Builder dialogMonthChanged = new AlertDialog.Builder(this)
                        .SetTitle(ItIsNot)
                        .SetMessage(AlertMessage)
                        .SetIcon(Resource.Drawable.Warning_Sign)
                        .SetPositiveButton("Yes", (c, ev) => { })
                        .SetNegativeButton("No", (c, ev) =>
                        {
                            ((Spinner)sender).SetSelection(monthToday - 1);
                        });

                    soundPlayer.PlaySound_AlertWarning(this);

                    AlertDialog alertMonthChanged = dialogMonthChanged.Create();
                    alertMonthChanged.Show();
                    break;
                case true:
                    break;
            }
        }
    }
}