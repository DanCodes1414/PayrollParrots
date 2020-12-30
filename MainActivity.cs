using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using PayrollParrots.Model;
using PayrollParrots.Helper;
using Newtonsoft.Json;
using Android.Views;
using System.Linq;

namespace PayrollParrots
{
    //#fix
    //add REP, IRDA, N-R
    //login/signups
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spinner;
        TextView _txtLabel;
        ListView listfilter;
        Payroll payroll;
        Payroll[] listitem;
        GridPayroll adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            DateTime dateToday = DateTime.Now;
            int monthToday = dateToday.Month;

            spinner = FindViewById<Spinner>(Resource.Id.monthSpinnerList);
            var adaptersp = ArrayAdapter.CreateFromResource(this, Resource.Array.month_array, Android.Resource.Layout.SimpleSpinnerItem);
            adaptersp.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adaptersp;
            spinner.SetSelection(monthToday - 1);

            _txtLabel = FindViewById<TextView>(Resource.Id.noEmployees);
            listfilter = (ListView)FindViewById(Resource.Id.filterList);
            _txtLabel.Visibility = ViewStates.Invisible;

            spinner.ItemSelected += BindDataFilter;

            Button _startPayroll = FindViewById<Button>(Resource.Id.startPayroll);
            _startPayroll.Click += (sender, e) => {
                PlayButton_Click(sender, e);
                StartActivity(new Intent(this, typeof(PayrollFamily)));
            };

            void PlayButton_Click(object sender, EventArgs e)
            {
                MediaPlayer _player = MediaPlayer.Create(this, Resource.Drawable.buttonclick);
                _player.Start();
            }
        }
        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Review or Delete?");
            alert.SetMessage("Would you like to see your employee's details or delete this employee?");
            alert.SetIcon(Resource.Drawable.Question_Mark);
            alert.SetButton("Delete", (c, ev) =>
            {
                MediaPlayer player = MediaPlayer.Create(this, Resource.Drawable.alert_sound);
                player.Start();
                Android.App.AlertDialog.Builder dialog2 = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert2 = dialog2.Create();
                alert2.SetTitle("Delete Employee");
                alert2.SetMessage("Are you sure!");
                alert2.SetIcon(Resource.Drawable.Warning_Sign);
                alert2.SetButton("yes", (c, ev) =>
                {
                    TextView _txtLabel;
                    payroll = listitem[e.Position];
                    PayrollHelper.DeletePayroll(this, payroll);
                    _txtLabel = FindViewById<TextView>(Resource.Id.noEmployees);
                    MediaPlayer player = MediaPlayer.Create(this, Resource.Drawable.delete_sound);
                    player.Start();
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
            if(((Spinner)sender).SelectedItem.ToString() == "January")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("January")).ToArray();
                month = "January";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "Febuary")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("Febuary")).ToArray();
                month = "Febuary";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "March")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("March")).ToArray();
                month = "March";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "April")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("April")).ToArray();
                month = "April";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "May")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("May")).ToArray();
                month = "May";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "June")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("June")).ToArray();
                month = "June";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "July")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("July")).ToArray();
                month = "July";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "August")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("August")).ToArray();
                month = "August";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "September")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("September")).ToArray();
                month = "September";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "October")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("October")).ToArray();
                month = "October";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "November")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("November")).ToArray();
                month = "November";
            }
            else if (((Spinner)sender).SelectedItem.ToString() == "December")
            {
                listitem = PayrollHelper.GetPayrollList(this).Where(x => x.Month.Contains("December")).ToArray();
                month = "December";
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