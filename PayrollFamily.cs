using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Text;
using static Android.Widget.TextView;
using PayrollParrots.UsedManyTimes;
using PayrollParrots.Model;
using Newtonsoft.Json;

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
            EditText birthDay_ = FindViewById<EditText>(Resource.Id.employeeAge);
            int _employeeAge = 0;
            birthDay_.AfterTextChanged += (sender, e) =>
            {
                int.TryParse(birthDay_.Text, out _employeeAge);
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
                MonthSelctedNotTodaysMonth(sender, e);
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

                    soundPlayer.PlaySound_ButtonClick(this);

                    Intent intent = new Intent(this, typeof(PayrollCurrentMonth));
                    intent.PutExtra("FamilyDeductionCategory", JsonConvert.SerializeObject(payrollFamilyDeductions));
                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("monthsRemaining", monthsRemaining);
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
                editText.SetText("0", BufferType.Editable);
                editText.Text.Remove(0);
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
            if (((Spinner)sender).SelectedItem.ToString() == Months.January.ToString())
            {
                monthsRemaining = (int)Months.January;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.Febuary.ToString())
            {
                monthsRemaining = (int)Months.Febuary;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.March.ToString())
            {
                monthsRemaining = (int)Months.March;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.April.ToString())
            {
                monthsRemaining = (int)Months.April;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.May.ToString())
            {
                monthsRemaining = (int)Months.May;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.June.ToString())
            {
                monthsRemaining = (int)Months.June;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.July.ToString())
            {
                monthsRemaining = (int)Months.July;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.August.ToString())
            {
                monthsRemaining = (int)Months.August;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.September.ToString())
            {
                monthsRemaining = (int)Months.September;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.October.ToString())
            {
                monthsRemaining = (int)Months.October;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.November.ToString())
            {
                monthsRemaining = (int)Months.November;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.December.ToString())
            {
                monthsRemaining = (int)Months.December;
            }
            return monthsRemaining;
        }

        //alert pop-up for if another month selected from spinner
        private void MonthSelctedNotTodaysMonth(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;

            if (((Spinner)sender).SelectedItem.ToString() == Months.January.ToString() && monthToday != 1)
            {
                MonthChanged_AlertPopUp(sender, e, Months.January.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.Febuary.ToString() && monthToday != 2)
            {
                MonthChanged_AlertPopUp(sender, e, Months.Febuary.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.March.ToString() && monthToday != 3)
            {
                MonthChanged_AlertPopUp(sender, e, Months.March.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.April.ToString() && monthToday != 4)
            {
                MonthChanged_AlertPopUp(sender, e, Months.April.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.May.ToString() && monthToday != 5)
            {
                MonthChanged_AlertPopUp(sender, e, Months.May.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.June.ToString() && monthToday != 6)
            {
                MonthChanged_AlertPopUp(sender, e, Months.June.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.July.ToString() && monthToday != 7)
            {
                MonthChanged_AlertPopUp(sender, e, Months.July.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.August.ToString() && monthToday != 8)
            {
                MonthChanged_AlertPopUp(sender, e, Months.August.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.September.ToString() && monthToday != 9)
            {
                MonthChanged_AlertPopUp(sender, e, Months.September.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.October.ToString() && monthToday != 10)
            {
                MonthChanged_AlertPopUp(sender, e, Months.October.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.November.ToString() && monthToday != 11)
            {
                MonthChanged_AlertPopUp(sender, e, Months.November.ToString(), monthToday);
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.December.ToString() && monthToday != 12)
            {
                MonthChanged_AlertPopUp(sender, e, Months.December.ToString(), monthToday);
            }
        }

        private void MonthChanged_AlertPopUp(object sender, AdapterView.ItemSelectedEventArgs e, string month, int monthToday)
        {
            static string AlertTitle(string month)
            {
                string ItIsNot = "It is not " + month + "!";
                return ItIsNot;
            }

            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();

            const string AlertMessage = "Are you sure you want to change the month?";
            string ItIsNot = AlertTitle(month);

            alert.SetTitle(ItIsNot);
            alert.SetMessage(AlertMessage);
            alert.SetIcon(Resource.Drawable.Warning_Sign);
            alert.SetButton("Yes", (c, ev) =>
            {
                monthsRemaining = SpinnerMonth_ItemSelected(sender, e);
            });
            alert.SetButton2("No", (c, ev) =>
            {
                ((Spinner)sender).SetSelection(monthToday - 1);
                monthsRemaining = 12 - monthToday;
            });

            soundPlayer.PlaySound_AlertWarning(this);

            alert.Show();
        }
    }
}
