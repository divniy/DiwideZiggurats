using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<TeamSelectedSignal>();
            
            Container.Bind<CameraController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<UnitSpawnPoint>().FromComponentInHierarchy().AsTransient();
            Container.Bind<GateFacade>().FromComponentsInHierarchy().AsTransient();
        }
    }
}