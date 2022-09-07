using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDisplay : MonoBehaviour
{
    GameObject[,] carGrid = new GameObject[4, 4];
    GameObject[,] playerGrid = new GameObject[4, 1];

    [Tooltip("The game board that indicates what pieces are to be displayed")]
    public JGameBoard board;

    public GameObject[] carColumns;
    public GameObject[] players;

    private void Start()
    {
        SetupCarsGrid(carGrid);
        SetupPlayerGrid(playerGrid);
        DisplayTwoDimensionnalGrid(carGrid);
        DisplayTwoDimensionnalGrid(playerGrid);
        StartCoroutine(UpdateDisplay(carGrid, playerGrid));    
    }

    public void SetupCarsGrid(GameObject[,] gridGo)
    {
        for (int x = 0; x < carColumns.Length; x++)
        {
            int y = 0;
            foreach (Transform t in carColumns[x].transform)
            {
                gridGo[x, y] = t.gameObject;
                y++;
            }
        }
    }

    public void SetupPlayerGrid(GameObject[,] gridGo)
    {
        for (int x = 0; x < players.Length; x++)
        {
            gridGo[x, 0] = players[x];
        }
    }

    void DisplayTwoDimensionnalGrid(GameObject[,] gridGo)
    {
        foreach(GameObject go in gridGo)
        {
            Debug.Log(go);
        }
    }

    IEnumerator UpdateDisplay(GameObject[,] carsGridGo, GameObject[,] playersGridGo)
    {
        while (true)
        {
            for (int y = 0; y < board.carGrid.GetLength(1); y++)
            {
                for (int x = 0; x < board.carGrid.GetLength(0); x++)
                {
                    carsGridGo[x, y].SetActive(board.GetValueAt(x, y, board.carGrid));
                }
            }

            for (int y = 0; y < board.playerGrid.GetLength(1); y++)
            {
                for (int x = 0; x < board.playerGrid.GetLength(0); x++)
                {
                    playersGridGo[x, y].SetActive(board.GetValueAt(x, y, board.playerGrid));
                }
            }


            yield return null;
        }
    }
}
