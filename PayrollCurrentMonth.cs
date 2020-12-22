using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Text;
using Android.Widget;

namespace PayrollParrots
{
    [Activity(Label = "PayrollCurrentMonth")]
    public class PayrollCurrentMonth : Activity
    {
        //#fix
        //add 9% epf rate
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_current_month);
            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);

            //currentmonthremu
            EditText currentMonthRemuneration_ = FindViewById<EditText>(Resource.Id.currentMonthRemuneration);
            currentMonthRemuneration_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _currentMonthRemuneration = 0.00;
            double _EPFContribution = 0.00;
            currentMonthRemuneration_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(currentMonthRemuneration_.Text, out _currentMonthRemuneration);
                if (_employeeAge < 60)
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
                        _EPFContribution = Math.Ceiling(EPFWage1 * 0.11);
                    }
                    else if (_currentMonthRemuneration > 5000 && _currentMonthRemuneration <= 20000)
                    {
                        double EPFWage2 = (Math.Ceiling(_currentMonthRemuneration * 0.01)) * 100;
                        _EPFContribution = Math.Ceiling(EPFWage2 * 0.11);
                    }
                    else
                    {
                        _EPFContribution = Math.Ceiling(_currentMonthRemuneration * 0.11);
                    }
                }
                else
                {
                    _EPFContribution = 0;
                }
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
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                PlayButton_Click(sender, e);
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

            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }
    }

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