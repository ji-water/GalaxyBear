using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CheckForGenerateItem());
    }

    IEnumerator CheckForGenerateItem()
    {
        
        while (true)
        {
            GameObject item;
            for (int i = 0; i < transform.childCount; i++)
            {
                item = transform.GetChild(i).gameObject;
                if (item.activeSelf == false)
                {
                    item.SetActive(true);
                }

            }
            yield return new WaitForSeconds(10f);
        }
        


    }
}
