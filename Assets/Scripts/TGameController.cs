using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGameController : MonoBehaviour
{
    public float minimumFramePeriod;

    float _frameTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            if (_frameTimer < minimumFramePeriod)
            {
                _frameTimer++;
            } else
            {
                _frameTimer = 0f;
                PlayFrame();
            }

        }
    }

    void PlayFrame()
    {
        TCarController.i.UpdateCars();
    }


}
