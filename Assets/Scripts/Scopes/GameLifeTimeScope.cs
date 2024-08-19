using EnemyScripts;
using OtherScripts;
using PlayerScripts;
using Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameLifeTimeScope : LifetimeScope
    {

        [SerializeField] private PlayerData playerData;
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private ScoreBoard scoreBoard;
        
        protected override void Configure(IContainerBuilder builder)
        {

            builder.Register<SceneService>(Lifetime.Singleton).AsSelf();

            // Component 
            builder.RegisterComponent(scoreBoard);
            
            // Data
            builder.RegisterInstance(playerData).AsSelf();
            builder.RegisterInstance(enemyData).AsSelf();
        }
    }
}