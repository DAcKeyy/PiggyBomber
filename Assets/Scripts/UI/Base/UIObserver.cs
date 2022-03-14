using ScenesManagement.Base;
using UnityEngine;

namespace UI.Base
{
    public abstract class UIObserver : MonoBehaviour
    {
        protected GameCanvas ActiveCanvas;

        public virtual void ChangeUIBySceneState(SceneState state)
        {
            
        }
    }
}