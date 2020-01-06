using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class SpaceshipController : MonoBehaviour
    {
        public GameObject healthEffect;
        public GameObject bullet;
        public Transform pivot;
        public Transform bulletSpawn;
        public AudioSource rockCollisionSound;
        public AudioSource healthCollisionSound;

        public float movementSpeed = 50f;
        public float rollSpeed = 10f;
        public float targetRotAngle = 45f;
        public bool invertUpDown = true;
        public float acceleration = 50f;
        public float maxHealth = 10f;

        private Rigidbody m_Rigidbody;
        private SpaceshipInput m_SpaceshipInput;
        private float m_Health = 0f;
        private float m_HFXTimer = 0f;
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

            if (healthEffect)
            {
                healthEffect.SetActive(false);
            }
        }

        private void Update()
        {
            if (m_SpaceshipInput)
            {
                m_SpaceshipInput.HandleInput();
            }

            if (m_SpaceshipInput.shootABullet)
            {
                ShootABullet();
            }

            m_HFXTimer += Time.deltaTime;

            if(m_HFXTimer >= 2f)
            {
                if(healthEffect)
                {
                    healthEffect.SetActive(false);
                }
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

                if (rockCollisionSound)
                {
                    rockCollisionSound.Play();
                }
            }
            else if (collision.collider.transform.root.gameObject.tag == "Health")
            {
                m_Health += 1f;

                m_Health = Mathf.Clamp(m_Health, 0f, maxHealth);

                if (healthCollisionSound)
                {
                    healthCollisionSound.Play();
                }

                if(healthEffect)
                {
                    healthEffect.SetActive(true);
                    m_HFXTimer = 0f;
                }
            }
        }

        void Translate()
        {
            m_Rigidbody.velocity = new Vector3(m_SpaceshipInput.horizontal, m_SpaceshipInput.vertical * (invertUpDown ? -1f : 1f), 0f) * movementSpeed;
        }

        void ClampEdge()
        {
            //dapatkan transform position
            Vector3 theTransformPosition = transform.position;

            //catat nilai z nya
            float theZ = transform.position.z;

            //konversi koordinat world ke viewport
            Vector3 thePositionVP = Camera.main.WorldToViewportPoint(theTransformPosition);

            //clamp x
            thePositionVP.x = Mathf.Clamp01(thePositionVP.x);

            //clamp y
            thePositionVP.y = Mathf.Clamp01(thePositionVP.y);

            //selesai
            theTransformPosition = Camera.main.ViewportToWorldPoint(thePositionVP);
            transform.position = new Vector3(theTransformPosition.x, theTransformPosition.y, theZ);
        }

        void Roll()
        {
            Quaternion targetRot = Quaternion.AngleAxis(-m_SpaceshipInput.horizontal * targetRotAngle, transform.forward);
            pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRot, Time.fixedDeltaTime * rollSpeed);
        }

        void ShootABullet()
        {
            GameObject obj = GameManager.instance.pooler.GetPooledGameObject("bullet");
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

