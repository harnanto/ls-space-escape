using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceEscape
{
    public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool m_IsDown;
        private float m_DownTime;


        public bool isButtonDown
        {
            get
            {
                return m_IsDown;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.m_IsDown = true;
            this.m_DownTime = Time.realtimeSinceStartup;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.m_IsDown = false;
        }

        void Update()
        {
            if (!this.m_IsDown) return;
            if (Time.realtimeSinceStartup - this.m_DownTime > 2f)
            {
                //print("Handle Long Tap");
                this.m_IsDown = false;
            }
        }
    }
}
