using DI.Signals;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Farm.Canvases
{
    public class FarmPreGameCanvas : GameCanvas
    {
        [SerializeField] private Button _tapButton;
        [Inject] private SignalBus _signalBus;
        
        public void Awake()
        {
            _tapButton.onClick.AddListener(() => _signalBus.Fire(new StartGameSignal()));
        }
    }
}
