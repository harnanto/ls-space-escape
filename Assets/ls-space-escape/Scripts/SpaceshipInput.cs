﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public abstract class SpaceshipInput : MonoBehaviour
    {
        public float horizontal = 0f;
        public float vertical = 0f;
        public float speed = 0f;
        public bool shootABullet = false;

        protected SpaceshipController m_SpaceshipController;

        private void Start()
        {
            m_SpaceshipController = GetComponent<SpaceshipController>();
        }

        public virtual void HandleInput()
        {

        }
    }
}