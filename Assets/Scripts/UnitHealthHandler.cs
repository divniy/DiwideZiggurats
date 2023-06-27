using System;
using NaughtyAttributes;
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

        public float Health => health;
        public event Action<float> HealthChanged;
        public event Action UnitDied;
        
        public void OnSpawned(UnitSettings settings)
        {
            _maxHealth = health = settings.health;
            // health = _maxHealth;
        }

        public void OnDespawned()
        {
            health = _maxHealth = default;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            OnHealthChanged(health);
            if (health == 0) Die();
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