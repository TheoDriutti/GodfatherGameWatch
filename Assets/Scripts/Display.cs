using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public GameObject[] players;

    private void Start()
    {
        SetupPlayerGrid(GameController.instance.board.playerGridGo);
        StartCoroutine(UpdateDisplay(GameController.instance.board.playerGridGo));
    }

    public void SetupPlayerGrid(GameObject[,] gridGo)
    {
        for (int x = 0; x < players.Length; x++)
        {
            gridGo[x, 0] = players[x];
        }
    }

    IEnumerator UpdateDisplay(GameObject[,] playersGridGo)
    {
        while (GameController.instance.gameState == GameController.GameState.Game)
        {
            for (int y = 0; y < GameController.instance.board.playerGrid.GetLength(1); y++)
            {
                for (int x = 0; x < GameController.instance.board.playerGrid.GetLength(0); x++)
                {
                    playersGridGo[x, y].SetActive(GameController.instance.board.GetValueAt(x, y, GameController.instance.board.playerGrid));
                }
            }

            DisplayOil();
            yield return null;
            
        }
    }

    private void DisplayOil()
    {
        for (int x = 0; x < 4; x++)
        {
            switch(GameController.instance.playerController.NumberOfOil)
            {
                case 0:
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case 1:
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    break;
                case 2:
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    break;
                case 3:
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    GameController.instance.board.playerGridGo[x, 0].gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    break;
            }
        }
    }
}
