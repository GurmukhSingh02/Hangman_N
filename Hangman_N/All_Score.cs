using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hangman_N.Resources;

namespace Hangman_N
{
    [Activity(Label = "All_Score")]
    public class All_Score : Activity
    {
        List<HangmanScore> myList;
        public ConClass myConnectionClass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.All_Score);

            myConnectionClass = new ConClass();
            myList = myConnectionClass.ViewAll();
            Button btnHighScoresBack = FindViewById<Button>
                (Resource.Id.btnHighScoresBack);

            btnHighScoresBack.Click += btnHighScoresBack_Click;

            // Display the player names and high scores 
            ListView HighScoresListView = FindViewById<ListView>(Resource.Id.HighScoresListView);
            HighScoresListView.Adapter = new List_Adp(this, myList);
        }

        private void btnHighScoresBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}