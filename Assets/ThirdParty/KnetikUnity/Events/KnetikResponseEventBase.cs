
namespace KnetikUnity.Events
{
    /// <inheritdoc />
    /// <summary>
    /// An event sent in response to a request that can potentially succeed or fail.
    /// </summary>
    public abstract class KnetikResponseEventBase : IKnetikEvent
    {
        public object Requester { get; private set; }

        protected KnetikResponseEventBase(object requester)
        {
            Requester = requester;
        }

        /// <summary>
        /// Should the listener process this response (or not)?
        /// </summary>
        public bool ShouldProcess(object listener)
        {
            if ((Requester == null) || (listener == Requester))
            {
                return true;
            }

            return false;
        }
    }
}
