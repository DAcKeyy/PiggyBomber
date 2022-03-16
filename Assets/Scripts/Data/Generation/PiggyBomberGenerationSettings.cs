using System;
using System.Collections.Generic;
using ActorComponents.Base;
using ActorComponents.Factories;
using ScenesManagement.FarmBomber.LevelGeneration;
using Unity.Mathematics;
using UnityEngine;

namespace Data.Generation
{
    [Serializable]
    public struct PiggyBomberGenerationSettings
    {
        public RoomSettings _roomSettings;
        public EnemiesSettings _enemiesSettings;
        public BombFactory.BombSettings _bombSettings;
        public CreaturesSettings _creaturesSettings;
        
        [Serializable]
        public struct RoomSettings
        {
            [Header("Границы уровня будут сверх RoomSize параметров")]
            //TODO: Ограничение не меньше 9 на 9
            public uint2 _roomSize;
            public int2 _roomOffset;
            public BoundsFactory.BoundsSettings _boundsSettings;
            public StonesFactory.StonesSettings _stonesSettings;
            public HaystackFactory.HaystackSettings _haystackSettings;
            public HaystackGeneration.HaystackGenerationSettings _haystackGenerationSettings;
            public Sprite _dirtSprite;
            public Sprite _dirtSpriteWithHole;
        }
        
        [Serializable]
        public struct EnemiesSettings
        {
            public List<Creature> _enemies;
        }
        
        [Serializable]
        public struct CreaturesSettings
        {
            public DogFactory.DogSettings _dogSettings;
            public FarmerFactory.FarmerSettings _farmerSettings;
        }
    }
}
