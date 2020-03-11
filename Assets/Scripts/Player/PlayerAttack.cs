using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerManager manager;
    public CharacterController controller;
    Vector3 moveDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHitBox") 
        {
            FindObjectOfType<AudioManager>().Play("Bang");
            Destroy(other.transform.parent.gameObject);
            //manager.health++;
        }
    }


}
