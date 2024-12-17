using CodeBase.Data;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Services
{
    public interface IPersistanceProgressService :IService
    {
        PlayerProgress Progress { get; set; }
    }
}