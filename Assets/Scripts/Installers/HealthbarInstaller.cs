using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class HealthbarInstaller : MonoInstaller
    {
        public Renderer meshRenderer;

        public override void InstallBindings()
        {
            Container.BindInstance(meshRenderer);
            Container.BindInterfacesAndSelfTo<HealthbarInstaller>().AsSingle();
        }
    }
}