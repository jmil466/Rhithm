using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fogColour : MonoBehaviour
{

    bool end = false;
    float speed = 0.001F;

    bool redTurn = true;
    bool greenTurn = false;
    bool blueTurn = false;
    Color lerpedColor = Color.white;
    float tick;

    int FUCKME = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //lerpedColor = Color.Lerp(Color.blue, Color.red,1 );//Mathf.PingPong(Time.time, ));



        RenderSettings.fogColor = lerpedColor;

        StartCoroutine(ChangeEngineColour());

        tick = 10f;

        //if (FUCKME == 0)
        //{
        //    Red();
        //}
        //else if (FUCKME == 1)
        //{
        //    Green();
        //}
        //else if (FUCKME == 2)
        //{
        //    Blue();
        //}



    }


    private void Red()
    {
        tick += Time.deltaTime * speed;
        lerpedColor = Color.Lerp(Color.blue, Color.red, tick);

        FUCKME++;
    }
    private void Green()
    {
        tick += Time.deltaTime * speed;
        lerpedColor = Color.Lerp(Color.red, Color.green, tick);

        FUCKME++;

    }
    private void Blue()
    {

        tick += Time.deltaTime * speed;
        lerpedColor = Color.Lerp(Color.green, Color.blue, tick);

        FUCKME = 0;

    }



    private IEnumerator ChangeEngineColour()
    {

        if (FUCKME == 0)
        {

            tick += Time.deltaTime * speed;
            lerpedColor = Color.Lerp(Color.blue, Color.red, tick);
            yield return null;

            FUCKME = 1;
        }

        if (FUCKME == 1)
        {
            tick += Time.deltaTime * speed;
            lerpedColor = Color.Lerp(Color.red, Color.green, tick);
            yield return null;

            FUCKME = 2;

            //if (lerpedColor == Color.green)
            //{

            //    greenTurn = false;
            //    blueTurn = true;
            //}
        }

        if (FUCKME == 2)
        {
            tick += Time.deltaTime * speed;
            lerpedColor = Color.Lerp(Color.green, Color.blue, tick);
            yield return null;

            //if (lerpedColor == Color.blue)
            //{
            //    redTurn = true;
            //    blueTurn = false; ;
            //}

            FUCKME = 0;
        }


    }

}




