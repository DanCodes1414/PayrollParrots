using System.Collections.Generic;
using Android.Content;
using Android.Database.Sqlite;
using PayrollParrots.Model;
using Android.Database;

namespace PayrollParrots.DataBase
{
    public class PayrollAccountDetails
    {
        private const string TableName = "AccountTable";
        private const string ColumnID = "ID";
        private const string ColumnCompanyName = "CompanyName";
        private const string ColumnEmail = "Email";
        private const string ColumnPassword = "Password";
        public const string CreateQuery = "CREATE TABLE " + TableName + " ( "
            + ColumnID + " INTEGER PRIMARY KEY,"
               + ColumnCompanyName + " TEXT,"
               + ColumnEmail + " TEXT,"
               + ColumnPassword + " TEXT)";


        public const string DeleteQuery = "DROP TABLE IF EXISTS " + TableName;

        public PayrollAccountDetails()
        {
        }

        public static void InsertAccountDetails(Context context, PayrollAccount payrollAccount, string Email)
        {
            SQLiteDatabase db = new DataStore(context, Email).WritableDatabase;
            ContentValues contentValues = new ContentValues();
            contentValues.Put(ColumnCompanyName, payrollAccount.CompanyName);
            contentValues.Put(ColumnEmail, payrollAccount.Email);
            contentValues.Put(ColumnPassword, payrollAccount.Password);

            db.Insert(TableName, null, contentValues);
            db.Close();
        }

        public static PayrollAccount Authenticate(Context context, PayrollAccount payrollAccount, string Email)
        {
            SQLiteDatabase db = new DataStore(context, Email).ReadableDatabase;
            string[] columns = new string[] { ColumnID, ColumnCompanyName, ColumnEmail, ColumnPassword };
            ICursor cursor = db.Query(TableName, columns,
            ColumnEmail + "=?", new string[] { payrollAccount.Email }, null, null, null);
            if (cursor != null && cursor.MoveToFirst() && cursor.Count > 0)
            {
                PayrollAccount account1 = new PayrollAccount(cursor.GetString(3));
                if (payrollAccount.Password.Equals(account1.Password))
                {
                    return account1;
                }
            }
            return null;
        }

        public static List<PayrollAccount> GetAccountList(Context context, string Email)
        {
            List<PayrollAccount> payrollAccount = new List<PayrollAccount>();
            SQLiteDatabase db = new DataStore(context, Email).ReadableDatabase;
            string[] columns = new string[] { ColumnID, ColumnCompanyName, ColumnEmail, ColumnPassword };

            using (ICursor cursor = db.Query(TableName, columns, null, null, null, null, null))
            {
                while (cursor.MoveToNext())
                {
                    payrollAccount.Add(new PayrollAccount
                    {
                        Id = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnID)),
                        CompanyName = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnCompanyName)),
                        Email = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmail)),
                        Password = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnPassword))
                    });
                }
            }
            db.Close();
            return payrollAccount;
        }
    }
}