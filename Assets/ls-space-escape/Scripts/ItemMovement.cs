using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    [RequireComponent(typeof(Rigidbody))]
    public class ItemMovement : MonoBehaviour
    {
        public GameObject effect;
        public float speed = -100f;

        private Rigidbody m_Rigidbody;
        private PooledObjectDestroyer m_POD;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_POD = GetComponent<PooledObjectDestroyer>();
        }

        private void FixedUpdate()
        {
            m_Rigidbody.velocity = Vector3.forward * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.transform.root.gameObject.tag == "Player")
            {
                m_POD.Destroy();
                if (effect)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
                }
            }
        }
    }
}