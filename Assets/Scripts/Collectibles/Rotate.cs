using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed;
    public GameObject[] jellybeans;

    // Update is called once per frame
    void Update()
    {
        jellybeans = GameObject.FindGameObjectsWithTag("Gem");
        foreach (GameObject go in jellybeans)
        {
            go.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
