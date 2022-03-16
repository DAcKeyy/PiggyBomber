using ActorComponents.Actors.Creatures;
using ActorComponents.Movement;
using DI.Signals;
using UnityEngine;
using Zenject;

namespace ActorComponents.Base
{
    [RequireComponent(typeof(_2DMovement), typeof(Pig))]
    public class Player2DControls : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        private _2DMovement _2dMovement;
        private Pig _pig;
        
        private void Awake()
        {
            _pig = GetComponent<Pig>();
            
            _2dMovement = GetComponent<_2DMovement>();
            
            _signalBus.Subscribe<PlayerMoveInputSignal>(x => Move(x.Direction));
            
            _signalBus.Subscribe<PlayerFireInputSignal>(Fire);
        }

        private void Move(Vector2 direction)
        {
            _2dMovement.Move(direction);
        }

        private void Fire()
        {
            _pig.PlaceBomb();
        }
    }
}