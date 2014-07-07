﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace TribalWars.Tools
{
    /// <summary>
    /// Interact met the network and set proxy
    /// on requests if necessary
    /// </summary>
    public static class Network
    {
        public static WebRequest CreateWebRequest(string url)
        {
            var client = WebRequest.Create(url);
            client.Proxy = WebRequest.GetSystemWebProxy();
            return client;
        }

        public static string GetWebRequest(string url)
        {
            WebRequest request = CreateWebRequest(url);
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static XDocument DownloadXml(string url)
        {
            string xml = GetWebRequest(url);
            return XDocument.Load(xml);
        }
    }
}
