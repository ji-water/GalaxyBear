using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunction : MonoBehaviour
{

    public enum ITEM {health, time, shield};
    public ITEM itemType;
    public HealthManager HM;
    public TimerManager TM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
