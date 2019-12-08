using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemCollide : MonoBehaviour
{
    private bool isActive;
    GameObject ItemManager;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        ItemManager = GameObject.Find("ItemManager");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ItemManager.GetComponent<AudioSource>().Play();
            this.gameObject.SetActive(false);
            isActive = false;
        }
    }

    
}
