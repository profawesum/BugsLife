using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{


    [SerializeField] CollectibleManager collectibleManager;

    public string levelToLoad;

    public bool ableToAcces = false;
    public int amountOfBeansToUnlock;

    private void Start()
    {
        collectibleManager = GameObject.Find("CollectibleManager").GetComponent<CollectibleManager>();
    }

    private void Update()
    {
        if (collectibleManager.basicGemCount >= amountOfBeansToUnlock) {
            ableToAcces = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && ableToAcces) {
            Application.LoadLevel(levelToLoad);
        }
    }
}
