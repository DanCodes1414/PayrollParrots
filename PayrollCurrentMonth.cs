using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Text;
using Android.Widget;
using static Android.Widget.TextView;

namespace PayrollParrots
{
    /*public enum EPFRate
    {
        EPFElevenPercentRate,
        EPFNinePercentRate
    }*/

    [Activity(Label = "PayrollCurrentMonth")]
    public class PayrollCurrentMonth : Activity
    {
        public Dictionary<string, double> EPFRate = new Dictionary<string, double>();
        public const double EmployeeMaxAgeForEPFContribution = 60;
        double _EPFRate;
        double _currentMonthRemuneration = 0.00;
        double _EPFContribution = 0.00;
        int _employeeAge;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            _employeeAge = Intent.GetIntExtra("employeeAge", 0);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_current_month);
            //EPF rate
            RadioButton EPFRate9 = FindViewById<RadioButton>(Resource.Id.radio9rate);
            EPFRate9.CheckedChange += (sender, e) =>
            {
                double _EPFRate = RadioButton_CheckedChanged(sender, e);
            };
            RadioButton EPFRate11 = FindViewById<RadioButton>(Resource.Id.radio11rate);
            EPFRate11.CheckedChange += (sender, e) =>
            {
                double _EPFRate = RadioButton_CheckedChanged(sender, e);
            };

