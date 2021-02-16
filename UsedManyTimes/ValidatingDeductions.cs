using Android.Widget;
namespace PayrollParrots.UsedManyTimes
{
    public class ValidatingDeductions
    {
        //check deduction input is below item limit
        public bool ValidateDeductionInputsLowerThanLimit(double name, double value, EditText editText)
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
                editText.Error = null;
                return true;
            }
        }

        //check Father + Mother Relief + both parents relief not greater than 0
        public bool ValidateBothParentsReliefAndParentsMedicalExpensesNotGreaterThanZero(double name, double name2, EditText editText)
        {
            if ((name > 0) && (name2 > 0))
            {
                editText.Error = "Father Relief/Mother Relief and medical expenses for own parents cannot both be greater than 0";
                return false;
            }
            else
            {
                editText.Error = null;
                return true;
            }
        }
    }
}