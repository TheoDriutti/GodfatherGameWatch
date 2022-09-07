using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCarGrid : MonoBehaviour
{
    [HideInInspector] public bool[,] grid = new bool[4, 5];

    private static TCarGrid _instance;
    public static TCarGrid i { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    public bool GetValueAt(int x, int y)
    {
        return grid[x, y];
    }

    public void SetValueAt(int x, int y, bool value = true)
    {
        grid[x, y] = value;
    }
}
