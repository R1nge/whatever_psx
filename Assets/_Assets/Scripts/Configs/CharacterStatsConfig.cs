using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CharacterStatsConfig", menuName = "Configs/CharacterStatsConfig")]
    public class CharacterStatsConfig : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private int maxHealth;
        [SerializeField] private int jumps;
        [SerializeField] private float jumpForce;

        public float Speed => speed;
        public int MaxHealth => maxHealth;
        public int Jumps => jumps;
        public float JumpForce => jumpForce;
    }
}