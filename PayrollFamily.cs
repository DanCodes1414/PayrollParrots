using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Text;
using static Android.Widget.TextView;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollFamily")]
    public class PayrollFamily : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        private int _kidsU18;
        private int _over18inHE;
        private int _disabledChildren;
        private int _disabledChildreninHE;
        private int _kidsU18split;
        private int _over18inHEsplit;
        private int _disabledChildrensplit;
        private int _disabledChildreninHEsplit;
        double disabledDeduction = 0.00;
        double disabledSpouseDeduction = 0.00;
        double spouseNoIncomeDeduction = 0.00;
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

            //setting spinner to display todays month
            if (monthToday == 1)
            {
                spinnerMonth.SetSelection(0);
            }
            else if (monthToday == 2)
            {
                spinnerMonth.SetSelection(1);
            }
            else if (monthToday == 3)
            {
                spinnerMonth.SetSelection(2);
            }
            else if (monthToday == 4)
            {
                spinnerMonth.SetSelection(3);
            }
            else if (monthToday == 5)
            {
                spinnerMonth.SetSelection(4);
            }
            else if (monthToday == 6)
            {
                spinnerMonth.SetSelection(5);
            }
            else if (monthToday == 7)
            {
                spinnerMonth.SetSelection(6);
            }
            else if (monthToday == 8)
            {
                spinnerMonth.SetSelection(7);
            }
            else if (monthToday == 9)
            {
                spinnerMonth.SetSelection(8);
            }
            else if (monthToday == 10)
            {
                spinnerMonth.SetSelection(9);
            }
            else if (monthToday == 11)
            {
                spinnerMonth.SetSelection(10);
            }
            else if (monthToday == 12)
            {
                spinnerMonth.SetSelection(11);
            }
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
                    double totalFamilyDeductions = (_kidsU18 * 2000) + (_over18inHE * 8000) + (_disabledChildren * 6000) + (_disabledChildreninHE * 14000) + (_kidsU18split * 1000) + (_over18inHEsplit * 4000) + (_disabledChildrensplit * 3000) + (_disabledChildreninHEsplit * 7000) + disabledDeduction + disabledSpouseDeduction + spouseNoIncomeDeduction;

                    soundPlayer.PlaySound_ButtonClick(this);

                    Intent intent = new Intent(this, typeof(PayrollCurrentMonth));
                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("totalFamilyDeductions", totalFamilyDeductions);
                    intent.PutExtra("monthsRemaining", monthsRemaining);
                    intent.PutExtra("kidsU18", _kidsU18);
                    intent.PutExtra("over18inHE", _over18inHE);
                    intent.PutExtra("disabledChildren", _disabledChildren);
                    intent.PutExtra("disabledChildreninHE", _disabledChildreninHE);
                    intent.PutExtra("disabledDeduction", disabledDeduction);
                    intent.PutExtra("disabledSpouseDeduction", disabledSpouseDeduction);
                    intent.PutExtra("spouseNoIncomeDeduction", spouseNoIncomeDeduction);
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
                spouseNoIncomeDeduction = 4000.00;
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
                        disabledDeduction = 6000.00;
                        break;
                    case Resource.Id.radioSpouseDisabledTrue:
                        disabledSpouseDeduction = 5000.00;
                        break;
                    case Resource.Id.radioDisabledFalse:
                        disabledDeduction = 0.00;
                        break;
                    case Resource.Id.radioSpouseDisabledFalse:
                        disabledSpouseDeduction = 0.00;
                        break;
                    default:
                        break;
                }
            }
        }

        public void NumberOfKids_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditText editText = sender as EditText;
            switch (editText.Id)
            {
                case Resource.Id.u18kids:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _kidsU18 = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.over18inHE:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _over18inHE = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.disabledChildren:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _disabledChildren = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.disabledChildreninHE:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _disabledChildreninHE = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.u18kidssplit:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _kidsU18split = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.over18inHEsplit:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _over18inHEsplit = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.disabledChildrensplit:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _disabledChildrensplit = int.Parse(editText.Text);
                    }
                    break;
                case Resource.Id.disabledChildreninHEsplit:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _disabledChildreninHEsplit = int.Parse(editText.Text);
                    }
                    break;
                default:
                    break;
            }
        }

        private int SpinnerMonth_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if (((Spinner)sender).SelectedItem.ToString() == Months.January.ToString())
            {
                monthsRemaining = 11;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.Febuary.ToString())
            {
                monthsRemaining = 10;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.March.ToString())
            {
                monthsRemaining = 9;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.April.ToString())
            {
                monthsRemaining = 8;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.May.ToString())
            {
                monthsRemaining = 7;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.June.ToString())
            {
                monthsRemaining = 6;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.July.ToString())
            {
                monthsRemaining = 5;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.August.ToString())
            {
                monthsRemaining = 4;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.September.ToString())
            {
                monthsRemaining = 3;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.October.ToString())
            {
                monthsRemaining = 2;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.November.ToString())
            {
                monthsRemaining = 1;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.December.ToString())
            {
                monthsRemaining = 0;
            }
            return monthsRemaining;
        }

        //pop-up for if another month selected from spinner
        private void MonthSelctedNotTodaysMonth(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            static string AlertTitle(string month)
            {
                string ItIsNot = "It is not " + month + "!";
                return ItIsNot;
            }
            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            const string AlertMessage = "Are you sure you want to change the month?";
            string ItIsNot;

            if (((Spinner)sender).SelectedItem.ToString() == Months.January.ToString() && monthToday != 1)
            {
                ItIsNot = AlertTitle(Months.January.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 11;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.Febuary.ToString() && monthToday != 2)
            {
                ItIsNot = AlertTitle(Months.Febuary.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 10;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.March.ToString() && monthToday != 3)
            {
                ItIsNot = AlertTitle(Months.March.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 9;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.April.ToString() && monthToday != 4)
            {
                ItIsNot = AlertTitle(Months.April.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 8;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.May.ToString() && monthToday != 5)
            {
                ItIsNot = AlertTitle(Months.May.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 7;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.June.ToString() && monthToday != 6)
            {
                ItIsNot = AlertTitle(Months.June.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 6;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.July.ToString() && monthToday != 7)
            {
                ItIsNot = AlertTitle(Months.July.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 5;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.August.ToString() && monthToday != 8)
            {
                ItIsNot = AlertTitle(Months.August.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 4;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.September.ToString() && monthToday != 9)
            {
                ItIsNot = AlertTitle(Months.September.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 3;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.October.ToString() && monthToday != 10)
            {
                ItIsNot = AlertTitle(Months.October.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 2;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.November.ToString() && monthToday != 11)
            {
                ItIsNot = AlertTitle(Months.November.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 1;
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                    monthsRemaining = 12 - monthToday;
                });
                soundPlayer.PlaySound_AlertWarning(this);

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.December.ToString() && monthToday != 12)
            {
                ItIsNot = AlertTitle(Months.December.ToString());
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                    monthsRemaining = 0;
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
}
