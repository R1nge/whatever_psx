using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.CharacterSelection;
using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class CharacterSelectionController
    {
        private readonly CharacterSelectionService _characterSelectionService;
        private readonly ConfigProvider _configProvider;
        private readonly CharacterSkinFactory _characterSkinFactory;

        private GameObject[] _characters;

        private CharacterSelectionController(CharacterSelectionService characterSelectionService,
            ConfigProvider configProvider, CharacterSkinFactory characterSkinFactory)
        {
            _characterSelectionService = characterSelectionService;
            _configProvider = configProvider;
            _characterSkinFactory = characterSkinFactory;
        }

        public void Init(Vector3 origin)
        {
            _characters = new GameObject[_configProvider.Characters.Length];

            for (int i = 0; i < _configProvider.Characters.Length; i++)
            {
                var character = _characterSkinFactory.Create(i);
                character.transform.position = origin + new Vector3(0, 0, 5);
                var angleIncrement = 360f / _configProvider.Characters.Length;
                var angle = angleIncrement * i;
                character.transform.RotateAround(origin, Vector3.up, angle);
                character.transform.LookAt(origin, Vector3.up);
                _characters[i] = character;
            }
        }

        public void SelectNextCharacter()
        {
            var previous = _characterSelectionService.SelectedCharacterIndex;
            _characterSelectionService.SelectNextCharacter();
            SelectCharacter(previous);
        }

        public void SelectPreviousCharacter()
        {
            var previous = _characterSelectionService.SelectedCharacterIndex;
            _characterSelectionService.SelectPreviousCharacter();
            SelectCharacter(previous);
        }

        private void SelectCharacter(int previous)
        {
            var current = _characterSelectionService.SelectedCharacterIndex;

            _characters[previous].SetActive(false);
            _characters[current].SetActive(true);
        }
    }
}