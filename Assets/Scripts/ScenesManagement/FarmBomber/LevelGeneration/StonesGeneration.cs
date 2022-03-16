using ActorComponents.Factories;
using Data.Generation;
using ScenesManagement.Base;
using UnityEngine;

namespace ScenesManagement.FarmBomber.LevelGeneration
{
    public class StonesGeneration : ILevelGenerator
    {
        private readonly PiggyBomberGenerationSettings.RoomSettings _roomSettings;
        private readonly StonesFactory _stonesFactory;
        private readonly GameObject _stonesParent;
        
        public StonesGeneration(
            PiggyBomberGenerationSettings.RoomSettings roomSettings, 
            StonesFactory stonesFactory)
        {
            _roomSettings = roomSettings;
            _stonesFactory = stonesFactory;
            _stonesParent = new GameObject("Rolling Stones")
            {
                transform = { position = Vector3.zero }
            };
        }

        
        public void Create()
        {
            var xRoomSize = (int)_roomSettings._roomSize[0];
            var yRoomSize = (int)_roomSettings._roomSize[1];
            var xRoomCenter = _roomSettings._roomOffset[0];
            var yRoomCenter = _roomSettings._roomOffset[1];
            var currentSpawnPosition = new Vector2();
            
            for (var x = xRoomCenter; x < xRoomSize + xRoomCenter; x++) 
            {
                if(x < xRoomCenter + 3) continue;
                if(x > xRoomSize - 3) continue;
                if((x % 4) != 0) continue;
                
                for (var y = yRoomCenter; y < yRoomSize + yRoomCenter; y++) 
                {
                    if(y < yRoomCenter + 3) continue;
                    if(y > yRoomSize - 3) continue;
                    if((y % 4) != 0) continue;
                    
                    _stonesFactory.Create(
                        new Vector2(x,y),
                        _stonesParent.transform);
                }
            }
        }

        public void Update()
        {
            
        }
    }
}