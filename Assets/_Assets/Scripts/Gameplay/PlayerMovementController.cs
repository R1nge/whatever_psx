using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class PlayerMovementController
    {
        private readonly Transform _transform;
        private readonly CharacterController _characterController;

        public PlayerMovementController(Transform transform, CharacterController characterController)
        {
            _transform = transform;
            _characterController = characterController;
        }
        
        public void Move(Vector3 input)
        {
            var forward = _transform.TransformDirection(Vector3.forward);
            var right = _transform.TransformDirection(Vector3.right);
            var direction = forward * input.z + right * input.x;
            _characterController.Move(direction * Time.deltaTime);
        }
    }
}