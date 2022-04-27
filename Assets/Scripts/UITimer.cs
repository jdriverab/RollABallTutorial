using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text timerText;
    public GameObject platformToHide;

    private float time;
    private int timerInTotalSeconds;

    void SetTimer()
    {
        time += Time.deltaTime;
        timerInTotalSeconds = Mathf.FloorToInt(time) % 10;
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }

    void HideAndShowPlatform()
    {

        if (platformToHide.activeSelf)
        {
            platformToHide.SetActive(false);
        }
        else
        {
            platformToHide.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        SetTimer();

        if(timerInTotalSeconds == 0)
        {
            HideAndShowPlatform();
        }


    }
}
