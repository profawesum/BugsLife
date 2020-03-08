using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropShadow : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        //raycast downwards
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            this.transform.position = hit.point;
            //draw the raycast line
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
        }
    }
}
