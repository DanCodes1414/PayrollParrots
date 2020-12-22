using Android.Content;
using Android.Database.Sqlite;

namespace PayrollParrots.Helper
{
    public class DataStore : SQLiteOpenHelper
    {
        private static readonly string _DatabaseName = "payrollDB12.db";
        public DataStore(Context context) : base(context, _DatabaseName, null, 1)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(PayrollHelper.CreateQuery);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(PayrollHelper.DeleteQuery);
            OnCreate(db);
        }
    }
}