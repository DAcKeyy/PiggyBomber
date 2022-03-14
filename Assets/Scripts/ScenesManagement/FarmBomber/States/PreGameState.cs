using System.Collections;
using ScenesManagement.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScenesManagement.FarmBomber.States
{
    public class PreGameState : SceneState
    {
        private readonly InputAction _fireInputAction; 
        
        public PreGameState(SceneStateMachine stateMachineMachine, InputActionAsset actionAsset) : base(stateMachineMachine)
        {
            _fireInputAction = actionAsset.FindActionMap("Player").FindAction("Fire");
        }

        public override IEnumerator Init()
        {
            yield return new WaitUntil(() => _fireInputAction.triggered);
            base.SceneStateMachineMachine.SetState(new GameRunState(SceneStateMachineMachine));
        }
    }
}