using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Heart = new GameObject[3];
    static private int hitCount;
    static private bool hitFlag = false;

    public PauseMenu SceneManager;
    public Transform player;
    public GameObject isShieldImg;

    void Start()
    {
        hitFlag = false;
        hitCount = 0;
        for(int i=0; i<3; i++)
        {
            Heart[i].SetActive(true);
        }
    }

    public void Heal()
    {
        if (hitCount > 0)
        {
            hitCount--;
            Heart[hitCount].SetActive(true);
        }
    }

    public void Shield()
    {
        hitFlag = true;
        isShieldImg.SetActive(true);
        Invoke("HitFlagOff", 10f);
    }

    public void HitFlagOff()
    {
        isShieldImg.SetActive(false);
        hitFlag = false;
    }

    public void Hit()
    {
        if (hitCount<3 && !hitFlag)
        {
            Handheld.Vibrate();

            hitFlag = true;
            Heart[hitCount].SetActive(false);
            hitCount++;
            if (hitCount >= 3)
            {
                this.GetComponent<GameOver>().GAMEOVER(true);
                return;
            }
            StartCoroutine("HitAnime");
        }
    }

    
    IEnumerator HitAnime()
    {
        Vector3 playerSize = new Vector3(1, 1, 1);
        /*
        for (int k = 0; k < 3; k++)
        {
            
            // 작아지기
            for (int i = 0; i < 8; i++)
            {
                playerSize.x -= 0.01f;
                playerSize.y -= 0.01f;
                playerSize.z -= 0.01f;
                player.localScale = playerSize;
                if (i == 7)
                    player.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.002f);
                player.gameObject.SetActive(true);
            }
            // 커지기
            for (int i = 0; i < 8; i++)
            {
                playerSize.x += 0.01f;
                playerSize.y += 0.01f;
                playerSize.z += 0.01f;
                player.localScale = playerSize;
                if (i == 7)
                    player.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.002f);
                player.gameObject.SetActive(true);
            }
        }
        */
        yield return new WaitForSeconds(3f);
        hitFlag = false;
    }
    

}
