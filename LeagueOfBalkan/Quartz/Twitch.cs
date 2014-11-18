using System;
using System.Collections.Generic;
using LeagueOfBalkan.Models;
using System.Net;
using Newtonsoft.Json;
using Quartz;
using System.Linq;

namespace LeagueOfBalkan.Quartz
{
    public class Twitch : IJob
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Execute(IJobExecutionContext context)
        {
            dynamic results;

            var urlx = "https://api.twitch.tv/kraken/streams?game=League+of+Legends";

            using (var w = new WebClient())
            {
                var json_data = string.Empty;

                try
                {
                    json_data = w.DownloadString(urlx);
                }
                catch (Exception) { }

                results = JsonConvert.DeserializeObject(json_data);
            }

            var viewers = new List<int>();
            var medium = new List<string>();
            var display_name = new List<string>();
            var logo = new List<string>();
            var status = new List<string>();
            var url = new List<string>();

            foreach (dynamic item in results.streams)
            {
                viewers.Add((int)item.viewers);
                medium.Add((string)item.preview.medium);
                display_name.Add((string)item.channel.display_name);
                logo.Add((string)item.channel.logo);
                if ((string)item.channel.status == null)
                {
                    status.Add((string)item.channel.display_name);
                }
                else
                {
                    status.Add((string)item.channel.status);
                }

                if ((string)item.channel.url == null)
                {
                    url.Add("www.twitch.tv");
                }
                else
                {
                    url.Add((string)item.channel.url);
                }
            }

            var i = 0;
            var x = 80;
            foreach (dynamic item in results.streams)
            {
                var tw = db.TwitchData.Single(t => t.ID == x);
                tw.viewers = viewers[i];
                tw.medium = medium[i];
                tw.display_name = display_name[i];
                tw.logo = logo[i];
                tw.status = status[i];
                tw.url = url[i];

                //db.TwitchData.Add(twitch);
                //db.Entry(twitch).State = EntityState.Modified;
                i++;
                x++;
            }
            db.SaveChanges();
        }

        public void GetData()
        {
            dynamic results;

            var urlx = "https://api.twitch.tv/kraken/streams?game=League+of+Legends";

            using (var w = new WebClient())
            {
                var json_data = string.Empty;

                try
                {
                    json_data = w.DownloadString(urlx);
                }
                catch (Exception) { }

                results = JsonConvert.DeserializeObject(json_data);
            }

            var viewers = new List<int>();
            var medium = new List<string>();
            var display_name = new List<string>();
            var logo = new List<string>();
            var status = new List<string>();
            var url = new List<string>();

            foreach (dynamic item in results.streams)
            {
                viewers.Add((int)item.viewers);
                medium.Add((string)item.preview.medium);
                display_name.Add((string)item.channel.display_name);
                logo.Add((string)item.channel.logo);
                status.Add((string)item.channel.status);
                url.Add((string)item.channel.url);
            }

            var i = 0;

            foreach (dynamic item in results.streams)
            {
                var twitch = new TwitchData
                {
                    viewers = viewers[i],
                    medium = medium[i],
                    display_name = display_name[i],
                    logo = logo[i],
                    status = status[i],
                    url = url[i]
                };

                db.TwitchData.Add(twitch);
                db.SaveChanges();

                i++;
            }
        }
    }
}