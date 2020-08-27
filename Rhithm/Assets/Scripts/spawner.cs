using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public static float length = 1f;
    public Vector3 size = new Vector3(1f, 1f, length);
    public Vector3 spawnPos = new Vector3(1.9f, 1.49f, -508f); 

    public GameObject lanePrefab;


    void Start()
    {
        GameObject lane = Instantiate(lanePrefab, spawnPos, Quaternion.identity);
        lane.transform.localScale = size;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
