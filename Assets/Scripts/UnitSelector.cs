using System;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class UnitSelector : IPoolable<UnitSettings>
    {
        [Inject] private Settings _settings;
        [Inject] private SignalBus _signalBus;
        [Inject] private UnitFacade _unitFacade;
        [Inject] private GateFacade _gateFacade;
        
        public void OnSpawned(UnitSettings settings)
        {
            _signalBus.Subscribe<TeamSelectedSignal>(OnTeamSelected);
            if(_gateFacade.IsSelected) SelectUnit();
        }
        
        public void OnDespawned()
        {
            _signalBus.Unsubscribe<TeamSelectedSignal>(OnTeamSelected);
        }

        private void OnTeamSelected(TeamSelectedSignal signal)
        {
            if (_unitFacade.gameObject.layer == signal.layer)
            {
                SelectUnit();
            }
            else
            {
                DeselectUnit();
            }
        }

        public void SelectUnit()
        {
            _settings.selectionCircle.SetActive(true);
        }

        public void DeselectUnit()
        {
            _settings.selectionCircle.SetActive(false);
        }
        
        [System.Serializable]
        public class Settings
        {
            public GameObject selectionCircle;
        }
    }
}