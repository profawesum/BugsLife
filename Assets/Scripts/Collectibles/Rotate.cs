using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 50;
    public GameObject[] jellybeans;

    public GameObject[] healthPickup;

    // Update is called once per frame
    void Update()
    {
        //find all the jellybeans
        jellybeans = GameObject.FindGameObjectsWithTag("Gem");
        healthPickup = GameObject.FindGameObjectsWithTag("healthPickup");
        
        //for each jellybean rotate it
        foreach (GameObject go in jellybeans)
        {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
        foreach (GameObject go in healthPickup) {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
