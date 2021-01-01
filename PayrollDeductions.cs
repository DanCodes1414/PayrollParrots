using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Text;
using Android.Widget;

namespace PayrollParrots
{
    //#fix
    [Activity(Label = "PayrollDeductions")]
    public class PayrollDeductions : Activity
    {
        public const double EmployeeMaxAgeForEPFContribution = 60;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_deductions);
            double _arrears = Intent.GetDoubleExtra("arrears", 0.00);
            double _commission = Intent.GetDoubleExtra("commission", 0.00);
            double _othersEPFNO = Intent.GetDoubleExtra("othersNoEPF", 0.00);
            double _others = Intent.GetDoubleExtra("Others", 0.00);
            double _currentMonthRemuneration = Intent.GetDoubleExtra("currentMonthRemuneration", 0.00);
            //lifeStyleRelief
            EditText lifeStyleRelief_ = FindViewById<EditText>(Resource.Id.lifeStyleRelief);
            lifeStyleRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _lifeStyleRelief = 0.00;
            lifeStyleRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(lifeStyleRelief_.Text, out _lifeStyleRelief);
                Validate(_lifeStyleRelief, 2500, lifeStyleRelief_);
            };
            //SOCSOContribution
            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
            double SOCSOWage = _currentMonthRemuneration + _arrears + _commission + _othersEPFNO + _others;
            double _SOCSOContribution = 0.00;
            if (_employeeAge < EmployeeMaxAgeForEPFContribution)
            {
                if (SOCSOWage <= 30)
                {
                    _SOCSOContribution = 0.10;
                }
                else if (SOCSOWage > 30 && SOCSOWage <= 50)
                {
                    _SOCSOContribution = 0.30;
                }
                else if (SOCSOWage > 50 && SOCSOWage <= 70)
                {
                    _SOCSOContribution = 0.30;
                }
                else if (SOCSOWage > 70 && SOCSOWage <= 100)
                {
                    _SOCSOContribution = 0.40;
                }
                else if (SOCSOWage > 100 && SOCSOWage <= 140)
                {
                    _SOCSOContribution = 0.60;
                }
                else if (SOCSOWage > 140 && SOCSOWage <= 200)
                {
                    _SOCSOContribution = 0.85;
                }
                else if (SOCSOWage > 200 && SOCSOWage <= 300)
                {
                    _SOCSOContribution = 1.25;
                }
                else if (SOCSOWage > 300 && SOCSOWage <= 400)
                {
                    _SOCSOContribution = 1.75;
                }
                else if (SOCSOWage > 400 && SOCSOWage <= 500)
                {
                    _SOCSOContribution = 2.25;
                }
                else if (SOCSOWage > 500 && SOCSOWage <= 600)
                {
                    _SOCSOContribution = 2.75;
                }
                else if (SOCSOWage > 600 && SOCSOWage <= 700)
                {
                    _SOCSOContribution = 3.25;
                }
                else if (SOCSOWage > 700 && SOCSOWage <= 800)
                {
                    _SOCSOContribution = 3.75;
                }
                else if (SOCSOWage > 800 && SOCSOWage <= 900)
                {
                    _SOCSOContribution = 4.25;
                }
                else if (SOCSOWage > 900 && SOCSOWage <= 1000)
                {
                    _SOCSOContribution = 4.75;
                }
                else if (SOCSOWage > 1000 && SOCSOWage <= 1100)
                {
                    _SOCSOContribution = 5.25;
                }
                else if (SOCSOWage > 1100 && SOCSOWage <= 1200)
                {
                    _SOCSOContribution = 5.75;
                }
                else if (SOCSOWage > 1200 && SOCSOWage <= 1300)
                {
                    _SOCSOContribution = 6.25;
                }
                else if (SOCSOWage > 1300 && SOCSOWage <= 1400)
                {
                    _SOCSOContribution = 6.75;
                }
                else if (SOCSOWage > 1400 && SOCSOWage <= 1500)
                {
                    _SOCSOContribution = 7.25;
                }
                else if (SOCSOWage > 1500 && SOCSOWage <= 1600)
                {
                    _SOCSOContribution = 7.75;
                }
                else if (SOCSOWage > 1600 && SOCSOWage <= 1700)
                {
                    _SOCSOContribution = 8.25;
                }
                else if (SOCSOWage > 1700 && SOCSOWage <= 1800)
                {
                    _SOCSOContribution = 8.75;
                }
                else if (SOCSOWage > 1800 && SOCSOWage <= 1900)
                {
                    _SOCSOContribution = 9.25;
                }
                else if (SOCSOWage > 1900 && SOCSOWage <= 2000)
                {
                    _SOCSOContribution = 9.75;
                }
                else if (SOCSOWage > 2000 && SOCSOWage <= 2100)
                {
                    _SOCSOContribution = 10.25;
                }
                else if (SOCSOWage > 2100 && SOCSOWage <= 2200)
                {
                    _SOCSOContribution = 10.75;
                }
                else if (SOCSOWage > 2200 && SOCSOWage <= 2300)
                {
                    _SOCSOContribution = 11.25;
                }
                else if (SOCSOWage > 2300 && SOCSOWage <= 2400)
                {
                    _SOCSOContribution = 11.75;
                }
                else if (SOCSOWage > 2400 && SOCSOWage <= 2500)
                {
                    _SOCSOContribution = 12.25;
                }
                else if (SOCSOWage > 2500 && SOCSOWage <= 2600)
                {
                    _SOCSOContribution = 12.75;
                }
                else if (SOCSOWage > 2600 && SOCSOWage <= 2700)
                {
                    _SOCSOContribution = 13.25;
                }
                else if (SOCSOWage > 2700 && SOCSOWage <= 2800)
                {
                    _SOCSOContribution = 13.75;
                }
                else if (SOCSOWage > 2800 && SOCSOWage <= 2900)
                {
                    _SOCSOContribution = 14.25;
                }
                else if (SOCSOWage > 2900 && SOCSOWage <= 3000)
                {
                    _SOCSOContribution = 14.75;
                }
                else if (SOCSOWage > 3000 && SOCSOWage <= 3100)
                {
                    _SOCSOContribution = 15.25;
                }
                else if (SOCSOWage > 3100 && SOCSOWage <= 3200)
                {
                    _SOCSOContribution = 15.75;
                }
                else if (SOCSOWage > 3200 && SOCSOWage <= 3300)
                {
                    _SOCSOContribution = 16.25;
                }
                else if (SOCSOWage > 3300 && SOCSOWage <= 3400)
                {
                    _SOCSOContribution = 16.75;
                }
                else if (SOCSOWage > 3400 && SOCSOWage <= 3500)
                {
                    _SOCSOContribution = 17.25;
                }
                else if (SOCSOWage > 3500 && SOCSOWage <= 3600)
                {
                    _SOCSOContribution = 17.75;
                }
                else if (SOCSOWage > 3600 && SOCSOWage <= 3700)
                {
                    _SOCSOContribution = 18.25;
                }
                else if (SOCSOWage > 3700 && SOCSOWage <= 3800)
                {
                    _SOCSOContribution = 18.75;
                }
                else if (SOCSOWage > 3800 && SOCSOWage <= 3900)
                {
                    _SOCSOContribution = 19.25;
                }
                else if (SOCSOWage > 3900 && SOCSOWage <= 4000)
                {
                    _SOCSOContribution = 19.75;
                }
                else
                {
                    _SOCSOContribution = 19.75;
                }
            }
            else
            {
                _SOCSOContribution = 0;
            }
            //lifeInsurance
            EditText lifeInsurance_ = FindViewById<EditText>(Resource.Id.lifeInsurance);
            lifeInsurance_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _lifeInsurance = 0.00;
            lifeInsurance_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(lifeInsurance_.Text, out _lifeInsurance);
                Validate(_lifeInsurance, 3000, lifeInsurance_);
            };
            //basicEquipment
            EditText basicEquipment_ = FindViewById<EditText>(Resource.Id.basicEquipment);
            basicEquipment_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _basicEquipment = 0.00;
            basicEquipment_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(basicEquipment_.Text, out _basicEquipment);
                Validate(_basicEquipment, 6000, basicEquipment_);
            };
            //educationYourSelf
            EditText educationYourSelf_ = FindViewById<EditText>(Resource.Id.educationYourSelf);
            educationYourSelf_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _educationYourSelf = 0.00;
            educationYourSelf_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(educationYourSelf_.Text, out _educationYourSelf);
                Validate(_educationYourSelf, 7000, educationYourSelf_);
            };
            //medicalExamintion
            EditText medicalExamintion_ = FindViewById<EditText>(Resource.Id.medicalExamintion);
            medicalExamintion_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _medicalExamintion = 0.00;
            medicalExamintion_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalExamintion_.Text, out _medicalExamintion);
                Validate(_medicalExamintion, 500, medicalExamintion_);
            };
            //medicalDisease
            EditText medicalDisease_ = FindViewById<EditText>(Resource.Id.medicalDisease);
            medicalDisease_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _medicalDisease = 0.00;
            medicalDisease_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalDisease_.Text, out _medicalDisease);
            };
            medicalExamintion_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalExamintion_.Text, out _medicalExamintion);
                Validate(_medicalExamintion + _medicalDisease, 6000, medicalDisease_);
            };
            medicalDisease_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalExamintion_.Text, out _medicalExamintion);
                Validate(_medicalExamintion + _medicalDisease, 6000, medicalDisease_);
            };
            //SSPN
            EditText SSPN_ = FindViewById<EditText>(Resource.Id.SSPN);
            SSPN_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _SSPN = 0.00;
            SSPN_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(SSPN_.Text, out _SSPN);
                Validate(_SSPN, 8000, SSPN_);
            };
            //PRS
            EditText PRS_ = FindViewById<EditText>(Resource.Id.PRS);
            PRS_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _PRS = 0.00;
            PRS_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(PRS_.Text, out _PRS);
                Validate(_PRS, 3000, PRS_);
            };
            //smallKidEducation
            EditText smallKidEducation_ = FindViewById<EditText>(Resource.Id.smallKidEducation);
            smallKidEducation_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _smallKidEducation = 0.00;
            smallKidEducation_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(smallKidEducation_.Text, out _smallKidEducation);
                Validate(_smallKidEducation, 2000, smallKidEducation_);
            };
            //breastFeedingEquipment
            EditText breastFeedingEquipment_ = FindViewById<EditText>(Resource.Id.breastFeedingEquipment);
            breastFeedingEquipment_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _breastFeedingEquipment = 0.00;
            breastFeedingEquipment_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(breastFeedingEquipment_.Text, out _breastFeedingEquipment);
                Validate(_breastFeedingEquipment, 1000, breastFeedingEquipment_);
            };
            //alimonyFormerWife
            EditText alimonyFormerWife_ = FindViewById<EditText>(Resource.Id.alimonyFormerWife);
            alimonyFormerWife_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _alimonyFormerWife = 0.00;
            alimonyFormerWife_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(alimonyFormerWife_.Text, out _alimonyFormerWife);
                Validate(_alimonyFormerWife, 4000, alimonyFormerWife_);
            };
            //EMInsurance
            EditText EMInsurance_ = FindViewById<EditText>(Resource.Id.EMInsurance);
            EMInsurance_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _EMInsurance = 0.00;
            EMInsurance_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(EMInsurance_.Text, out _EMInsurance);
                Validate(_EMInsurance, 3000, EMInsurance_);
            };
            //fatherRelief
            EditText fatherRelief_ = FindViewById<EditText>(Resource.Id.fatherRelief);
            fatherRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _fatherRelief = 0.00;
            fatherRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(fatherRelief_.Text, out _fatherRelief);
                Validate(_fatherRelief, 1500, fatherRelief_);
            };
            //motherRelief
            EditText motherRelief_ = FindViewById<EditText>(Resource.Id.motherRelief);
            motherRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _motherRelief = 0.00;
            motherRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(motherRelief_.Text, out _motherRelief);
                Validate(_motherRelief, 1500, motherRelief_);
            };
            //mapaRelief
            EditText mapaRelief_ = FindViewById<EditText>(Resource.Id.mapaRelief);
            mapaRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _mapaRelief = 0.00;
            mapaRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(mapaRelief_.Text, out _mapaRelief);
                Validate(_mapaRelief, 5000, mapaRelief_);
                Validate2(_mapaRelief, _fatherRelief + _motherRelief, mapaRelief_);
            };
            fatherRelief_.AfterTextChanged += (sender, args) =>
            {
                Validate2(_mapaRelief, _fatherRelief + _motherRelief, mapaRelief_);
            };
            motherRelief_.AfterTextChanged += (sender, args) =>
            {
                Validate2(_mapaRelief, _fatherRelief + _motherRelief, mapaRelief_);
            };

            double TotalDeductions = _lifeStyleRelief + _SOCSOContribution + _lifeInsurance + _basicEquipment + _educationYourSelf + _medicalExamintion + _medicalDisease + _smallKidEducation + _breastFeedingEquipment + _alimonyFormerWife + _EMInsurance + _fatherRelief + _motherRelief;
            Button _fourthContinue = FindViewById<Button>(Resource.Id.continuePayroll4);
            _fourthContinue.Click += (sender, e) => {
                if (Validate(_lifeStyleRelief, 2500, lifeStyleRelief_) == false
                | Validate(_lifeInsurance, 3000, lifeInsurance_) == false | Validate(_basicEquipment, 6000, basicEquipment_) == false
                | Validate(_educationYourSelf, 7000, educationYourSelf_) == false | Validate(_medicalExamintion, 500, medicalExamintion_) == false
                | Validate(_medicalDisease, 6000, medicalDisease_) == false | Validate(_smallKidEducation, 2000, smallKidEducation_) == false
                | Validate(_breastFeedingEquipment, 1000, breastFeedingEquipment_) == false
                | Validate(_alimonyFormerWife, 4000, alimonyFormerWife_) == false | Validate(_EMInsurance, 3000, EMInsurance_) == false
                | Validate(_fatherRelief, 1500, fatherRelief_) == false | Validate(_motherRelief, 1500, motherRelief_) == false
                | Validate(_medicalExamintion + _medicalDisease, 6000, medicalDisease_) == false | Validate(_mapaRelief, 5000, mapaRelief_) == false
                | Validate2(_mapaRelief, _fatherRelief + _motherRelief, mapaRelief_) == false | Validate(_SSPN, 8000, SSPN_) == false
                | Validate(_PRS, 3000, PRS_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Make sure all fields are below their limits", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    PlayButton_Click(sender, e);
                    double _BIK = Intent.GetDoubleExtra("BIK", 0.00);
                    double _VOLA = Intent.GetDoubleExtra("VOLA", 0.00);
                    double _totalFamilyDeductions = Intent.GetDoubleExtra("totalFamilyDeductions", 0.00);
                    double _bonus = Intent.GetDoubleExtra("bonus", 0.00);
                    double _othersEISNO = Intent.GetDoubleExtra("othersNoEIS", 0.00);
                    int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                    double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                    double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                    double _kidsU18 = Intent.GetDoubleExtra("kidsU18", 0.00);
                    double _over18inHE = Intent.GetDoubleExtra("over18inHE", 0.00);
                    double _disabledChildren = Intent.GetDoubleExtra("disabledChildren", 0.00);
                    double _disabledChildreninHE = Intent.GetDoubleExtra("disabledChildreninHE", 0.00);
                    double disabledDeduction = Intent.GetDoubleExtra("disabledDeduction", 0.00);
                    double disabledSpouseDeduction = Intent.GetDoubleExtra("disabledSpouseDeduction", 0.00);
                    double spouseNoIncomeDeduction = Intent.GetDoubleExtra("spouseNoIncomeDeduction", 0.00);
                    string _employeeName = Intent.GetStringExtra("employeeName");
                    Intent intent = new Intent(this, typeof(PayrollRebates));
                    intent.PutExtra("lifeStyleRelief", _lifeStyleRelief);
                    intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                    intent.PutExtra("lifeInsurance", _lifeInsurance);
                    intent.PutExtra("basicEquipment", _basicEquipment);
                    intent.PutExtra("educationYourSelf", _educationYourSelf);
                    intent.PutExtra("medicalExamintion", _medicalExamintion);
                    intent.PutExtra("medicalDisease", _medicalDisease);
                    intent.PutExtra("smallKidEducation", _smallKidEducation);
                    intent.PutExtra("breastFeedingEquipment", _breastFeedingEquipment);
                    intent.PutExtra("alimonyFormerWife", _alimonyFormerWife);
                    intent.PutExtra("EMInsurance", _EMInsurance);
                    intent.PutExtra("fatherRelief", _fatherRelief);
                    intent.PutExtra("motherRelief", _motherRelief);
                    intent.PutExtra("mapaRelief", _mapaRelief);
                    intent.PutExtra("totalDeductions", TotalDeductions);
                    intent.PutExtra("SSPN", _SSPN);
                    intent.PutExtra("PRS", _PRS);

                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("othersEISNO", _othersEISNO);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("bonus", _bonus);
                    intent.PutExtra("arrears", _arrears);
                    intent.PutExtra("commission", _commission);
                    intent.PutExtra("othersEPFNO", _othersEPFNO);
                    intent.PutExtra("others", _others);
                    intent.PutExtra("currentMonthRemuneration", _currentMonthRemuneration);
                    intent.PutExtra("BIK", _BIK);
                    intent.PutExtra("VOLA", _VOLA);
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
                }
            };

            //button-click sound
            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }

        //check if input greater than limit
        bool Validate(double name, double value, EditText editText)
        {
            if ((name > value) && editText.Hint == "Medical expenses for serious diseases[Up to RM6000]")
            {
                editText.Error = "Cost of medical expenses(examintaion + serious diseases) cannot be greater than " + value;
                return false;
            }
            else if ((name > value) && editText.Hint != "Medical expenses for serious diseases[Up to RM6000]")
            {
                editText.Error = "Cannot be greater than " + value;
                return false;
            }
            else
            {
                return true;
            }
        }

        //check Father + Mother Relief + both parents relief greater than limit
        bool Validate2(double name, double name2, EditText editText)
        {
            if ((name > 0) && (name2 > 0))
            {
                editText.Error = "Father Relief/Mother Relief and medical expenses for own parents cannot both be greater than 0";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
