using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private GameObject loadingUI;
        [SerializeField] private GameObject characterSelectionUI;
        [SerializeField] private GameObject gameUI;
        public GameObject LoadingUI => loadingUI;
        public GameObject CharacterSelectionUI => characterSelectionUI;
        public GameObject GameUI => gameUI;
    }
}