using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMobileInput : MonoBehaviour
{
    private Vector3 startTouchPos, endTouchPos;
    private Vector3 startPlayerPos, endPlayerPos;
    private float moveTime;
    private float moveDuration = 0.08f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            startTouchPos = Input.GetTouch(0).position;
            UnityEngine.Debug.Log("StartTouch is " + startTouchPos);

            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            UnityEngine.Debug.Log("End touch is " + endTouchPos);

            //Left Swipe                            //Checking if at left most lane

            if (endTouchPos.x < startTouchPos.x && transform.position.x >= 0)
            {
                StartCoroutine(Fly("left"));
            }

            //Right Swipe                            //Checking if at right most lane

            if (endTouchPos.x > startTouchPos.x && transform.position.x <= 1)
            {
                StartCoroutine(Fly("right"));
            }

        }


    }

    private IEnumerator Fly(string direction)
    {
        if (direction.Equals("left"))
        {
            moveTime = 0f;
            startPlayerPos = transform.position;
            endPlayerPos = new Vector3((startPlayerPos.x - 2f), transform.position.y, transform.position.z);

            while(moveTime < moveDuration)
            {
                moveTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPlayerPos, endPlayerPos, moveTime / moveDuration);
                yield return null;
            }

        }

        if (direction.Equals("right"))
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