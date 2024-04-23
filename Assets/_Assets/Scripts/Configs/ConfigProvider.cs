using UnityEngine;
using UnityEngine.InputSystem;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private Characters characters;
        [SerializeField] private InputActionAsset input;
        public UIConfig UIConfig => uiConfig;
        public Characters Characters => characters;
        public InputActionAsset Input => input;
    }
}