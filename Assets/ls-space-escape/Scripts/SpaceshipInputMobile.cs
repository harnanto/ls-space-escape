using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class SpaceshipInputMobile : SpaceshipInput
    {
        private Canvas_MobileInput m_virtualJoystick;

        protected override void Start()
        {
            base.Start();

            m_virtualJoystick = GameObject.Find("Canvas_MobileInput").GetComponent<Canvas_MobileInput>();
        }

        public override void HandleInput()
        {
            horizontal = m_virtualJoystick.horizontal;
            vertical = m_virtualJoystick.vertical;
            speed = 0f;
            shootABullet = false;

            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    shootABullet = true;
                }
            }
        }
    }
}