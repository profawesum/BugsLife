using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] CollectibleManager collectManager;

    public float speed = 7.5f;
    public float jumpSpeed = 7.5f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    public bool canMove = true;
    public bool climbable = false;

    public float jumpTime;
    public float fasterSpeed = 10;
    public float originalSpeed = 7.5f;
    public float speedTimer = 0;

    public float fasterJumpSpeed = 35;
    public float jumpBoostTimer;

    public GameObject SpeedBoostImage;
    public GameObject JumpBoostImage;
    public Image JumpBoost;
    public Image SpeedBoost;

    public GameObject playerModel;
    public bool resetPlayerPos;
    public float hitTimer;

    void Start()
    {

        collectManager = GameObject.Find("CollectibleManager").GetComponent<CollectibleManager>();
        //finding the images
        JumpBoostImage = GameObject.Find("Jump");
        JumpBoost = JumpBoostImage.GetComponent<Image>();
        //finding the images
        SpeedBoostImage = GameObject.Find("Speed");
        SpeedBoost = SpeedBoostImage.GetComponent<Image>();

        Screen.SetResolution(720, 480, true);

        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }


    public void hitByEnemy() {
        playerModel.SetActive(false);
        hitTimer = 0.2f;
    }

    public void resetPos() {
        resetPlayerPos = true;
    }

    void Update()
    {

        hitTimer -= Time.deltaTime;
        if (hitTimer < 0) {
            playerModel.SetActive(true);
            hitTimer = 0;
        }

        #region ui stuff

        speedTimer -= Time.deltaTime;
        SpeedBoost.fillAmount = speedTimer / 5;

        if (speedTimer <= 0) {
            speedTimer = 0;
            speed = 7.5f;
        }

        jumpBoostTimer -= Time.deltaTime;
        JumpBoost.fillAmount = jumpBoostTimer / 5;

        if (jumpBoostTimer <= 0)
        {
            jumpBoostTimer = 0;
            jumpSpeed = 25.0f;
        }

        #endregion


        //various movement settings
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


        //making it so the player can climb walls
        if (climbable)
        {
            forward = transform.TransformDirection(Vector3.up);
            curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            gravity = 100;
        }

        if (Input.GetButton("Fire3")) {
            gravity = 1900;
        }
        else if(!climbable)
        {
            gravity = 600;
        }

        //jump functionality
        if (Input.GetButton("Jump")){
            jumpTime += 1 * Time.deltaTime;
            if(jumpTime <= 0.2f) {
                 moveDirection.y = jumpSpeed;
            }
        }

        //resets the jump counter
        if (characterController.isGrounded) {
            jumpTime = 0;
        }

        //applies gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }

        if (resetPlayerPos == true) {
            resetPlayerPos = false;
            transform.position = Vector3.zero;
        }
        if (transform.position.y < -5.0f)
        {
            transform.position = Vector3.zero;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillZone")
        {
            FindObjectOfType<AudioManager>().Play("Bang");
            resetPos();
        }
        if (other.tag == "Speed") 
        {
            FindObjectOfType<AudioManager>().Play("SpeedB");

            speed = fasterSpeed;
            speedTimer = 5;
           // Destroy(other.gameObject);
        }
        if (other.tag == "JumpBoost")
        {
            FindObjectOfType<AudioManager>().Play("JumpB");

            jumpSpeed = fasterJumpSpeed;
            jumpBoostTimer = 5;
            //Destroy(other.gameObject);
        }

        //colliding with a gem calls the function to update the amount of gems the player has
        if (other.tag == "Gem")
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(other.gameObject);
            collectManager.updateGemCount();
        }

        //colliding with another ant collects them
        if (other.tag == "Ant")
        {
            FindObjectOfType<AudioManager>().Play("Bang");
            Destroy(other.gameObject);
            collectManager.updateAntCount();
        }
        //collides with the main collectible
        if (other.tag == "mainCollectible")
        {
            Destroy(other.gameObject);
            collectManager.updateMainCollectible();
        }

        //checks to see if they are colliding with a climable object
        if (other.tag == "Climbable") 
        {
            climbable = true;
        }
    }

    //when the player leaves the climbable zone
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Climbable")
        {
            climbable = false;
            moveDirection.y = jumpSpeed;
        }  
            
    }
}
