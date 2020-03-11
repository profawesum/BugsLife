using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{

    //counts for the gems
    public int basicGemCount;
    public Text gemCountText;

    //counts for the main Collectible
    //public int mainCollectibleCount;
    //public Text mainCollectibleText;

    ////counts for the ants found
    //public int antCount;
    //public Text antText;

    //the amount of jellybeans left in the level
    public GameObject[] jellyBean;

    private void Start()
    {
        //locking and hiding the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        //makes it so there can only ever be one collectiblemanager object
        GameObject[] temp = GameObject.FindGameObjectsWithTag("CollectManager");
        for (var i = 0; i < temp.Length - 1; i++)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        //if (sceneName == "MainMenu")
        //{
        //    Debug.Log("Here");
        //    basicGemCount = 0;
        //    gemCountText.text = basicGemCount.ToString();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //colliding with a gem calls the function to update the amount of gems the player has
        if (other.tag == "Gem") 
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
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
        if (other.tag == "mainCollectible") 
        {
            FindObjectOfType<AudioManager>().Play("Click");
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
        gemCountText.text = basicGemCount.ToString();
    }

}
