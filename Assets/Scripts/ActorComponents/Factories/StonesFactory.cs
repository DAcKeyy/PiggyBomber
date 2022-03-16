using System;
using ActorComponents.Actors;
using ActorComponents.Actors.Creatures;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class StonesFactory : IFactory<Vector2, Transform, Stone>
    {
        private readonly StonesSettings _settings;
        private readonly DiContainer _diContainer;

        public StonesFactory(
            StonesSettings settings, 
            DiContainer diContainer)
        {
            _settings = settings;
            _diContainer = diContainer;
        }

        public Stone Create(Vector2 position, Transform parent)
        {
            var stoneObj = _diContainer.InstantiatePrefab(
                    _settings._prefub,
                    position, 
                    Quaternion.identity, 
                    parent)
                .GetComponent<Stone>();

            return stoneObj;
        }
        
        [Serializable]
        public struct StonesSettings
        {
            public Stone _prefub;
        }
    }
}