            //currentmonthremu
            EditText currentMonthRemuneration_ = FindViewById<EditText>(Resource.Id.currentMonthRemuneration);
            currentMonthRemuneration_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            currentMonthRemuneration_.AfterTextChanged += (sender, args) =>
            {
                //double.TryParse(currentMonthRemuneration_.Text, out _currentMonthRemuneration);
                EditText_TextChanged(sender, args, _EPFRate);
            };
            //BIK
            EditText BIK_ = FindViewById<EditText>(Resource.Id.BIK);
            BIK_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _BIK = 0.00;
            BIK_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(BIK_.Text, out _BIK);
            };
            //VOLA
            EditText VOLA_ = FindViewById<EditText>(Resource.Id.VOLA);
            VOLA_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _VOLA = 0.00;
            VOLA_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(VOLA_.Text, out _VOLA);
            };
            Button _secondContinue = FindViewById<Button>(Resource.Id.continuePayroll2);
            _secondContinue.Click += (sender, e) =>
            {
                PlayButton_Click(sender, e);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                double _totalFamilyDeductions = Intent.GetDoubleExtra("totalFamilyDeductions", 0.00);
                double _kidsU18 = Intent.GetDoubleExtra("kidsU18", 0.00);
                double _over18inHE = Intent.GetDoubleExtra("over18inHE", 0.00);
                double _disabledChildren = Intent.GetDoubleExtra("disabledChildren", 0.00);
                double _disabledChildreninHE = Intent.GetDoubleExtra("disabledChildreninHE", 0.00);
                double disabledDeduction = Intent.GetDoubleExtra("disabledDeduction", 0.00);
                double disabledSpouseDeduction = Intent.GetDoubleExtra("disabledSpouseDeduction", 0.00);
                double spouseNoIncomeDeduction = Intent.GetDoubleExtra("spouseNoIncomeDeduction", 0.00);
                string _employeeName = Intent.GetStringExtra("employeeName");

                Intent intent = new Intent(this, typeof(PayrollAdditionalCurrentMonth));
                intent.PutExtra("currentMonthRemuneration", _currentMonthRemuneration);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("BIK", _BIK);
                intent.PutExtra("VOLA", _VOLA);
                intent.PutExtra("EPFRate", _EPFRate);

                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("totalFamilyDeductions", _totalFamilyDeductions);
                intent.PutExtra("monthsRemaining", _monthsRemaining);
                intent.PutExtra("kidsU18", _kidsU18);
                intent.PutExtra("over18inHE", _over18inHE);
                intent.PutExtra("disabledChildren", _disabledChildren);
                intent.PutExtra("disabledChildreninHE", _disabledChildreninHE);
                intent.PutExtra("disabledDeduction", disabledDeduction);
                intent.PutExtra("disabledSpouseDeduction", disabledSpouseDeduction);
                intent.PutExtra("spouseNoIncomeDeduction", spouseNoIncomeDeduction);
                StartActivity(intent);
            };

            //button-click sound
            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }

        //change epfrate
        private double RadioButton_CheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (e.IsChecked)
            {
                switch (radioButton.Id)
                {
                    case Resource.Id.radio9rate:
                        _EPFRate = 0.09;
                        EPFRate.Remove("EPFElevenPercentRate");
                        EPFRate.Add("EPFNinePercentRate", 0.09);
                        EPFRate.Keys.Equals("EPFNinePercentRate");
                        break;
                    case Resource.Id.radio11rate:
                        _EPFRate = 0.11;
                        EPFRate.Remove("EPFNinePercentRate");
                        EPFRate.Add("EPFElevenPercentRate", 0.11);
                        EPFRate.Keys.Equals("EPFElevenPercentRate");
                        break;
                    default:
                        break;
                }
            }
            return _EPFRate;
        }

        public void EditText_TextChanged(object sender, AfterTextChangedEventArgs e, double _EPFRate)
        {
            EditText editText = sender as EditText;
            _employeeAge = Intent.GetIntExtra("employeeAge", 0);
            switch (editText.Id)
            {
                case Resource.Id.currentMonthRemuneration:
                    if (editText.Length() == 0)
                    {
                        editText.SetText("0", BufferType.Editable);
                        editText.Text.Remove(0);
                    }
                    else
                    {
                        _currentMonthRemuneration = double.Parse(editText.Text);
                        if (_employeeAge < EmployeeMaxAgeForEPFContribution)
                        {
                            if (EPFRate.Values.Equals(0.11))
                            {
                                if (_currentMonthRemuneration <= 20)
                                {
                                    if (_currentMonthRemuneration <= 10)
                                    {
                                        _EPFContribution = 0.00;
                                    }
                                    else if (_currentMonthRemuneration > 10 && _currentMonthRemuneration <= 20)
                                    {
                                        _EPFContribution = 3.00;
                                    }
                                }
                                else if (_currentMonthRemuneration > 20 && _currentMonthRemuneration <= 5000)
                                {
                                    double EPFWage1 = (Math.Ceiling(_currentMonthRemuneration * 0.05)) * 20;
                                    _EPFContribution = Math.Ceiling(EPFWage1 * _EPFRate);
                                }
                                else if (_currentMonthRemuneration > 5000 && _currentMonthRemuneration <= 20000)
                                {
                                    double EPFWage2 = (Math.Ceiling(_currentMonthRemuneration * 0.01)) * 100;
                                    _EPFContribution = Math.Ceiling(EPFWage2 * _EPFRate);
                                }
                                else
                                {
                                    _EPFContribution = Math.Ceiling(_currentMonthRemuneration * _EPFRate);
                                }
                            }
                            else if (EPFRate.Values.Equals(0.09))
                            {
                                if (_currentMonthRemuneration <= 20)
                                {
                                    if (_currentMonthRemuneration <= 10)
                                    {
                                        _EPFContribution = 0.00;
                                    }
                                    else if (_currentMonthRemuneration > 10 && _currentMonthRemuneration <= 20)
                                    {
                                        _EPFContribution = 2.00;
                                    }
                                }
                                else if (_currentMonthRemuneration > 20 && _currentMonthRemuneration <= 5000)
                                {
                                    double EPFWage1 = (Math.Ceiling(_currentMonthRemuneration * 0.05)) * 20;
                                    _EPFContribution = Math.Ceiling(EPFWage1 * _EPFRate);
                                }
                                else if (_currentMonthRemuneration > 5000 && _currentMonthRemuneration <= 20000)
                                {
                                    double EPFWage2 = (Math.Ceiling(_currentMonthRemuneration * 0.01)) * 100;
                                    _EPFContribution = Math.Ceiling(EPFWage2 * _EPFRate);
                                }
                                else
                                {
                                    _EPFContribution = Math.Ceiling(_currentMonthRemuneration * _EPFRate);
                                }
                            }
                        }
                        else
                        {
                            _EPFContribution = 0;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    //class to limit decimal places
    public class DecimalDigitsInputFilter : Java.Lang.Object, IInputFilter
    {
        readonly string regexStr = string.Empty;

        public DecimalDigitsInputFilter(int digitsBeforeZero, int digitsAfterZero)
        {
            regexStr = "^[0-9]{0," + digitsBeforeZero + "}([.][0-9]{0," + (digitsAfterZero - 1) + "})?$";
        }

        public Java.Lang.ICharSequence FilterFormatted(Java.Lang.ICharSequence source, int start, int end, ISpanned dest, int dstart, int dend)
        {
            Regex regex = new Regex(regexStr);

            if (regex.IsMatch(dest.ToString()) || dest.ToString().Equals(""))
            {
                if (dest.ToString().Length < 12 && source.ToString() != ".")
                {
                    return new Java.Lang.String(source.ToString());
                }
                else if (source.ToString() == ".")
                {
                    return new Java.Lang.String(source.ToString());
                }
                else if (dest.ToString().Length >= 13 && dest.ToString().Length <= 20)
                {
                    return new Java.Lang.String(source.ToString());
                }
                else
                {
                    return new Java.Lang.String(string.Empty);

                }
            }

            return new Java.Lang.String(string.Empty);
        }
    }
}