using System;
namespace ShootTracker.Models
{
    public class TestShoot
    {
        public int ID { get; set; }
        public string Good { get; set; }
        public string ShotName { get; set; }
        public int Take { get; set; }
        public DateTime In_TC { get; set; }
        public DateTime Out_TC { get; set; }
        public DateTime Duration { get; set; }
        public string AudioChannel_1 { get; set; }
        public string AudioChannel_2 { get; set; }
        public string Commits { get; set; }
    }
}
