using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using Newtonsoft.Json;
using PayrollParrots.Model;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollPreviousDeductions")]
    public class PayrollPreviousDeductions : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly ValidatingDeductions validatingDeductions = new ValidatingDeductions();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_previous_deductions);

            var FamilyDeductionItems = JsonConvert.DeserializeObject<PayrollFamilyDeductions>(Intent.GetStringExtra("FamilyDeductionItems"));
            var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
            var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
            var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));
            var AdditionalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("AdditionalRemuneration"));
            var DeductionItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Deductions"));
            var RebateItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("Rebates"));
            var PreviousRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousRemuneration"));
            var PreviousBIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousBIK"));
            var PreviousVOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("PreviousVOLA"));

            //previousLifeStyleRelief
            double _lifeStyleRelief = DeductionItems["LifeStyleRelief"];
            EditText previousLifeStyleRelief_ = FindViewById<EditText>(Resource.Id.previousLifeStyleRelief);
            previousLifeStyleRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousLifeStyleRelief = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousLifeStyleRelief_, _lifeStyleRelief, 2500);
            };

            //previousSportsRelief
            double _sportsRelief = DeductionItems["SportsRelief"];
            EditText previousSportsRelief_ = FindViewById<EditText>(Resource.Id.previousSportsRelief);
            previousSportsRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousSportsRelief = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousSportsRelief_, _sportsRelief, 500);
            };

            //previousSOCSOContribution
            double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
            EditText previousSOCSOContribution_ = FindViewById<EditText>(Resource.Id.previousSOCSOContribution);
            double _previousSOCSOContribution = 0.00;
            previousSOCSOContribution_.AfterTextChanged += (sender, args) =>
            {
                _previousSOCSOContribution = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousSOCSOContribution_, _SOCSOContribution, 250);
            };

            //previouslifeInsurance
            double _lifeInsurance = DeductionItems["LifeInsurance"];
            EditText previousLifeInsurance_ = FindViewById<EditText>(Resource.Id.previouslifeInsurance);
            previousLifeInsurance_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousLifeInsurance = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousLifeInsurance_, _lifeInsurance, 3000);
            };

            //previousBasicEquipment
            double _basicEquipment = DeductionItems["SupportingEquipment"];
            EditText previousBasicEquipment_ = FindViewById<EditText>(Resource.Id.previousBasicEquipment);
            previousBasicEquipment_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousSupportingEquipment = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousBasicEquipment_, _basicEquipment, 6000);
            };

            //previousEducationYourSelf
            double _educationYourSelf = DeductionItems["EducationFeesForSelf"];
            EditText previousEducationYourSelf_ = FindViewById<EditText>(Resource.Id.previousEducationYourSelf);
            previousEducationYourSelf_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousEducationFeesForSelf = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousEducationYourSelf_, _educationYourSelf, 7000);
            };

            //previousMedicalExamination
            double _medicalExamination = DeductionItems["MedicalExamination"];
            EditText previousMedicalExamination_ = FindViewById<EditText>(Resource.Id.previousMedicalExamination);
            previousMedicalExamination_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousMedicalExamination = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousMedicalExamination_, _medicalExamination, 1000);
            };

            //previousMedicalVaccination
            double _medicalVaccination = DeductionItems["MedicalVaccination"];
            EditText previousMedicalVaccination_ = FindViewById<EditText>(Resource.Id.previousMedicalVaccination);
            previousMedicalVaccination_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousMedicalVaccination = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousMedicalVaccination_, _medicalVaccination, 1000);
            };

            //previousMedicalDisease
            double _medicalDisease = DeductionItems["MedicalDisease"];
            EditText previousMedicalDisease_ = FindViewById<EditText>(Resource.Id.previousMedicalDisease);
            previousMedicalDisease_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousMedicalDisease = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousMedicalDisease_, _medicalDisease, 8000);
            };
            previousMedicalExamination_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(_medicalExamination + _medicalVaccination + _medicalDisease + payrollItems.PreviousMedicalDisease + payrollItems.PreviousMedicalVaccination + payrollItems.PreviousMedicalExamination, 8000, previousMedicalDisease_);
            };
            previousMedicalVaccination_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(_medicalExamination + _medicalVaccination + _medicalDisease + payrollItems.PreviousMedicalDisease + payrollItems.PreviousMedicalVaccination + payrollItems.PreviousMedicalExamination, 8000, previousMedicalDisease_);
            };
            previousMedicalDisease_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(_medicalExamination + _medicalVaccination + _medicalDisease + payrollItems.PreviousMedicalDisease + payrollItems.PreviousMedicalVaccination + payrollItems.PreviousMedicalExamination, 8000, previousMedicalDisease_);
            };

            //previousSSPN
            double _SSPN = DeductionItems["SSPN"];
            EditText previousSSPN_ = FindViewById<EditText>(Resource.Id.previousSSPN);
            previousSSPN_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousSSPN = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousSSPN_, _SSPN, 8000);
            };

            //previousPRS
            double _PRS = DeductionItems["PRS"];
            EditText previousPRS_ = FindViewById<EditText>(Resource.Id.previousPRS);
            previousPRS_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousPRS = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousPRS_, _PRS, 3000);
            };

            //previousSmallKidEducation
            double _smallKidEducation = DeductionItems["KindergartenAndChildCareFees"];
            EditText previousSmallKidEducation_ = FindViewById<EditText>(Resource.Id.previousSmallKidEducation);
            previousSmallKidEducation_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousKindergartenAndChildCareFees = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousSmallKidEducation_, _smallKidEducation, 3000);
            };

            //previousBreastFeedingEquipment
            double _breastFeedingEquipment = DeductionItems["BreastFeedingEquipment"];
            EditText previousBreastFeedingEquipment_ = FindViewById<EditText>(Resource.Id.previousBreastFeedingEquipment);
            previousBreastFeedingEquipment_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousBreastFeedingEquipment = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousBreastFeedingEquipment_, _breastFeedingEquipment, 1000);
            };

            //previousAlimonyFormerWife
            double _alimonyFormerWife = DeductionItems["AlimonyToFormerWife"];
            EditText previousAlimonyFormerWife_ = FindViewById<EditText>(Resource.Id.previousAlimonyFormerWife);
            previousAlimonyFormerWife_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousAlimonyToFormerWife = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousAlimonyFormerWife_, _alimonyFormerWife, 4000);
            };

            //previousEMInsurance
            double _EMInsurance = DeductionItems["EducationAndMedicalInsurance"];
            EditText previousEMInsurance_ = FindViewById<EditText>(Resource.Id.previousEMInsurance);
            previousEMInsurance_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousEducationAndMedicalInsurance = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousEMInsurance_, _EMInsurance, 3000);
            };

            //previousFatherRelief
            double _fatherRelief = DeductionItems["FatherRelief"];
            EditText previousFatherRelief_ = FindViewById<EditText>(Resource.Id.previousFatherRelief);
            previousFatherRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousFatherRelief = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousFatherRelief_, _fatherRelief, 1500);
            };

            //previousMotherRelief
            double _motherRelief = DeductionItems["MotherRelief"];
            EditText previousMotherRelief_ = FindViewById<EditText>(Resource.Id.previousMotherRelief);
            previousMotherRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousMotherRelief = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousMotherRelief_, _motherRelief, 1500);
            };

            //previousMapaRelief
            double _mapaRelief = DeductionItems["MedicalExpenseForParents"];
            EditText previousMapaRelief_ = FindViewById<EditText>(Resource.Id.previousMapaRelief);
            previousMapaRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _previousMapaRelief = 0.00;
            previousMapaRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(previousMapaRelief_.Text, out _previousMapaRelief);
                payrollItems.PreviousMedicalExpenseForParents = _previousMapaRelief;
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousMedicalExpenseForParents + _mapaRelief, 8000, previousMapaRelief_);
                validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.PreviousMedicalExpenseForParents, payrollItems.PreviousFatherRelief + payrollItems.PreviousMotherRelief, previousMapaRelief_);
            };
            previousFatherRelief_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.PreviousMedicalExpenseForParents, payrollItems.PreviousFatherRelief + payrollItems.PreviousMotherRelief, previousMapaRelief_);
            };
            previousMotherRelief_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.PreviousMedicalExpenseForParents, payrollItems.PreviousFatherRelief + payrollItems.PreviousMotherRelief, previousMapaRelief_);
            };

            //previousDomesticTourismExpenditure
            double _domesticTourismExpenditure = DeductionItems["DomesticTourismExpenditure"];
            EditText previousDomesticTourismExpenditure_ = FindViewById<EditText>(Resource.Id.previousDomesticTourismExpenditure);
            previousDomesticTourismExpenditure_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PreviousDomesticTourismExpenditure = editTextToDouble.EditTextPreviousDeductions_AfterTextChanged(previousDomesticTourismExpenditure_, _domesticTourismExpenditure, 1000);
            };

            Button _seventhContinue = FindViewById<Button>(Resource.Id.continuePayroll7);
            _seventhContinue.Click += (sender, e) =>
            {
                if (validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousLifeStyleRelief + _lifeStyleRelief, 2500, previousLifeStyleRelief_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousSportsRelief + _sportsRelief, 500, previousSportsRelief_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(_previousSOCSOContribution + _SOCSOContribution, 250, previousSOCSOContribution_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousLifeInsurance + _lifeInsurance, 3000, previousLifeInsurance_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.SupportingEquipment + _basicEquipment, 6000, previousBasicEquipment_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousEducationFeesForSelf + _educationYourSelf, 7000, previousEducationYourSelf_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousMedicalExamination + _medicalExamination, 500, previousMedicalExamination_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousMedicalDisease + _medicalDisease, 6000, previousMedicalDisease_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousKindergartenAndChildCareFees + _smallKidEducation, 3000, previousSmallKidEducation_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousBreastFeedingEquipment + _breastFeedingEquipment, 1000, previousBreastFeedingEquipment_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousMedicalVaccination + _medicalVaccination, 1000, previousMedicalVaccination_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousAlimonyToFormerWife + _alimonyFormerWife, 4000, previousAlimonyFormerWife_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousEducationAndMedicalInsurance + _EMInsurance, 3000, previousEMInsurance_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousFatherRelief + _fatherRelief, 1500, previousFatherRelief_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousMotherRelief + _motherRelief, 1500, previousMotherRelief_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousMedicalExpenseForParents + _mapaRelief, 8000, previousMapaRelief_) == false | validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.PreviousMedicalExpenseForParents, payrollItems.PreviousFatherRelief + payrollItems.MotherRelief, previousMapaRelief_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousSSPN + _SSPN, 8000, previousSSPN_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousPRS + _PRS, 3000, previousPRS_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PreviousDomesticTourismExpenditure + _domesticTourismExpenditure, 1000, previousDomesticTourismExpenditure_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Make sure all fields are below their limits", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    soundPlayer.PlaySound_ButtonClick(this);

                    PayrollCategory payrollCategory = new PayrollCategory(payrollItems);

                    double _SOCSOContribution = Intent.GetDoubleExtra("SOCSOContribution", 0.00);
                    int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                    double _previousEPFContribution = Intent.GetDoubleExtra("previousEPFContribution", 0.00);
                    double _MTDPrevious = Intent.GetDoubleExtra("MTDPrevious", 0.00);
                    double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                    double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                    int _employeeAge = Intent.GetIntExtra("employeeAge", 0);
                    string _employeeName = Intent.GetStringExtra("employeeName");

                    Intent intent = new Intent(this, typeof(PayrollPreviousRebates));
                    intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                    intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(NormalRemunerationItems));
                    intent.PutExtra("BIK", JsonConvert.SerializeObject(BIKItems));
                    intent.PutExtra("VOLA", JsonConvert.SerializeObject(VOLAItems));
                    intent.PutExtra("AdditionalRemuneration", JsonConvert.SerializeObject(AdditionalRemunerationItems));
                    intent.PutExtra("Deductions", JsonConvert.SerializeObject(DeductionItems));
                    intent.PutExtra("Rebates", JsonConvert.SerializeObject(RebateItems));
                    intent.PutExtra("PreviousRemuneration", JsonConvert.SerializeObject(PreviousRemunerationItems));
                    intent.PutExtra("PreviousBIK", JsonConvert.SerializeObject(PreviousBIKItems));
                    intent.PutExtra("PreviousVOLA", JsonConvert.SerializeObject(PreviousVOLAItems));
                    intent.PutExtra("PreviousDeductions", JsonConvert.SerializeObject(payrollCategory.PreviousDeductions));

                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("previousEPFContribution", _previousEPFContribution);
                    intent.PutExtra("MTDPrevious", _MTDPrevious);
                    intent.PutExtra("previousSOCSOContribution", _previousSOCSOContribution);
                    intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                    intent.PutExtra("monthsRemaining", _monthsRemaining);
                    StartActivity(intent);
                }
            };
        }
    }
}
