using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHitBox") {
            Destroy(other.transform.parent.gameObject);
            manager.health++;
        }
    }


}
