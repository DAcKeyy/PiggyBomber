using ActorComponents.Actors;
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

        private void Start()
        {
            if(SceneState == null) SetState(new PreGameState(this));
        }
    }
}