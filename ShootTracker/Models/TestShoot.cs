using System;
namespace ShootTracker.Models
{
    public class TestShoot
    {
        public int ID { get; set; }
        public string Good { get; set; }
        public string ShotName { get; set; }
        public int Take { get; set; }
        public string InTimeCode { get; set; }
        public string OutTimeCode { get; set; }
        public string Duration { get; set; }
        public string Audio01 { get; set; }
        public string Audio02 { get; set; }
        public string Comments { get; set; }
        public int ProjectID { get; set; }
    }
}