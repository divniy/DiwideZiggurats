using System;
using NaughtyAttributes;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitHealthHandler : MonoBehaviour, IPoolable<UnitSettings>
    {
        [Inject] private UnitEnvironment _environment;
        public IReactiveProperty<float> Health { get; private set; }
        public IReadOnlyReactiveProperty<bool> IsDead { get; private set; }

        private IDisposable _disposable;

        private void Awake()
        {
            Health = new ReactiveProperty<float>();
            IsDead = Health.Select(h => h <= 0).ToReactiveProperty();
        }

        public void OnSpawned(UnitSettings settings)
        {
            Health.Value = settings.health;
            _disposable = IsDead.Where(isDead => isDead == true).Subscribe(_ => Die());
        }

        public void OnDespawned()
        {
            _disposable.Dispose();
        }

        public void TakeDamage(float damage)
        {
            Health.Value = Mathf.Max(Health.Value - damage, 0);
        }
        
        // [Button]
        private void Die()
        {
            _environment.StartAnimation("Die");
        }
    }
}