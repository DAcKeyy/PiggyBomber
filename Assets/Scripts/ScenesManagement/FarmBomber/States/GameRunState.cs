using System.Collections;
using ScenesManagement.Base;
using UnityEngine;

namespace ScenesManagement.FarmBomber.States
{
    public class GameRunState : SceneState
    {
        private FarmBomberStateMachine _stateMachineMachine;
        
        public GameRunState(FarmBomberStateMachine stateMachineMachine) : base(stateMachineMachine)
        {
            this._stateMachineMachine = stateMachineMachine;
            
        }

        public override IEnumerator Init()
        {
            var player =_stateMachineMachine._DiContainer.InstantiatePrefab(_stateMachineMachine.Player2DControls);
            _stateMachineMachine._Camera.FollowTarget(player.gameObject);
            yield return null;
        }
    }
}