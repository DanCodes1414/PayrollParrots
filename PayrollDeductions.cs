using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    //#fix
    [Activity(Label = "PayrollDeductions")]
    public class PayrollDeductions : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        public const double EmployeeMaxAgeForEPFContribution = 60;
        readonly TaxCalculation taxCalculation = new TaxCalculation();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_deductions);
            double _arrears = Intent.GetDoubleExtra("arrears", 0.00);
            double _commission = Intent.GetDoubleExtra("commission", 0.00);
            double _othersEPFNO = Intent.GetDoubleExtra("othersNoEPF", 0.00);
            double _others = Intent.GetDoubleExtra("Others", 0.00);
            double _currentMonthRemuneration = Intent.GetDoubleExtra("currentMonthRemuneration", 0.00);
            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);

            //lifeStyleRelief
            EditText lifeStyleRelief_ = FindViewById<EditText>(Resource.Id.lifeStyleRelief);
            lifeStyleRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _lifeStyleRelief = 0.00;
            lifeStyleRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(lifeStyleRelief_.Text, out _lifeStyleRelief);
                Validate(_lifeStyleRelief, 2500, lifeStyleRelief_);
            };

            //sportsRelief
            EditText sportsRelief_ = FindViewById<EditText>(Resource.Id.sportsRelief);
            sportsRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _sportsRelief = 0.00;
            sportsRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(sportsRelief_.Text, out _sportsRelief);
                Validate(_sportsRelief, 500, sportsRelief_);
            };

            //SOCSOContribution
            double SOCSOWage = _currentMonthRemuneration + _arrears + _commission + _othersEPFNO + _others;
            double _SOCSOContribution = taxCalculation.EmployeeSOCSOCalculation(_employeeAge, SOCSOWage);
            
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

            //medicalExamination
            EditText medicalExamination_ = FindViewById<EditText>(Resource.Id.medicalExamination);
            medicalExamination_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _medicalExamination = 0.00;
            medicalExamination_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalExamination_.Text, out _medicalExamination);
                Validate(_medicalExamination, 1000, medicalExamination_);
            };

            //medicalVaccination
            EditText medicalVaccination_ = FindViewById<EditText>(Resource.Id.medicalVaccination);
            medicalVaccination_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _medicalVaccination = 0.00;
            medicalVaccination_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalVaccination_.Text, out _medicalVaccination);
                Validate(_medicalVaccination, 1000, medicalVaccination_);
            };

            //medicalDisease
            EditText medicalDisease_ = FindViewById<EditText>(Resource.Id.medicalDisease);
            medicalDisease_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _medicalDisease = 0.00;
            medicalDisease_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalDisease_.Text, out _medicalDisease);
            };
            medicalExamination_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalExamination_.Text, out _medicalExamination);
                Validate(_medicalExamination + _medicalVaccination + _medicalDisease, 8000, medicalDisease_);
            };
            medicalVaccination_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalVaccination_.Text, out _medicalVaccination);
                Validate(_medicalExamination + _medicalVaccination + _medicalDisease, 8000, medicalDisease_);
            };
            medicalDisease_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(medicalDisease_.Text, out _medicalDisease);
                Validate(_medicalExamination + _medicalVaccination + _medicalDisease, 8000, medicalDisease_);
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
                Validate(_smallKidEducation, 3000, smallKidEducation_);
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
                Validate(_mapaRelief, 8000, mapaRelief_);
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

            //domesticTourismExpenditure
            EditText domesticTourismExpenditure_ = FindViewById<EditText>(Resource.Id.domesticTourismExpenditure);
            domesticTourismExpenditure_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _domesticTourismExpenditure = 0.00;
            domesticTourismExpenditure_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(domesticTourismExpenditure_.Text, out _domesticTourismExpenditure);
                Validate(_domesticTourismExpenditure, 1000, domesticTourismExpenditure_);
            };

            double TotalDeductions = _lifeStyleRelief + _SOCSOContribution + _lifeInsurance + _basicEquipment + _educationYourSelf + _medicalExamination + _medicalDisease + _smallKidEducation + _breastFeedingEquipment + _alimonyFormerWife + _EMInsurance + _fatherRelief + _motherRelief;
            Button _fourthContinue = FindViewById<Button>(Resource.Id.continuePayroll4);
            _fourthContinue.Click += (sender, e) => {
                if (Validate(_lifeStyleRelief, 2500, lifeStyleRelief_) == false | Validate(_sportsRelief, 500, sportsRelief_) == false
                | Validate(_lifeInsurance, 3000, lifeInsurance_) == false | Validate(_basicEquipment, 6000, basicEquipment_) == false
                | Validate(_educationYourSelf, 7000, educationYourSelf_) == false | Validate(_medicalExamination, 1000, medicalExamination_) == false
                | Validate(_medicalDisease, 8000, medicalDisease_) == false | Validate(_smallKidEducation, 3000, smallKidEducation_) == false
                | Validate(_breastFeedingEquipment, 1000, breastFeedingEquipment_) == false | Validate(_medicalVaccination, 1000, medicalVaccination_) == false
                | Validate(_alimonyFormerWife, 4000, alimonyFormerWife_) == false | Validate(_EMInsurance, 3000, EMInsurance_) == false
                | Validate(_fatherRelief, 1500, fatherRelief_) == false | Validate(_motherRelief, 1500, motherRelief_) == false
                | Validate(_medicalExamination + _medicalDisease + _medicalVaccination, 8000, medicalDisease_) == false | Validate(_mapaRelief, 8000, mapaRelief_) == false
                | Validate2(_mapaRelief, _fatherRelief + _motherRelief, mapaRelief_) == false | Validate(_SSPN, 8000, SSPN_) == false
                | Validate(_PRS, 3000, PRS_) == false | Validate(_domesticTourismExpenditure, 1000, domesticTourismExpenditure_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Make sure all fields are below their limits", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    soundPlayer.PlaySound_ButtonClick(this);

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
                    intent.PutExtra("medicalExamination", _medicalExamination);
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
                    intent.PutExtra("sportsRelief", _sportsRelief);
                    intent.PutExtra("medicalVaccination", _medicalVaccination);
                    intent.PutExtra("domesticTourismExpenditure", _domesticTourismExpenditure);

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
        }

        //check if input greater than limit
        bool Validate(double name, double value, EditText editText)
        {
            if ((name > value) && editText.Hint == "Medical Expenses For Serious Diseases[Up to RM8000]")
            {
                editText.Error = "Cost of medical expenses(examintaion + serious diseases) cannot be greater than " + value;
                return false;
            }
            else if ((name > value) && editText.Hint != "Medical Expenses For Serious Diseases[Up to RM8000]")
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
