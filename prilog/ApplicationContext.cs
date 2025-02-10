using ContextLibrary.Entities;

namespace ContextLibrary
{
    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;
        private static readonly List<Request> requests = [];
        private static readonly List<Adjuster> adjuster = [];
        private static readonly List<AdjusterRequests> adjusterRequests = [];
        public List<Request> Requests { get => requests; }
        public List<Adjuster> Adjuster { get => adjuster; }
        public List<AdjusterRequests> AdjusterRequests { get => adjusterRequests; }

        protected virtual void Dispose(bool disposing)
        {
            // check if already disposed 
            if (!_isDisposed)
            {
                // set the bool value to true 
                _isDisposed = true;
            }
        }
        public void Dispose()
        {
            // Invoke the above virtual 
            // dispose(bool disposing) method 
            Dispose(disposing: true);

            // Notify the garbage collector 
            // about the cleaning event 
            GC.SuppressFinalize(this);
        }
    }
}
