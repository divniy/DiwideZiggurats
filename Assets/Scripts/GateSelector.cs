using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat
{
    public class GateSelector
    {
        [Inject] private UnitRegistry _unitRegistry;

        public void Select()
        {
            foreach (var unit in _unitRegistry.Units)
            {
                unit.UnitSelector.SelectUnit();
            }
        }

    }
}