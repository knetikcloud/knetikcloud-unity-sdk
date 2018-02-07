
namespace KnetikUnity.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Event that is fired when the Knetik client has initialized and is ready to be used for authentication
    /// </summary>
    public class KnetikClientReadyRequestEvent : KnetikRequestEventBase
    {
        public KnetikClientReadyRequestEvent(object requester) : base(requester)
        {
        }
    }
}
