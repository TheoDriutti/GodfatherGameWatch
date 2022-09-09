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
    bool timeDisplayed;
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

    // Affiche l'heure quand le boutton "Time" est effoncé
    public void DisplayTime()
    {
        // Cache le score si la partie est en cours 
        if (gameStarted == true)
        {
            tens.enabled = false;
            thousands.enabled = false;
        }
        timeText.enabled = true;
        timeDisplayed = true;
        timeText.text = DateTime.Now.ToString("hh:mm");
        if (DateTime.Now.ToString("tt") == "AM")
        {
            am.enabled = true;
        }
        else
        {
            pm.enabled = true;
        }
    }

    // Cache l'heure quand le bouton "Time" est relaché
    public void HideTime()
    {
        // Affiche le score si la partie est en cours 
        if (gameStarted == true)
        {
            tens.enabled = true;
            thousands.enabled = true;
        }
        timeText.enabled = false;
        timeDisplayed = false;
        if (DateTime.Now.ToString("tt") == "AM")
        {
            am.enabled = false;
        }
        else
        {
            pm.enabled = false;
        }
    }

    public void GameStarted()
    {
        GameController.instance.StartGame();
        // Affichage du score quand la partie commence
        if (gameStarted == false)
        {
            gameStarted = true;
            tens.enabled = true;
            thousands.enabled = true;
        }
    }
    public void AddScore()
    {
        score++;
        // Ajoute un zero à la dizaine quand le score est inférieur à 10
        if (score % 100 < 10)
        {
            tens.text = 0 + (score % 100).ToString();
        }
        // Affiche le score sur les chiffre de la dizaine
        else
        {
            tens.text = (score % 100).ToString();
        }
        // Affiche le score sur les chiffre du millier
        if (score >= 100)
        {
            thousands.text = (score / 100).ToString();
        }
    }
}
