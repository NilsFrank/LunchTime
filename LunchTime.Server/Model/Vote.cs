using System;
using System.Collections.Generic;

namespace LunchTime.Server.Model
{
    public class Vote
    {
        public Location location { get; set; }
        public Guid guid { get; set; }
    }

    public class Votes
    {
        public List<Vote> votes { get; set; }
    }
}