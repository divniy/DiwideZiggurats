using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class GateFacade : MonoBehaviour
    {
        [Inject] private UnitSpawner _unitSpawner;
        [Inject] private GateSelector _gateSelector;
        public UnitSpawner UnitSpawner => _unitSpawner;

        public void Select()
        {
            _gateSelector.Select();
        }
    }
}