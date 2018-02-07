
namespace KnetikUnity.Events
{
    public class KnetikClientAuthenticateResponseEvent<T> : KnetikResponseEventBase
    {
        public T AuthToken { get; set; }

        public KnetikClientAuthenticateResponseEvent(object requester) : base(requester)
        {
        }
    }
}
