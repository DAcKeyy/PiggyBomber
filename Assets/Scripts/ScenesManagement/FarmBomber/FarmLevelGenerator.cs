using ActorComponents.Factories;
using Data.Generation;
using ScenesManagement.Base;
using ScenesManagement.FarmBomber.LevelGeneration;
using UnityEngine;
using Zenject;

namespace ScenesManagement.FarmBomber
{
    public class FarmLevelGenerator : ILevelGenerator
    {
        private readonly DiContainer _diContainer;
        private readonly PiggyBomberGenerationSettings _settings;
        private readonly ILevelGenerator _boundsGenerator;
        private readonly ILevelGenerator _haystackGeneration;
        private readonly ILevelGenerator _stonesGeneration;

        public FarmLevelGenerator(PiggyBomberGenerationSettings settings, DiContainer diContainer)
        {
            _settings = settings;
            _diContainer = diContainer;

            _boundsGenerator = new BoundsGeneration(
                settings._roomSettings, 
                new BoundsFactory(settings._roomSettings._boundsSettings, _diContainer));
            
            _haystackGeneration = new HaystackGeneration(
                settings._roomSettings,
                new HaystackFactory(settings._roomSettings._haystackSettings, _diContainer));
            
            _stonesGeneration = new StonesGeneration(
                settings._roomSettings,
                new StonesFactory(settings._roomSettings._stonesSettings, _diContainer));
            
            //_playerGeneration = playerGeneration;
            //_enemiesGeneration = enemiesGeneration;
        }

        public void Create()
        {
            _boundsGenerator.Create();
            _stonesGeneration.Create();
            _haystackGeneration.Create();
            
            var xRoomSize = (int)_settings._roomSettings._roomSize[0];
            var yRoomSize = (int)_settings._roomSettings._roomSize[1];
            var xRoomCenter = _settings._roomSettings._roomOffset[0];
            var yRoomCenter = _settings._roomSettings._roomOffset[1];
            
            for (var x = xRoomCenter; x < xRoomSize + xRoomCenter ; x++) {
                for (var y = yRoomCenter; y < yRoomSize + yRoomCenter ; y++) {
                    CreateDirtBackground(
                        _settings._roomSettings._dirtSprite,
                        new Vector2(x, y));
                }
            }
        }

        public void Update()
        {
            _boundsGenerator.Update();
            _stonesGeneration.Update();
            _haystackGeneration.Update();
        }
        
        private void CreateDirtBackground(Sprite dirtSprite, Vector2 position)
        {
            var spriteTile = new GameObject("Dirt") {
                transform = {
                    position = position
                }
            };

            var spriteRenderer = spriteTile.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = dirtSprite;
            spriteRenderer.sortingLayerName = "Background";
            spriteRenderer.sortingOrder = -99;
        }
    }
}