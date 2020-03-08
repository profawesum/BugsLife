using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 50;
    public GameObject[] jellybeans;

    public GameObject[] healthPickup;
    public GameObject[] speedBoost;
    public GameObject[] jumpBoost;

    // Update is called once per frame
    void Update()
    {
        //find all the jellybeans
        jellybeans = GameObject.FindGameObjectsWithTag("Gem");
        healthPickup = GameObject.FindGameObjectsWithTag("healthPickup");
        speedBoost = GameObject.FindGameObjectsWithTag("Speed");
        jumpBoost = GameObject.FindGameObjectsWithTag("JumpBoost");
        
        //for each jellybean rotate it
        foreach (GameObject go in jellybeans)
        {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
        foreach (GameObject go in healthPickup) {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
        foreach (GameObject go in speedBoost)
        {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }

        foreach (GameObject go in jumpBoost)
        {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
