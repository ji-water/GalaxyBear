using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFunction : MonoBehaviour
{

    public enum ITEM {health, time, shield};
    public ITEM itemType;
    public HealthManager HM;
    public TimerManager TM;

    public Image item_image;

    public GameObject ItemManager;

    /*
    void Start()
    {
        ItemManager = GameObject.Find("ItemManager");    
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            ItemManager.GetComponent<AudioSource>().Play();
            if (itemType == ITEM.health)
            {
                HM.Heal();
                gameObject.SetActive(false);
            }
            else if (itemType == ITEM.time)
            {
                TM.TimeUp();
                gameObject.SetActive(false);
            }
            else if (itemType == ITEM.shield)
            {
                HM.Shield();
                gameObject.SetActive(false);
            }
        }
    }

}
