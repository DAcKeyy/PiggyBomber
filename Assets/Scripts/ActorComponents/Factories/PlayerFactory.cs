using ActorComponents.Base;
using UnityEngine;
using Zenject;

namespace ActorComponents.Factories
{
    public class PlayerFactory : IFactory<Vector2, Player2DControls>
    {
        public Player2DControls Create(Vector2 param)
        {
            throw new System.NotImplementedException();
        }
    }
}