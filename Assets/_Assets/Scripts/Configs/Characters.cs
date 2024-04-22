using System;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Characters", menuName = "Configs/Characters")]
    public class Characters : ScriptableObject
    {
        [SerializeField] private Character[] characters;
        public int Length => characters.Length;

        public GameObject GetSkin(int index)
        {
            if (index < 0 || index >= characters.Length)
            {
                Debug.LogError("Skin index out of range: " + index);
                return null;
            }

            return characters[index].skin;
        }

        public GameObject GetCharacter(int index)
        {
            if (index < 0 || index >= characters.Length)
            {
                Debug.LogError("Character index out of range: " + index);
                return null;
            }

            return characters[index].character;
        }
    }

    [Serializable]
    public struct Character
    {
        public GameObject skin;
        public GameObject character;
    }
}