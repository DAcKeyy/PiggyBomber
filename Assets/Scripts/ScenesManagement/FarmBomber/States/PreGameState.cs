using System.Collections;
using DI.Signals;
using ScenesManagement.Base;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ScenesManagement.FarmBomber.States
{
    public class PreGameState : SceneState
    {
        private readonly InputAction _fireInputAction;
        private bool isStarted;
        private FarmBomberStateMachine _stateMachineMachine;
        
        public PreGameState(FarmBomberStateMachine stateMachineMachine, InputActionAsset actionAsset) : base(stateMachineMachine)
        {
            _stateMachineMachine = stateMachineMachine;
            _stateMachineMachine.SignalBus.Subscribe<StartGameSignal>(x => isStarted = true);
            _fireInputAction = actionAsset.FindActionMap("Player").FindAction("Fire");
            _fireInputAction.performed += (x) => Debug.Log(x.action);
        }

        public override IEnumerator Init()
        {
            yield return new WaitUntil(() => isStarted);
            base.SceneStateMachineMachine.SetState(new GameRunState(_stateMachineMachine));
        }
    }
}