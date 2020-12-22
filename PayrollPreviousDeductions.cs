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
    [Activity(Label = "PayrollPreviousDeductions")]
    public class PayrollPreviousDeductions : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_previous_deductions);
            //previousLifeStyleRelief
            double _lifeStyleRelief = Intent.GetDoubleExtra("lifeStyleRelief", 0.00);
            EditText previousLifeStyleRelief_ = FindViewById<EditText>(Resource.Id.previousLifeStyleRelief);
            previousLifeStyleRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousLifeStyleRelief = 0.00;
            previousLifeStyleRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousLifeStyleRelief_.Text, out _previousLifeStyleRelief);
                Validate(_previousLifeStyleRelief + _lifeStyleRelief, 2500, previousLifeStyleRelief_);
            };
            //previousSOCSOContribution
            double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
            EditText previousSOCSOContribution_ = FindViewById<EditText>(Resource.Id.previousSOCSOContribution);
            previousSOCSOContribution_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousSOCSOContribution = 0.00;
            previousSOCSOContribution_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousSOCSOContribution_.Text, out _previousSOCSOContribution);
                Validate(_previousSOCSOContribution + _SOCSOContribution, 250, previousSOCSOContribution_);
            };
            //previouslifeInsurance
            double _lifeInsurance = Intent.GetDoubleExtra("lifeInsurance", 0.00);
            EditText previousLifeInsurance_ = FindViewById<EditText>(Resource.Id.previouslifeInsurance);
            previousLifeInsurance_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousLifeInsurance = 0.00;
            previousLifeInsurance_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousLifeInsurance_.Text, out _previousLifeInsurance);
                Validate(_previousLifeInsurance + _previousLifeInsurance, 3000, previousLifeInsurance_);
            };
            //previousBasicEquipment
            double _basicEquipment = Intent.GetDoubleExtra("basicEquipment", 0.00);
            EditText previousBasicEquipment_ = FindViewById<EditText>(Resource.Id.previousBasicEquipment);
            previousBasicEquipment_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousBasicEquipment = 0.00;
            previousBasicEquipment_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousBasicEquipment_.Text, out _previousBasicEquipment);
                Validate(_previousBasicEquipment + _basicEquipment, 6000, previousBasicEquipment_);
            };
            //previousEducationYourSelf
            double _educationYourSelf = Intent.GetDoubleExtra("educationYourSelf", 0.00);
            EditText previousEducationYourSelf_ = FindViewById<EditText>(Resource.Id.previousEducationYourSelf);
            previousEducationYourSelf_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousEducationYourSelf = 0.00;
            previousEducationYourSelf_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousEducationYourSelf_.Text, out _previousEducationYourSelf);
                Validate(_previousEducationYourSelf + _educationYourSelf, 7000, previousEducationYourSelf_);
            };
            //previousMedicalExamintion
            double _medicalExamintion = Intent.GetDoubleExtra("medicalExamintion", 0.00);
            EditText previousMedicalExamintion_ = FindViewById<EditText>(Resource.Id.previousMedicalExamintion);
            previousMedicalExamintion_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousMedicalExamintion = 0.00;
            previousMedicalExamintion_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMedicalExamintion_.Text, out _previousMedicalExamintion);
                Validate(_previousMedicalExamintion + _medicalExamintion, 500, previousMedicalExamintion_);
            };
            //previousMedicalDisease
            double _medicalDisease = Intent.GetDoubleExtra("medicalDisease", 0.00);
            EditText previousMedicalDisease_ = FindViewById<EditText>(Resource.Id.previousMedicalDisease);
            previousMedicalDisease_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousMedicalDisease = 0.00;
            previousMedicalDisease_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMedicalDisease_.Text, out _previousMedicalDisease);
                //Validate(_previousMedicalDisease + _medicalDisease, 6000, previousMedicalDisease_);
            };
            previousMedicalExamintion_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMedicalExamintion_.Text, out _previousMedicalExamintion);
                Validate(_medicalExamintion + _medicalDisease + _previousMedicalDisease + _previousMedicalExamintion, 6000, previousMedicalDisease_);
            };
            previousMedicalDisease_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMedicalExamintion_.Text, out _previousMedicalExamintion);
                Validate(_medicalExamintion + _medicalDisease + _previousMedicalDisease + _previousMedicalExamintion, 6000, previousMedicalDisease_);
            };
            //previousSSPN
            double _SSPN = Intent.GetDoubleExtra("SSPN", 0.00);
            EditText previousSSPN_ = FindViewById<EditText>(Resource.Id.previousSSPN);
            previousSSPN_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousSSPN = 0.00;
            previousSSPN_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousSSPN_.Text, out _previousSSPN);
                Validate(_previousSSPN + _SSPN, 8000, previousSSPN_);
            };
            //previousPRS
            double _PRS = Intent.GetDoubleExtra("PRS", 0.00);
            EditText previousPRS_ = FindViewById<EditText>(Resource.Id.previousPRS);
            previousPRS_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousPRS = 0.00;
            previousPRS_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousPRS_.Text, out _previousPRS);
                Validate(_previousPRS + _PRS, 3000, previousPRS_);
            };
            //previousSmallKidEducation
            double _smallKidEducation = Intent.GetDoubleExtra("smallKidEducation", 0.00);
            EditText previousSmallKidEducation_ = FindViewById<EditText>(Resource.Id.previousSmallKidEducation);
            previousSmallKidEducation_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousSmallKidEducation = 0.00;
            previousSmallKidEducation_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousSmallKidEducation_.Text, out _previousSmallKidEducation);
                Validate(_previousSmallKidEducation + _smallKidEducation, 2000, previousSmallKidEducation_);
            };
            //previousBreastFeedingEquipment
            double _breastFeedingEquipment = Intent.GetDoubleExtra("breastFeedingEquipment", 0.00);
            EditText previousBreastFeedingEquipment_ = FindViewById<EditText>(Resource.Id.previousBreastFeedingEquipment);
            previousBreastFeedingEquipment_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousBreastFeedingEquipment = 0.00;
            previousBreastFeedingEquipment_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousBreastFeedingEquipment_.Text, out _previousBreastFeedingEquipment);
                Validate(_previousBreastFeedingEquipment + _breastFeedingEquipment, 1000, previousBreastFeedingEquipment_);
            };
            //previousAlimonyFormerWife
            double _alimonyFormerWife = Intent.GetDoubleExtra("alimonyFormerWife", 0.00);
            EditText previousAlimonyFormerWife_ = FindViewById<EditText>(Resource.Id.previousAlimonyFormerWife);
            previousAlimonyFormerWife_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousAlimonyFormerWife = 0.00;
            previousAlimonyFormerWife_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousAlimonyFormerWife_.Text, out _previousAlimonyFormerWife);
                Validate(_previousAlimonyFormerWife + _alimonyFormerWife, 4000, previousAlimonyFormerWife_);
            };
            //previousEMInsurance
            double _EMInsurance = Intent.GetDoubleExtra("EMInsurance", 0.00);
            EditText previousEMInsurance_ = FindViewById<EditText>(Resource.Id.previousEMInsurance);
            previousEMInsurance_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousEMInsurance = 0.00;
            previousEMInsurance_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousEMInsurance_.Text, out _previousEMInsurance);
                Validate(_previousEMInsurance + _EMInsurance, 3000, previousEMInsurance_);
            };
            //previousFatherRelief
            double _fatherRelief = Intent.GetDoubleExtra("fatherRelief", 0.00);
            EditText previousFatherRelief_ = FindViewById<EditText>(Resource.Id.previousFatherRelief);
            previousFatherRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousFatherRelief = 0.00;
            previousFatherRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousFatherRelief_.Text, out _previousFatherRelief);
                Validate(_previousFatherRelief + _fatherRelief, 1500, previousFatherRelief_);
            };
            //previousMotherRelief
            double _motherRelief = Intent.GetDoubleExtra("motherRelief", 0.00);
            EditText previousMotherRelief_ = FindViewById<EditText>(Resource.Id.previousMotherRelief);
            previousMotherRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousMotherRelief = 0.00;
            previousMotherRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMotherRelief_.Text, out _previousMotherRelief);
                Validate(_previousMotherRelief + _motherRelief, 1500, previousMotherRelief_);
            };
            //previousMapaRelief
            double _mapaRelief = Intent.GetDoubleExtra("mapaRelief", 0.00);
            EditText previousMapaRelief_ = FindViewById<EditText>(Resource.Id.previousMapaRelief);
            previousMapaRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousMapaRelief = 0.00;
            previousMapaRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMapaRelief_.Text, out _previousMapaRelief);
                Validate(_previousMapaRelief + _mapaRelief, 5000, previousMapaRelief_);
                Validate2(_previousMapaRelief, _previousFatherRelief + _previousMotherRelief, previousMapaRelief_);
            };
            previousFatherRelief_.AfterTextChanged += (sender, args) =>
            {
                Validate2(_previousMapaRelief, _previousFatherRelief + _previousMotherRelief, previousMapaRelief_);
            };
            previousMotherRelief_.AfterTextChanged += (sender, args) =>
            {
                Validate2(_previousMapaRelief, _previousFatherRelief + _previousMotherRelief, previousMapaRelief_);
            };

            Button _seventhContinue = FindViewById<Button>(Resource.Id.continuePayroll7);
            _seventhContinue.Click += (sender, e) =>
            {
                if (Validate(_previousLifeStyleRelief + _lifeStyleRelief, 2500, previousLifeStyleRelief_) == false | Validate(_previousSOCSOContribution + _SOCSOContribution, 250, previousSOCSOContribution_) == false
                | Validate(_previousLifeInsurance + _lifeInsurance, 3000, previousLifeInsurance_) == false | Validate(_previousBasicEquipment + _basicEquipment, 6000, previousBasicEquipment_) == false
                | Validate(_previousEducationYourSelf + _educationYourSelf, 7000, previousEducationYourSelf_) == false | Validate(_previousMedicalExamintion + _medicalExamintion, 500, previousMedicalExamintion_) == false
                | Validate(_previousMedicalDisease + _medicalDisease, 6000, previousMedicalDisease_) == false | Validate(_previousSmallKidEducation + _smallKidEducation, 2000, previousSmallKidEducation_) == false
                | Validate(_previousBreastFeedingEquipment + _breastFeedingEquipment, 1000, previousBreastFeedingEquipment_) == false
                | Validate(_previousAlimonyFormerWife + _alimonyFormerWife, 4000, previousAlimonyFormerWife_) == false | Validate(_previousEMInsurance + _EMInsurance, 3000, previousEMInsurance_) == false
                | Validate(_previousFatherRelief + _fatherRelief, 1500, previousFatherRelief_) == false | Validate(_previousMotherRelief + _motherRelief, 1500, previousMotherRelief_) == false
                | Validate(_previousMapaRelief + _mapaRelief, 5000, previousMapaRelief_) == false | Validate2(_previousMapaRelief, _previousFatherRelief + _previousMotherRelief, previousMapaRelief_) == false
                | Validate(_previousSSPN + _SSPN, 8000, previousSSPN_) == false | Validate(_previousPRS + _PRS, 3000, previousPRS_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Make sure all fields are below their limits", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    PlayButton_Click(sender, e);
                    double _currentMonthRemuneration = Intent.GetDoubleExtra("currentMonthRemuneration", 0.00);
                    double _BIK = Intent.GetDoubleExtra("BIK", 0.00);
                    double _VOLA = Intent.GetDoubleExtra("VOLA", 0.00);
                    double _totalFamilyDeductions = Intent.GetDoubleExtra("totalFamilyDeductions", 0.00);
                    double _bonus = Intent.GetDoubleExtra("bonus", 0.00);
                    double _arrears = Intent.GetDoubleExtra("arrears", 0.00);
                    double _commission = Intent.GetDoubleExtra("commission", 0.00);
                    double _othersEPFNO = Intent.GetDoubleExtra("othersNoEPF", 0.00);
                    double _others = Intent.GetDoubleExtra("others", 0.00);
                    double _lifeStyleRelief = Intent.GetDoubleExtra("lifeStyleRelief", 0.00);
                    double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
                    double _lifeInsurance = Intent.GetDoubleExtra("lifeInsurance", 0.00);
                    double _basicEquipment = Intent.GetDoubleExtra("basicEquipment", 0.00);
                    double _educationYourSelf = Intent.GetDoubleExtra("educationYourSelf", 0.00);
                    double _medicalExamintion = Intent.GetDoubleExtra("medicalExamintion", 0.00);
                    double _medicalDisease = Intent.GetDoubleExtra("medicalDisease", 0.00);
                    double _smallKidEducation = Intent.GetDoubleExtra("smallKidEducation", 0.00);
                    double _breastFeedingEquipment = Intent.GetDoubleExtra("breastFeedingEquipment", 0.00);
                    double _alimonyFormerWife = Intent.GetDoubleExtra("alimonyFormerWife", 0.00);
                    double _EMInsurance = Intent.GetDoubleExtra("EMInsurance", 0.00);
                    double _fatherRelief = Intent.GetDoubleExtra("fatherRelief", 0.00);
                    double _motherRelief = Intent.GetDoubleExtra("motherRelief", 0.00);
                    int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                    double _zakatByEmployee = Intent.GetDoubleExtra("zakatByEmployee", 0.00);
                    double _zakatByPayroll = Intent.GetDoubleExtra("zakatByPayroll", 0.00);
                    double _departureLevy = Intent.GetDoubleExtra("departureLevy", 0.00);
                    double _totalDeductions = Intent.GetDoubleExtra("totalDeductions", 0.00);
                    double _previousMonthsRemuneration = Intent.GetDoubleExtra("previousMonthsRemuneration", 0.00);
                    double _previousEPFContribution = Intent.GetDoubleExtra("previousEPFContribution", 0.00);
                    double _previousBIK = Intent.GetDoubleExtra("previousBIK", 0.00);
                    double _previousVOLA = Intent.GetDoubleExtra("previousVOLA", 0.00);
                    double _MTDPrevious = Intent.GetDoubleExtra("MTDPrevious", 0.00);
                    double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                    double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                    double _kidsU18 = Intent.GetDoubleExtra("kidsU18", 0.00);
                    double _over18inHE = Intent.GetDoubleExtra("over18inHE", 0.00);
                    double _disabledChildren = Intent.GetDoubleExtra("disabledChildren", 0.00);
                    double _disabledChildreninHE = Intent.GetDoubleExtra("disabledChildreninHE", 0.00);
                    double disabledDeduction = Intent.GetDoubleExtra("disabledDeduction", 0.00);
                    double disabledSpouseDeduction = Intent.GetDoubleExtra("disabledSpouseDeduction", 0.00);
                    double spouseNoIncomeDeduction = Intent.GetDoubleExtra("spouseNoIncomeDeduction", 0.00);
                    double _OthersEISNO = Intent.GetDoubleExtra("othersNoEIS", 0.00);
                    int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                    string _employeeName = Intent.GetStringExtra("employeeName");
                    Intent intent = new Intent(this, typeof(PayrollPreviousRebates));
                    intent.PutExtra("previousLifeStyleRelief", _previousLifeStyleRelief);
                    intent.PutExtra("previousSOCSOContribution", _previousSOCSOContribution);
                    intent.PutExtra("previousLifeInsurance", _previousLifeInsurance);
                    intent.PutExtra("previousBasicEquipment", _previousBasicEquipment);
                    intent.PutExtra("previousEducationYourSelf", _previousEducationYourSelf);
                    intent.PutExtra("previousMedicalExamintion", _previousMedicalExamintion);
                    intent.PutExtra("previousMedicalDisease", _previousMedicalDisease);
                    intent.PutExtra("previousSmallKidEducation", _previousSmallKidEducation);
                    intent.PutExtra("previousBreastFeedingEquipment", _previousBreastFeedingEquipment);
                    intent.PutExtra("previousAlimonyFormerWife", _previousAlimonyFormerWife);
                    intent.PutExtra("previousEMInsurance", _previousEMInsurance);
                    intent.PutExtra("previousFatherRelief", _previousFatherRelief);
                    intent.PutExtra("previousMotherRelief", _previousMotherRelief);
                    intent.PutExtra("previousMapaRelief", _previousMapaRelief);
                    intent.PutExtra("previousSSPN", _previousSSPN);
                    intent.PutExtra("previousPRS", _previousPRS);

                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("PRS", _PRS);
                    intent.PutExtra("SSPN", _SSPN);
                    intent.PutExtra("othersEISNO", _OthersEISNO);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("previousMonthsRemuneration", _previousMonthsRemuneration);
                    intent.PutExtra("previousEPFContribution", _previousEPFContribution);
                    intent.PutExtra("previousBIK", _previousBIK);
                    intent.PutExtra("previousVOLA", _previousVOLA);
                    intent.PutExtra("MTDPrevious", _MTDPrevious);
                    intent.PutExtra("zakatByEmployee", _zakatByEmployee);
                    intent.PutExtra("zakatByPayroll", _zakatByPayroll);
                    intent.PutExtra("departureLevy", _departureLevy);
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
                    intent.PutExtra("bonus", _bonus);
                    intent.PutExtra("arrears", _arrears);
                    intent.PutExtra("commission", _commission);
                    intent.PutExtra("othersEPFNO", _othersEPFNO);
                    intent.PutExtra("Others", _others);
                    intent.PutExtra("currentMonthRemuneration", _currentMonthRemuneration);
                    intent.PutExtra("BIK", _BIK);
                    intent.PutExtra("VOLA", _VOLA);
                    intent.PutExtra("totalFamilyDeductions", _totalFamilyDeductions);
                    intent.PutExtra("monthsRemaining", _monthsRemaining);
                    intent.PutExtra("totalDeductions", _totalDeductions);
                    intent.PutExtra("kidsU18", _kidsU18);
                    intent.PutExtra("over18inHE", _over18inHE);
                    intent.PutExtra("disabledChildren", _disabledChildren);
                    intent.PutExtra("disabledChildreninHE", _disabledChildreninHE);
                    intent.PutExtra("disabledDeduction", disabledDeduction);
                    intent.PutExtra("disabledSpouseDeduction", disabledSpouseDeduction);
                    intent.PutExtra("spouseNoIncomeDeduction", spouseNoIncomeDeduction);
                    intent.PutExtra("mapaRelief", _mapaRelief);
                    StartActivity(intent);
                }
            };

            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }
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
