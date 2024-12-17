using CodeBase.Data;

namespace CodeBase.Services
{
    public interface ISavedProgress : ISavedReader
    {
        void SaveProgress(PlayerProgress progress);
    }
}