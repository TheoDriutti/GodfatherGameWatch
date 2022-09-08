using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerController : MonoBehaviour
{
    private float _timeBeforePlayerAction;
    public int NumberOfOil;
    private int _maxOfOil = 3;
    private void Start()
    {
        _timeBeforePlayerAction = JGameController.instance._timeBtwPlayerAction;
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
        JGameController.instance.board.SetValueAt(JGameController.instance._playerColumn, JGameController.instance.board.playerGrid.GetLength(1) - 1, JGameController.instance.board.playerGrid, false);

        JGameController.instance._playerColumn++;
        if (JGameController.instance._playerColumn > JGameController.instance.board.playerGrid.GetLength(0)- 1) JGameController.instance._playerColumn = JGameController.instance.board.playerGrid.GetLength(0) - 1;

        ResetPlayerValue();
        ResetTime();
    }

    private void MovePlayerLeft()
    {
        JGameController.instance.board.SetValueAt(JGameController.instance._playerColumn, JGameController.instance.board.playerGrid.GetLength(1) - 1, JGameController.instance.board.playerGrid, false);

        JGameController.instance._playerColumn--;
        if (JGameController.instance._playerColumn < 0) JGameController.instance._playerColumn = 0;

        ResetPlayerValue();
        ResetTime();
    }

    private void ResetPlayerValue()
    {
        JGameController.instance.board.SetValueAt(JGameController.instance._playerColumn, JGameController.instance.board.playerGrid.GetLength(1) - 1, JGameController.instance.board.playerGrid);
    }
    private void ResetTime()
    {
        _timeBeforePlayerAction = JGameController.instance._timeBtwPlayerAction;
    }

    private void RefillPlayerOil()
    {
        if (JGameController.instance._playerColumn == JGameController.instance.board.playerGrid.GetLength(0) - 1)
        {
            NumberOfOil = _maxOfOil;
        }
    }


}
