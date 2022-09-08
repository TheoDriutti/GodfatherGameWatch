using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _timeBeforePlayerAction;
    public int NumberOfOil;
    private int _maxOfOil = 3;
    private void Start()
    {
        _timeBeforePlayerAction = GameController.instance._timeBtwPlayerAction;
        ResetPlayerValue();
        NumberOfOil = _maxOfOil;
    }

    private void Update()
    {
        _timeBeforePlayerAction -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow) && (_timeBeforePlayerAction < 0))
        {
            MovePlayerRight();
            RefillPlayerOil();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (_timeBeforePlayerAction < 0))
        {
            MovePlayerLeft();
            RefillPlayerOil();
        }
    }

    private void MovePlayerRight()
    {
        GameController.instance.board.SetValueAt(GameController.instance._playerColumn, GameController.instance.board.playerGrid.GetLength(1) - 1, GameController.instance.board.playerGrid, false);

        GameController.instance._playerColumn++;
        if (GameController.instance._playerColumn > GameController.instance.board.playerGrid.GetLength(0)- 1) GameController.instance._playerColumn = GameController.instance.board.playerGrid.GetLength(0) - 1;

        ResetPlayerValue();
        ResetTime();
    }

    private void MovePlayerLeft()
    {
        GameController.instance.board.SetValueAt(GameController.instance._playerColumn, GameController.instance.board.playerGrid.GetLength(1) - 1, GameController.instance.board.playerGrid, false);

        GameController.instance._playerColumn--;
        if (GameController.instance._playerColumn < 0) GameController.instance._playerColumn = 0;

        ResetPlayerValue();
        ResetTime();
    }

    private void ResetPlayerValue()
    {
        GameController.instance.board.SetValueAt(GameController.instance._playerColumn, GameController.instance.board.playerGrid.GetLength(1) - 1, GameController.instance.board.playerGrid);
    }
    private void ResetTime()
    {
        _timeBeforePlayerAction = GameController.instance._timeBtwPlayerAction;
    }

    private void RefillPlayerOil()
    {
        if (GameController.instance._playerColumn == GameController.instance.board.playerGrid.GetLength(0) - 1)
        {
            NumberOfOil = _maxOfOil;
        }
    }


}