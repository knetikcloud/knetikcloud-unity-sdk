using System;
using System.Collections.Generic;
using KnetikUnity.Client;

namespace KnetikUnity.Events
{
    public class KnetikWebCallEvent : IKnetikEvent
    {
        public DateTime StartTime { get; set; }

        public KnetikResponseContext Context { get; set; }

        public string WebPath { get; set; }

        public KnetikRequestType RequestType { get; set; }

        public Dictionary<string, string> HeaderParams { get; set; }

        public Dictionary<string, string> QueryParams { get; set; }

        public string PostBody { get; set; }

        public List<string> AuthSettings { get; set; }

        public KnetikWebCallEvent()
        {
            HeaderParams = new Dictionary<string, string>();
            QueryParams = new Dictionary<string, string>();
            AuthSettings = new List<string>();
        }
    }
}
