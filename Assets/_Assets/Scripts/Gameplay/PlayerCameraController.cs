using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class PlayerCameraController
    {
        private readonly Transform _player;
        private readonly Transform _camera;
        private float _rotationX = 0f;

        public PlayerCameraController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Look(float horizontal, float vertical, float sensitivity, float lookXLimit)
        {
            _rotationX += -vertical * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
            _camera.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            _player.rotation *= Quaternion.Euler(0, horizontal * sensitivity, 0);
        }
    }
}