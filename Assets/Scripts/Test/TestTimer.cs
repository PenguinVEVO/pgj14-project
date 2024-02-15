using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] private float time;
    private bool timeUp;

    // Update is called once per frame
    void Update()
    {
        if (timeUp != true)
        {
            Timer();
        }
        else
        {
            return;
        }

        Debug.Log(time);
    }

    void Timer()
    {
        time = time - Time.deltaTime;
        timerText.text = time.ToString();

        if (time == Mathf.Clamp(0f, -0.1f, 0.1f))
        {
            timeUp = true;
            timerText.text = "Timer is up!";
        }
    }
}
