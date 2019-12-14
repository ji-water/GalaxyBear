using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManage : MonoBehaviour
{
    public Sprite health_image, time_image, shield_image;

    void Start()
    {
        StartCoroutine(CheckForGenerateItem());
    }

    IEnumerator CheckForGenerateItem()
    {
        
        while (true)
        {
            GameObject item;
            Image item_image;
            for (int i = 0; i < transform.childCount; i++)
            {
                item = transform.GetChild(i).gameObject;
                item_image = item.GetComponent<ItemFunction>().item_image;
                if (item.activeSelf == false)
                {
                    item.SetActive(true);

                    int item_type = Random.Range(0, 3);
                    switch (item_type)
                    {
                        case 0: //health
                            item_image.sprite = health_image;
                            item.GetComponent<ItemFunction>().itemType = ItemFunction.ITEM.health;
                            break;
                        case 1: //time
                            item_image.sprite = time_image;
                            item.GetComponent<ItemFunction>().itemType = ItemFunction.ITEM.time;
                            break;
                        case 2: //shield
                            item_image.sprite = shield_image;
                            item.GetComponent<ItemFunction>().itemType = ItemFunction.ITEM.shield;
                            break;
                    }
                }

            }
            yield return new WaitForSeconds(10f);
        }
        


    }
}
