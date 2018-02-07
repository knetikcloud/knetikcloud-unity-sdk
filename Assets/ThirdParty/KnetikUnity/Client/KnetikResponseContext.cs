using System;

namespace KnetikUnity.Client
{
    public class KnetikResponseContext :  IDisposable
    {
        public KnetikResponseReceivedHandler ResponseReceived;

        public KnetikRestResponse Response { get; set; }

        public bool HasFinished { get { return (Response != null); } }

        ~KnetikResponseContext()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            ResponseReceived = null;
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
            ResponseReceived = null;
        }
    }
}
