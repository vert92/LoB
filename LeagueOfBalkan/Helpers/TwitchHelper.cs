﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace LeagueOfBalkan.Helpers
{
    public static class TwitchHelper
    {
        private static T _downloadTwitchData<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;

                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }

                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}