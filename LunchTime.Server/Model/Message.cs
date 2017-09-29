using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Server.Model
{
    public class Message
    {
        public string Username { get; set; }

        public string MessageText { get; set; }

        public DateTime CreatedTimeStamp { get; set; }
    }
}
