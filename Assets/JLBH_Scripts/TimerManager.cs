using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timeText;
    private float time;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        time = 120f;
        coroutine = countdown();
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
