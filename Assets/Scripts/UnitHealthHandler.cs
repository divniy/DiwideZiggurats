using System;
using NaughtyAttributes;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitHealthHandler : MonoBehaviour, IPoolable<UnitSettings>
    {
        [SerializeField, ProgressBar("_maxHealth", EColor.Red)] 
        private float health;
        private float _maxHealth;
        [Inject] private UnitEnvironment _environment;

        public ReactiveProperty<float> Health { get; private set; }
        public event Action<float> HealthChanged;
        public event Action UnitDied;

        private void Awake()
        {
            Health = new();
        }

        public void OnSpawned(UnitSettings settings)
        {
            _maxHealth = settings.health;
            Health.Value = settings.health;
            Health.Subscribe(_ => health = _);
        }

        public void OnDespawned()
        {
            // health = _maxHealth = default;
        }

        public void TakeDamage(float damage)
        {
            Health.Value = Mathf.Max(Health.Value - damage, 0);
            OnHealthChanged(health);
            if (Health.Value == 0) Die();
        }
        
        [Button]
        private void Die()
        {
            _environment.StartAnimation("Die");
            OnUnitDied();
        }

        protected virtual void OnHealthChanged(float newHealth)
        {
            HealthChanged?.Invoke(newHealth);
        }

        protected virtual void OnUnitDied()
        {
            UnitDied?.Invoke();
        }
    }
}