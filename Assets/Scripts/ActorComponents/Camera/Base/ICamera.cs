using UnityEngine;

namespace ActorComponents.Camera.Base
{
    public interface ICamera
    {
        public void FollowTarget(GameObject target);
    }
}