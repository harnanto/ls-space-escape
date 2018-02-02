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

            shootABullet = Input.GetMouseButtonDown(0);
        }
    }
}
