using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class CharacterFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly CharacterSkinFactory _characterSkinFactory;
        private readonly ConfigProvider _configProvider;

        private CharacterFactory(IObjectResolver objectResolver, CharacterSkinFactory characterSkinFactory, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _characterSkinFactory = characterSkinFactory;
            _configProvider = configProvider;
        }
        public GameObject Create(int characterIndex)
        {
            var character = _objectResolver.Instantiate(_configProvider.Characters.GetCharacter(characterIndex));
            var skin = _characterSkinFactory.Create(characterIndex);
            skin.transform.SetParent(character.transform);
            return character;
        }
    }
}