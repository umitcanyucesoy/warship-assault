using System;
using Interfaces;
using Services;
using Ship;
using UnityEngine;
using VContainer;

namespace PlayerScripts
{
    public class Player : MonoBehaviour,ICollision
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private ParticleSystem crashVFX;
        private SceneService _sceneService;

        [Inject]
        public void Construct(PlayerData playerData, SceneService sceneService)
        {
            _playerData = playerData;
            _sceneService = sceneService;
        }        
        
        private void Start()
        {
            
        }
        

        private void OnTriggerEnter(Collider other)
        {
            StartCrashSequence();
        }

        public void StartCrashSequence()
        {
            Invoke("ReloadLevel",1);
            crashVFX.Play();
            GetComponent<PlayerControls>().enabled = false;
            
        }

        private void ReloadLevel()
        {
            if (_sceneService != null)
            {
                _sceneService.ReloadLevel();
            }
            else
            {
                Debug.Log("SceneService is not set.");
            }
        }
    }
}
