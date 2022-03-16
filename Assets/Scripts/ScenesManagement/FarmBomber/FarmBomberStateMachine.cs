using ActorComponents.Base;
using ActorComponents.Camera.Base;
using ScenesManagement.Base;
using ScenesManagement.FarmBomber.States;
using UnityEngine.InputSystem;
using Zenject;

namespace ScenesManagement.FarmBomber
{
    public class FarmBomberStateMachine : SceneStateMachine
    {
        [Inject] public InputActionAsset PlayerInputAction { get; }
        [Inject] public SignalBus SignalBus { get; }
        [Inject] public Player2DControls Player2DControls { get; }
        [Inject] public DiContainer _DiContainer { get; }
        [Inject] public ICamera _Camera { get; }

        private void Start()
        {
            if(SceneState == null) SetState(new PreGameState(this, PlayerInputAction));
        }
    }
}