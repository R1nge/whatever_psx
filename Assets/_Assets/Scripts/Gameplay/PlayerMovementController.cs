using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class PlayerMovementController
    {
        private readonly Transform _transform;
        private readonly CharacterController _characterController;
        private Vector3 _direction;

        public PlayerMovementController(Transform transform, CharacterController characterController)
        {
            _transform = transform;
            _characterController = characterController;
        }

        public void Move(Vector3 input, float speed)
        {
            var forward = _transform.TransformDirection(Vector3.forward);
            var right = _transform.TransformDirection(Vector3.right);
            _direction = (forward * input.z + right * input.x) * speed;
        }

        public void Gravity(float gravity)
        {
            _direction.y -= gravity;
        }

        public void Jump(float jumpForce)
        {
            _direction.y = jumpForce;
        }

        public void Update()
        {
            _characterController.Move(_direction * Time.deltaTime);
        }
    }
}