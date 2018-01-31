using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpaceshipController : MonoBehaviour
    {
        public Transform pivot;
        public Transform bulletSpawn;
        public AudioSource collisionSound;

        public float movementSpeed = 50f;
        public float rollSpeed = 10f;
        public float targetRotAngle = 45f;
        public bool invertUpDown = true;
        public float acceleration = 50f;
        public float speed = 0f;
        public float maxHealth = 10f;

        private Rigidbody m_Rigidbody;
        private SpaceshipInput m_SpaceshipInput;
        private float m_Health = 0f;
        
        public float health
        {
            get
            {
                return m_Health;
            }
        }

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_SpaceshipInput = GetComponent<SpaceshipInput>();
            m_Health = maxHealth;
        }

        private void Update()
        {
            if (m_SpaceshipInput)
            {
                m_SpaceshipInput.HandleInput();
            }

            if(m_SpaceshipInput.shootABullet)
            {
                ShootABullet();
            }
        }

        private void FixedUpdate()
        {
            Translate();

            ClampEdge();

            Roll();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.transform.root.gameObject.tag == "Enemy")
            {
                m_Health -= 1f;

                if(collisionSound)
                {
                    collisionSound.Play();
                }
            }
        }

        void Translate()
        {
            speed = speed + m_SpaceshipInput.speed * acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0f, 100f);
            //Debug.Log(speed);
            m_Rigidbody.velocity = new Vector3(m_SpaceshipInput.horizontal, m_SpaceshipInput.vertical * (invertUpDown ? -1f : 1f), 0f) * movementSpeed;
        }

        void ClampEdge()
        {
            float theZ = transform.position.z;
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            transform.position = new Vector3(transform.position.x, transform.position.y, theZ);
        }

        void Roll()
        {
            Quaternion targetRot = Quaternion.AngleAxis(-m_SpaceshipInput.horizontal * targetRotAngle, transform.forward);
            pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRot, Time.fixedDeltaTime * rollSpeed);
        }

        public void ShootABullet()
        {
            GameObject obj = GameManager.instance.pooler.GetPooledGameObject("laserbullet");
            if (obj)
            {
                BulletMovement rm = obj.GetComponent<BulletMovement>();
                if (rm)
                {
                    obj.transform.position = bulletSpawn.position;
                    obj.SetActive(true);
                }
            }
        }
    }
}
