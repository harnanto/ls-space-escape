using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpaceEscape
{
    public class MobileAxis : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private Image m_BackgroundImage;
        private Image m_JoystickImage;
        private Vector3 m_InputVector;

        public float horizontal
        {
            get
            {
                return m_InputVector.x;
            }
        }

        public float vertical
        {
            get
            {
                return m_InputVector.z;
            }
        }

        void Start()
        {
            m_BackgroundImage = GetComponent<Image>();
            m_JoystickImage = transform.GetChild(0).GetComponent<Image>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position;

            bool ret = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    m_BackgroundImage.rectTransform,
                    eventData.position,
                    eventData.pressEventCamera,
                    out position
                );

            if (ret)
            {
                position.x = position.x / m_BackgroundImage.rectTransform.sizeDelta.x;
                position.y = position.y / m_BackgroundImage.rectTransform.sizeDelta.y;

                

                position = position / 0.5f;

                m_InputVector = new Vector3(position.x, 0, position.y);

                m_InputVector = m_InputVector.magnitude > 1 ? m_InputVector.normalized : m_InputVector;

                m_JoystickImage.rectTransform.anchoredPosition = new Vector3(
                        m_InputVector.x * m_BackgroundImage.rectTransform.sizeDelta.x / 2,
                        m_InputVector.z * m_BackgroundImage.rectTransform.sizeDelta.y / 2
                    );

                //Debug.Log(position + " - " + m_InputVector);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_InputVector = Vector3.zero;
            m_JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}

