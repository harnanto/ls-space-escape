using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class SpaceshipInputKeyboard : SpaceshipInput
    {
        public float delayBetweenDown = 0.5f;

        private bool m_IsDown;
        private float m_DelayTimer;
        private bool m_ReadyToDown = false;

        public override void HandleInput()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            //
            if (Input.GetMouseButton(0))
            {
                m_ReadyToDown = true;
                m_IsDown = true;
            }
            else
            {
                m_ReadyToDown = false;
                m_IsDown = false;
            }

            m_DelayTimer += Time.deltaTime;

            m_IsDown = false;

            if (m_DelayTimer > delayBetweenDown && m_ReadyToDown)
            {
                m_IsDown = true;
                m_DelayTimer = 0f;
            }

            //
            shootABullet = m_IsDown;
        }
    }
}

