using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    /* Variables */
    Vector3 moveToPosition; // This is where the camera will move after the start
    float speed = 0.5f; // this is the speed at which the camera moves
    bool started = true; // stops the movement until we want it


    /* functions */
    void Start()
    {
        // Since this object as an child the (0, 0, 0) position will be the same as the players. So we can just add to the zero vector and it will be position correctly. 

        transform.position = new Vector3(0, 1, -2);


        moveToPosition = new Vector3(0, 5.6f, -7.6f); 

        // The following function decides how long to stare at the player before moving
        LookAtPlayerFor(1f); // waits for 3.5 seconds then starts 
    }

    void FixedUpdate()
    {
        // so we only want the movement to start when we decide
        if (!started)
            return;

        // Move the camera into position
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed * Time.deltaTime);

        // Ensure the camera always looks at the player
        transform.LookAt(transform.parent);
    }

    private IEnumerator LookAtPlayerFor(float time)
    {
        yield return new WaitForSeconds(time);
        started = true;
    }
}
