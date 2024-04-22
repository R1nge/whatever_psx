using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class CharacterSelectionState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIStateMachine _uiStateMachine;

        public CharacterSelectionState(GameStateMachine stateMachine, UIStateMachine uiStateMachine)
        {
            _stateMachine = stateMachine;
            _uiStateMachine = uiStateMachine;
        }

        public async UniTask Enter()
        {
            await _uiStateMachine.SwitchState(UIStateType.CharacterSelection);
        }

        public async UniTask Exit()
        {
        }
    }
}