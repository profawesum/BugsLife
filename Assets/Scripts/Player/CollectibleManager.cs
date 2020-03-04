using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    
    //counts for the gems
    public int basicGemCount;
    public Text gemCountText;

    
    private void OnTriggerEnter(Collider other)
    {
        //colliding with a gem calls the function to update the amount of gems the player has
        if (other.tag == "Gem") {
            Destroy(other.gameObject);
            updateGemCount();
        }
    }


    //increase the value of the gems
    public void updateGemCount() {
        basicGemCount++;
        gemCountText.text = "Gems: " + basicGemCount.ToString();
    }

}
