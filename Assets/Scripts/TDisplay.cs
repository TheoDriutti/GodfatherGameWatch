using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDisplay : MonoBehaviour
{
    Transform[,] grid = new Transform[5, 6];

    public TCarGrid carGrid;
    public Transform gridRoot;

    // Start is called before the first frame update
    void Start()
    {
        SetupGrid();
        StartCoroutine(UpdateDisplay());
    }

    public void SetupGrid()
    {
        int x = 0;
        foreach (Transform col in gridRoot)
        {
            int y = 0;
            foreach (Transform piece in col)
            {
                grid[x, y] = piece;

                y++;    
            }
            x++;
        }
    }

    IEnumerator UpdateDisplay()
    {
        while (true)
        {
            int x = 0;
            foreach (Transform col in grid)
            {
                int y = 0;
                foreach (Transform piece in col)
                {   
                    grid[x, y].gameObject.SetActive(carGrid.GetValueAt(x, y));

                    y++;
                }
                x++;
            }

            yield return null;
        }
    }
}
