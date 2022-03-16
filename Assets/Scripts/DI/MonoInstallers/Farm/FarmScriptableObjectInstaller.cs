using Data.Generation;
using UnityEngine;
using Zenject;

namespace DI.MonoInstallers.Farm
{
    [CreateAssetMenu(fileName = "FarmScriptableObjectInstaller", menuName = "Installers/FarmScriptableObjectInstaller")]
    public class FarmScriptableObjectInstaller : ScriptableObjectInstaller<FarmScriptableObjectInstaller>
    {
        [SerializeField] private PiggyBomberGenerationSettings _settings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PiggyBomberGenerationSettings>().FromInstance(_settings).AsSingle();
        }
    }
}