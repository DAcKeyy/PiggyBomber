using System;
using ActorComponents.Actors;
using ActorComponents.Actors.Creatures;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class BombFactory : IFactory<Vector2, Transform, Bomb>
    {
        private readonly BombSettings _settings;
        private readonly DiContainer _diContainer;

        public BombFactory(
            BombSettings settings, 
            DiContainer diContainer)
        {
            _settings = settings;
            _diContainer = diContainer;
        }

        public Bomb Create(Vector2 position , Transform parent)
        {
            var bombObj = _diContainer.InstantiatePrefab(
                    _settings._prefub,
                    position, 
                    Quaternion.identity, 
                    parent)
                .GetComponent<Bomb>();

            return bombObj;
        }
        
        [Serializable]
        public struct BombSettings
        {
            public Bomb _prefub;
        }
    }
}
