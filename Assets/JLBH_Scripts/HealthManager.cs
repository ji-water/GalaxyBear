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

    private IEnumerator hit_ani_cor;

    void Start()
    {
        hitCount = 0;
        for(int i=0; i<3; i++)
        {
            Heart[i].SetActive(true);
        }
        hit_ani_cor = HitAnime();
    }

    public void Hit()
    {
        Debug.Log("hitflag:" + hitFlag);
        if (!hitFlag)
        {
            hitCount++;
            Debug.Log("hit!"+hitCount);
            Heart[hitCount-1].SetActive(false);

            hitFlag = true;
            StartCoroutine(hit_ani_cor);
        }
        if (hitCount >= 3) //gameover
        {
            Debug.Log("heart over");
            StopCoroutine(hit_ani_cor);
            this.GetComponent<GameOver>().GAMEOVER();
        }
    }

    IEnumerator HitAnime()
    {
        Vector3 playerSize = new Vector3(1, 1, 1);
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
        hitFlag = false;
        StopCoroutine(hit_ani_cor);
    }

}
