using Android.Content;
using Android.Preferences;

namespace PayrollParrots.UsedManyTimes
{
    public class SaveSharedPreference
    {
        static readonly string PREF_USER_NAME = "username";

        static ISharedPreferences GetSharedPreferences(Context context)
        {
            return PreferenceManager.GetDefaultSharedPreferences(context);
        }

        public static void SetUserName(Context context, string userName)
        {
            ISharedPreferencesEditor editor = GetSharedPreferences(context).Edit();
            editor.PutString(PREF_USER_NAME, userName);
            editor.Commit();
        }

        public static string GetUserName(Context ctx)
        {
            return GetSharedPreferences(ctx).GetString(PREF_USER_NAME, "");
        }
    }
}
