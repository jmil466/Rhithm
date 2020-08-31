using System;
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardThrust = 1000f;
    public float sidewaysThrust = 100f;
    public Boolean pickup = false;
    public float pickupTime = 0.1f;


    public float testTurn = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 right = new Vector3(0.5f, 0f, 0f);
        Vector3 left = new Vector3(-0.5f, 0f, 0f);


        //How to make char jump lane when left/right clicked

       // if (Input.GetKey("w"))
       // {
       //     rb.AddForce(0, 0, forwardThrust * Time.deltaTime); //Time makes it so framerate does not change how often force is applied
       //}
        if (Input.GetKey("a"))
        {
            rb.transform.Rotate(0, 0f, -100f, Space.Self);


            //rb.AddForce(-sidewaysThrust * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.position = rb.position + right;
            //rb.transform.Translate(right * testTurn * Time.deltaTime);

            //rb.AddForce(sidewaysThrust * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //UnityEngine.Debug.Log("Space pressed");

            StartCoroutine(flagPickup());
        }


        IEnumerator flagPickup()
        {
            //How to make cooldown for this?
            pickup = true;

            //UnityEngine.Debug.Log("Pickup is " + pickup);

            yield return new WaitForSeconds(pickupTime);
            pickup = false;
            //UnityEngine.Debug.Log("Pickup is " + pickup);

        }

    }

}
