using System;
using ActorComponents.Actors;
using ActorComponents.Actors.Creatures;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class BoundsFactory : IFactory<Vector2, Transform, Sprite, Bound>
    {
        private readonly DiContainer _diContainer;
        private readonly BoundsSettings _boundsSettings;

        public BoundsFactory(
            BoundsSettings boundsSettings, 
            DiContainer diContainer)
        {
            _boundsSettings = boundsSettings;
            _diContainer = diContainer;
        }

        public Bound Create(Vector2 position, Transform parent, Sprite sprite)
        {

            var buildObj = _diContainer.InstantiatePrefab(
                    _boundsSettings._prefub,
                    position, 
                    Quaternion.identity, 
                    parent)
                .GetComponent<Bound>();
            
            buildObj.SetSprite(sprite);

            return buildObj;
        }
        
        [Serializable]
        public struct BoundsSettings
        {
            public Bound _prefub;
            public Sprite _verticalBounds;
            public Sprite _horizontalBounds;
        }
    }
}