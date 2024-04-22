using _Assets.Scripts.Services.UIs.Controllers;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class CharacterSelectionView : MonoBehaviour
    {
        [Inject] private CharacterSelectionController _characterSelectionController;
        private readonly Vector3 _origin = Vector3.zero;
        private bool _canSelect = true;

        private void Start() => _characterSelectionController.Init(_origin);

        private async void Update()
        {
            if (!_canSelect)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _canSelect = false;
                await _characterSelectionController.SelectPreviousCharacter();
                _canSelect = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _canSelect = false;
                await _characterSelectionController.SelectNextCharacter();
                _canSelect = true;
            }
        }
    }
}