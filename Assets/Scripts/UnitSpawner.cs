using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitSpawner : IInitializable, ITickable
    {
        private UnitFacade.Factory _unitFactory;
        private UnitSettings _settings;
        private Transform _spawnPoint;
        private float _lastSpawnTime;
        private int _unitCount;
        
        public UnitSpawner(
            UnitFacade.Factory unitFactory, 
            UnitSettings settings, 
            Transform spawnPoint)
        {
            _unitFactory = unitFactory;
            _settings = settings;
            _spawnPoint = spawnPoint;
        }
        
        public void Initialize()
        {
            SpawnUnit();
        }

        public void Tick()
        {
            if (Time.realtimeSinceStartup - _lastSpawnTime > _settings.respawnTime)
            {
                SpawnUnit();
            }
        }

        private void SpawnUnit()
        {
            var unitFacade = _unitFactory.Create();
            unitFacade.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);
            _lastSpawnTime = Time.realtimeSinceStartup;
            _unitCount++;
        }
    }
}