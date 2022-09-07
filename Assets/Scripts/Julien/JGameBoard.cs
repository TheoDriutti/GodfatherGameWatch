using UnityEngine;

public class JGameBoard : MonoBehaviour
{
    public bool[,] carGrid = new bool[4, 4];
    public bool[,] playerGrid = new bool[4, 1];

    public bool GetValueAt(int x, int y, bool[,] grid)
    {
        return grid[x, y];
    }

    public void SetValueAt(int x, int y, bool[,] grid, bool newValue = true)
    {
        grid[x, y] = newValue;
    }

    public void Clear(bool[,] grid)
    { 
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y] = false;
            }
        }
    }

    private void Awake()
    {
        Clear(carGrid);
        Clear(playerGrid);
    }
}
