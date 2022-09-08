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

    public Combination comb;
    public int _indexComb = 0;
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
                    else //si voiture sur deriere ligne     
                        JGameController.instance.board.carGrid[x, y] = false;
                }

            }
            _checkLastLine = true;
        }

        _checkLastLine = false;

        JGameController.instance.board.SetValueAt(FindComb(), 3, JGameController.instance.board.carGrid);


    }

    private int FindComb()
    {

        if (comb.combInt.Count == 0 || _indexComb >= 3)
        {
            int rand = UnityEngine.Random.Range(0, 24);
            comb = ListOfCombinations[rand];
            _indexComb = 0;
        }
        else
            _indexComb++;

        return comb.combInt[_indexComb] - 1;
    }

}
