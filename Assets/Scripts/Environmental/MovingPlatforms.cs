using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public float position1;
    public float position2;

    public float speed = 5.0f;

    public Vector3 direction;

    public Vector3 target;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(position1 + Mathf.PingPong(Time.time, position2), transform.position.y, transform.position.z);
    }
}
