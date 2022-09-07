using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerController : MonoBehaviour
{
    private float _timeBeforePlayerAction;
    private void Start()
    {
        _timeBeforePlayerAction = JGameController.instance._timeBtwPlayerAction;
        ResetPlayerValue();
    }

    private void Update()
    {
        _timeBeforePlayerAction -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow) && (_timeBeforePlayerAction < 0))
        {
            MovePlayerRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (_timeBeforePlayerAction < 0))
        {
            MovePlayerLeft();
        }
    }

    private void MovePlayerRight()
    {
        JGameController.instance.board.SetValueAt(JGameController.instance._playerColumn, JGameController.instance.board.playerGrid.GetLength(1) - 1, JGameController.instance.board.playerGrid, false);

        JGameController.instance._playerColumn++;
        if (JGameController.instance._playerColumn > 3) JGameController.instance._playerColumn = 3;

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

}
