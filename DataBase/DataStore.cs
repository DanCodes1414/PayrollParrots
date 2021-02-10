using Android.Content;
using Android.Database.Sqlite;

namespace PayrollParrots.DataBase
{
    public class DataStore : SQLiteOpenHelper
    {
        public DataStore(Context context, string _DatabaseName) : base(context, _DatabaseName, null, 1)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(PayrollAccountDetails.CreateQuery);
            db.ExecSQL(PayrollEmployeeDetails.CreateQuery);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(PayrollAccountDetails.DeleteQuery);
            db.ExecSQL(PayrollEmployeeDetails.DeleteQuery);
            OnCreate(db);
        }
    }
}