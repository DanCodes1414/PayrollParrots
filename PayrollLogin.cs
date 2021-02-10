using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using PayrollParrots.DataBase;
using PayrollParrots.Model;
using PayrollParrots.UsedManyTimes;

namespace PayrollParrots
{
    [Activity(Label = "PayrollLogin", MainLauncher = true)]
    public class PayrollLogin : Activity
    {
        PayrollAccount[] emailItem;
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (SaveSharedPreference.GetUserName(this).Length > 0)
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                string DatabaseName = SaveSharedPreference.GetUserName(this).Replace("@", "").Replace(".", "") + ".db";
                intent.PutExtra("email", DatabaseName);
                StartActivity(intent);
            }

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payroll_login);

            TextView goToSignUp = FindViewById<TextView>(Resource.Id.goToSignUpLayout);
            EditText emailID = FindViewById<EditText>(Resource.Id.emaillogin);
            EditText passwordID = FindViewById<EditText>(Resource.Id.passwordlogin);

            goToSignUp.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(PayrollSignUp)));
            };

            Button logIn = FindViewById<Button>(Resource.Id.login);

            logIn.Click += (sender, e) =>
            {
                string Email = emailID.Text.ToString();
                string Password = passwordID.Text.ToString();
                string DatabaseName = Email.Replace("@", "").Replace(".", "") + ".db";

                emailItem = PayrollAccountDetails.GetAccountList(this, DatabaseName).Where(x => x.Email.Equals(Email)).ToArray();

                var user = PayrollAccountDetails.Authenticate(this, new PayrollAccount(null, null, Email, Password), DatabaseName);

                if (user != null)
                {
                    Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();
                    soundPlayer.PlaySound_ButtonClick(this);
                    SaveSharedPreference.SetUserName(this, DatabaseName);

                    Intent intent = new Intent(this, typeof(MainActivity));
                    intent.PutExtra("email", DatabaseName);
                    StartActivity(intent);
                }
                else if (emailItem.Length == 0)
                {
                    emailID.Error = "Email does not exist";
                    Toast.MakeText(this, "Email does not exist", ToastLength.Short).Show();
                }
                else
                {
                    passwordID.Error = "Password is incorrect";
                    Toast.MakeText(this, "Login Failed! Please verify your Password", ToastLength.Short).Show();
                }
            };
        }
    }
}
