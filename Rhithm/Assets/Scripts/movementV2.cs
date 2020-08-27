using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class movementV2 : MonoBehaviour
{
    public Rigidbody rb;
    public bool pickup = false;
    public float pickupTime = 0.1f;


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("a"))
        {
            if(rb.transform.position.x > -1f)
            {
               // rb.transform.position.x = rb.transform.position.x - 1f;  //new Vector3(0f, 0f, -1f);
            }
        }

        if (Input.GetKey("d"))
        {
            if (rb.transform.position.x < 1f)
            {
                rb.transform.position = new Vector3(0f, 0f, 1f);
            }
        }



            if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(flagPickup());
        }
    }


IEnumerator flagPickup()
{
    //How to make cooldown for this?
    pickup = true;
    rb.transform.position = new Vector3(0f, -0.1f, 0f);

    yield return new WaitForSeconds(pickupTime);
    pickup = false;
    rb.transform.position = new Vector3(0f, 0.1f, 0f);
    }
}
