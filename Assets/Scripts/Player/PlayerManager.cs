using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

  //  public Text healthText;
    public int health = 3;

    public Image healthImage;
    public GameObject healthGO;

//    public Vector3 resetPos;

    [SerializeField] PlayerMove playerMove;

    //setting up the ui in the first frame
    private void Start()
    {
        healthGO = GameObject.Find("HealthHeart");
        healthImage = healthGO.GetComponent<Image>();
        healthImage.fillAmount = 1;
    //    healthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //load back into the menu when escape is hit
        if (Input.GetButtonDown("Menu"))
        {
            Application.LoadLevel(0);
        }

        //if the player should be dead
        if (health <= 0) {
            //reload the scene
            FindObjectOfType<AudioManager>().Play("Bang");
            playerMove.resetPos();
            health = 3;
            healthImage.fillAmount = 1;
        }

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
            FindObjectOfType<AudioManager>().Play("Hit");
            healthImage.fillAmount -= 0.1f;
            //FindObjectOfType<AudioManager>().Play("Hit");
            healthImage.fillAmount -= 0.33f;
            playerMove.hitByEnemy();
        }
        if (other.tag == "KillZone") {
            health = 0;
        }
        if (other.tag == "healthPickup")
        {
            //if the player has less than max health gain 1 health
            if (health < 3)
            {
                FindObjectOfType<AudioManager>().Play("Pickup");
                Debug.Log("Hit the health pickup");
                health++;
                healthImage.fillAmount += 0.33f;
                Destroy(other.gameObject);
            }
        }
    }
}
