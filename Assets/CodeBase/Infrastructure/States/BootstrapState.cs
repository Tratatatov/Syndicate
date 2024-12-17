using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;


        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }


        public void Enter()
        {
           
            _sceneLoader.Load(Initial, EnterLoadScene);
        }


        public void Exit()
        {
        }

        private void EnterLoadScene()
        {
            _stateMachine.Enter<LoadLevelState, string>("Main");
        }

        private void RegisterServices()
        {
            _services.RegisterSingleService<ISaveLoadService>(new SaveLoadService());
            _services.RegisterSingleService<IAssetProvider>(new AssetsProvider());
            _services.RegisterSingleService(InputService());
            _services.RegisterSingleService<IGameFactory>(
                new GameFactory(AllServices.Container.Single<IAssetProvider>()));
            _services.RegisterSingleService<IPersistanceProgressService>(new PersistanceProgressService());
        }

        private IInputService InputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            return new MobileInputService();
        }
    }
}