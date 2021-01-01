using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Widget;
using Android.Text;
using static Android.Widget.TextView;

namespace PayrollParrots
{
    [Activity(Label = "PayrollFamily")]
    public class PayrollFamily : Activity
    {
        public const string January = "January";
        public const string Febuary = "Febuary";
        public const string March = "March";
        public const string April = "April";
        public const string May = "May";
        public const string June = "June";
        public const string July = "July";
        public const string August = "August";
        public const string September = "September";
        public const string October = "October";
        public const string November = "November";
        public const string December = "December";
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
            Spinner spinner = FindViewById<Spinner>(Resource.Id.monthSpinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.month_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            //month today
            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;
            //setting spinner to display todays month
            if (monthToday == 1)
            {
                spinner.SetSelection(0);
            }
            else if (monthToday == 2)
            {
                spinner.SetSelection(1);
            }
            else if (monthToday == 3)
            {
                spinner.SetSelection(2);
            }
            else if (monthToday == 4)
            {
                spinner.SetSelection(3);
            }
            else if (monthToday == 5)
            {
                spinner.SetSelection(4);
            }
            else if (monthToday == 6)
            {
                spinner.SetSelection(5);
            }
            else if (monthToday == 7)
            {
                spinner.SetSelection(6);
            }
            else if (monthToday == 8)
            {
                spinner.SetSelection(7);
            }
            else if (monthToday == 9)
            {
                spinner.SetSelection(8);
            }
            else if (monthToday == 10)
            {
                spinner.SetSelection(9);
            }
            else if (monthToday == 11)
            {
                spinner.SetSelection(10);
            }
            else if (monthToday == 12)
            {
                spinner.SetSelection(11);
            }

            spinner.ItemSelected += SpinnerMonth_ItemSelected;
            spinner.ItemSelected += MonthNotNow;

            //marital status
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.statusSpinner);
            var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.status_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;
            spinner2.ItemSelected += Spinner2_ItemSelected;

            //disabled
            RadioButton disabledTrue = FindViewById<RadioButton>(Resource.Id.radioDisabledTrue);
            disabledTrue.CheckedChange += RadioButton_CheckedChanged;
            RadioButton disabledFalse = FindViewById<RadioButton>(Resource.Id.radioDisabledFalse);
            disabledFalse.CheckedChange += RadioButton_CheckedChanged;

            //spouse disabled
            EditText errorView = FindViewById<EditText>(Resource.Id.erroreditview);
            RadioButton spouseDisabledTrue = FindViewById<RadioButton>(Resource.Id.radioSpouseDisabledTrue);
            spouseDisabledTrue.CheckedChange += RadioButton_CheckedChanged;
            RadioButton spouseDisabledFalse = FindViewById<RadioButton>(Resource.Id.radioSpouseDisabledFalse);
            spouseDisabledFalse.CheckedChange += RadioButton_CheckedChanged;
            spouseDisabledTrue.Click += (sender, e) =>
            {
                disabledSpouseCan();
            };
            spouseDisabledFalse.Click += (sender, e) =>
            {
                disabledSpouseCan();
            };

            //kidsunder18 or in education 2000
            EditText kidsU18 = FindViewById<EditText>(Resource.Id.u18kids);
            kidsU18.TextChanged += EditText_TextChanged;

            //over 18 HE 8000
            EditText over18inHE = FindViewById<EditText>(Resource.Id.over18inHE);
            over18inHE.TextChanged += EditText_TextChanged;

            //disabled 6000
            EditText disabledChildren = FindViewById<EditText>(Resource.Id.disabledChildren);
            disabledChildren.TextChanged += EditText_TextChanged;

            //disabled HE 14000
            EditText disabledChildreninHE = FindViewById<EditText>(Resource.Id.disabledChildreninHE);
            disabledChildreninHE.TextChanged += EditText_TextChanged;

            //kidsunder18 or in education 1000
            EditText kidsU18split = FindViewById<EditText>(Resource.Id.u18kidssplit);
            kidsU18split.TextChanged += EditText_TextChanged;

