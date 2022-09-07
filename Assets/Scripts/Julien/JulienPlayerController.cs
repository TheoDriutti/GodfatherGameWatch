using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulienPlayerController : MonoBehaviour
{
    [SerializeField] List<GameObject> PlayerPos = new List<GameObject>();
    [Tooltip("Position from O to 3 where the player start")]
    [SerializeField] int _playerStartPos = 0;
    private int _playerCurrentPos;
    [SerializeField] float _timeBtwPlayerAction = 0.1f;
    private float _timeBeforePlayerAction;
    private void Start()
    {
        PlayerPos[_playerStartPos].SetActive(true);
        _playerCurrentPos = _playerStartPos;
        _timeBeforePlayerAction = _timeBtwPlayerAction;
    }

    private void Update()
    {
        _timeBeforePlayerAction -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.RightArrow) && (_timeBeforePlayerAction < 0))
        {
            MovePlayer(_playerCurrentPos + 1, _playerCurrentPos);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && (_timeBeforePlayerAction < 0))
        {
            MovePlayer(_playerCurrentPos - 1, _playerCurrentPos);
        }
    }

    private void MovePlayer(int nextPos, int currentPos)
    {
        var clampedValue = Mathf.Clamp(nextPos, 0, 3);
        PlayerPos[_playerCurrentPos].SetActive(false);
        PlayerPos[clampedValue].SetActive(true);
        _playerCurrentPos = clampedValue;
        ResetTime();
    }

    private void ResetTime()
    {
        _timeBeforePlayerAction = _timeBtwPlayerAction;
    }


}
