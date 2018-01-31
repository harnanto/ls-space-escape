using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class SpaceshipInputKeyboard : SpaceshipInput
    {
        public override void HandleInput()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            speed = 0f;
            if (Input.GetKey(KeyCode.F))
            {
                speed = 1f;
                //speed += m_SpaceshipController.acceleration * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.V))
            {
                speed = -1f;
                //speed -= m_SpaceshipController.acceleration * Time.deltaTime;
            }

            shootABullet = Input.GetMouseButtonDown(0);
        }
    }
}
