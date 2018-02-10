using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class SpaceshipInputMobile : SpaceshipInput
    {
        private MobileAxis m_MobileAxis;
        private MobileButton m_MobileButton;

        protected override void Start()
        {
            base.Start();

            m_MobileAxis = GameObject.Find("MobileAxis").GetComponent<MobileAxis>();
            m_MobileButton = GameObject.Find("MobileButton").GetComponent<MobileButton>();
        }

        public override void HandleInput()
        {
            horizontal = m_MobileAxis.horizontal;

            vertical = m_MobileAxis.vertical;
           
            shootABullet = m_MobileButton.isButtonDown;
        }
    }
}

