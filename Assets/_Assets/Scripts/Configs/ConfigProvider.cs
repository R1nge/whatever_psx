using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private Characters characters;
        public UIConfig UIConfig => uiConfig;
        public Characters Characters => characters;
    }
}