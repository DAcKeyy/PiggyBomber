using UnityEngine;

namespace ActorComponents.Movement
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class _2DMovement : MonoBehaviour
    {
        private Collider2D _actorCollider2D;
        private Rigidbody2D _actorRigidbody2D;
        
        public void Start()
        {
            this._actorCollider2D = GetComponent<Collider2D>();
            _actorRigidbody2D = GetComponent<Rigidbody2D>();;
        }
        
        public void Move(Vector2 direction)
        {
            
        }
    }
}
