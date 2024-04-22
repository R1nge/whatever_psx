using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class CharacterSkinFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private CharacterSkinFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public GameObject Create(int index)
        {
            var skin = _objectResolver.Instantiate(_configProvider.Characters.GetSkin(index));
            return skin;
        }
    }
}