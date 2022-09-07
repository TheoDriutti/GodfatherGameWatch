using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JCarsController : MonoBehaviour
{
    #region INTERNAL TYPES
    [System.Serializable]
    public class Combination
    {
        public List<int> combInt;
    }
    #endregion

    public List<Combination> ListOfCombinations = new List<Combination> ();

    private Combination comb;
    private int _indexComb = 0;
    private bool _firstCarAlreadySpawned;
    private bool _carAlreadySpawned;
    private bool _checkLastLine;
    public void UpdateCars()
    {
        for (int y = 0; y < JGameController.instance.board.carGrid.GetLength(1); y++)
        {
            for (int x = 0; x < JGameController.instance.board.carGrid.GetLength(0); x++)
            {
                if (JGameController.instance.board.carGrid[x, y] == true)
                {                    
                    if (_checkLastLine) 
                    {
                        JGameController.instance.board.SetValueAtNextPosition(x, y, JGameController.instance.board.carGrid); 
                    }
                    else if(!_firstCarAlreadySpawned)
                    {
                        JGameController.instance.board.carGrid[x, y] = false;
                        JGameController.instance.board.SetValueAt(FindComb(), 3, JGameController.instance.board.carGrid);
                        _carAlreadySpawned = true;
                        _firstCarAlreadySpawned = true;
                        
                    }
                }

            }
            _checkLastLine = true;
        }

        _checkLastLine = false;

        if (!_carAlreadySpawned)
        {
            JGameController.instance.board.SetValueAt(FindComb(), 3, JGameController.instance.board.carGrid);
        }

        _carAlreadySpawned = false;
        _firstCarAlreadySpawned = false;
    }

    private int FindComb()
    {
        if (comb == null || _indexComb > 3)
        {
            int rand = UnityEngine.Random.Range(0, 24);
            comb = ListOfCombinations[rand];
            _indexComb = 0;
        }

        Debug.Log(comb.combInt[++_indexComb] - 1);
        return comb.combInt[++_indexComb] - 1;
    }

}
