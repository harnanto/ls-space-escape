using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class PooledObjectDestroyer : MonoBehaviour
    {
        public float timeToDestroy = 2f;

        private void OnEnable()
        {
            Invoke("Destroy", timeToDestroy);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}
