using NaughtyAttributes;
using UnityEditor.EditorTools;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class GateFacade : MonoBehaviour
    {
        [Inject] private UnitSpawner _unitSpawner;
        [Inject] private GateSelector _gateSelector;
        public UnitSpawner UnitSpawner => _unitSpawner;
        [ShowNativeProperty]
        public bool IsSelected => _gateSelector.isSelected;

        // public void Select()
        // {
        // _gateSelector.Select();
        // }
    }
}