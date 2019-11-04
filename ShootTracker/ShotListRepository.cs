using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ShootTracker.Models;

namespace ShootTracker
{
    public class ShotListRepository
    {
        private static string ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<Shoot> GetAllShots()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT ID, Good, ShotName, Take, InTimeCode, OutTimeCode, Duration, Audio01, Audio02, Comments, ProjectID FROM Test_Shoot;";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Shoot> allShots = new List<Shoot>();
                while (reader.Read())
                {
                    Shoot currentShoot = new Shoot();
                    currentShoot.ID = reader.GetInt32("ID");
                    currentShoot.Good = reader.GetString("Good");
                    currentShoot.ShotName = reader.GetString("ShotName");
                    currentShoot.Take = reader.GetInt32("Take");
                    currentShoot.InTimeCode = reader.GetString("InTimeCode");
                    currentShoot.OutTimeCode = reader.GetString("OutTimeCode");
                    currentShoot.Duration = reader.GetString("Duration");
                    currentShoot.Audio01 = reader.GetString("Audio01");
                    currentShoot.Audio02 = reader.GetString("Audio02");
                    currentShoot.Comments = reader.GetString("Comments");
                    currentShoot.ProjectID = reader.GetInt32("ProjectID");
                             
                    allShots.Add(currentShoot);
                }
                return allShots;
            }
        }
    }
}
