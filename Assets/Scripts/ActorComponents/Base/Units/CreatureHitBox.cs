using ActorComponents.Actors.Triggers;
using UnityEngine;

namespace ActorComponents.Base.Units
{
    public class CreatureHitBox : MonoBehaviour, IWeaponVisitor
    {
        [SerializeField] protected Creature _creature;
        
        public void Visit(Explosion weapon)
        {
            _creature.GetDamage((int) weapon.Damage);
        }
    }
}