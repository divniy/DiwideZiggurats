using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Diwide.Ziggurat
{
    public class TeamPopup : MonoBehaviour
    {
        // [SerializeField] private UnitSettings unitSettings;
        public UnitSettings unitSettings;
        // public float maxHealth;
        public Slider maxHealthSlider;

        private void Start()
        {
            maxHealthSlider.value = unitSettings.health;
            maxHealthSlider.OnValueChangedAsObservable().Subscribe(newValue => unitSettings.health = newValue);
        }
    }
}