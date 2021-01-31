using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using PayrollParrots.Model;
using PayrollParrots.Helper;
using Newtonsoft.Json;
using Android.Views;
using System.Linq;
using PayrollParrots.UsedManyTimes;
using AlertDialog = Android.App.AlertDialog;

namespace PayrollParrots
{
    public enum Months
    {
        January = 11,
        Febuary = 10,
        March = 9,
        April = 8,
        May = 7,
        June = 6,
        July = 5,
        August = 4,
        September = 3,
        October = 2,
        November = 1,
        December = 0
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        Spinner spinnerMonth;
        TextView _txtLabel;
        ListView listfilter;
        Payroll payroll;
        Payroll[] listitem;
        GridPayroll adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //get todays month
            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;

            spinnerMonth = FindViewById<Spinner>(Resource.Id.monthSpinnerList);
            var adapterMonth = ArrayAdapter.CreateFromResource(this, Resource.Array.month_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterMonth.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerMonth.Adapter = adapterMonth;

            //set spinner startup month
            spinnerMonth.SetSelection(monthToday - 1);

            _txtLabel = FindViewById<TextView>(Resource.Id.noEmployees);
            listfilter = (ListView)FindViewById(Resource.Id.filterList);
            _txtLabel.Visibility = ViewStates.Invisible;

            spinnerMonth.ItemSelected += BindDataFilterTest;

            Button _startPayroll = FindViewById<Button>(Resource.Id.startPayroll);

            _startPayroll.Click += (sender, e) => {
                soundPlayer.PlaySound_ButtonClick(this);
                StartActivity(new Intent(this, typeof(PayrollFamily)));
            };
        }

        //pop-up when item in list is clicked
        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            AlertDialog.Builder dialogReviewOrDelete = new AlertDialog.Builder(this)
                .SetTitle("Review or Delete?")
                .SetMessage("Would you like to see your employee's details or delete this employee?")
                .SetIcon(Resource.Drawable.Question_Mark)
                .SetPositiveButton("Delete", (c, ev) =>
                {
                    soundPlayer.PlaySound_AlertWarning(this);
                    AlertDialog.Builder dialogDelete = new AlertDialog.Builder(this)
                    .SetTitle("Delete Employee")
                    .SetMessage("Are you sure!")
                    .SetIcon(Resource.Drawable.Warning_Sign)
                    .SetPositiveButton("yes", (c, ev) =>
                    {
                        payroll = listitem[e.Position];
                        PayrollHelper.DeletePayroll(this, payroll);

                        soundPlayer.PlaySound_DeleteEmployee(this);

                        StartActivity(new Intent(this, typeof(MainActivity)));
                        Toast.MakeText(this, "Employee Deleted Sucessfully!", ToastLength.Short).Show();
                        GC.Collect();
                    })
                    .SetNegativeButton("no", (c, ev) => { });

                    AlertDialog alertDelete = dialogDelete.Create();
                    alertDelete.Show();
                })
                .SetNegativeButton("Review", (c, ev) =>
                {
                    payroll = PayrollHelper.SelectPayroll(this, listitem[e.Position].Id);
                    var intent = new Intent(this, typeof(PayrollReview));
                    intent.PutExtra("payroll", JsonConvert.SerializeObject(payroll));
                    StartActivity(intent);
                })
                .SetNeutralButton("Cancel", (c, ev) => { });

            AlertDialog alertReviewOrDelete = dialogReviewOrDelete.Create();
            alertReviewOrDelete.Show();
        }

        private void BindDataFilterTest(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(((Spinner)sender).SelectedItem.ToString())).OrderBy(y => y.Name).ToArray();
            if (listitem.Length > 0)
            {
                listfilter.Visibility = ViewStates.Visible;
                _txtLabel.Visibility = ViewStates.Invisible;
                adapter = new GridPayroll(this, listitem);
                listfilter.Adapter = adapter;
                listfilter.ItemClick += List_ItemClick;
            }
            else
            {
                listfilter.Visibility = ViewStates.Invisible;
                _txtLabel.Visibility = ViewStates.Visible;
                _txtLabel.Text = "No employees for " + ((Spinner)sender).SelectedItem.ToString() + "!!";
            }
        }
    }
}
