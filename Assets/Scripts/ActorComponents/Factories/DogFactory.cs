using System;
using ActorComponents.Actors;
using ActorComponents.Actors.Creatures;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class DogFactory : IFactory<Vector2, Transform, Dog>
    {
        private readonly DogSettings _settings;
        private readonly DiContainer _diContainer;
        public DogFactory(DogSettings settings, DiContainer diContainer)
        {
            _settings = settings;
            _diContainer = diContainer;
        }

        public Dog Create(Vector2 position, Transform parent)
        {
            var dogObj = _diContainer.InstantiatePrefab(
                    _settings._prefub,
                    position, 
                    Quaternion.identity, 
                    parent)
                .GetComponent<Dog>();

            return dogObj;
        }
        
        [Serializable]
        public struct DogSettings
        {
            public Dog _prefub;
        }
    }
}
