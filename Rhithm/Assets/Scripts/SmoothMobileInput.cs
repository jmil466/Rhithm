using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public class SmoothMobileInput : MonoBehaviour
{
    private Vector3 startTouchPos, endTouchPos;
    private Vector3 startPlayerPos, endPlayerPos;
    private float moveTime;
    private float moveDuration = 0.08f;

    private float swipeDelta;
    //make this half of screen width
    private float longSwipeRange = (Screen.width/2);
    public bool lerpComplete = false;

    // Update is called once per frame
    void Update()
    {
        lerpComplete = false;
        //UnityEngine.Debug.Log("pos is now " + transform.position.x);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            //l +
            swipeDelta = startTouchPos.x - endTouchPos.x;

            UnityEngine.Debug.Log("SwipeDelta ABS is " + Math.Abs(swipeDelta));

            if ((Math.Abs(swipeDelta)) > longSwipeRange)
            {
                UnityEngine.Debug.Log("Long Swipe detected");

                if (transform.position.x == -2 || transform.position.x == 2)
                {
                    longSwipe(swipeDelta);
                }
                else
                {
                    StartCoroutine(Fly(swipeDelta));
                }

            }
            else
            {
                StartCoroutine(Fly(swipeDelta));
            }
        }
    }

    public void longSwipe(float SwipeDelta)
    {
        StartCoroutine(longFly(SwipeDelta));
    }

    public IEnumerator longFly(float swipeDelta)
    {
        UnityEngine.Debug.Log("swipe delta is " + swipeDelta);


        if (swipeDelta > 0)
        {
            UnityEngine.Debug.Log("x pos is " + transform.position.x);

            // check if pos is at left most lane
            if (transform.position.x == 2)
            {
                UnityEngine.Debug.Log("Stepping into first if");


                moveTime = 0f;
                startPlayerPos = transform.position;
                endPlayerPos = new Vector3((startPlayerPos.x - 4f), transform.position.y, transform.position.z);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPlayerPos, endPlayerPos, moveTime / moveDuration);
                    yield return null;
                }
                lerpComplete = true;
            }
        }

        if (swipeDelta < 0)
        {
            // check if pos is at right most lane
            if (transform.position.x == -2)
            {

                UnityEngine.Debug.Log("Stepping into 2nd if");

                moveTime = 0f;
                startPlayerPos = transform.position;
                endPlayerPos = new Vector3((startPlayerPos.x + 4f), transform.position.y, transform.position.z);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPlayerPos, endPlayerPos, moveTime / moveDuration);
                    yield return null;
                }
            }
        }
    }

    public IEnumerator Fly(float swipeDelta)
    {
        if (swipeDelta > 0)
        {
            // check if pos is at left most lane
            if (transform.position.x >= 0)
            {
                moveTime = 0f;
                startPlayerPos = transform.position;
                endPlayerPos = new Vector3((startPlayerPos.x - 2f), transform.position.y, transform.position.z);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPlayerPos, endPlayerPos, moveTime / moveDuration);
                    yield return null;
                }
            }
        }

        if (swipeDelta < 0)
        {
            // check if pos is at right most lane
            if (transform.position.x <= 1)
            {
                moveTime = 0f;
                startPlayerPos = transform.position;
                endPlayerPos = new Vector3((startPlayerPos.x + 2f), transform.position.y, transform.position.z);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPlayerPos, endPlayerPos, moveTime / moveDuration);
                    yield return null;
                }
            }
        }
    }
}
