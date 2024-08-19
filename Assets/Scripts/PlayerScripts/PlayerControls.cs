using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

namespace Ship
{
    public class PlayerControls : MonoBehaviour
    { 
        [Header("----------SHIP SETTINGS----------")]
        [SerializeField] private InputAction movement;
        [SerializeField] private float shipControlSpeed = 30f;
        [SerializeField] private float xRange = 13.5f;
        [SerializeField] private float yRange = 15f;
        [SerializeField] private float positionPitchFactor = -2f;
        [SerializeField] private float controlPitchFactor = -15f;
        [SerializeField] private float positionYawFactor = 2f;
        [SerializeField] private float controlRollFactor = -20f;
    
    
        private float yThrow, xThrow;

        private void OnEnable()
        {
            movement.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
        }

        private void Update()
        {
            ProcessTranslation();
            ProcessRotation();
        }

        private void ProcessTranslation()
        {
            xThrow = movement.ReadValue<Vector2>().x;
            yThrow = movement.ReadValue<Vector2>().y;

        
            float xOffset = xThrow * Time.deltaTime * shipControlSpeed;
            float rawXPos = transform.localPosition.x + xOffset;
            float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        
        
            float yOffset = yThrow * Time.deltaTime * shipControlSpeed;
            float rawYPos = transform.localPosition.y + yOffset;
            float clampedYPos = Mathf.Clamp(rawYPos, -3, yRange);

            transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        }
    

        private void ProcessRotation()
        {
            float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
            float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
            float pitch =  pitchDueToPosition + pitchDueToControlThrow;
            float yaw = transform.localPosition.x * positionYawFactor;
            float roll = xThrow * controlRollFactor;
            transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
        }
    
    
    }
}


