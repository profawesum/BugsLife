using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiltingLeaf : MonoBehaviour
{

    public bool timeStart = false;
    public float timer;
    public float smooth = 2.0F;
    public float tiltAngle = -90.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            timeStart = true;
            timer = 3;
        }
    }

    private void Update()
    {


        if (timeStart) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
                float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
            if (timer <= -15) {
                float tiltAroundZ = Input.GetAxis("Horizontal") * -tiltAngle;
                //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
                Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                timeStart = false;
                timer = 3;
            }
        }
    }
}
