using System.Collections.Generic;
using Android.Content;
using Android.Database.Sqlite;
using PayrollParrots.Model;
using Android.Database;
namespace PayrollParrots.Helper
{
    public class PayrollHelper
    {
        private const string TableName = "payrollTable";
        private const string ColumnID = "Id";
        private const string ColumnName = "Name";
        private const string ColumnAge = "Age";
        private const string ColumnMonth = "Month";
        private const string ColumnPCB = "PCB";
        private const string ColumnEPF = "EPF";
        private const string ColumnSOCSO = "SOCSO";
        private const string ColumnEIS = "EIS";
        private const string ColumnGross = "GrossSalary";
        private const string ColumnNet = "NetSalary";
        private const string ColumnEmployerEPF = "EmployerEPF";
        private const string ColumnEmployerSOCSO = "EmployerSOCSO";
        private const string ColumnEmployerEIS = "EmployerEIS";
        public const string CreateQuery = "CREATE TABLE " + TableName + " ( "
            + ColumnID + " INTEGER PRIMARY KEY,"
               + ColumnName + " TEXT,"
               + ColumnAge + " TEXT,"
               + ColumnMonth + " TEXT,"
               + ColumnPCB + " TEXT,"
               + ColumnEPF + " TEXT,"
               + ColumnSOCSO + " TEXT,"
               + ColumnEIS + " TEXT,"
               + ColumnGross + " TEXT,"
               + ColumnNet + " TEXT,"
               + ColumnEmployerEPF + " TEXT,"
               + ColumnEmployerSOCSO + " TEXT,"
               + ColumnEmployerEIS + " TEXT)";


        public const string DeleteQuery = "DROP TABLE IF EXISTS " + TableName;

        public PayrollHelper()
        {
        }

        public static void InsertPayrollData(Context context, Payroll payroll)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            ContentValues contentValues = new ContentValues();
            contentValues.Put(ColumnName, payroll.Name);
            contentValues.Put(ColumnAge, payroll.Age);
            contentValues.Put(ColumnMonth, payroll.Month);
            contentValues.Put(ColumnPCB, payroll.PCB);
            contentValues.Put(ColumnEPF, payroll.EPFMain);
            contentValues.Put(ColumnSOCSO, payroll.SOCSO);
            contentValues.Put(ColumnEIS, payroll.EIS);
            contentValues.Put(ColumnGross, payroll.GrossSalary);
            contentValues.Put(ColumnNet, payroll.NetSalary);
            contentValues.Put(ColumnEmployerEPF, payroll.EmployerEPF);
            contentValues.Put(ColumnEmployerSOCSO, payroll.EmployerSOCSO);
            contentValues.Put(ColumnEmployerEIS, payroll.EmployerEIS);

            db.Insert(TableName, null, contentValues);
            db.Close();
        }

        public static Payroll SelectPayroll(Context context, int payrollId)
        {
            Payroll payroll;
            SQLiteDatabase db = new DataStore(context).ReadableDatabase;
            string[] columns = new string[] { ColumnID, ColumnName, ColumnAge, ColumnMonth, ColumnPCB, ColumnEPF, ColumnSOCSO, ColumnEIS, ColumnGross, ColumnNet, ColumnEmployerEPF, ColumnEmployerSOCSO, ColumnEmployerEIS };
            using (ICursor cursor = db.Query(TableName, columns, ColumnID + "=" + payrollId, null, null, null, null))
            {
                if (cursor.MoveToNext())
                {
                    payroll = new Payroll
                    {
                        Id = cursor.GetInt(cursor.GetColumnIndexOrThrow(ColumnID)),
                        Name = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnName)),
                        Age = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnAge)),
                        Month = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnMonth)),
                        PCB = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnPCB)),
                        EPFMain = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEPF)),
                        SOCSO = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnSOCSO)),
                        EIS = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEIS)),
                        GrossSalary = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnGross)),
                        NetSalary = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnNet)),
                        EmployerEPF = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmployerEPF)),
                        EmployerEIS = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmployerSOCSO)),
                        EmployerSOCSO = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmployerEIS))
                    };
                }
                else
                {
                    payroll = null;
                }
            }
            return payroll;
        }

        public static List<Payroll> GetPayrollList(Context context)
        {
            List<Payroll> payroll = new List<Payroll>();
            SQLiteDatabase db = new DataStore(context).ReadableDatabase;
            string[] columns = new string[] { ColumnID, ColumnName, ColumnAge, ColumnMonth, ColumnPCB, ColumnEPF, ColumnSOCSO, ColumnEIS, ColumnGross, ColumnNet, ColumnEmployerEPF, ColumnEmployerSOCSO, ColumnEmployerEIS };

            using (ICursor cursor = db.Query(TableName, columns, null, null, null, null, null))
            {
                while (cursor.MoveToNext())
                {
                    payroll.Add(new Payroll
                    {
                        Id = cursor.GetInt(cursor.GetColumnIndexOrThrow(ColumnID)),
                        Name = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnName)),
                        Age = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnAge)),
                        Month = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnMonth)),
                        PCB = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnPCB)),
                        EPFMain = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEPF)),
                        SOCSO = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnSOCSO)),
                        EIS = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEIS)),
                        GrossSalary = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnGross)),
                        NetSalary = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnNet)),
                        EmployerEPF = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmployerEPF)),
                        EmployerEIS = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmployerSOCSO)),
                        EmployerSOCSO = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnEmployerEIS))
                    });
                }
            }
            db.Close();
            return payroll;
        }

        public static void DeletePayroll(Context context, Payroll payroll)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            db.Delete(TableName, ColumnName + "=? AND " + ColumnAge + "=? AND " + ColumnMonth + "=? AND " + ColumnPCB + "=? AND " + ColumnEPF + "=? AND " + ColumnSOCSO + "=? AND " + ColumnEIS + "=? AND " + ColumnGross + "=? AND " + ColumnNet + "=? AND " + ColumnEmployerEPF + "=? AND " + ColumnEmployerSOCSO + "=? AND " + ColumnEmployerEIS + "=? OR " + ColumnID + "=" + payroll.Id, new string[] { payroll.Name });
            db.Close();

        }
    }
}