using NaughtyAttributes;
using UnityEngine;

namespace Diwide.Ziggurat
{
    [CreateAssetMenu(fileName = "Resources/UnitSettings.asset", menuName = "Unit Settings", order = 0)]
    public class UnitSettings : ScriptableObject
    {
        public UnitTeam unitTeam = UnitTeam.Red;
        public float respawnTime = 10f;
        public float health = 100;
        public float attackRange = 2f;
        [Range(0, 100)] public int strongAttackProbability = 30;
        public AttackDamageDictionary attackDamageDictionary = new()
            {
                { AttackType.Fast, 10}, 
                { AttackType.Strong, 20}
            };
        [Tag] public string weaponTag = "Weapon";
    }
}