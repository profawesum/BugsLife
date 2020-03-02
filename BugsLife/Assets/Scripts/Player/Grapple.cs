using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    public bool connectable = false;

    // Update is called once per frame
    void Update()
    {
        if (connectable && Input.GetButton("Fire3")) { 
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            connectable = true;
        }
    }
}
