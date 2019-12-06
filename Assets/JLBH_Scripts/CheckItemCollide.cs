using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemCollide : MonoBehaviour
{
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            isActive = false;
        }
    }

    
}
