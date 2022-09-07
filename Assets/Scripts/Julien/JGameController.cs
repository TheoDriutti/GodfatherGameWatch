using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JGameController : MonoBehaviour
{
    [SerializeField] float _timeBtwPlayerAction = 0.1f;
    private float _timeBeforePlayerAction;

    //Where the player start
    int _playerColumn = 0;  

    public JGameBoard board;

    private void Update()
    {
        board.SetValueAt(_playerColumn, board.playerGrid.GetLength(1) - 1, board.playerGrid, false);

        _timeBeforePlayerAction -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow) && (_timeBeforePlayerAction < 0))
        {
            _playerColumn++;
            if (_playerColumn < 0) _playerColumn = 0;
            if (_playerColumn > 3) _playerColumn = 3;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (_timeBeforePlayerAction < 0))
        {
            _playerColumn--;
            if (_playerColumn < 0) _playerColumn = 0;
            if (_playerColumn > 3) _playerColumn = 3;
        }

        board.SetValueAt(_playerColumn, board.playerGrid.GetLength(1) - 1, board.playerGrid);


    }

    private void MovePlayer()
    {
                
    }
}
