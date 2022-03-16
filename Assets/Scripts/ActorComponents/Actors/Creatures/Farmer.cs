using ActorComponents.Base;
using ActorComponents.Base.AI;
using UnityEngine;

namespace ActorComponents.Actors.Creatures
{
    [RequireComponent(
        typeof(TopDown2DViewControls), 
        typeof(AIVision2D))]
    public class Farmer : Creature
    {
        [SerializeField] private TopDown2DViewControls._2DViewSettings _normalSprites;
        [SerializeField] private TopDown2DViewControls._2DViewSettings _angrySprites;
        [SerializeField] private TopDown2DViewControls._2DViewSettings _dirtySprites;
        
        public State CurrentState { get; private set; }
        private TopDown2DViewControls _2dView;
        private AIVision2D _2dVision;

        private void Awake()
        {
            _2dView = GetComponent<TopDown2DViewControls>();
            _2dVision = GetComponent<AIVision2D>();
            _2dVision.TargetFounded += transforms => FollowTarget(AIVision2D.GetClosestTarget(transforms, transform));
            ChangeState(State.Normal);
        }

        private void FollowTarget(Transform target)
        {
            
        }
        
        private void ChangeState(State dogState)
        {
            switch (dogState)
            {
                case State.Normal:
                    CurrentState = dogState;
                    _2dView.ChangeViewSetup(_normalSprites);
                    break;
                case State.Angry:
                    CurrentState = dogState;
                    _2dView.ChangeViewSetup(_angrySprites);
                    break;
                case State.Stunned:
                    CurrentState = dogState;
                    _2dView.ChangeViewSetup(_dirtySprites);
                    break;
            }
        }

        public enum State
        {
            Normal,
            Angry,
            Stunned
        }
    }
}