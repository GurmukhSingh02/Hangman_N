using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hangman_N.Resources;
using SQLite;

namespace Hangman_N
{
    public class ConClass
    {

        private string dbpath { get; set; }

        private SQLiteConnection db { get; set; }





        public ConClass()
        {

            string dbPath =
                Path.Combine(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.Personal), "HangmanDB.sqlite");

            db = new SQLiteConnection(dbPath);

            db.CreateTable<HangmanScore>();
        }




        public List<HangmanScore> ViewAll()
        {
            try
            {
                ;
                return db.Query<HangmanScore>("select *  from HangmanScore  ORDER BY Score DESC");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }







        public string UpdateScore(int id, string name, int score)
        {


            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "HangmanDB.sqlite");
                var db = new SQLiteConnection(dbPath);
                var item = new HangmanScore();

                item.Id = id;
                item.Name = name;
                item.Score = score;

                db.Update(item);
                return "Record Updated...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }



        public string InsertNewPlayer(string name, int score)
        {


            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "HangmanDB.sqlite");
                var db = new SQLiteConnection(dbPath);
                var item = new HangmanScore();
                item.Name = name;
                item.Score = score;

                db.Insert(item);
                return "You have been added to the database";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }


        public string DeletePlayer(int id)
        {

            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "HangmanDB.sqlite");
                var db = new SQLiteConnection(dbPath);
                var item = new HangmanScore();
                item.Id = id;


                db.Delete(item);
                return "You have been added to the database";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }


        }

    }
}
