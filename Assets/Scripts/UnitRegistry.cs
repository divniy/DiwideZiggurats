using System.Collections.Generic;

namespace Diwide.Ziggurat
{
    public class UnitRegistry
    {
        private List<UnitFacade> _units = new();
        public IReadOnlyList<UnitFacade> Units => _units;

        public void Add(UnitFacade unit)
        {
            _units.Add(unit);
        }

        public void Remove(UnitFacade unit)
        {
            _units.Remove(unit);
        }
    }
}