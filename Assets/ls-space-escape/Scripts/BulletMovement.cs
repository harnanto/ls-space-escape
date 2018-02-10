using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletMovement : MonoBehaviour
    {
        public GameObject explosion;
        public float speed = 700f;

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
            if (collision.collider.transform.root.gameObject.tag == "Enemy")
            {
                m_POD.Destroy();

                if (explosion)
                {
                    Instantiate(explosion, transform.position, Quaternion.identity);
                }

                //tambah nilai
                GameManager.instance.AddScore();
            }
        }
    }
}

