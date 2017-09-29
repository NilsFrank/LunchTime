using System.Collections.Generic;

namespace LunchTime.Server.Model
{
    public class Location
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Locations
    {
        public List<Location> locations { get; set; }
    }
}
