using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearingPlatforms : MonoBehaviour
{


    public bool startTimer = false;
    public float timer;

    public float disappearTimer = 5;
    public float reappearTimer = 7;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2) { 
            //TODO:
            //Make it look like it is about to disappear
        }
        if (timer >= disappearTimer) {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
        if (timer >= reappearTimer) {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
            timer = 0;
        }
        
    }
}
