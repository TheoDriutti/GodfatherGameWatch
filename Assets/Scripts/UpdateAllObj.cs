using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAllObj : MonoBehaviour
{
    public GameObject objHolder;
    public GameObject uiHolder;
    bool _alreadyActiveHolder;
    public float _timer;
    public float _maxOpacity = 0.8f;

    public IEnumerator StartDisplayAll(int time)
    {
        yield return new WaitForSeconds(time);  
        objHolder.SetActive(false);
        uiHolder.SetActive(false);

    }

    private void Update()
    {
        if(GameController.instance.gameState == GameController.GameState.Game)
        {
            if(!_alreadyActiveHolder)
            {
                objHolder.SetActive(true);
                uiHolder.SetActive(true);
            }

            _timer += Time.deltaTime;

            if(_timer > 240f)
            {
                foreach(Transform child in objHolder.transform)
                {
                    if(child.gameObject.GetComponent<SpriteRenderer>() != null)
                        child.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, _maxOpacity);
                }
            }
            else
            {
                foreach (Transform child in objHolder.transform)
                {
                    if (child.gameObject.GetComponent<SpriteRenderer>() != null)
                        child.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, (_timer/240f)* _maxOpacity);
                }
            }

        }
       
    }

}
