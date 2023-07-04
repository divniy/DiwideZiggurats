using Diwide.Ziggurat.UI;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class HealthbarInstaller : MonoInstaller
    {
        public MeshRenderer meshRenderer;

        public override void InstallBindings()
        {
            Container.BindInstance(meshRenderer);
            Container.BindInterfacesAndSelfTo<HealthbarPresenter>().AsSingle();
        }
    }
}