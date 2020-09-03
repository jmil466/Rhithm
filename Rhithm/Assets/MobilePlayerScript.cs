using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerScript : MonoBehaviour
{
    public static MobilePlayerScript Instance { set; get; }

    private const float DEADZONE = 100f;
    private bool swipeLeft, swipeRight;
    private Vector2 swipeDelta, startTouch;

    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //Reset all booleans
        swipeLeft = swipeRight = false;

        //Check for input
        
        //////////Computer inputs - For Debugging and use in editor
        #region
        if(Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }
        #endregion

        // Mobile Inputs
        #region
        if (Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
            startTouch = Input.touches[0].position;

            }
        else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        }
        #endregion

        //Calculate swipe distance
        swipeDelta = Vector2.zero;

        //Mobile Inputs
        if(startTouch != Vector2.zero)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }
        //Computer inputs
        else if (Input.GetMouseButton(0))
        {
            swipeDelta = (Vector2)Input.mousePosition - startTouch;

        }

        //Check for deadzone
        if(swipeDelta.magnitude > DEADZONE)
        {
            //Confirmed swipe

            float x = swipeDelta.x;

            if(x < 0) 
            {
                swipeLeft = true;
            }
            else
            {
                swipeRight = true;
            }
        }

        startTouch = swipeDelta = Vector2.zero;

    }



}
