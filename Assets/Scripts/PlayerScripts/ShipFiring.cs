using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition;

namespace Ship
{
    public class ShipFiring : MonoBehaviour
    {
        [SerializeField] private InputAction fire;
        [SerializeField] private List<GameObject> lasers;
        
        
        private void Update()
        {
            ProcessFiring();
        }
        
        private void OnEnable()
        {
            fire.Enable();
        }

        private void OnDisable()
        {
            fire.Disable();
        }

        private void ProcessFiring()
        {
            if (fire.ReadValue<float>() > .5)
            {
                SetActiveLasers(true);
            }
            else
            {
                SetActiveLasers(false);
            }
        }


        private void SetActiveLasers(bool isActive)
        {
            foreach (var laser in lasers)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = isActive;
            }
        }
    }
}
