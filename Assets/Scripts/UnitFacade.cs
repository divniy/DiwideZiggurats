using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        [Inject] private PoolableManager<UnitSettings> _poolableManager;
        [Inject] private UnitEnvironment _unitEnvironment;
        [Inject] private UnitSettings _settings;
        [Inject] private IReadOnlyDictionary<UnitTeam, int> _unitTeamLayerDictionary;
        [Inject] private Animator _animator;
        [Inject] private UnitHealthHandler _healthHandler;
        // [Inject] private UnitSelector _unitSelector;
        [Inject] private UnitRegistry _unitRegistry;
        public UnitSettings Settings => _settings;
        public Animator Animator => _animator;
        public UnitHealthHandler HealthHandler => _healthHandler;
        // public UnitSelector UnitSelector => _unitSelector;
        public event Action<UnitHealthHandler> EnemyHitAction;
        
        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            _unitRegistry.Add(this);
            gameObject.layer = _unitTeamLayerDictionary[_settings.unitTeam];
            gameObject.name = Utils.GetRandomName();
            _poolableManager.TriggerOnSpawned(_settings);
        }

        public void OnDespawned()
        {
            _pool = null;
            _unitRegistry.Remove(this);
            gameObject.layer = LayerMask.NameToLayer("Default");
            _poolableManager.TriggerOnDespawned();
        }
        
        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnEnemyHitAction(UnitHealthHandler targetHealthHandler)
        {
            EnemyHitAction?.Invoke(targetHealthHandler);
        }
        
        public class Factory : PlaceholderFactory<UnitFacade>
        {
        }
    }
}