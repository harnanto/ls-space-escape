using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    [RequireComponent(typeof(Rigidbody))]
    public class RockMovement : MonoBehaviour
    {
        public float minSpeed = -250f;
        public float maxSpeed = -50f;
        public float minScale = 1f;
        public float maxScale = 10f;

        private Rigidbody m_Rigidbody;
        private PooledObjectDestroyer m_POD;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_POD = GetComponent<PooledObjectDestroyer>();
        }

        private void FixedUpdate()
        {
            float spd = Random.Range(minSpeed, maxSpeed);
            m_Rigidbody.velocity = Vector3.forward * spd;
            m_Rigidbody.angularVelocity = new Vector3(10f, 10f, 10f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.transform.root.gameObject.tag == "Player" ||
                collision.collider.transform.root.gameObject.tag == "Bullet")
            {
                //Invoke("Destroy", 0f);
                m_POD.Destroy();
                //Debug.Log("destroy");
            }
        }
    }
}
