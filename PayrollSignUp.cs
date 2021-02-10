using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using PayrollParrots.Model;
using PayrollParrots.UsedManyTimes;
using PayrollParrots.DataBase;
using System.Linq;
using System.IO;

namespace PayrollParrots
{
    [Activity(Label = "PayrollSignUp")]
    public class PayrollSignUp : Activity
    {
        PayrollAccount payrollAccount;
        PayrollAccount[] emailItem;
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_signup);

            TextView goToLogIn = FindViewById<TextView>(Resource.Id.goToLogInLayout);
            EditText companyName = FindViewById<EditText>(Resource.Id.companyName);
            EditText emailID = FindViewById<EditText>(Resource.Id.emailsignup);
            EditText passwordID = FindViewById<EditText>(Resource.Id.passwordsignup);

            goToLogIn.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(PayrollLogin)));
            };

            Button signUp = FindViewById<Button>(Resource.Id.signup);

            signUp.Click += (sender, e) => {
                string Email = emailID.Text.ToString();
                string DatabaseName = Email.Replace("@", "").Replace(".", "") + ".db";
                emailItem = PayrollAccountDetails.GetAccountList(this, DatabaseName).Where(x => x.Email.Equals(Email)).ToArray();
                if (string.IsNullOrEmpty(companyName.Text) | string.IsNullOrEmpty(emailID.Text) | string.IsNullOrEmpty(passwordID.Text))
                {
                    Toast.MakeText(this, "Make sure all fields are not empty!", ToastLength.Long).Show();
                }
                else if (!IsEmailValid(Email))
                {
                    emailID.Error = "Invalid Email!";
                    Toast.MakeText(this, "Invalid Email!", ToastLength.Short).Show();
                }
                else if (emailItem.Length > 0)
                {
                    emailID.Error = "Email already exists!";
                    Toast.MakeText(this, "Email already exists!", ToastLength.Short).Show();
                }
                else
                {
                    payrollAccount = new PayrollAccount
                    {
                        CompanyName = companyName.Text,
                        Email = emailID.Text,
                        Password = passwordID.Text
                    };

                    soundPlayer.PlaySound_ButtonClick(this);

                    PayrollAccountDetails.InsertAccountDetails(this, payrollAccount, DatabaseName);

                    Toast.MakeText(this, "Account Created! Login now!", ToastLength.Long).Show();

                    StartActivity(new Intent(this, typeof(PayrollLogin)));
                }
            };
        }

        bool IsEmailValid(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }
    }
}
