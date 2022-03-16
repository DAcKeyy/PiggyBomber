using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace ScenesManagement.Base
{
    public class SceneStateMachine : MonoBehaviour
    {
        public Action<SceneState> StateChanged;
        [Inject] public SignalBus SignalBus;
        [SerializeField] private UnityEvent<SceneState> _stateChanged;
        protected SceneState SceneState;

        
        public void SetState(SceneState sceneState)
        {
            if (SceneState != null) StartCoroutine(SceneState.Exit());
            
            SceneState = sceneState;
            
            _stateChanged.Invoke(SceneState);
            StateChanged(SceneState);

            StartCoroutine(SceneState.Init());
        }
    }
}
