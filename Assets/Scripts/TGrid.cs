using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGrid : MonoBehaviour
{
    [HideInInspector] public bool[,] grid = new bool[4, 6];

    private static TGrid _instance;
    public static TGrid i { get { return _instance; } }

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
