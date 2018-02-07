
namespace KnetikUnity.Events
{
    /// <summary>
    /// An event that client code can subscribe to.
    /// </summary>
    public interface IKnetikEvent
    {
    }

    /// <summary>
    /// Event-listening callback for specific type of event.
    /// </summary>
    public delegate void EventHandler<TEvent>(TEvent e) where TEvent : IKnetikEvent;
}
