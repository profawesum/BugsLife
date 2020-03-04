﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    
    //counts for the gems
    public int basicGemCount;
    public Text gemCountText;

    //counts for the main Collectible
    public int mainCollectibleCount;
    public Text mainCollectibleText;

    //counts for the ants found
    public int antCount;
    public Text antText;

    //the amount of jellybeans left in the level
    public GameObject[] jellyBean;


    private void Update()
    {
        //find the amount of jellybeans left
        jellyBean = GameObject.FindGameObjectsWithTag("Gem");

        if (jellyBean.Length == 0) { 
            //TODO:
            //do some stuff to spawn in a main collectible
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //colliding with a gem calls the function to update the amount of gems the player has
        if (other.tag == "Gem") {
            Destroy(other.gameObject);
            updateGemCount();
        }

        //colliding with another ant collects them
        if (other.tag == "Ant")
        {
            Destroy(other.gameObject);
            updateAntCount();
        }
        //collides with the main collectible
        if (other.tag == "mainCollectible") {
            Destroy(other.gameObject);
            updateMainCollectible();
        }
    }


    //updates the main collectible
    public void updateMainCollectible() { 
    

    }

    //increase the amount of ants the player has found
    public void updateAntCount() { 
    

    }

    //increase the value of the gems
    public void updateGemCount() {
        basicGemCount++;
        gemCountText.text = "Gems: " + basicGemCount.ToString();
    }

}