using ActorComponents.Actors;
using ScenesManagement.Base;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DI.MonoInstallers.Farm
{
    public class FarmInstaller : MonoInstaller
    {
        [SerializeField] private SceneStateMachine _sceneStateMachine;
        [SerializeField] private InputActionAsset _playerControls;
        [SerializeField] private Pig _player;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.Bind<SceneStateMachine>().FromInstance(_sceneStateMachine).AsSingle();
            Container.Bind<InputActionAsset>().FromInstance(_playerControls).AsSingle();
            Container.Bind<Pig>().FromInstance(_player).AsSingle();
        }
    }
}