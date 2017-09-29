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

        public void Send(Message message)
        {
            Clients.All.addMessage(message);
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

        public void Vote(Location location,
                         Guid user)
        {
            var votes = Helper.GetAllFromJson<Votes>(votePath);
            Votes newVotes = votes;

            foreach (var vote in votes.votes)
            {
                if (vote.guid == user)
                {
                    newVotes.votes.Remove(vote);
                }
            }

            newVotes.votes.Add(new Vote
            {
                location = location,
                guid = user
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

        public void GetUser(Guid guid)
        {
            var user = Helper.GetUserForGuid(userPath, guid);

            Clients.Caller.getUser(user);
        }
    }

    public static class Helper
    {
        public static T GetAllFromJson<T>(string path)
        {
            StreamReader reader = new StreamReader(path);
            T jsonObject = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());

            return jsonObject;
        }

        public static User GetUserForGuid(string path,
                                          Guid guid)
        {
            var users = GetAllFromJson<Users>(path);

            return users.users.FirstOrDefault(x => x.guid == guid);
        }
    }
}