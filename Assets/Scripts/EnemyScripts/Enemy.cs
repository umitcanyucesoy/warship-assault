using Interfaces;
using OtherScripts;
using PlayerScripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using VContainer;
using VContainer.Unity;

namespace EnemyScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour,IDamageable
    {

        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private GameObject deathVFX;
        [SerializeField] private GameObject hitVFX;
        [SerializeField] private Transform parent;
        private ScoreBoard _scoreBoard;
        private IObjectResolver _objectResolver;
        private int currentHealth;

        [Inject]
        public void Construct(EnemyData enemyData, PlayerData playerData,IObjectResolver objectResolver,ScoreBoard scoreBoard)
        {
            _enemyData = enemyData;
            _playerData = playerData;
            _objectResolver = objectResolver;
            _scoreBoard = scoreBoard;
        }
        
        private void Start()
        {
            currentHealth = _enemyData.health;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
        
        private void OnParticleCollision(GameObject other)
        {
            TakeDamage();
            if (currentHealth <= 0)
            {
                KillEnemy();
            }
        }
        
        public void TakeDamage()
        {
            currentHealth -= _playerData.attackDamage;
            GameObject vfx = _objectResolver.Instantiate(hitVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
        }

        private void KillEnemy()
        {
            GameObject vfx = _objectResolver.Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
            _scoreBoard.IncreaseScore(_enemyData.scorePerDeath);
        }

        
    }
    
    
}
