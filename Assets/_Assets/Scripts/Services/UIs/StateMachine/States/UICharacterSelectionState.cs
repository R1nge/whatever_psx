using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UICharacterSelectionState : IAsyncState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UICharacterSelectionState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public async UniTask Enter() => _ui = _uiFactory.CreateUI(UIStateType.CharacterSelection);

        public async UniTask Exit() => Object.Destroy(_ui);
    }
}