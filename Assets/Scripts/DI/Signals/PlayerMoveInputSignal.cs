using UnityEngine;

namespace DI.Signals
{
    public class PlayerMoveInputSignal
    {
        public PlayerMoveInputSignal(Vector2 direction)
        {
            Direction = direction;
        }
        
        public Vector2 Direction { get; private set; }
    }
}