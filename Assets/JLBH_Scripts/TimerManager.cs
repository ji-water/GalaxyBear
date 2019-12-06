using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timeText;
    private float time;
    private IEnumerator coroutine;

    void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        time = 120f;
        coroutine = countdown();
        Time.timeScale = 1;
        StartCoroutine(coroutine);
    }

    IEnumerator countdown()
    {
        while (time > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
            timeText.text = Mathf.Ceil(time).ToString();
        }
        Debug.Log("time out");
        this.GetComponent<GameOver>().GAMEOVER(false);
        StopCoroutine(coroutine);
    }

}
