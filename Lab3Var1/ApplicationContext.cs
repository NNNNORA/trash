using ContextLibrary.Entities;

namespace ContextLibrary
{
    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;
        private static readonly List<Request> requests = [];
        private static readonly List<Mechanic> mechanics = new List<Mechanic>
        {
            new Mechanic { LFP = "Пивоваров И.И." },
            new Mechanic { LFP = "Курилкин П.П." },
            new Mechanic { LFP = "Бычков С.С." }
        };
        private static readonly List<MechanicRequests> mechanicRequests = [];
        public List<Request> Requests { get => requests; }
        public List<Mechanic> Mechanics { get => mechanics; }
        public List<MechanicRequests> MechanicRequests { get => mechanicRequests; }
        public Mechanic? GetMechanicForRequest(Request request)
        {
            return mechanicRequests.FirstOrDefault(mr => mr.Request == request)?.Mechanic;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
