using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceEscape
{
    public class Canvas_StartMenu : MonoBehaviour
    {
        public GameObject creditsPanel;

        private void Start()
        {
        }

        private void Update()
        {
        }

        public void GameScene()
        {
            GameManager.instance.GameScene();
        }

        public void toggleCreditsPanel()
        {
            if(creditsPanel)
            {
                creditsPanel.SetActive(!creditsPanel.activeSelf);
            }
        }
    }

}