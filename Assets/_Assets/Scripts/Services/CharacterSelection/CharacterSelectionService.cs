using _Assets.Scripts.Configs;

namespace _Assets.Scripts.Services.CharacterSelection
{
    public class CharacterSelectionService
    {
        private readonly ConfigProvider _configProvider;

        private CharacterSelectionService(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        private int _selectedCharacterIndex;
        public int SelectedCharacterIndex => _selectedCharacterIndex;

        public void SelectNextCharacter()
        {
            _selectedCharacterIndex = (_selectedCharacterIndex + 1) % _configProvider.Characters.Length;
        }

        public void SelectPreviousCharacter()
        {
            _selectedCharacterIndex = (_selectedCharacterIndex - 1 + _configProvider.Characters.Length) % _configProvider.Characters.Length;
        }
    }
}