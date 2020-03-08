using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{


    public Animator animator;
    [SerializeField] PlayerMove playerMove;
    public CharacterController controller;

    private void Start()
    {
        controller = GetComponentInParent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.velocity != Vector3.zero)
        {
            if (playerMove.climbable)
            {
                animator.SetBool("Climbing", true);
                animator.SetBool("Running", false);
                animator.SetBool("Grounded", true);
            }
            else if (!playerMove.climbable && controller.isGrounded)
            {

                animator.SetBool("Climbing", false);
                animator.SetBool("Running", true);
                animator.SetBool("Grounded", true);
            }
            else if(!controller.isGrounded) {
                animator.SetBool("Grounded", false);
                animator.SetBool("Climbing", false);
                animator.SetBool("Running", false);
            }
        }
        else {
            animator.SetBool("Climbing", false);
            animator.SetBool("Running", false);
            animator.SetBool("Grounded", true);
        }


    }
}
