using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourLerp : MonoBehaviour
{

    public float lerpDuration;
    private Color[] colors = new Color[3];
    private Color lerpedColor;
    int FUCK = 0;

    void Start()
    {


        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;



        StartCoroutine(LerpColors());
    }

    private IEnumerator LerpColors()
    {

        while (FUCK < 10000)
        {

            for (int i = 0; i <= 2; i++)
            {

                UnityEngine.Debug.Log("FUCK ME i = " + i);

                //if(i == 2)
                //{
                //    k = i;
                //}

                lerpedColor = Color.Lerp(colors[i], colors[i + 1], Mathf.PingPong(Time.time, 0.1F));

                RenderSettings.fogColor = lerpedColor;
                if (i == 2)
                {

                    UnityEngine.Debug.Log("CHANGE");
                    Color temp = colors[2];

                    colors[2] = colors[1];
                    colors[1] = colors[0];
                    colors[0] = temp;
                    i = 0;
                }
            }

            FUCK++;


            // }

            yield return new WaitForSeconds(1);



        }

    }
}
