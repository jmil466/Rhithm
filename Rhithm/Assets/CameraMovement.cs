using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 moveToPosition; // This is where the camera will move after the start
    float speed = 0.5f; // this is the speed at which the camera moves
    //bool started = true; // stops the movement until we want it

    /* functions */
    void Start()
    {
        //Start Position
        transform.position = new Vector3(0, 1, -2);

        //End Position
        moveToPosition = new Vector3(0, 6f, -8.5f);
    }

    void FixedUpdate()
    {
        //speed at which camera will move backwards
        speed += 0.01f;

        // Move the camera into position
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed * Time.deltaTime);
    }
}
