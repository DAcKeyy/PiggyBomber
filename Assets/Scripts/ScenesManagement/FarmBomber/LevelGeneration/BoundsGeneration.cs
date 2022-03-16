using ActorComponents.Factories;
using Data.Generation;
using ScenesManagement.Base;
using UnityEngine;

namespace ScenesManagement.FarmBomber.LevelGeneration
{
    public class BoundsGeneration : ILevelGenerator
    {
        private readonly PiggyBomberGenerationSettings.RoomSettings _roomSettings;
        private readonly BoundsFactory _boundsFactory;
        private readonly GameObject _boundsParent;

        public BoundsGeneration(
            PiggyBomberGenerationSettings.RoomSettings roomSettings,
            BoundsFactory boundsFactory)
        {
            _roomSettings = roomSettings;
            _boundsFactory = boundsFactory;
            _boundsParent = new GameObject("Boudns")
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
            

            for (var i = xRoomCenter; i < xRoomSize + xRoomCenter; i++)
            {
                currentSpawnPosition = new Vector2(i, yRoomCenter);
                
                _boundsFactory.Create(
                    currentSpawnPosition,
                    _boundsParent.transform,
                    _roomSettings._boundsSettings._horizontalBounds);
            }
            
            for (var i = yRoomCenter + 1; i < yRoomSize + yRoomCenter; i++)
            {
                currentSpawnPosition = new Vector2(currentSpawnPosition.x, i);
                
                _boundsFactory.Create(
                    currentSpawnPosition,
                    _boundsParent.transform,
                    _roomSettings._boundsSettings._verticalBounds);
            }
            
            for (var i = xRoomSize - 2 + xRoomCenter; i > xRoomCenter - 1; i--)
            {
                currentSpawnPosition = new Vector2(i, currentSpawnPosition.y);
                
                _boundsFactory.Create(
                    currentSpawnPosition,
                    _boundsParent.transform,
                    _roomSettings._boundsSettings._horizontalBounds);
            }
            
            for (var i = yRoomSize - 2 + yRoomCenter; i > yRoomCenter; i--)
            {
                currentSpawnPosition = new Vector2(currentSpawnPosition.x, i);
                
                _boundsFactory.Create(
                    currentSpawnPosition,
                    _boundsParent.transform,
                    _roomSettings._boundsSettings._verticalBounds);
            }
        }
        

        public void Update()
        {
            
        }
    }
}