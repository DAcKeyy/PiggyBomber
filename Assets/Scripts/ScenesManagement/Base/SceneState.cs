using System;
using System.Collections;

namespace ScenesManagement.Base
{
    public abstract class SceneState
    {
        public Action Inited = delegate {  };
        public Action Exited = delegate {  };
    
        protected SceneStateMachine SceneStateMachineMachine;

        public SceneState(SceneStateMachine stateMachineMachine)
        {
            SceneStateMachineMachine = stateMachineMachine;
        }

        public virtual IEnumerator Init()
        {
            Inited();
            yield break;
        }

        public virtual IEnumerator Exit()
        {
            Exited();
            yield break;
        }
    }
}
