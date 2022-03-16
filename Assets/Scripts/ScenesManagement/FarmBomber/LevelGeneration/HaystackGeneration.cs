using System;
using ActorComponents.Factories;
using Data.Generation;
using ScenesManagement.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScenesManagement.FarmBomber.LevelGeneration
{
    public class HaystackGeneration : ILevelGenerator
    {
        private readonly PiggyBomberGenerationSettings.RoomSettings _roomSettings;
        private readonly HaystackFactory _haystackFactory;
        private readonly GameObject _haystacksParent;
        
        public HaystackGeneration(
            PiggyBomberGenerationSettings.RoomSettings roomSettings, 
            HaystackFactory haystackFactory)
        {
            _roomSettings = roomSettings;
            _haystackFactory = haystackFactory;
            _haystacksParent = new GameObject("Haystacks")
            {
                transform = { position = Vector2.zero }
            };
        }

        public void Create()
        {
            var xRoomSize = (int)_roomSettings._roomSize[0];
            var yRoomSize = (int)_roomSettings._roomSize[1];
            var xRoomCenter = _roomSettings._roomOffset[0];
            var yRoomCenter = _roomSettings._roomOffset[1];
            
            for (var i = 0; i < _roomSettings._haystackGenerationSettings._randomAmount; i++)
            {
                _haystackFactory.Create(
                    new Vector2(
                        Random.Range(xRoomCenter, xRoomSize + xRoomCenter),
                        Random.Range(yRoomCenter, yRoomSize + yRoomCenter)),
                    _haystacksParent.transform);
            }
        }

        public void Update()
        {
            
        }
        
        [Serializable]
        public struct HaystackGenerationSettings
        {
            public uint _randomAmount;
        }
    }
}