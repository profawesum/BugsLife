using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    public Animator animator;
    public CharacterController playerController;

    [SerializeField] PlayerMove playerMove;

    private void Start()
    {
        playerController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.velocity != Vector3.zero)
        {
            if (playerMove.climbable)
            {
                animator.SetBool("climbing", true);
                animator.SetBool("moving", false);
            }
            else
            {
                animator.SetBool("moving", true);
                animator.SetBool("climbing", false);
            }
        }
        else {
            animator.SetBool("moving", false);
            //animator.SetBool("climbing", false);
        }
    }
}
