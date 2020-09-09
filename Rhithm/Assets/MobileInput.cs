using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 50f;
    private Vector2 swipeDelta, startTouch;

    private Vector2 endTouch;

    private Vector3 currentPos;

    private void Update()
    {

        //Check for input

        #region
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.touches[0].position;
                UnityEngine.Debug.Log("Start Touch = " + startTouch);
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;

                endTouch = Input.touches[0].position;
                UnityEngine.Debug.Log("Touch phase ended");
            }
        }
        #endregion

        //Calculate swipe distance
        swipeDelta = Vector2.zero;

        if (startTouch != Vector2.zero)
        {
            //UnityEngine.Debug.Log("Value of endTouch is " + endTouch);

            if (Input.touches.Length != 0) // endTouch != Vector2.zero) //
            {
                //endTouch = Input.touches[0].position;
                UnityEngine.Debug.Log("Value of endTouch is" + endTouch);

                swipeDelta = endTouch - startTouch;//endTouch - startTouch;
            }

            float x = swipeDelta.x;

            UnityEngine.Debug.Log("Value of swipeDelta is " + x);

            //Check for deadzone

            if (swipeDelta.magnitude > DEADZONE)
            {
                currentPos = transform.position;

                if (x < 0)
                {
                    if (currentPos.x >= 0)
                    {
                        transform.Translate(-2, 0, 0);
                        currentPos = transform.position;

                        UnityEngine.Debug.Log("Position is now " + currentPos);
                    }

                    UnityEngine.Debug.Log("Left swipe Registered");
                }
                else if (x > 0)
                {
                    if (currentPos.x <= 1)
                    {
                        transform.Translate(2, 0, 0);
                        currentPos = transform.position;

                        UnityEngine.Debug.Log("Position is now " + currentPos);
                    }

                    UnityEngine.Debug.Log("Right swipe Registered");
                }
            }
            else
            {
                UnityEngine.Debug.Log("Magnitude of swipeDelta is NOT ENOUGH ");
            }
        }

        startTouch = swipeDelta  = Vector2.zero;
    }
}