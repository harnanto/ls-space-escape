using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceEscape
{
    public class Canvas_StartMenu : MonoBehaviour
    {
        public GameObject creditsPanel;

        public void GameScene()
        {
            SceneManager.LoadScene("Game");
        }

        public void ToggleCreditsPanel()
        {
            if(creditsPanel)
            {
                creditsPanel.SetActive(!creditsPanel.activeSelf);
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

