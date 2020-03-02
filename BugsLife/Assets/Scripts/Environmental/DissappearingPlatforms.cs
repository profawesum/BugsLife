using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearingPlatforms : MonoBehaviour
{


    public bool startTimer = false;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5) {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
        if (timer >= 10) {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
            timer = 0;
        }
        
    }
}
