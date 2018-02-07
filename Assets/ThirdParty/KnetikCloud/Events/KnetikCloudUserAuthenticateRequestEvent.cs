using com.knetikcloud.Credentials;
using KnetikUnity.Events;

namespace com.knetikcloud.Events
{
    public class KnetikCloudUserAuthenticateRequestEvent : KnetikClientAuthenticateRequestEventBase
    {
        public KnetikUserCredentials UserCredentials { get; set; }
    }
}
