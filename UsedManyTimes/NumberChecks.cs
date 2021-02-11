namespace PayrollParrots.UsedManyTimes
{
    public static class NumberChecks
    {
        public static bool IsPositive(double number)
        {
            return number > 0.00;
        }

        public static bool IsNegative(double number)
        {
            return number < 0.00;
        }

        public static bool IsZero(double number)
        {
            return number == 0.00;
        }

        public static bool IsNegativeOrZero(double number)
        {
            return number <= 0.00;
        }
    }
}
