using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class PlayerMovementController
    {
        private readonly Transform _transform;

        public PlayerMovementController(Transform transform)
        {
            _transform = transform;
        }
        
        public void Move(Vector3 direction)
        {
            _transform.position += direction;
        }
    }
}