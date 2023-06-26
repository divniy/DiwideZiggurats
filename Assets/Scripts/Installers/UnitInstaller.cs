using TheKiwiCoder;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class UnitInstaller : MonoInstaller<UnitInstaller>
    {
        public GameObject unitPrefab;
        public TheKiwiCoder.BehaviourTree behaviourTree;
        
        public override void InstallBindings()
        {
            Container.BindFactory<UnitFacade, UnitFacade.Factory>()
                .FromMonoPoolableMemoryPool<UnitFacade>(b => b
                    .WithInitialSize(2)
                    .FromSubContainerResolve()
                    .ByNewPrefabMethod(unitPrefab, InstallUnit)
                    .UnderTransformGroup("Units")
            );
        }

        private void InstallUnit(DiContainer subContainer)
        {
            subContainer.Bind<UnitFacade>().FromNewComponentOnRoot().AsSingle();
            // subContainer.BindInstance();
            // var treeClone = subContainer.Instantiate<TheKiwiCoder.BehaviourTree>(behaviourTree);
            // var treeClone = behaviourTree.Clone();
            // subContainer.Bind<UnitBehaviourTreeRunner>().FromNewComponentOnRoot().AsSingle().WithArguments(treeClone);
            subContainer.BindInterfacesAndSelfTo<UnitBehaviourTreeRunner>()
                .FromNewComponentOnRoot().AsSingle().WithArguments(behaviourTree);
            subContainer.Bind<UnitEnvironment>().FromComponentOnRoot().AsSingle();
            subContainer.Bind<PoolableManager>().AsSingle();
        }
    }
}