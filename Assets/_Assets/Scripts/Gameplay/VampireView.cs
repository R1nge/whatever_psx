using _Assets.Scripts.Configs;
using _Assets.Scripts.Services;
using Cinemachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class VampireView : MonoBehaviour
    {
        [SerializeField] private CharacterStatsConfig stats;
        [SerializeField] private float lookLimit = 90f;
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        [SerializeField] private CharacterController characterController;
        private PlayerMovementController _playerMovementController;
        private PlayerCameraController _playerCameraController;
        [Inject] private InputService _inputService;

        private void Start()
        {
            _playerMovementController = new PlayerMovementController(transform, characterController);
            _playerCameraController = new PlayerCameraController(transform, playerCamera.transform);
        }

        private void Update()
        {
            _playerCameraController.Look(_inputService.LookHorizontal, _inputService.LookVertical, 0.2f, lookLimit);
            _playerMovementController.Move(new Vector3(_inputService.MoveHorizontal, 0, _inputService.MoveVertical), stats.Speed);
        }
    }
}