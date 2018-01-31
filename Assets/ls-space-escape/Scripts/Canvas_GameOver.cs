﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceEscape
{
    public class Canvas_GameOver : MonoBehaviour
    {
        public Text scoreText;

        private void Start()
        {
            if(scoreText)
            {
                scoreText.text = "Last Score: " + GameManager.instance.score.ToString();
            }
        }

        private void Update()
        {
        }

        public void GoToStartMenu()
        {
            GameManager.instance.InitScene();
        }
    }

}