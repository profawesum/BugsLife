using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Text healthText;
    public int health = 10;

    //setting up the ui in the first frame
    private void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player should be dead
        if (health <= 0) {
            //reload the scene
            Application.LoadLevel(Application.loadedLevel);
        }

        //DEBUG STUFF, DELETE LATER
        //Used to damage the player
        if (Input.GetKeyDown(KeyCode.E)) {
            health -= 1;
            healthText.text = "Health: " + health.ToString();
        }
        //END WHAT SHOULD BE DELETED LATER

        //setting up some raycasting stuffs
        RaycastHit hit;

        //used for interactions
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3.5f)){
            Debug.Log("Hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (Input.GetButtonDown("Fire2") && hit.transform.tag == "Interactible") { 
                //add in the interactible coding 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the player has hit an enemy deal some damage
        if (other.tag == "Enemy") {
            health -= 1;
            healthText.text = "Health: " + health.ToString();
        }
        if (other.tag == "KillZone") {
            health = 0;
        }
    }
}
