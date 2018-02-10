using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceEscape
{
    [RequireComponent(typeof(SpaceshipController))]
    public class SpaceshipHUD : MonoBehaviour
    {
        public Text scoreText;
        public Image healthImage;

        private SpaceshipController m_SpaceshipController;

        private void Start()
        {
            m_SpaceshipController = GetComponent<SpaceshipController>();
        }

        private void Update()
        {
            if (!scoreText)
            {
                return;
            }

            if (!healthImage)
            {
                return;
            }

            scoreText.text = GameManager.instance.score.ToString();
            healthImage.fillAmount = m_SpaceshipController.health / m_SpaceshipController.maxHealth;
        }
    }
}

