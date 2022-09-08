using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TGameController : MonoBehaviour
{
    private static TGameController _instance;
    public static TGameController i { get { return _instance; } }

    public float frameDuration;
    public Text text;

    public float pauseTime;
    public float flickerTime;

    private float _frameTimer = 0f;
    private int _currentFrame;

    private float _pauseTimer = 0f;
    private int _missCount = 0;

    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (JGameController.instance.gameState == JGameController.GameState.Game)
        {
            if (_frameTimer < frameDuration)
            {
                _frameTimer += Time.deltaTime;
            } else
            {
                _frameTimer = 0f;
                PlayFrame();
            }
        } else if (JGameController.instance.gameState == JGameController.GameState.MissPause)
        {
            if (_pauseTimer < pauseTime)
            {
                _pauseTimer += Time.deltaTime;

            } else
            {
                if (_missCount < 3)
                {
                    _pauseTimer = 0f;
                    JGameController.instance.gameState = JGameController.GameState.Game;
                } else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    public void Miss()
    {
        _missCount++;
        JGameController.instance.gameState = JGameController.GameState.MissPause;
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
