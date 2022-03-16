using ActorComponents.Factories;
using Data.Generation;
using ScenesManagement.Base;

namespace ScenesManagement.FarmBomber.LevelGeneration
{
    public class PlayerGeneration : ILevelGenerator
    {
        private readonly PiggyBomberGenerationSettings.RoomSettings _roomSettings;
        private readonly HaystackFactory _haystackFactory;
        
        public PlayerGeneration(PiggyBomberGenerationSettings.RoomSettings roomSettings, HaystackFactory haystackFactory)
        {
            _roomSettings = roomSettings;
            _haystackFactory = haystackFactory;
        }
        
        public void Create()
        {
            
        }

        public void Update()
        {
            
        }
    }
}