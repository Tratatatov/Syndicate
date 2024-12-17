using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Services;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelProgressState : IState

    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistanceProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadLevelProgressState(GameStateMachine gameStateMachine, IPersistanceProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositiononLevel
                .LevelName);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress("Main");
        }
    }
}