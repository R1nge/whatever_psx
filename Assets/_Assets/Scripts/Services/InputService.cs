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
        public float Horizontal => _configProvider.Input.FindAction("Move").ReadValue<Vector2>().x;
        public float Vertical => _configProvider.Input.FindActionMap("Player").FindAction("Move").ReadValue<Vector2>().y;

        public void Enable() => _enabled = true;
        
        public void Disable() => _enabled = false;
    }
}