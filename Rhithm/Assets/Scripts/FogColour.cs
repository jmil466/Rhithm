using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogColour : MonoBehaviour
{

    Color[] col = new Color[3];
    public float ColorTransTime = 5f;
    Color lerpedColor;
    public bool repeatable = true;
    public float speed = 2f;
    public float duration = 5f;
    public float magic = 0.02F;

    // Use this for initialization
    IEnumerator Start()
    {
        col[0] = Color.blue;
        col[1] = Color.red;
        col[2] = Color.green;

        while (repeatable)
        {
            yield return RepeatLerp(col[0], col[1], duration);
            yield return RepeatLerp(col[1], col[2], duration);
            yield return RepeatLerp(col[2], col[0], duration);
            // lerp down scale

        }
    }

    public IEnumerator RepeatLerp(Color start, Color end, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * magic;
            RenderSettings.fogColor = Color.Lerp(start, end, i);
            yield return null;

        }
    }
}
