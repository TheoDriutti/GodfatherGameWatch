using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JGameController : MonoBehaviour
{
    public static JGameController instance; 
    public enum GameState
    {
        Lauch,
        Game,
        GameOver,
        End,
    }
    public GameState gameState;
    public JGameBoard board;
    public JCarsController carsController;
    public JPlayerController playerController;

    [Header("GameController")]
    [Tooltip("Time Btw Each update of the Game")]
    [SerializeField] float _timeBetweenUpdatingGame = 0.7f; 
    private float _timeBeforeUpdatingGame;
    [SerializeField] float _percentToHaveBaby = 0.2f;

    [Header("PlayerController")]
    [Tooltip("Time Btw Player Movement")]
    public float _timeBtwPlayerAction = 0.1f;

    [Tooltip("Which position the Player Start")]
    public int _playerColumn = 0;  

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance in the scene");
        }
        instance = this;

        gameState = GameState.Game;
    }

    private void Start()
    {
        _timeBeforeUpdatingGame = _timeBetweenUpdatingGame;
    }

    private void Update()
    {
        _timeBeforeUpdatingGame -= Time.deltaTime;

        if(_timeBeforeUpdatingGame < 0)
        {
            UpdateGame();
            ResetGameTime();
        }
    }

    private void UpdateGame()
    {
        carsController.UpdateCars();
    }

    private void ResetGameTime()
    {
        _timeBeforeUpdatingGame = _timeBetweenUpdatingGame;
    }
}
