using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public class ScaleParticleSystem : MonoBehaviour
    {
        public float scale = 1f;

        private void Start()
        {
            ParticleScaler.Scale(GetComponent<ParticleSystem>(), scale);
        }
    }
}
