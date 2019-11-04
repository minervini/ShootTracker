using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ShootTracker.Models;

namespace ShootTracker
{
    public class ProjectRepository
    {
        private static string ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<Project>GetProjects()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT ProjectID, ProjectName, ShootDate FROM Project";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Project> allProjects = new List<Project>();
                while (reader.Read())
                {
                    Project currentProject = new Project();
                    currentProject.ProjectID = reader.GetInt32("ProjectID");
                    currentProject.ProjectName = reader.GetString("ProjectName");
                    currentProject.ShootDate = reader.GetString("ShootDate");

                    allProjects.Add(currentProject);
                }
                return allProjects;
            }
        }
    }
}
