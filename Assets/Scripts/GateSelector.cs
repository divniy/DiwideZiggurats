using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class GateSelector : IInitializable, IDisposable
    {
        [Inject] private GateFacade _gateFacade;
        [Inject] private UnitSettings _unitSettings;
        [Inject] private SignalBus _signalBus;
        [Inject] private PopupPresenter _popupPresenter;

        public bool isSelected;
        // [Inject] private UnitRegistry _unitRegistry;
        public void Initialize()
        {
            _signalBus.Subscribe<TeamSelectedSignal>(OnTeamSelected);
            
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<TeamSelectedSignal>(OnTeamSelected);
        }
        
        private void OnTeamSelected(TeamSelectedSignal signal)
        {
            if (_gateFacade.gameObject.layer == signal.layer)
            {
                Select();
            }
            else
            {
                Deselect();
            }
        }

        public void Select()
        {
            isSelected = true;
            _popupPresenter.Show(_unitSettings);
        }

        public void Deselect()
        {
            isSelected = false;
        }

    }
}