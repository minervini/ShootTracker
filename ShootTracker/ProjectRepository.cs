using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ShootTracker.Models;
using System;

namespace ShootTracker
{
    public class ProjectRepository
    {
        private static string ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<Project>GetProjects()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM Project";

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

        public void CreateProject(Project projectToCreate)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO project (ProjectName, ShootDate) Values (@projectName, @shootDate)";
            cmd.Parameters.AddWithValue("projectName", projectToCreate.ProjectName);
            cmd.Parameters.AddWithValue("shootDate", projectToCreate.ShootDate);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProject(int projectID)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "Delete FROM project WHERE ProjectID = @projectID;";
                cmd.Parameters.AddWithValue("projectID", projectID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
