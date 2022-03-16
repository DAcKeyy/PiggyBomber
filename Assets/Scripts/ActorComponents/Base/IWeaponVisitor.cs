using ActorComponents.Actors.Triggers;

namespace ActorComponents.Base
{
    public interface IWeaponVisitor
    {
        public void Visit(Explosion weapon);
    }
}