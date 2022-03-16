using System;
using DI.Signals;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Farm.Canvases
{
    public class FarmGameRunCanvas : GameCanvas
    {
        [SerializeField] private Button _fireButton;
        [SerializeField] private Joystick _joystick;
        [Inject] private SignalBus _signalBus;
        
        private void Awake()
        {
            _fireButton.onClick.AddListener(() => _signalBus.Fire(new PlayerFireInputSignal()));
        }

        private void Update()
        {
           _signalBus.Fire(new PlayerMoveInputSignal(_joystick.Direction));
        }
    }
}
