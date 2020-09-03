using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance { set; get; }

    private const float DEADZONE = 20f;
    private bool swipeLeft, swipeRight;
    private Vector2 swipeDelta, startTouch;

    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }

    private Vector2 endTouch;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //Reset all booleans
        swipeLeft = swipeRight = false;

        //Check for input

        #region
        if (Input.touches.Length != 0)
        {
            UnityEngine.Debug.Log("Touch Registered");

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.touches[0].position;

                UnityEngine.Debug.Log("Start Touch = " + startTouch);

            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                //startTouch = swipeDelta = Vector2.zero;
                endTouch = Input.touches[0].position;

                UnityEngine.Debug.Log("Touch phase ended");
            }

        }
        #endregion

        //Calculate swipe distance
        swipeDelta = Vector2.zero;


        if (startTouch != Vector2.zero)
        {
            UnityEngine.Debug.Log("Value of endTouch is " + endTouch);

            if(endTouch != Vector2.zero) //(Input.touches.Length != 0)
            {
                UnityEngine.Debug.Log("Step in Registered");


                swipeDelta =   Input.touches[0].position - startTouch;//endTouch - startTouch;
            }


         
            float x = swipeDelta.x;

            UnityEngine.Debug.Log("Value of swipeDelta is " + x);

            //Check for deadzone

            if (swipeDelta.magnitude > DEADZONE)
            {
                if (x < 0)
                {
                    swipeLeft = true;
                    UnityEngine.Debug.Log("Left swipe Registered");
                }
                else if (x > 0)
                {
                    swipeRight = true;
                    UnityEngine.Debug.Log("Right swipe Registered");
                }
            }
        }

        startTouch = swipeDelta = Vector2.zero;

    }



}
