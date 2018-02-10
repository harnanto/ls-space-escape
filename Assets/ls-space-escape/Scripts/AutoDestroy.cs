using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class AutoDestroy : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2f);
        }
    }
}

