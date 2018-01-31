using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class ParticleSystemAutoSize : MonoBehaviour
    {
        public GameObject player;
        private ParticleSystem m_ParticleSystem;

        private void Start()
        {
            m_ParticleSystem = GetComponent<ParticleSystem>();
            if (!player)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            Resize();
        }

        private void Update()
        {
            Resize();
        }

        void Resize()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(m_ParticleSystem.transform.position);
            pos.x = 1f;
            pos.y = 1f;
            Vector3 tmp = Camera.main.ViewportToWorldPoint(pos);

            ParticleSystem.ShapeModule psShape = m_ParticleSystem.shape;
            Vector3 boxSize = psShape.scale;
            boxSize = new Vector3(tmp.x, tmp.y, 2f);
            psShape.scale = boxSize;

            ParticleSystem.MainModule mainMod = m_ParticleSystem.main;
            mainMod.startSpeed = 5f + player.GetComponent<SpaceshipController>().speed;
        }
    }
}