            //over 18 HE 4000
            EditText over18inHEsplit = FindViewById<EditText>(Resource.Id.over18inHEsplit);
            over18inHEsplit.TextChanged += EditText_TextChanged;

            //disabled 3000
            EditText disabledChildrensplit = FindViewById<EditText>(Resource.Id.disabledChildrensplit);
            disabledChildrensplit.TextChanged += EditText_TextChanged;

            //disabled HE 7000
            EditText disabledChildreninHEsplit = FindViewById<EditText>(Resource.Id.disabledChildreninHEsplit);
            disabledChildreninHEsplit.TextChanged += EditText_TextChanged;


            Button _firstContinue = FindViewById<Button>(Resource.Id.continuePayroll1);

            _firstContinue.Click += (sender, e) =>
            {
                if (disabledSpouseCan() == false)
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
                    PlayButton_Click(sender, e);
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

            //button-click sound
            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }

            //check if have spouse
            bool disabledSpouseCan()
            {
                if ((spinner2.SelectedItem.ToString() == "Single" | spinner2.SelectedItem.ToString() == "Divorce/Widower/Widow") && (spouseDisabledTrue.Checked == true))
                {
                    errorView.Error = "You don't have a spouse";
                    return false;
                }
                else
                {
                    errorView.Error = null;
                    return true;
                }
            }
        }

        private void Spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if (((Spinner)sender).SelectedItem.ToString() == "Married and spouse not working")
            {
                spouseNoIncomeDeduction = 4000.00;
            }
        }

        private void RadioButton_CheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
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
                        disabledSpouseDeduction = 3500.00;
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

        public void EditText_TextChanged(object sender, TextChangedEventArgs e)
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

        private void SpinnerMonth_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if (((Spinner)sender).SelectedItem.ToString() == January)
            {
                monthsRemaining = 11;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Febuary)
            {
                monthsRemaining = 10;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == March)
            {
                monthsRemaining = 9;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == April)
            {
                monthsRemaining = 8;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == May)
            {
                monthsRemaining = 7;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == June)
            {
                monthsRemaining = 6;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == July)
            {
                monthsRemaining = 5;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == August)
            {
                monthsRemaining = 4;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == September)
            {
                monthsRemaining = 3;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == October)
            {
                monthsRemaining = 2;
            }
            else if (((Spinner)sender).SelectedItem.ToString() == November)
            {
                monthsRemaining = 1;
            }
            else
            {
                monthsRemaining = 0;
            }
        }

        //pop-up for if month changed
        private void MonthNotNow(object sender, AdapterView.ItemSelectedEventArgs e)
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

            if (((Spinner)sender).SelectedItem.ToString() == January && monthToday != 1)
            {
                ItIsNot = AlertTitle(January);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Febuary && monthToday != 2)
            {
                ItIsNot = AlertTitle(Febuary);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == March && monthToday != 3)
            {
                ItIsNot = AlertTitle(March);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == April && monthToday != 4)
            {
                ItIsNot = AlertTitle(April);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == May && monthToday != 5)
            {
                ItIsNot = AlertTitle(May);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == June && monthToday != 6)
            {
                ItIsNot = AlertTitle(June);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == July && monthToday != 7)
            {
                ItIsNot = AlertTitle(July);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == August && monthToday != 8)
            {
                ItIsNot = AlertTitle(August);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == September && monthToday != 9)
            {
                ItIsNot = AlertTitle(September);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == October && monthToday != 10)
            {
                ItIsNot = AlertTitle(October);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == November && monthToday != 11)
            {
                ItIsNot = AlertTitle(November);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == December && monthToday != 12)
            {
                ItIsNot = AlertTitle(December);
                alert.SetTitle(ItIsNot);
                alert.SetMessage(AlertMessage);
                alert.SetIcon(Resource.Drawable.Warning_Sign);
                alert.SetButton("Yes", (c, ev) =>
                {
                });
                alert.SetButton2("No", (c, ev) =>
                {
                    ((Spinner)sender).SetSelection(monthToday - 1);
                });

                alert.Show();
            }
            else
            {
            }
        }
    }
}
