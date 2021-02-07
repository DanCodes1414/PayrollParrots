using System.Text.RegularExpressions;
using Android.Text;

namespace PayrollParrots.UsedManyTimes
{
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