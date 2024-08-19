using System;
using UnityEngine;

namespace OtherScripts
{
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField] private float timeTillDestroy = 3f;

        private void Start()
        {
            Destroy(gameObject,timeTillDestroy);
        }
    }
}