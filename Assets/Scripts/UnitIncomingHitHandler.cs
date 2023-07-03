using System;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitIncomingHitHandler : MonoBehaviour//, IPoolable<UnitSettings>
    {
        private UnitSettings _settings;
        private UnitFacade _facade;

        [Inject]
        private void Construct(UnitSettings settings, UnitFacade unitFacade)
        {
            _settings = settings;
            _facade = unitFacade;
        }
        
        // public void OnSpawned(UnitSettings unitSettings)
        // {
        //     _settings = unitSettings;
        // }
        //
        // public void OnDespawned()
        // {
        // }

        private void OnTriggerEnter(Collider other)
        {
            bool isWeapon = other.CompareTag(_settings.weaponTag);
            var otherRootGameObject = other.attachedRigidbody?.gameObject;
            bool isEnemy = gameObject.layer != otherRootGameObject.layer;
            if (isWeapon && otherRootGameObject && isEnemy)
            {
                UnitFacade enemyFacade = otherRootGameObject.GetComponent<UnitFacade>();
                enemyFacade.OnEnemyHitAction(_facade.HealthHandler);
                Debug.Log("Hit decected");
                
            }
        }
    }
}