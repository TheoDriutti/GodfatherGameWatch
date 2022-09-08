using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDisplay : MonoBehaviour
{
    public GameObject[] carColumns;
    public GameObject[] players;

    private void Start()
    {
        SetupCarsGrid(JGameController.instance.board.carGridGo);
        SetupPlayerGrid(JGameController.instance.board.playerGridGo);
        DisplayTwoDimensionnalGrid(JGameController.instance.board.carGridGo);
        DisplayTwoDimensionnalGrid(JGameController.instance.board.playerGridGo);
        StartCoroutine(UpdateDisplay(JGameController.instance.board.carGridGo, JGameController.instance.board.playerGridGo));
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
        while (JGameController.instance.gameState == JGameController.GameState.Game)
        {
            for (int y = 0; y < JGameController.instance.board.carGrid.GetLength(1); y++)
            {
                for (int x = 0; x < JGameController.instance.board.carGrid.GetLength(0); x++)
                {
                    carsGridGo[x, y].SetActive(JGameController.instance.board.GetValueAt(x, y, JGameController.instance.board.carGrid));
                }
            }

            for (int y = 0; y < JGameController.instance.board.playerGrid.GetLength(1); y++)
            {
                for (int x = 0; x < JGameController.instance.board.playerGrid.GetLength(0); x++)
                {
                    playersGridGo[x, y].SetActive(JGameController.instance.board.GetValueAt(x, y, JGameController.instance.board.playerGrid));
                }
            }

            DisplayOil();
            UpdatePlayerOil();
            yield return null;
            
        }
    }

    private void DisplayOil()
    {
        for (int x = 0; x < 4; x++)
        {
            switch(JGameController.instance.playerController.NumberOfOil)
            {
                case 0:
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case 1:
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    break;
                case 2:
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    break;
                case 3:
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    JGameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    break;
            }
        }
    }

    private void UpdatePlayerOil()
    {
        int playerPosClamp = Mathf.Clamp(JGameController.instance._playerColumn, 0, 3);
        if (JGameController.instance.board.carGrid[playerPosClamp, 0])
        {
            JGameController.instance.playerController.NumberOfOil--;
            JGameController.instance.board.carGrid[playerPosClamp, 0] = false;
        }
    }
}
