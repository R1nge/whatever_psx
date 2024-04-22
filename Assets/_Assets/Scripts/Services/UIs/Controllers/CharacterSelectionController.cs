using _Assets.Scripts.Services.CharacterSelection;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class CharacterSelectionController
    {
        private readonly CharacterSelectionService _characterSelectionService;

        private CharacterSelectionController(CharacterSelectionService characterSelectionService)
        {
            _characterSelectionService = characterSelectionService;
        }
        
        public void SelectNextCharacter()
        {
            _characterSelectionService.SelectNextCharacter();
        }

        public void SelectPreviousCharacter()
        {
            _characterSelectionService.SelectPreviousCharacter();
        }
    }
}