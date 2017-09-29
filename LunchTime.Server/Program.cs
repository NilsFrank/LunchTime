using System;
using System.Collections.Generic;
using System.IO;
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

        public void Send(string name,
                         string message)
        {
            Clients.All.addMessage(name, message);
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
            var locations = Helper.GetAllFromJson<Location>(locationPath);
            Clients.Caller.addMessage(locations);
        }

        public void GetAllVotes()
        {
            var votes = Helper.GetAllFromJson<Vote>(votePath);
            Clients.Caller.addMessage(votes);
        }

        public void Vote(Location location,
                         string user)
        {
            var votes = Helper.GetAllFromJson<Vote>(votePath);
            List<Vote> newVotes = votes;

            foreach (var vote in votes)
            {
                if (vote.User == user)
                {
                    newVotes.Remove(vote);
                }
            }

            newVotes.Add(new Vote
            {
                Location = location,
                User = user
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

            Clients.All.addMessage(newVotes);
        }
    }

    public static class Helper
    {
        public static List<T> GetAllFromJson<T>(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<T> jsonObject = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());

            return jsonObject;
        }
    }
}