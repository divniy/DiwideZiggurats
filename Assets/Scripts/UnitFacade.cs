using System;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        [Inject] private PoolableManager _poolableManager;
        [Inject] private UnitEnvironment _unitEnvironment;
        private IMemoryPool _pool;
        
        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            _poolableManager.TriggerOnSpawned();
        }

        public void OnDespawned()
        {
            _pool = null;
            _poolableManager.TriggerOnDespawned();
        }

        [Button]
        public void Die()
        {
            _unitEnvironment.StartAnimation("Die");
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