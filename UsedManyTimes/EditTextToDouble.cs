using Android.Text;
using Android.Widget;

namespace PayrollParrots.UsedManyTimes
{
    public class EditTextToDouble
    {
        readonly ValidatingDeductions validatingDeductions = new ValidatingDeductions();

        public double EditText_AfterTextChanged(EditText editText)
        {
            editText.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double.TryParse(editText.Text, out  double editTextdouble);
            return editTextdouble;
        }

        public double EditTextDeductions_AfterTextChanged(EditText editText, double deductionLimit)
        {
            editText.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double.TryParse(editText.Text, out double editTextdouble);
            validatingDeductions.ValidateDeductionInputsLowerThanLimit(editTextdouble, deductionLimit, editText);
            return editTextdouble;
        }

        public double EditTextPreviousDeductions_AfterTextChanged(EditText editText, double currentMonthDeductions, double deductionLimit)
        {
            editText.SetFilters(new IInputFilter[] { new DecimalDigitsInputFilter(12, 2) });
            double.TryParse(editText.Text, out double editTextdouble);
            validatingDeductions.ValidateDeductionInputsLowerThanLimit(editTextdouble + currentMonthDeductions, deductionLimit, editText);
            return editTextdouble;
        }
    }
}
