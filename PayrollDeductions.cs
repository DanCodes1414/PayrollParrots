using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using Newtonsoft.Json;
using PayrollParrots.Model;
using PayrollParrots.PayrollTax;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollDeductions")]
    public class PayrollDeductions : Activity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        SOCSOAndEISCalculations SOCSOAndEISCalculations;
        readonly ValidatingDeductions validatingDeductions = new ValidatingDeductions();
        readonly PayrollItems payrollItems = new PayrollItems();
        readonly EditTextToDouble editTextToDouble = new EditTextToDouble();
        public const double EmployeeMaxAgeForEPFContribution = 60;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_deductions);

            var FamilyDeductionItems = JsonConvert.DeserializeObject<PayrollFamilyDeductions>(Intent.GetStringExtra("FamilyDeductionItems"));
            var NormalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("NormalRemuneration"));
            var BIKItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("BIK"));
            var VOLAItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("VOLA"));
            var AdditionalRemunerationItems = JsonConvert.DeserializeObject<Dictionary<string, double>>(Intent.GetStringExtra("AdditionalRemuneration"));
            int _employeeAge = Intent.GetIntExtra("employeeAge", 0);

            //lifeStyleRelief
            EditText lifeStyleRelief_ = FindViewById<EditText>(Resource.Id.lifeStyleRelief);
            lifeStyleRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.LifeStyleRelief = editTextToDouble.EditTextDeductions_AfterTextChanged(lifeStyleRelief_, 2500);
            };

            //sportsRelief
            EditText sportsRelief_ = FindViewById<EditText>(Resource.Id.sportsRelief);
            sportsRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.SportsRelief = editTextToDouble.EditTextDeductions_AfterTextChanged(sportsRelief_, 500);
            };

            //SOCSOContribution
            SOCSOAndEISCalculations = new SOCSOAndEISCalculations(NormalRemunerationItems, AdditionalRemunerationItems);
            double _SOCSOContribution = SOCSOAndEISCalculations.EmployeeSOCSOCalculation(_employeeAge);
            
            //lifeInsurance
            EditText lifeInsurance_ = FindViewById<EditText>(Resource.Id.lifeInsurance);
            lifeInsurance_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.LifeInsurance = editTextToDouble.EditTextDeductions_AfterTextChanged(lifeInsurance_, 3000);
            };

            //basicEquipment
            EditText basicEquipment_ = FindViewById<EditText>(Resource.Id.basicEquipment);
            basicEquipment_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.SupportingEquipment = editTextToDouble.EditTextDeductions_AfterTextChanged(basicEquipment_, 6000);
            };

            //educationYourSelf
            EditText educationYourSelf_ = FindViewById<EditText>(Resource.Id.educationYourSelf);
            educationYourSelf_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.EducationFeesForSelf = editTextToDouble.EditTextDeductions_AfterTextChanged(educationYourSelf_, 7000);
            };

            //medicalExamination
            EditText medicalExamination_ = FindViewById<EditText>(Resource.Id.medicalExamination);
            medicalExamination_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.MedicalExamination = editTextToDouble.EditTextDeductions_AfterTextChanged(medicalExamination_, 1000);
            };

            //medicalVaccination
            EditText medicalVaccination_ = FindViewById<EditText>(Resource.Id.medicalVaccination);
            medicalVaccination_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.MedicalVaccination = editTextToDouble.EditTextDeductions_AfterTextChanged(medicalVaccination_, 1000);
            };

            //medicalDisease
            EditText medicalDisease_ = FindViewById<EditText>(Resource.Id.medicalDisease);
            medicalDisease_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.MedicalDisease = editTextToDouble.EditTextDeductions_AfterTextChanged(medicalDisease_, 8000); ;
            };
            medicalExamination_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExamination + payrollItems.MedicalVaccination + payrollItems.MedicalDisease, 8000, medicalDisease_);
            };
            medicalVaccination_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExamination + payrollItems.MedicalVaccination + payrollItems.MedicalDisease, 8000, medicalDisease_);
            };
            medicalDisease_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExamination + payrollItems.MedicalVaccination + payrollItems.MedicalDisease, 8000, medicalDisease_);
            };

            //SSPN
            EditText SSPN_ = FindViewById<EditText>(Resource.Id.SSPN);
            SSPN_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.SSPN = editTextToDouble.EditTextDeductions_AfterTextChanged(SSPN_, 8000);
            };

            //PRS
            EditText PRS_ = FindViewById<EditText>(Resource.Id.PRS);
            PRS_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.PRS = editTextToDouble.EditTextDeductions_AfterTextChanged(PRS_, 3000);
            };

            //smallKidEducation
            EditText smallKidEducation_ = FindViewById<EditText>(Resource.Id.smallKidEducation);
            smallKidEducation_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.KindergartenAndChildCareFees = editTextToDouble.EditTextDeductions_AfterTextChanged(smallKidEducation_, 3000);
            };

            //breastFeedingEquipment
            EditText breastFeedingEquipment_ = FindViewById<EditText>(Resource.Id.breastFeedingEquipment);
            breastFeedingEquipment_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.BreastFeedingEquipment = editTextToDouble.EditTextDeductions_AfterTextChanged(breastFeedingEquipment_, 1000);
            };

            //alimonyFormerWife
            EditText alimonyFormerWife_ = FindViewById<EditText>(Resource.Id.alimonyFormerWife);
            alimonyFormerWife_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.AlimonyToFormerWife = editTextToDouble.EditTextDeductions_AfterTextChanged(alimonyFormerWife_, 4000);
            };

            //EMInsurance
            EditText EMInsurance_ = FindViewById<EditText>(Resource.Id.EMInsurance);
            EMInsurance_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.EducationAndMedicalInsurance = editTextToDouble.EditTextDeductions_AfterTextChanged(EMInsurance_, 3000);
            };

            //fatherRelief
            EditText fatherRelief_ = FindViewById<EditText>(Resource.Id.fatherRelief);
            fatherRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.FatherRelief = editTextToDouble.EditTextDeductions_AfterTextChanged(fatherRelief_, 1500);
            };

            //motherRelief
            EditText motherRelief_ = FindViewById<EditText>(Resource.Id.motherRelief);
            motherRelief_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.MotherRelief = editTextToDouble.EditTextDeductions_AfterTextChanged(motherRelief_, 1500);
            };

            //mapaRelief
            EditText mapaRelief_ = FindViewById<EditText>(Resource.Id.mapaRelief);
            mapaRelief_.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double _mapaRelief = 0.00;
            mapaRelief_.AfterTextChanged += (sender, args) =>
            {
                double.TryParse(mapaRelief_.Text, out _mapaRelief);
                payrollItems.MedicalExpenseForParents = _mapaRelief;
                validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExpenseForParents, 8000, mapaRelief_);
                validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.MedicalExpenseForParents, payrollItems.FatherRelief + payrollItems.MotherRelief, mapaRelief_);
            };
            fatherRelief_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.MedicalExpenseForParents, payrollItems.FatherRelief + payrollItems.MotherRelief, mapaRelief_);
            };
            motherRelief_.AfterTextChanged += (sender, args) =>
            {
                validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.MedicalExpenseForParents, payrollItems.FatherRelief + payrollItems.MotherRelief, mapaRelief_);
            };

            //domesticTourismExpenditure
            EditText domesticTourismExpenditure_ = FindViewById<EditText>(Resource.Id.domesticTourismExpenditure);
            domesticTourismExpenditure_.AfterTextChanged += (sender, args) =>
            {
                payrollItems.DomesticTourismExpenditure = editTextToDouble.EditTextDeductions_AfterTextChanged(domesticTourismExpenditure_, 1000);
            };

            Button _fourthContinue = FindViewById<Button>(Resource.Id.continuePayroll4);
            _fourthContinue.Click += (sender, e) => {
                if (validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.LifeStyleRelief, 2500, lifeStyleRelief_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.SportsRelief, 500, sportsRelief_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.LifeInsurance, 3000, lifeInsurance_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.SupportingEquipment, 6000, basicEquipment_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.EducationFeesForSelf, 7000, educationYourSelf_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExamination, 1000, medicalExamination_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalDisease, 8000, medicalDisease_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.KindergartenAndChildCareFees, 3000, smallKidEducation_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.BreastFeedingEquipment, 1000, breastFeedingEquipment_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalVaccination, 1000, medicalVaccination_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.AlimonyToFormerWife, 4000, alimonyFormerWife_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.EducationAndMedicalInsurance, 3000, EMInsurance_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.FatherRelief, 1500, fatherRelief_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MotherRelief, 1500, motherRelief_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExamination + payrollItems.MedicalDisease + payrollItems.MedicalVaccination, 8000, medicalDisease_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.MedicalExpenseForParents, 8000, mapaRelief_) == false
                | validatingDeductions.ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(payrollItems.MedicalExpenseForParents, payrollItems.FatherRelief + payrollItems.MotherRelief, mapaRelief_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.SSPN, 8000, SSPN_) == false
                | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.PRS, 3000, PRS_) == false | validatingDeductions.ValidateDeductionInputsLowerThanLimit(payrollItems.DomesticTourismExpenditure, 1000, domesticTourismExpenditure_) == false)
                {
                    Toast toast = Toast.MakeText(this, "Make sure all fields are below their limits", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    soundPlayer.PlaySound_ButtonClick(this);

                    PayrollCategory payrollCategory = new PayrollCategory(payrollItems);

                    int _monthsRemaining = Intent.GetIntExtra("monthsRemaining", 11);
                    double _EPFContribution = Intent.GetDoubleExtra("EPFContribution", 0.00);
                    double _EPFAdditionalContribution = Intent.GetDoubleExtra("EPFAdditionalContribution", 0.00);
                    string _employeeName = Intent.GetStringExtra("employeeName");

                    Intent intent = new Intent(this, typeof(PayrollRebates));
                    intent.PutExtra("FamilyDeductionItems", JsonConvert.SerializeObject(FamilyDeductionItems));
                    intent.PutExtra("NormalRemuneration", JsonConvert.SerializeObject(NormalRemunerationItems));
                    intent.PutExtra("BIK", JsonConvert.SerializeObject(BIKItems));
                    intent.PutExtra("VOLA", JsonConvert.SerializeObject(VOLAItems));
                    intent.PutExtra("AdditionalRemuneration", JsonConvert.SerializeObject(AdditionalRemunerationItems));
                    intent.PutExtra("Deductions", JsonConvert.SerializeObject(payrollCategory.Deductions));

                    intent.PutExtra("monthsRemaining", _monthsRemaining);
                    intent.PutExtra("employeeAge", _employeeAge);
                    intent.PutExtra("employeeName", _employeeName);
                    intent.PutExtra("EPFAdditionalContribution", _EPFAdditionalContribution);
                    intent.PutExtra("EPFContribution", _EPFContribution);
                    intent.PutExtra("SOCSOContribution", _SOCSOContribution);
                    StartActivity(intent);
                }
            };
        }
    }
}
