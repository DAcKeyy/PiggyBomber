using ActorComponents.Base;
using ActorComponents.Movement;
using UnityEngine;

namespace ActorComponents.Actors.Creatures
{
    [RequireComponent(typeof(_2DMovement))]
    public class Pig : Creature
    {
        [SerializeField] private Bomb _bomb;
        
        public void PlaceBomb()
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
        }
    }
}