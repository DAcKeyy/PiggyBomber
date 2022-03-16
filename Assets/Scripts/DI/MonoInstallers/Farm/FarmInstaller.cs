using ActorComponents.Base;
using ActorComponents.Camera;
using ActorComponents.Camera.Base;
using Cinemachine;
using Data.Generation;
using DI.Signals;
using ScenesManagement.Base;
using ScenesManagement.FarmBomber;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DI.MonoInstallers.Farm
{
    public class FarmInstaller : MonoInstaller
    {
        [Inject] private PiggyBomberGenerationSettings _settings;
        [Inject] private DiContainer _diContainer;
        [SerializeField] private SceneStateMachine _sceneStateMachine;
        [SerializeField] private InputActionAsset _playerControls;
        [SerializeField] private Player2DControls _player;
        [SerializeField] private FarmCamera _vCamera;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<StartGameSignal>();
            Container.DeclareSignal<PlayerFireInputSignal>();
            Container.DeclareSignal<PlayerMoveInputSignal>();
            Container.DeclareSignal<PlayerCreatureDiedSignal>();

            Container.Bind<ICamera>().To<FarmCamera>().FromInstance(_vCamera).AsSingle();
            Container.Bind<SceneStateMachine>().FromInstance(_sceneStateMachine).AsSingle();
            Container.Bind<InputActionAsset>().FromInstance(_playerControls).AsSingle();
            Container.Bind<Player2DControls>().FromInstance(_player).AsSingle();

            Container.Bind<ILevelGenerator>().To<FarmLevelGenerator>().FromNew().AsSingle().WithArguments(_settings, _diContainer);
        }
    }
}