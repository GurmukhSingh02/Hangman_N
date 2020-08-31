using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Hangman_N.Assets;

namespace Hangman_N
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnNew;
        private Button btn_High_Scores;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            btnNew = FindViewById<Button>(Resource.Id.btnNewGameScreen);
            btnNew.Click += btnNew_Click;

            btn_High_Scores = FindViewById<Button>(Resource.Id.btnHighScores);
            btn_High_Scores.Click += btn_High_Scores_Click;
        }

        private void btn_High_Scores_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(All_Score));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Player));
        }
    }
}
