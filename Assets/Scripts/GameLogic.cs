using System;
using System.Collections;
using UnityEngine;


[SerializeField]
public class GameLogic : MonoBehaviour
{
    public GameObject gamePiecePrefab;

    GameObject[] players = new GameObject[4];
    int dice;
    private int winnerFound = -1;

    
    public int numberOfPlayers = 4;

    private void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = transform.GetChild(i).gameObject;
        }
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                yield return new WaitForSeconds(0.2f);
                dice = UnityEngine.Random.Range(1, 7);
                bool winner = players[i].GetComponent<Player>().DecideAndMovePiece(dice);
                if (winner)
                {
                    winnerFound = i;
                    Debug.Log("Winner is Player " + (i + 1));
                    break; // Stop game loop
                }
            }
        }
    }
}