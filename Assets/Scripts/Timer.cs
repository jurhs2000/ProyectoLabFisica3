using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Se encuentra en el objeto Timer que muestra el texto del tiempo
public class Timer : MonoBehaviour
{
    private float startTime;
    private bool state = false;
    public float deltaT;
    public InputField timeDivField;
    public float timeDivisor;

    void Start()
    {
        timeDivField.text = "100";
        startTime = Time.time;
        Time.timeScale = 0;
    }
    void Update()
    {
        deltaT = Time.time - startTime;

        string seconds = (deltaT % 60).ToString("f4");
        gameObject.GetComponent<TMP_Text>().text = seconds + " s";
        if (timeDivField.text != "0")
            timeDivisor = (float)(1f / float.Parse(timeDivField.text));
        else
            timeDivField.text = "100";
    }

    public void playTime()
    {
        if (state)
        {
            Time.timeScale = 0;
            state = false;
        }
        else
        {
            Time.timeScale = timeDivisor;
            state = true;
        }
    }

}