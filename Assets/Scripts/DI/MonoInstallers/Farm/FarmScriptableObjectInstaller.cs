using UnityEngine;
using Zenject;

namespace DI.MonoInstallers.Farm
{
    [CreateAssetMenu(fileName = "FarmScriptableObjectInstaller", menuName = "Installers/FarmScriptableObjectInstaller")]
    public class FarmScriptableObjectInstaller : ScriptableObjectInstaller<FarmScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}