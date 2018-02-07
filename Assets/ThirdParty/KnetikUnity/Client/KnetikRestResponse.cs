
using System.Collections.Generic;

namespace KnetikUnity.Client
{
    /// <summary>
    /// The response returned from a HTTP REST request
    /// </summary>
    public class KnetikRestResponse
    {
        public long ResponseCode { get; set; }

        public string Error { get; set; }

        public string Content { get; set; }

        public Dictionary<string, string> Headers;

        public KnetikRestResponse()
        {
            Error = string.Empty;
            Content = string.Empty;
        }
    }
}
