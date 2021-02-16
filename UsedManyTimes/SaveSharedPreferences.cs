using Android.Content;
using Android.Preferences;

namespace PayrollParrots.UsedManyTimes
{
    public class SaveSharedPreference
    {
        static readonly string PREF_DATA_BASE_NAME = "dataBaseName";

        static ISharedPreferences GetSharedPreferences(Context context)
        {
            return PreferenceManager.GetDefaultSharedPreferences(context);
        }

        public static void SetDataBaseName(Context context, string dataBaseName)
        {
            ISharedPreferencesEditor editor = GetSharedPreferences(context).Edit();
            editor.PutString(PREF_DATA_BASE_NAME, dataBaseName);
            editor.Commit();
        }

        public static string GetDataBaseName(Context ctx)
        {
            return GetSharedPreferences(ctx).GetString(PREF_DATA_BASE_NAME, "");
        }
    }
}
