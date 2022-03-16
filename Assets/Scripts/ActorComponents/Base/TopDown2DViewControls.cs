using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ActorComponents.Base
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TopDown2DViewControls : MonoBehaviour
    {
        [SerializeField] private _2DViewSettings _viewSettings;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeViewSetup(_2DViewSettings viewSettings)
        {
            _viewSettings = viewSettings;
        }
        
        public void ChangeViewDirection(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    _spriteRenderer.sprite = _viewSettings._leftDirectionSprite;
                    break;
                case MoveDirection.Up:
                    _spriteRenderer.sprite = _viewSettings._upDirectionSprite;
                    break;
                case MoveDirection.Right:
                    _spriteRenderer.sprite = _viewSettings._rightDirectionSprite;
                    break;
                case MoveDirection.Down:
                    _spriteRenderer.sprite = _viewSettings._downDirectionSprite;
                    break;
            }
        }
        
        [Serializable]
        public struct _2DViewSettings
        { 
            public Sprite _upDirectionSprite;
            public Sprite _leftDirectionSprite;
            public Sprite _rightDirectionSprite;
            public Sprite _downDirectionSprite;
        }
    }
}
