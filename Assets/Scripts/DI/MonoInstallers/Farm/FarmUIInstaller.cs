using UI.Base;
using UI.Farm.Canvases;
using UnityEngine;
using Zenject;

namespace DI.MonoInstallers.Farm
{
    public class FarmUIInstaller : MonoInstaller
    {
        [SerializeField] private UIObserver _sceneUIObserver;
        [SerializeField] private FarmGameOverCanvas _gameOverCanvas;
        [SerializeField] private FarmGameRunCanvas _gameRunCanvas;
        [SerializeField] private FarmPauseCanvas _gamePauseCanvas;
        [SerializeField] private FarmPreGameCanvas _gamePreGameCanvas;
        
        public override void InstallBindings()
        {
            Container.Bind<UIObserver>().FromInstance(_sceneUIObserver).AsSingle();
            Container.Bind<FarmGameOverCanvas>().FromInstance(_gameOverCanvas).AsSingle();
            Container.Bind<FarmGameRunCanvas>().FromInstance(_gameRunCanvas).AsSingle();
            Container.Bind<FarmPauseCanvas>().FromInstance(_gamePauseCanvas).AsSingle();
            Container.Bind<FarmPreGameCanvas>().FromInstance(_gamePreGameCanvas).AsSingle();
        }
    }
}