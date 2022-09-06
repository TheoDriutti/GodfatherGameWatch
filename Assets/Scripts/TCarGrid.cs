using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCarGrid : MonoBehaviour
{
    bool[,] grid = new bool[5, 6];

    public bool GetValueAt(int x, int y)
    {
        return grid[x, y];
    }

    public void SetValueAt(int x, int y, bool value = true)
    {
        grid[x, y] = value;
    }
}
