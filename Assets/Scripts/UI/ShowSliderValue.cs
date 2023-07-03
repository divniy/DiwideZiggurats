using UnityEngine;
using UnityEngine.UI;

namespace Diwide.Ziggurat.UI
{
	[RequireComponent(typeof(Text))]
	public class ShowSliderValue : MonoBehaviour
	{
		public void UpdateLabel (float value)
		{
			if (TryGetComponent<Text>(out var label))
			{
				label.text = Mathf.RoundToInt(value).ToString();
			}
		}
	}
}
