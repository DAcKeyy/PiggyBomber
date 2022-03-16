using UnityEngine;

namespace ActorComponents.Actors.Creatures
{
    [RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
    public class Bound : MonoBehaviour
    {
        private Collider2D _collider2D;
        private SpriteRenderer _spriteRenderer;
        
        public void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}