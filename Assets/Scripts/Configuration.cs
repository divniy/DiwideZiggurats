using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
	[CreateAssetMenu(fileName = "New Configuration", menuName = "Configuration")]
	public class Configuration : ScriptableObjectInstaller<Configuration>
	{
		
		public AnimationKeyDictionary animationKeyDictionary;
		public UnitTeamLayerDictionary unitTeamLayerDictionary;
		public UnitBehaviourTreeRunner.Settings unitBehaviourTreeSettings;
		public AttackAnimationDictionary attackAnimationDictionary;

		private IReadOnlyDictionary<AnimationType, string> AnimationKeysDictionary => animationKeyDictionary.Clone();
		private IReadOnlyDictionary<UnitTeam, int> UnitTeamLayers => unitTeamLayerDictionary.Clone();
		
		// private IReadOnlyDictionary<AttackType, string>
		
		public override void InstallBindings()
		{
			Container.BindInstance(AnimationKeysDictionary);
			Container.BindInstance(UnitTeamLayers);
			Container.BindInstance(attackAnimationDictionary);
			Container.BindInstance(unitBehaviourTreeSettings);
		}
	}
}