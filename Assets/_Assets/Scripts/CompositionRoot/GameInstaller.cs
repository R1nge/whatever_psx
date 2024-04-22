using _Assets.Scripts.Services.CharacterSelection;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.Controllers;
using _Assets.Scripts.Services.UIs.StateMachine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //TODO: move to character selection installer or something
            builder.Register<CharacterSelectionService>(Lifetime.Singleton);
            builder.Register<CharacterSelectionController>(Lifetime.Singleton);
            
            builder.Register<CharacterSkinFactory>(Lifetime.Singleton);
            builder.Register<CharacterFactory>(Lifetime.Singleton);
            //
            
            
            
            builder.Register<UIStatesFactory>(Lifetime.Singleton);
            builder.Register<UIStateMachine>(Lifetime.Singleton);
            builder.Register<UIFactory>(Lifetime.Singleton);
            
            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}