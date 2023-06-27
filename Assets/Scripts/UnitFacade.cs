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
        [Inject] private UnitHealthHandler _healthHandler;
        public UnitSettings Settings => _settings;
        public UnitHealthHandler HealthHandler => _healthHandler;
        
        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            gameObject.layer = _unitTeamLayerDictionary[_settings.unitTeam];
            _poolableManager.TriggerOnSpawned(_settings);
        }

        public void OnDespawned()
        {
            _pool = null;
            gameObject.layer = LayerMask.NameToLayer("Default");
            _poolableManager.TriggerOnDespawned();
        }
        
        public void Dispose()
        {
            
            _pool.Despawn(this);
        }
        
        public class Factory : PlaceholderFactory<UnitFacade>
        {
        }
    }
}