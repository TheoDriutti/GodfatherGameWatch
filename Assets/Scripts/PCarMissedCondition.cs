using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PCarMissedCondition : MonoBehaviour
{
    private static PCarMissedCondition _instance;
    public static PCarMissedCondition i { get { return _instance; } }

    public TDisplay carDisplay;

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
        failText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        failText.enabled = false;
        failImage1 = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
        failImage1.enabled = false;
        failImage2 = gameObject.transform.GetChild(2).gameObject.GetComponent<Image>();
        failImage2.enabled = false;
        failImage3 = gameObject.transform.GetChild(3).gameObject.GetComponent<Image>();
        failImage3.enabled = false;
    }

    public void CarMissed(int lane)
    {
        numbOfFail++;
        FindObjectOfType<AudioManager>().Play("CarMissed");
        GameController.instance.CarMiss(lane);
        GameObject isMissedCar = carDisplay.carObjectGrid[lane, 0].gameObject;
        switch (numbOfFail)
        {
            case 1:
                failText.enabled = true;
                failImage1.enabled = true;
                StartCoroutine(MissedCarAnim(isMissedCar, 3));
                break;
            case 2:
                failImage2.enabled = true;
                StartCoroutine(MissedCarAnim(isMissedCar, 3));
                break;
            case 3:
                failImage3.enabled = true;
                StartCoroutine(MissedCarAnim(isMissedCar, 3000));
                break;
        }
    }

    IEnumerator MissedCarAnim(GameObject _isMissedCar, int nmbOfFlash)
    {
        for (int i = 0; i <= nmbOfFlash; i++)
        {
            _isMissedCar.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            _isMissedCar.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }
}
