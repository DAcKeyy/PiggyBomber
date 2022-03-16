using System;
using ActorComponents.Actors;
using ActorComponents.Actors.Creatures;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class FarmerFactory : IFactory<Vector2, Transform, Farmer>
    {
        private readonly FarmerSettings _settings;
        private readonly DiContainer _diContainer;

        public FarmerFactory(
            FarmerSettings settings,
            DiContainer diContainer)
        {
            this._diContainer = diContainer;
            _settings = settings;
        }

        public Farmer Create(Vector2 position, Transform parent)
        {
            var farmerObj = _diContainer.InstantiatePrefab(
                    _settings._prefub,
                    position, 
                    Quaternion.identity, 
                    parent)
                .GetComponent<Farmer>();

            return farmerObj;
        }

        [Serializable]
        public struct FarmerSettings
        {
            public Farmer _prefub;
        }
    }
}
