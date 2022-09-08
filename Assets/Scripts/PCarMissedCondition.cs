using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PCarMissedCondition : MonoBehaviour
{
    private static PCarMissedCondition _instance;
    public static PCarMissedCondition i { get { return _instance; } }

    TextMeshProUGUI failText;
    Image failImage1;
    Image failImage2;
    Image failImage3;
    private int numbOfFail = 0;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        //failText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        //failText.enabled = false;
        //failImage1 = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
        //failImage1.enabled = false;
        //failImage2 = gameObject.transform.GetChild(2).gameObject.GetComponent<Image>();
        //failImage2.enabled = false;
        //failImage3 = gameObject.transform.GetChild(3).gameObject.GetComponent<Image>();
        //failImage3.enabled = false;
    }

    public void CarMissed(int lane)
    {
        numbOfFail++;
        GameController.instance.CarMiss(lane);
        switch (numbOfFail)
        {
            case 1:
                //failText.enabled = true;
                //failImage1.enabled = true;
                // Play missed car animation 3 times
                break;
            case 2:
                //failImage2.enabled = true;
                // Play missed car animation 3 times
                break;
            case 3:
                //failImage3.enabled = true;
                // Play missed car animation until game A button is pressed
                break;
        }
    }
}
