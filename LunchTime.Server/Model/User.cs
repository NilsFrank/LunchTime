using System;
using System.Collections.Generic;

namespace LunchTime.Server.Model
{
    public class User
    {
        public Guid guid { get; set; }
        public string username { get; set; }
    }

    public class Users
    {
        public List<User> users { get; set; }
    }
}