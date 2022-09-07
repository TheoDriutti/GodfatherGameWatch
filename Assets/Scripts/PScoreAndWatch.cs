using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PScoreAndWatch : MonoBehaviour
{
    TextMeshProUGUI timeText;
    TextMeshProUGUI am;
    TextMeshProUGUI pm;
    TextMeshProUGUI tens;
    TextMeshProUGUI thousands;
    bool gameStarted;
    int score;

    void Start()
    {
        timeText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        am = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        pm = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        tens = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        thousands = gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        timeText.enabled = false;
        am.enabled = false;
        pm.enabled = false;
        tens.enabled = false;
        thousands.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddScore();  
        }
    }

    public void DisplayTime()
    {
        timeText.enabled = true;
        timeText.text = DateTime.Now.ToString("HH:mm");
        if (DateTime.Now.ToString("tt") == "AM")
        {
            am.enabled = true;
        }
        else
        {
            pm.enabled = true;
        }
    }

    public void AddScore()
    {
        if (gameStarted == false)
        {
            gameStarted = true;
            timeText.enabled = false;
            tens.enabled = true;
            thousands.enabled = true;
        }
        /*else
        {
            score++;
            tens = score;
            if (score >= 100)
            {
                tens = " ";
                thousands = thousands++;
            }
        }*/
    }
}
