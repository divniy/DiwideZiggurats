using System;
using RotaryHeart.Lib.SerializableDictionary;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diwide.Ziggurat
{
	public enum AnimationType : byte
	{
		Move = 0,
		FastAttack = 1,
		StrongAttack = 2,
		Die = 3
	}

	[System.Flags]
	public enum IgnoreAxisType : byte
	{
		None = 0,
		X = 1,
		Y = 2,
		Z = 4
	}

	public enum UnitTeam : byte
	{
		Red = 6,
		Green = 7,
		Blue = 8
	}

	[Serializable]
	public class UnitTeamLayerDictionary : SerializableDictionaryBase<UnitTeam, int> {};
	

	// public struct UnitLayer
	// {
	// 	private UnitTeamLayer _layer;
	// 	
	// 	public UnitTeam(UnitTeamLayer layer)
	// 	{
	// 		_layer = layer;
	// 	}
	// }

	[Serializable]
	public class AnimationKeyDictionary : SerializableDictionaryBase<AnimationType, string> { }
}
