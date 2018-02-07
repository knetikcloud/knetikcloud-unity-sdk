
namespace KnetikUnity.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Send a request to listeners via the event system.
    /// Once the request is processed a response will be issued via the event system.
    /// </summary>
    public abstract class KnetikRequestEventBase : IKnetikEvent
    {
        public object Requester { get; private set; }

        protected KnetikRequestEventBase(object requester)
        {
            Requester = requester;
        }
    }
}
