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
            Scale(GetComponent<ParticleSystem>(), scale, true);
        }

        public void Scale(ParticleSystem particleSystem, float scale, bool scaleChildren)
        {
            if (!particleSystem)
                return;

            DoScale(particleSystem, scale, false);

            if (scaleChildren)
            {
                ParticleSystem[] children = particleSystem.GetComponentsInChildren<ParticleSystem>();

                for (int i = children.Length; i-- > 0;)
                {
                    if (children[i] == particleSystem)
                    {
                        continue;
                    }

                    DoScale(children[i], scale, true);
                }
            }
        }

        private void DoScale(ParticleSystem particleSystem, float scale, bool scalePos)
        {
            if (scalePos)
            {
                particleSystem.transform.localPosition *= scale;
            }

            ParticleSystem.MainModule psMain = particleSystem.main;

            psMain.startSizeMultiplier *= scale;
            psMain.gravityModifierMultiplier *= scale;
            psMain.startSpeedMultiplier *= scale;

            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.radius *= scale;
            shape.scale = shape.scale * scale;
        }
    }
}
