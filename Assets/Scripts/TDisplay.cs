using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDisplay : MonoBehaviour
{
    Transform[,] carObjectGrid = new Transform[4, 5];
     
    public TGrid carBoolGrid;

    // Start is called before the first frame update
    void Start()
    {
        SetupGrid();
        Clear(carBoolGrid.grid);
        StartCoroutine(UpdateDisplay());
    }

    public void SetupGrid()
    {
        int x = 0;
        foreach (Transform col in transform)
        {
            int y = 0;
            foreach (Transform piece in col)
            {
                carObjectGrid[x, y] = piece;

                y++;    
            }
            x++;
        }
    }

    public void Clear(bool[,] grid)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y] = false;
            }
        }
    }

    IEnumerator UpdateDisplay()
    {
        while (true)
        {
            for (int x = 0; x < carObjectGrid.GetLength(0); x++)
            {
                for (int y = 0; y < carObjectGrid.GetLength(1); y++)
                {   
                    carObjectGrid[x, y].gameObject.SetActive(carBoolGrid.GetValueAt(x, y));
                }
            }

            yield return null;
        }
    }
}
