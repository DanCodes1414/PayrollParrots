﻿using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Text;
using Android.Widget;

namespace PayrollParrots
{
    //#fix
    [Activity(Label = "PayrollAdditionalCurrentMonth")]
    public class PayrollAdditionalCurrentMonth : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_additional_current_month);
            //Bonus
            EditText bonus_ = FindViewById<EditText>(Resource.Id.bonus);
            bonus_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _bonus = 0.00;
            bonus_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(bonus_.Text, out _bonus);
            };
            //Arrears
            EditText arrears_ = FindViewById<EditText>(Resource.Id.arrears);
            arrears_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _arrears = 0.00;
            arrears_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(arrears_.Text, out _arrears);
            };
            //Commission
            EditText commission_ = FindViewById<EditText>(Resource.Id.commission);
            commission_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _commission = 0.00;
            commission_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(commission_.Text, out _commission);
            };
            //Other EPF not subject
            EditText OthersEPFNO_ = FindViewById<EditText>(Resource.Id.OthersEPFNO);
            OthersEPFNO_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _OthersEPFNO = 0.00;
            OthersEPFNO_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(OthersEPFNO_.Text, out _OthersEPFNO);
            };
            //Other EIS not subject
            EditText OthersEISNO_ = FindViewById<EditText>(Resource.Id.OthersEISNO);
            OthersEISNO_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _OthersEISNO = 0.00;
            OthersEISNO_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(OthersEISNO_.Text, out _OthersEISNO);
            };
            //Others
            EditText others_ = FindViewById<EditText>(Resource.Id.others);
            others_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _others = 0.00;
            others_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(others_.Text, out _others);
            };

            //additional EPF automatic calculation
            double _EPFAdditionalContribution = 0.00;
            double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
            //_EPFContribution2 = EPFContribution for both additional and normal remuneration 
            double _EPFContribution2 = 0.00;
            double _currentMonthRemuneration = Intent.GetDoubleExtra("currentMonthRemuneration", 0.00);
            double _EPFRate = Intent.GetDoubleExtra("EPFRate", 0.11);
            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
            Button _thirdContinue = FindViewById<Button>(Resource.Id.continuePayroll3);
            _thirdContinue.Click += (sender, e) =>
            {
                double additionalRemuneration = _bonus + _commission + _OthersEISNO + _others + _arrears;
                if (_employeeAge < 60)
                {
                    if (_EPFRate == 0.11)
                    {
                        if ((_currentMonthRemuneration + additionalRemuneration) <= 20)
                        {
                            if ((_currentMonthRemuneration + additionalRemuneration) <= 10)
                            {
                                _EPFContribution2 = 0.00;
                            }
                            else if ((_currentMonthRemuneration + additionalRemuneration) > 10 && (_currentMonthRemuneration + additionalRemuneration) <= 20)
                            {
                                _EPFContribution2 = 3.00;
                                _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                            }
                        }
                        else if ((_currentMonthRemuneration + additionalRemuneration) > 20 && (_currentMonthRemuneration + additionalRemuneration) <= 5000)
                        {
                            double EPFWage1 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.05)) * 20;
                            _EPFContribution2 = Math.Ceiling(EPFWage1 * _EPFRate);
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        }
                        else if ((_currentMonthRemuneration + additionalRemuneration) > 5000 && (_currentMonthRemuneration + additionalRemuneration) <= 20000)
                        {
                            double EPFWage2 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01)) * 100;
                            _EPFContribution2 = Math.Ceiling(EPFWage2 * _EPFRate);
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        }
                        else
                        {
                            _EPFContribution2 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * _EPFRate);
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        }
                    }
                    if (_EPFRate == 0.09)
                    {
                        if ((_currentMonthRemuneration + additionalRemuneration) <= 20)
                        {
                            if ((_currentMonthRemuneration + additionalRemuneration) <= 10)
                            {
                                _EPFContribution2 = 0.00;
                            }
                            else if ((_currentMonthRemuneration + additionalRemuneration) > 10 && (_currentMonthRemuneration + additionalRemuneration) <= 20)
                            {
                                _EPFContribution2 = 2.00;
                                _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                            }
                        }
                        else if ((_currentMonthRemuneration + additionalRemuneration) > 20 && (_currentMonthRemuneration + additionalRemuneration) <= 5000)
                        {
                            double EPFWage1 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.05)) * 20;
                            _EPFContribution2 = Math.Ceiling(EPFWage1 * _EPFRate);
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        }
                        else if ((_currentMonthRemuneration + additionalRemuneration) > 5000 && (_currentMonthRemuneration + additionalRemuneration) <= 20000)
                        {
                            double EPFWage2 = (Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * 0.01)) * 100;
                            _EPFContribution2 = Math.Ceiling(EPFWage2 * _EPFRate);
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        }
                        else
                        {
                            _EPFContribution2 = Math.Ceiling((_currentMonthRemuneration + additionalRemuneration) * _EPFRate);
                            _EPFAdditionalContribution = _EPFContribution2 - _EPFContribution;
                        }
                    }
                }
                else
                {
                    _EPFAdditionalContribution = 0;
                }
                PlayButton_Click(sender, e);
                double _BIK = Intent.GetDoubleExtra("BIK", 0.00);
                double _VOLA = Intent.GetDoubleExtra("VOLA", 0.00);
                double _totalFamilyDeductions = Intent.GetDoubleExtra("totalFamilyDeductions", 0.00);
                int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                double _kidsU18 = Intent.GetDoubleExtra("kidsU18", 0.00);
                double _over18inHE = Intent.GetDoubleExtra("over18inHE", 0.00);
                double _disabledChildren = Intent.GetDoubleExtra("disabledChildren", 0.00);
                double _disabledChildreninHE = Intent.GetDoubleExtra("disabledChildreninHE", 0.00);
                double disabledDeduction = Intent.GetDoubleExtra("disabledDeduction", 0.00);
                double disabledSpouseDeduction = Intent.GetDoubleExtra("disabledSpouseDeduction", 0.00);
                double spouseNoIncomeDeduction = Intent.GetDoubleExtra("spouseNoIncomeDeduction", 0.00);
                string _employeeName = Intent.GetStringExtra("employeeName");
                Intent intent = new Intent(this, typeof(PayrollDeductions));
                intent.PutExtra("bonus", _bonus);
                intent.PutExtra("arrears", _arrears);
                intent.PutExtra("commission", _commission);
                intent.PutExtra("othersEPFNO", _OthersEPFNO);
                intent.PutExtra("othersEISNO", _OthersEISNO);
                intent.PutExtra("Others", _others);
                intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);

                intent.PutExtra("employeeAge", _employeeAge);
                intent.PutExtra("employeeName", _employeeName);
                intent.PutExtra("kidsU18", _kidsU18);
                intent.PutExtra("over18inHE", _over18inHE);
                intent.PutExtra("disabledChildren", _disabledChildren);
                intent.PutExtra("disabledChildreninHE", _disabledChildreninHE);
                intent.PutExtra("disabledDeduction", disabledDeduction);
                intent.PutExtra("disabledSpouseDeduction", disabledSpouseDeduction);
                intent.PutExtra("spouseNoIncomeDeduction", spouseNoIncomeDeduction);
                intent.PutExtra("EPFContribution", _EPFContribution);
                intent.PutExtra("currentMonthRemuneration", _currentMonthRemuneration);
                intent.PutExtra("BIK", _BIK);
                intent.PutExtra("VOLA", _VOLA);
                intent.PutExtra("totalFamilyDeductions", _totalFamilyDeductions);
                intent.PutExtra("monthsRemaining", _monthsRemaining);
                StartActivity(intent);
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
