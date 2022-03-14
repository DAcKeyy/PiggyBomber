using ScenesManagement.Base;
using ScenesManagement.FarmBomber.States;
using UI.Base;
using UI.Farm.Canvases;
using Zenject;

namespace UI.Farm
{
    public class FarmUIObserver : UIObserver
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private DiContainer _diContainer;
        
        [Inject] private FarmGameOverCanvas _gameOverCanvas;
        [Inject] private FarmGameRunCanvas _gameRunCanvas;
        [Inject] private FarmPauseCanvas _gamePauseCanvas;
        [Inject] private FarmPreGameCanvas _gamePreGameCanvas;

        [Inject] 
        public void Init(SceneStateMachine sceneStateMachine)
        {
            sceneStateMachine.StateChanged += ChangeUIBySceneState;
        }

        public override void ChangeUIBySceneState(SceneState state)
        {
            switch (state)
            {
                case GameEndedState endedState:
                    if(ActiveCanvas != null) Destroy(ActiveCanvas.gameObject);
                    ActiveCanvas = _diContainer.InstantiatePrefab(_gameOverCanvas, transform).GetComponent<FarmGameOverCanvas>();
                    break;
                case GameRunState runState:
                    if(ActiveCanvas != null)Destroy(ActiveCanvas.gameObject);
                    ActiveCanvas = _diContainer.InstantiatePrefab(_gameRunCanvas, transform).GetComponent<FarmGameRunCanvas>();
                    break;
                case PreGameState preGameState:
                    if(ActiveCanvas != null)Destroy(ActiveCanvas.gameObject);
                    ActiveCanvas = _diContainer.InstantiatePrefab(_gamePreGameCanvas, transform).GetComponent<FarmPreGameCanvas>();
                    break;
                case GamePauseState pauseState:
                    if(ActiveCanvas != null)Destroy(ActiveCanvas.gameObject);
                    ActiveCanvas = _diContainer.InstantiatePrefab(_gamePauseCanvas, transform).GetComponent<FarmPauseCanvas>();
                    break;
            }
        }
    }
}