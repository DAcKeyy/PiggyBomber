using ActorComponents.Base;
using ScriptsExtensions;
using UnityEngine;

namespace ActorComponents.Movement
{
    [RequireComponent(
        typeof(Collider2D), 
        typeof(Rigidbody2D), 
        typeof(TopDown2DViewControls))]
    public class _2DMovement : MonoBehaviour
    {
        [SerializeField] private float _speedMultiplier = 1;
        
        private Collider2D _actorCollider2D;
        private Rigidbody2D _actorRigidbody2D;
        private TopDown2DViewControls _viewControls;
        
        public void Start()
        {
            _actorCollider2D = GetComponent<Collider2D>();
            _actorRigidbody2D = GetComponent<Rigidbody2D>();
            _viewControls = GetComponent<TopDown2DViewControls>();
        }
        
        public void Move(Vector2 direction)
        {
            _viewControls.ChangeViewDirection(direction.Vector2ToMoveDirection());
            
            transform.position = GetNewPosition(transform.position, direction, _speedMultiplier);
        }

        private static Vector2 GetNewPosition(Vector2 target, Vector2 toDirection, float speedMultiplier)
        {
            var position = new Vector2(
                target.x + toDirection.x * Time.deltaTime * speedMultiplier, 
                target.y + toDirection.y * Time.deltaTime * speedMultiplier);
            return position;
        } 
    }
}
