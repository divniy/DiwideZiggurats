using UnityEngine.UIElements;
using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class PopupInstaller : MonoInstaller
    {
        public PopupPresenter.Settings settings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings);
            Container.BindInterfacesAndSelfTo<PopupPresenter>().AsSingle();
        }
    }
}