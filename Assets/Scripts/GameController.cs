using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController instance { get { return _instance; } }
    public enum GameState
    {
        Lauch,
        Game,
        MissPause,
        GameOver,
        End,
    }
    public GameState gameState;

    public GameBoard board;
    public PlayerController playerController;

    [Header("PlayerController")]
    [Tooltip("Time Btw Player Movement")]
    public float _timeBtwPlayerAction = 0.1f;
    [Tooltip("Which position the Player Start")]
    public int _playerColumn = 0;

    public float frameDuration;

    public float pauseTime;

    private float _frameTimer = 0f;
    private int _currentFrame;

    private float _pauseTimer = 0f;
    private int _carMissCount = 0;
    private int _babyMissCount = 0;
    private int _missedCarCol;
    private int _missedBabyCol;
    private bool isCarMiss = false;

    void Awake()
    {
        _instance = this;
        //gameState = GameState.Game;
    }

    public void StartGame()
    {
        gameState = GameState.Game;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Game)
        {
            if (_frameTimer < frameDuration)
            {
                _frameTimer += Time.deltaTime;
            } else
            {
                _frameTimer = 0f;
                PlayFrame();
            }
        } else if (gameState == GameState.MissPause)
        {
            if (_pauseTimer < pauseTime)
            {
                _pauseTimer += Time.deltaTime;

            } else
            {
                if (_carMissCount < 3 && _babyMissCount < 2)
                {
                    _pauseTimer = 0f;
                    gameState = GameState.Game;
                    if (isCarMiss)
                    {
                        TCarController.i.carGrid.SetValueAt(_missedCarCol, 0, false);
                        isCarMiss = false;
                    } else
                    {
                        TCarController.i.strollerGrid.SetValueAt(_missedBabyCol, 0, false);
                    }
                } else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    public void CarMiss(int lane)
    {
        _carMissCount++;
        gameState = GameState.MissPause;
        _missedCarCol = lane;
        isCarMiss = true;
    }

    public void BabyMiss(int lane)
    {
        _babyMissCount++;
        gameState = GameState.MissPause;
        _missedBabyCol = lane;
    }

    void PlayFrame()
    {
        _currentFrame++;
        TCarController.i.UpdateCars();
    }

    public int GetCurrentFrame()
    {
        return _currentFrame;
    }
}
