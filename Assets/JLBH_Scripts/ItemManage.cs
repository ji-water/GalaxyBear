using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    void Start()
    {
        Debug.Log(" 히히히히ㅣ히");
        StartCoroutine(CheckForGenerateItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckForGenerateItem()
    {
        Debug.Log("ㅎ에에");
        
        while (true)
        {
            GameObject item;
            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log("들어오긴하니 ?");
                item = transform.GetChild(i).gameObject;
                if (item.activeSelf == false)
                {
                    Debug.Log("나왕");
                    item.SetActive(true);
                }

            }
            yield return new WaitForSeconds(10f);
        }
        


    }
}
