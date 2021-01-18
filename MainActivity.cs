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

namespace PayrollParrots
{
    public enum Months
    {
        January,
        Febuary,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
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

            spinnerMonth.ItemSelected += BindDataFilter;

            Button _startPayroll = FindViewById<Button>(Resource.Id.startPayroll);

            _startPayroll.Click += (sender, e) => {
                soundPlayer.PlaySound_ButtonClick(this);
                StartActivity(new Intent(this, typeof(PayrollFamily)));
            };
        }

        //pop-up when item in list is clicked
        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Review or Delete?");
            alert.SetMessage("Would you like to see your employee's details or delete this employee?");
            alert.SetIcon(Resource.Drawable.Question_Mark);
            alert.SetButton("Delete", (c, ev) =>
            {
                soundPlayer.PlaySound_AlertWarning(this);
                Android.App.AlertDialog.Builder dialog2 = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert2 = dialog2.Create();
                alert2.SetTitle("Delete Employee");
                alert2.SetMessage("Are you sure!");
                alert2.SetIcon(Resource.Drawable.Warning_Sign);
                alert2.SetButton("yes", (c, ev) =>
                {
                    payroll = listitem[e.Position];
                    PayrollHelper.DeletePayroll(this, payroll);

                    soundPlayer.PlaySound_DeleteEmployee(this);

                    StartActivity(new Intent(this, typeof(MainActivity)));
                    Toast.MakeText(this, "Employee Deleted Sucessfully!", ToastLength.Short).Show();
                    GC.Collect();
                });
                alert2.SetButton2("no", (c, ev) => { });
                alert2.Show();
            });
            alert.SetButton2("Review", (c, ev) =>
            {
                payroll = PayrollHelper.SelectPayroll(this, listitem[e.Position].Id);
                var intent = new Intent(this, typeof(PayrollReview));
                intent.PutExtra("payroll", JsonConvert.SerializeObject(payroll));
                StartActivity(intent);
            });
            alert.SetButton3("Cancel", (c, ev) => { });

            alert.Show();
        }

        private void BindDataFilter(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            string month = "";
            if (((Spinner)sender).SelectedItem.ToString() == Months.January.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.January.ToString())).ToArray();
                month = Months.January.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.Febuary.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.Febuary.ToString())).ToArray();
                month = Months.Febuary.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.March.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.March.ToString())).ToArray();
                month = Months.March.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.April.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.April.ToString())).ToArray();
                month = Months.April.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.May.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.May.ToString())).ToArray();
                month = Months.May.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.June.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.June.ToString())).ToArray();
                month = Months.June.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.July.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.July.ToString())).ToArray();
                month = Months.July.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.August.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.August.ToString())).ToArray();
                month = Months.August.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.September.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.September.ToString())).ToArray();
                month = Months.September.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.October.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.October.ToString())).ToArray();
                month = Months.October.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.November.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.November.ToString())).ToArray();
                month = Months.November.ToString();
            }
            else if (((Spinner)sender).SelectedItem.ToString() == Months.December.ToString())
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains(Months.December.ToString())).ToArray();
                month = Months.December.ToString();
            }
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
                _txtLabel.Text = "No employees for " + month + "!!";
            }
        }
    }
}
