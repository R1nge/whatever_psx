using _Assets.Scripts.Services;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class VampireController : MonoBehaviour
    {
        private PlayerMovementController _playerMovementController;
        [Inject] private InputService _inputService;

        private void Start()
        {
            _playerMovementController = new PlayerMovementController(transform);
        }

        private void Update()
        {
            Debug.Log(_inputService.Horizontal + " " + _inputService.Vertical);
            _playerMovementController.Move(new Vector3(_inputService.Horizontal, 0, _inputService.Vertical));
        }
    }
}