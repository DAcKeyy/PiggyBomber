using System;
using ActorComponents.Actors;
using ActorComponents.Actors.Creatures;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class HaystackFactory : IFactory<Vector2, Transform, Haystack>
    {
        private readonly HaystackSettings _settings;
        private readonly DiContainer _diContainer;

        public HaystackFactory(
            HaystackSettings settings,
            DiContainer diContainer)
        {
            _settings = settings;
            _diContainer = diContainer;
        }

        public Haystack Create(Vector2 position, Transform parent)
        {
            var haystackObj = _diContainer.InstantiatePrefab(
                    _settings._prefub,
                    position, 
                    Quaternion.identity, 
                    parent)
                .GetComponent<Haystack>();

            return haystackObj;
        }
        
        [Serializable]
        public struct HaystackSettings
        {
            public Haystack _prefub;
        }
    }
}
