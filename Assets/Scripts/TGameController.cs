using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TGameController : MonoBehaviour
{
    private static TGameController _instance;
    public static TGameController i { get { return _instance; } }

    public float frameDuration;
    public Text text;

    private float _frameTimer = 0f;
    private int _currentFrame;

    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_frameTimer < frameDuration)
        {
            _frameTimer += Time.deltaTime;
        } else
        {
            _frameTimer = 0f;
            PlayFrame();
        }
    }

    void PlayFrame()
    {
        _currentFrame++;
        text.text = _currentFrame.ToString();
        TCarController.i.UpdateCars();
    }

    public int GetCurrentFrame()
    {
        return _currentFrame;
    }

}
