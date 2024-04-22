using _Assets.Scripts.Services.UIs.Controllers;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class CharacterSelectionView : MonoBehaviour
    {
        [Inject] private CharacterSelectionController _characterSelectionController;
        private readonly Vector3 _origin = Vector3.zero;

        private void Start() => _characterSelectionController.Init(_origin);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _characterSelectionController.SelectPreviousCharacter();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _characterSelectionController.SelectNextCharacter();
            }
        }

        public void Animate()
        {
            
        }
    }
}