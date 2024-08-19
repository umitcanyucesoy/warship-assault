using UnityEngine;

namespace EnemyScripts
{
    [CreateAssetMenu(fileName = "Create", menuName = "Data/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        public int health;
        public int flySpeed;
        public int attackDamage;
        public int scorePerDeath;
    }
}