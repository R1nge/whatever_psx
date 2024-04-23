using _Assets.Scripts.Services;
using Cinemachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class VampireController : MonoBehaviour
    {
        [SerializeField] private float lookLimit = 90f;
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        private PlayerMovementController _playerMovementController;
        private PlayerCameraController _playerCameraController;
        [Inject] private InputService _inputService;

        private void Start()
        {
            _playerMovementController = new PlayerMovementController(transform);
            _playerCameraController = new PlayerCameraController(transform, playerCamera.transform);
        }

        private void Update()
        {
            Debug.Log(_inputService.MoveHorizontal + " " + _inputService.MoveVertical);
            _playerCameraController.Look(_inputService.LookHorizontal, _inputService.LookVertical, 0.2f, lookLimit);
            _playerMovementController.Move(new Vector3(_inputService.MoveHorizontal, 0, _inputService.MoveVertical));
        }
    }
}