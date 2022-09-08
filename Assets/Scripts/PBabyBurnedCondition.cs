using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PBabyBurnedCondition : MonoBehaviour
{
    TextMeshProUGUI failText;
    Image failImage1;
    Image failImage2;
    Image failImage3;
    private int numbOfFail;

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

    void BabyBurned(GameObject isBurnedBaby)
    {
        numbOfFail++;
        switch (numbOfFail)
        {
            case 1:
                failText.enabled = true;
                failImage1.enabled = true;
                StartCoroutine(BurnedBabyAnim(isBurnedBaby, 3));
                break;
            case 2:
                failImage2.enabled = true;
                StartCoroutine(BurnedBabyAnim(isBurnedBaby, 3));
                break;
            case 3:
                failImage3.enabled = true;
                StartCoroutine(BurnedBabyAnim(isBurnedBaby, 3));
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
