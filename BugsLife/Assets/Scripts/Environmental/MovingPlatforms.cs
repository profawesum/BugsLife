using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public GameObject waypoint1;
    public GameObject waypoint2;

    public float speed = 5.0f;

    public Vector3 direction;

    public Vector3 target;

    private void Start()
    {
        target = waypoint2.transform.position;
        direction = target - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Waypoint1")
        {
            target = waypoint2.transform.position;
            direction = target - transform.position;
        }
        else if(other.name == "Waypoint2") {
            target = waypoint1.transform.position;
            direction = target - transform.position;
        }
    }
}
