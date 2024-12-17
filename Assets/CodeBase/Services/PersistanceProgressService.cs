using CodeBase.Data;

namespace CodeBase.Services
{
    public class PersistanceProgressService : IPersistanceProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}