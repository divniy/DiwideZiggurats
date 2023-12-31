using TheKiwiCoder;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.Installers
{
    public class UnitInstaller : MonoInstaller
    {
        public UnitSelector.Settings unitSelectorSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(unitSelectorSettings);
            Container.Bind<UnitFacade>().FromNewComponentOnRoot().AsSingle();
            Container.Bind<Animator>().FromComponentOnRoot();
            // subContainer.BindInstance();
            // var treeClone = subContainer.Instantiate<TheKiwiCoder.BehaviourTree>(behaviourTree);
            // var treeClone = behaviourTree.Clone();
            // subContainer.Bind<UnitBehaviourTreeRunner>().FromNewComponentOnRoot().AsSingle().WithArguments(treeClone);
            Container.BindInterfacesAndSelfTo<UnitBehaviourTreeRunner>().FromNewComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitHealthHandler>().FromNewComponentOnRoot().AsSingle();
            Container.Bind<UnitIncomingHitHandler>().FromNewComponentOnRoot().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<UnitIncomingHitHandler>().FromNewComponentOnRoot().AsSingle();
            Container.BindInterfacesTo<UnitSelector>().AsSingle();
            Container.Bind<UnitEnvironment>().FromComponentOnRoot().AsSingle();
            Container.Bind<PoolableManager<UnitSettings>>().AsSingle();
        }
    }
}