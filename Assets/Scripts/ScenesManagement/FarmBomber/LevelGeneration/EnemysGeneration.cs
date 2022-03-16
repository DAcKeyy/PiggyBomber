using System;
using ActorComponents.Factories;
using Data.Generation;
using ScenesManagement.Base;

namespace ScenesManagement.FarmBomber.LevelGeneration
{
    public class EnemiesGeneration : ILevelGenerator
    {
        private readonly PiggyBomberGenerationSettings.EnemiesSettings _enemiesSettings;
        private readonly BoundsFactory _boundsFactory;

        public EnemiesGeneration(PiggyBomberGenerationSettings.EnemiesSettings enemiesSettings, BoundsFactory boundsFactory)
        {
            _enemiesSettings = enemiesSettings;
            _boundsFactory = boundsFactory;
        }

        public void Create()
        {
            
        }

        public void Update()
        {
            
        }
        
        [Serializable]
        public struct EnemiesSettings
        {
            //public Bound _prefub;
        }
    }
}