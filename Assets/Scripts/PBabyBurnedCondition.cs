using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PBabyBurnedCondition : MonoBehaviour
{
    private static PBabyBurnedCondition _instance;
    public static PBabyBurnedCondition i { get { return _instance; } }

    public TDisplay strollerDisplay;

    TextMeshProUGUI failText;
    Image failImage1;
    Image failImage2;
    private int numbOfFail;

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
    }

    public void BabyBurned(int lane)
    {
        numbOfFail++;
        FindObjectOfType<AudioManager>().Play("BabyBurned");
        GameController.instance.BabyMiss(lane);
        GameObject burnedBaby = strollerDisplay.carObjectGrid[lane, 0].gameObject;
        switch (numbOfFail)
        {
            case 1:
                failText.enabled = true;
                failImage1.enabled = true;
                StartCoroutine(BurnedBabyAnim(burnedBaby, 3));
                break;
            case 2:
                failImage2.enabled = true;
                StartCoroutine(BurnedBabyAnim(burnedBaby, 3000));
                break;
        }
    }

    IEnumerator BurnedBabyAnim(GameObject _isBurnedBaby, int nmbOfFlash)
    {
        for (int i = 0; i <= nmbOfFlash; i++)
        {
            _isBurnedBaby.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            _isBurnedBaby.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
        }
    }
}
