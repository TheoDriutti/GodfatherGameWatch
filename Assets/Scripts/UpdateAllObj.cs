using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateAllObj : MonoBehaviour
{
    public GameObject objHolder;
    public GameObject uiTextHolder;
    public GameObject uiImageHolder;
    bool _alreadyActiveHolder;
    public float _timeFullOpacity;
    public float _timer;
    public float _maxOpacity = 0.8f;

    public IEnumerator StartDisplayAll(int time)
    {
        yield return new WaitForSeconds(time);  
        objHolder.SetActive(false);
        uiImageHolder.SetActive(false);
        uiTextHolder.SetActive(false);
    }

    private void Update()
    {
        if(GameController.instance.gameState == GameController.GameState.Game)
        {
            if(!_alreadyActiveHolder)
            {
                objHolder.SetActive(true);
                uiTextHolder.SetActive(true);
                uiImageHolder.SetActive(true);
            }

            _timer += Time.deltaTime;

            if(_timer > _timeFullOpacity)
            {
                foreach(Transform child in objHolder.transform)
                {
                    if(child.gameObject.GetComponent<SpriteRenderer>() != null)
                        child.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, _maxOpacity);
                }
                foreach(Transform child in uiImageHolder.transform)
                {
                    if (child.GetComponent<Image>() != null)
                        child.GetComponent<Image>().color = new Color(0f, 0f, 0f, _maxOpacity);
                }
                foreach(Transform child in uiTextHolder.transform)
                {
                    if (child.GetComponent<TMP_Text>() != null)
                        child.GetComponent<TMP_Text>().color = new Color(0f, 0f, 0f, _maxOpacity);
                }
            }
            else
            {
                foreach (Transform child in objHolder.transform)
                {
                    if (child.gameObject.GetComponent<SpriteRenderer>() != null)
                        child.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, (_timer/ _timeFullOpacity) * _maxOpacity);
                }
                foreach (Transform child in uiImageHolder.transform)
                {
                    if (child.GetComponent<Image>() != null)
                        child.GetComponent<Image>().color = new Color(0f, 0f, 0f, (_timer / _timeFullOpacity) * _maxOpacity);
                }
                foreach (Transform child in uiTextHolder.transform)
                {
                    if (child.GetComponent<TMP_Text>() != null)
                        child.GetComponent<TMP_Text>().color = new Color(0f, 0f, 0f, (_timer / _timeFullOpacity) * _maxOpacity);
                }
            }

        }
       
    }

}
