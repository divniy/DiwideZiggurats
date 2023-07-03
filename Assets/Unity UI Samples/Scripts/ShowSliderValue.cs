using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowSliderValue : MonoBehaviour
{
	public void UpdateLabel (float value)
	{
		if (TryGetComponent<Text>(out var label))
		{
			label.text = Mathf.RoundToInt(value).ToString();
		}
		// Text lbl = GetComponent<Text>();
		// if (lbl != null)
		// 	lbl.text = Mathf.RoundToInt (value * 100) + "%";
	}
}
