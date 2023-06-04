using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
	[CreateAssetMenu(fileName = "New Configuration", menuName = "Configuration")]
	public class Configuration : ScriptableObjectInstaller<Configuration>
	{
		[SerializeField]
		private AnimationKeyDictionary _keys;

		public IReadOnlyDictionary<AnimationType, string> GetDictionary => _keys.Clone();
		
		public override void InstallBindings()
		{
			Container.BindInstance(GetDictionary);
		}
	}
}