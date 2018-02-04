using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceEscape
{
    public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public float delayBetweenDown = 0.5f;

        private bool m_IsDown;
        private float m_DelayTimer;
        private bool m_ReadyToDown = false;

        public bool isButtonDown
        {
            get
            {
                return m_IsDown;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            m_ReadyToDown = true;
            m_IsDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_ReadyToDown = false;
            m_IsDown = false;
        }

        void Update()
        {
            m_DelayTimer += Time.deltaTime;

            m_IsDown = false;

            if (m_DelayTimer > delayBetweenDown && m_ReadyToDown)
            {
                m_IsDown = true;
                m_DelayTimer = 0f;
            }
        }
    }
}
