using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitSpawnPoint : MonoBehaviour
    {
        [SerializeField] private UnitTeam unitTeam = UnitTeam.Red;
        private UnitFacade.Factory _unitFactory;
        private IReadOnlyDictionary<UnitTeam, int> _unitTeamLayerDictionary;

        [Inject]
        private void Construct(UnitFacade.Factory unitFactory, 
            IReadOnlyDictionary<UnitTeam, int> unitTeamLayerDictionary)
        {
            _unitFactory = unitFactory;
            _unitTeamLayerDictionary = unitTeamLayerDictionary;
        }
        
        [Button]
        public void SpawnUnit()
        {
            var unitFacade = _unitFactory.Create();
            unitFacade.transform.position = transform.position;
            unitFacade.gameObject.layer = _unitTeamLayerDictionary[unitTeam];
        }
    }
}