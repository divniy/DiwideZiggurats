using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitSpawnPoint : MonoBehaviour
    {
        // [SerializeField] private UnitTeam unitTeam = UnitTeam.Red;
        private UnitFacade.Factory _unitFactory;

        [Inject]
        private void Construct(UnitFacade.Factory unitFactory)
        {
            _unitFactory = unitFactory;
        }
        
        [Button]
        public void SpawnUnit()
        {
            var unitFacade = _unitFactory.Create();
            unitFacade.transform.position = transform.position;
            unitFacade.transform.rotation = transform.rotation;
        }
    }
}