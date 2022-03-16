using DI.Signals;
using UnityEngine;
using Zenject;

namespace ScenesManagement.Base
{
    public class LevelGenerator : MonoBehaviour
    {
        [Inject] private ILevelGenerator _levelGeneration;
        [Inject] private SignalBus _signalBus;

        private void Start()
        {
            _signalBus.Subscribe<StartGameSignal>(x => _levelGeneration.Create());
        }
    }
}
