using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class InputService
    {
        private readonly ConfigProvider _configProvider;

        public InputService(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }
        
        private bool _enabled;
        public bool Enabled => _enabled;
        public float MoveHorizontal => _configProvider.Input.FindAction("Move").ReadValue<Vector2>().x;
        public float MoveVertical => _configProvider.Input.FindActionMap("Player").FindAction("Move").ReadValue<Vector2>().y;
        
        public float LookHorizontal => _configProvider.Input.FindAction("Look").ReadValue<Vector2>().x;
        public float LookVertical => _configProvider.Input.FindAction("Look").ReadValue<Vector2>().y;

        public void Enable() => _enabled = true;
        
        public void Disable() => _enabled = false;
    }
}