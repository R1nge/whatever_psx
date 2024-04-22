using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.CharacterSelection;
using _Assets.Scripts.Services.Factories;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class CharacterSelectionController
    {
        private readonly CharacterSelectionService _characterSelectionService;
        private readonly ConfigProvider _configProvider;
        private readonly CharacterSkinFactory _characterSkinFactory;

        private GameObject[] _characters;
        private bool _canSelect = true;

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

        public async UniTask SelectNextCharacter()
        {
            var previous = _characterSelectionService.SelectedCharacterIndex;
            _characterSelectionService.SelectNextCharacter();
            await SelectCharacter(previous);
        }

        public async UniTask SelectPreviousCharacter()
        {
            var previous = _characterSelectionService.SelectedCharacterIndex;
            _characterSelectionService.SelectPreviousCharacter();
            await SelectCharacter(previous);
        }

        private async UniTask SelectCharacter(int previous)
        {
            if (!_canSelect)
            {
                return;
            }

            _canSelect = false;
            var current = _characterSelectionService.SelectedCharacterIndex;

            var previousCharacterPosition = _characters[previous].transform.position;
            var currentCharacterPosition = _characters[current].transform.position;
            const float duration = .25f;
            _characters[previous].transform.DOMove(currentCharacterPosition, duration);
            _characters[current].transform.DOMove(previousCharacterPosition, duration);
            await UniTask.Delay((int)(duration * 1000f));
            _canSelect = true;
        }
    }
}