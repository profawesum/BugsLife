using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is to be used on a separate gameobject at the base of the player so they can attack 
//mario style by jumping on top of the enemy
public class PlayerAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //if the player hits an enemy destroy it
        if (other.name == "Enemy") {
            Debug.Log("hit enemy");
            Destroy(other.gameObject);
        }
    }

}
