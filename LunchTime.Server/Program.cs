using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchTime.Server.Model;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Owin;

namespace LunchTime.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    public class MyHub : Hub
    {
        private const string votePath = "Content/Votes.json";
        private const string locationPath = "Content/Locations.json";
        private const string userPath = "Content/User.json";

        public List<User> Users = new List<User>();

        public void Send(string message,
                         User user)
        {
            foreach (var checkUser in Users)
            {
                if (checkUser.guid == user.guid)
                {
                    if (checkUser.username != user.username)
                    {
                        checkUser.username = user.username;
                    }
                }
            }

            var newMessage = new Message
            {
                CreatedTimeStamp = DateTime.Now,
                MessageText = message,
                Username = user.username
            };

            Clients.All.addMessage(newMessage);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public void GetAllLocations()
        {
            var locations = Helper.GetAllFromJson<Locations>(locationPath);
            Clients.Caller.getAllLocations(locations);
        }

        public void GetAllVotes()
        {
            var votes = Helper.GetAllFromJson<Votes>(votePath);
            Clients.Caller.getAllVotes(votes);
        }

        public void RegisterUser(User user)
        {
            var hasUser = Users.Any(x => x.guid == user.guid);

            if (!hasUser)
            {
                Users.Add(user);
            }
        }

        public void Vote(Location location,
                         User user)
        {
            var votes = Helper.GetAllFromJson<Votes>(votePath);
            Votes newVotes = Helper.GetAllFromJson<Votes>(votePath);

            foreach (var vote in votes.votes)
            {
                if (vote.guid == user.guid)
                {
                    newVotes.votes.Remove(vote);
                }
            }

            newVotes.votes.Add(new Vote
            {
                location = location,
                guid = user.guid
            });

            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(votePath, false);
                var jsonString = JsonConvert.SerializeObject(newVotes);
                writer.Write(jsonString);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            Clients.All.vote(newVotes);
        }
    }

    public static class Helper
    {
        public static T GetAllFromJson<T>(string path)
        {
            StreamReader reader = new StreamReader(path);
            T jsonObject = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            reader.Close();

            return jsonObject;
        }
    }
}