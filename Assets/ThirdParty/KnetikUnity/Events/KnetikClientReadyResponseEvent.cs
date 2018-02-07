using KnetikUnity.Client;

namespace KnetikUnity.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Event that is fired when the Knetik client has initialized and is ready to be used for authentication
    /// </summary>
    public class KnetikClientReadyResponseEvent : KnetikResponseEventBase
    {
        public bool Ready { get; private set; }

        public KnetikServerEnvironment ServerEnvironment { get; private set; }
 
        public KnetikClientReadyResponseEvent(object requester, bool isReady, KnetikServerEnvironment serverEnvironment) :
            base(requester)
        {
            Ready = isReady;
            ServerEnvironment = serverEnvironment;
        }
    }
}
