using UnityEngine;

namespace Diwide.Ziggurat
{
    [CreateAssetMenu(fileName = "Resources/UnitSettings.asset", menuName = "Unit Settings", order = 0)]
    public class UnitSettings : ScriptableObject
    {
        public UnitTeam unitTeam = UnitTeam.Red;
        public float health = 100;
        public float fastAttackDamage = 10;
    }
}