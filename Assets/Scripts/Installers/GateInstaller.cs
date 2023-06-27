using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class GateInstaller : MonoInstaller<GateInstaller>
    {
        [SerializeField] private GameObject unitPrefab;
        [SerializeField, Expandable] private UnitSettings unitSettings;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private TheKiwiCoder.BehaviourTree behaviourTree;
        
        public override void InstallBindings()
        {
            Container.BindInstance(unitSettings);
            Container.BindInstance(behaviourTree);
            Container.BindFactory<UnitFacade, UnitFacade.Factory>()
                .FromMonoPoolableMemoryPool<UnitFacade>(b => b
                    .WithInitialSize(2)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<UnitInstaller>(unitPrefab)
                    .UnderTransformGroup("Units")
                );
            Container.BindInterfacesAndSelfTo<UnitSpawner>().AsSingle().WithArguments(spawnPoint);
            // Container.BindInstance(spawnPoint).WhenInjectedInto<UnitSpawner>();
            Container.Bind<UnitSpawnPoint>().FromComponentInChildren().AsSingle();
        }
    }
}