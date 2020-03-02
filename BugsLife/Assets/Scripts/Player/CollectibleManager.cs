using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{

    public int basicGemCount;

    public Text gemCountText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gem") {
            Destroy(other.gameObject);
            updateGemCount();
        }
    }

    public void updateGemCount() {
        basicGemCount++;
        gemCountText.text = "Gems: " + basicGemCount.ToString();
    }

}
