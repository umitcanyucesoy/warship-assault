using UnityEngine;

namespace PlayerScripts
{
    [CreateAssetMenu(fileName = "Create", menuName = "Data/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public int health;
        public int flySpeed;
        public int attackDamage;
    }
}