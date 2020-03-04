using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    
    //counts for the gems
    public int basicGemCount;
    public Text gemCountText;

    public Text antCountText;
    public int antCount;

    
    private void OnTriggerEnter(Collider other)
    {
        //colliding with a gem calls the function to update the amount of gems the player has
        if (other.tag == "Gem") {
            Destroy(other.gameObject);
            updateGemCount();
        }

        //if the player finds a lost ant
        if (other.tag == "LostAnt") {
            Destroy(other.gameObject);
            updateLostAntCount();
        }
    }


    //finds the lost ant
    public void updateLostAntCount() {
        antCount++;
        antCountText.text = "Ants Found: " + antCount.ToString();
        
    }

    //increase the value of the gems
    public void updateGemCount() {
        basicGemCount++;
        gemCountText.text = "JellyBeans: " + basicGemCount.ToString();
    }

}
