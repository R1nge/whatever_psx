using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.UIs.Controllers;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class CharacterSelectionView : MonoBehaviour
    {
        [Inject] private ConfigProvider _configProvider;
        [Inject] private CharacterSelectionController _characterSelectionController;
        [Inject] private CharacterSkinFactory _characterSkinFactory;
        private Vector3 _origin = Vector3.zero;

        private void Start()
        {
            for (int i = 0; i < _configProvider.Characters.Length; i++)
            {
                _characterSkinFactory.Create(i);
            }
        }

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
    }
}