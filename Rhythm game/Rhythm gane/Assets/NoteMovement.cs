using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    private Vector3 currentPos;
    public Rigidbody rb;
    public float speed = -20f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = gameObject.transform.position;

        if(currentPos.z < 10f)
        {
            Destroy(this);

            UnityEngine.Debug.Log("Despawned block!");
        }

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime * 10);

        rb.velocity = new Vector3(0f, 0f, speed);


    }
}
