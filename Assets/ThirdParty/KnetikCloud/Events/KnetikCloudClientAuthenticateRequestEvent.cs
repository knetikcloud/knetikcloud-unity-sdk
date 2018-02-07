using com.knetikcloud.Credentials;
using KnetikUnity.Events;

namespace com.knetikcloud.Events
{
    public class KnetikCloudClientAuthenticateRequestEvent : KnetikClientAuthenticateRequestEventBase
    {
        public KnetikCloudCredentials CloudCredentials { get; set; }
    }
}
