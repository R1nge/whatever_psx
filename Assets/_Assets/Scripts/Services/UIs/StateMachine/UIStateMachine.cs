using System.Collections.Generic;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStateMachine : GenericAsyncStateMachine<UIStateType, IAsyncState>
    {
        private UIStateMachine(UIStatesFactory uiStatesFactory)
        {
            States = new Dictionary<UIStateType, IAsyncState>
            {
                { UIStateType.Loading, uiStatesFactory.CreateState(UIStateType.Loading, this) },
                { UIStateType.CharacterSelection, uiStatesFactory.CreateState(UIStateType.CharacterSelection, this) }
            };
        }
    }
}