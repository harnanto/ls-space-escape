using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceEscape
{
    public class Canvas_Splash : MonoBehaviour
    {
        public float duration = 3f;
        public string nextScene = "Init";

        private float m_Timer = 0f;

        private void Update()
        {
            m_Timer += Time.deltaTime;

            if(m_Timer > duration)
            {
                m_Timer = 0f;

                SceneManager.LoadScene(nextScene);
            }
        }
    }
}