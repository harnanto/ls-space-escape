using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleScaler
{
    public static void Scale(ParticleSystem particleSystem, float scale, bool scaleChildren)
    {
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

    private static void DoScale(ParticleSystem particleSystem, float scale, bool scalePos)
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