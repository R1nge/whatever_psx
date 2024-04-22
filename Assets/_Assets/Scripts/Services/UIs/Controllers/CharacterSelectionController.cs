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
                character.transform.rotation = Quaternion.Euler(new Vector3(0, -180f, 0));
                _characters[i] = character;
            }
        }

        public async UniTask SelectNextCharacter()
        {
            _characterSelectionService.SelectNextCharacter();
            await SelectCharacter(true);
        }

        public async UniTask SelectPreviousCharacter()
        {
            _characterSelectionService.SelectPreviousCharacter();
            await SelectCharacter(false);
        }

        private async UniTask SelectCharacter(bool right)
        {
            if (!_canSelect)
            {
                return;
            }

            _canSelect = false;
            const float duration = .25f;

            if (right)
            {
                var lastCharacterPosition = _characters[^1].transform.position;

                // Move each character to the position of the next character (to the right)
                for (int i = _characters.Length - 1; i > 0; i--)
                {
                    _characters[i].transform.DOMove(_characters[i - 1].transform.position, duration);
                }

                // Move the last character to the first position
                _characters[0].transform.DOMove(lastCharacterPosition, duration);
            }
            else
            {
                var firstCharacterPosition = _characters[0].transform.position;

                // Move each character to the position of the previous character (to the left)
                for (int i = 0; i < _characters.Length - 1; i++)
                {
                    _characters[i].transform.DOMove(_characters[i + 1].transform.position, duration);
                }

                // Move the first character to the last position
                _characters[^1].transform.DOMove(firstCharacterPosition, duration);
            }

            await UniTask.Delay((int)(duration * 1000f));
            _canSelect = true;
        }
    }
}