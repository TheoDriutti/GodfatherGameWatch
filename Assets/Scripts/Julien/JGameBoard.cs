using UnityEngine;

public class JGameBoard : MonoBehaviour
{
    public bool[,] carGrid = new bool[4, 4];
    public bool[,] playerGrid = new bool[5, 1];
    public GameObject[,] carGridGo = new GameObject[4, 4];
    public GameObject[,] playerGridGo = new GameObject[5, 1];

    public bool GetValueAt(int x, int y, bool[,] grid)
    {
        return grid[x, y];
    }

    public void SetValueAt(int x, int y, bool[,] grid, bool newValue = true)
    {
        grid[x, y] = newValue;
    }

    public void SetValueAtNextPosition(int x, int y, bool[,] grid)
    {
        grid[x, y] = false;
        grid[x, y - 1] = true;   
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
