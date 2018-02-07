using com.knetikcloud.Credentials;
using KnetikUnity.Events;

namespace com.knetikcloud.Events
{
    public class KnetikCloudTokenAuthenticateRequestEvent : KnetikClientAuthenticateRequestEventBase
    {
        public KnetikTokenCredentials TokenCredentials { get; set; }
    }
}
