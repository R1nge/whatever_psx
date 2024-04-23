using _Assets.Scripts.Services;
using _Assets.Scripts.Services.CharacterSelection;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.UIs.Controllers;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameplayInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InputService>(Lifetime.Singleton);
            
            builder.Register<CharacterSelectionService>(Lifetime.Singleton);
            builder.Register<CharacterSelectionController>(Lifetime.Singleton);

            builder.Register<CharacterSkinFactory>(Lifetime.Singleton);
            builder.Register<CharacterFactory>(Lifetime.Singleton);
        }
    }
}