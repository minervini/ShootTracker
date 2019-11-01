using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ShootTracker.Models;

namespace ShootTracker
{
    public class ShotListRepository
    {
        private static string ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<TestShoot> GetAllShots()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT ID, Good, ShotName, Take, InTimeCode, OutTimeCode, Duration, Audio01, Audio02, Comments, ProjectID FROM Test_Shoot;";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                List<TestShoot> allShots = new List<TestShoot>();
                while (reader.Read())
                {
                    TestShoot currentShot = new TestShoot();
                    currentShot.ID = reader.GetInt32("ID");
                    currentShot.Good = reader.GetString("Good");
                    currentShot.ShotName = reader.GetString("ShotName");
                    currentShot.Take = reader.GetInt32("Take");
                    currentShot.InTimeCode = reader.GetString("InTimeCode");
                    currentShot.OutTimeCode = reader.GetString("OutTimeCode");
                    currentShot.Duration = reader.GetString("Duration");
                    currentShot.Audio01 = reader.GetString("Audio01");
                    currentShot.Audio02 = reader.GetString("Audio02");
                    currentShot.Comments = reader.GetString("Comments");
                    currentShot.ProjectID = reader.GetInt32("ProjectID");

                    allShots.Add(currentShot);
                }
                return allShots;
            }
        }
    }
}
