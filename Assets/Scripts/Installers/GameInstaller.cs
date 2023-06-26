using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<UnitSpawnPoint>().FromComponentInHierarchy().AsTransient();
        }
    }
}