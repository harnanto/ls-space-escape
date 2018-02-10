using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class SpaceshipInput : MonoBehaviour
    {
        public float horizontal = 0f;
        public float vertical = 0f;
        public bool shootABullet = false;

        protected SpaceshipController m_SpaceshipController;

        protected virtual void Start()
        {
            m_SpaceshipController = GetComponent<SpaceshipController>();
        }

        public virtual void HandleInput()
        {

        }
    }
}
