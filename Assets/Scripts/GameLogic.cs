using System;
using System.Collections;
using UnityEngine;


[SerializeField]
public class GameLogic : MonoBehaviour
{
    public GameObject gamePiecePrefab; //Prefab for game piece

    GameObject[] players = new GameObject[4]; 
    int dice; //En variabel som holder verdien til terningen
    private int winnerFound = -1; //En variabel som tracker om en vinner er fundet


    public int numberOfPlayers = 4; //Antal spillere i spillet

    private void Start()
    {
        //Initialiser spillerens spilobjekter ved at få children af GameLogic objektet
        for (int i = 0; i < players.Length; i++) 
        {
            players[i] = transform.GetChild(i).gameObject;
        }
        //Starter spil loop coroutine
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        //Fortsætter spillet i et loop indtil der er en vinder
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                yield return new WaitForSeconds(0.2f); //Venter 0.2 sekunder før næste spiller
                dice = UnityEngine.Random.Range(1, 7); //Ruller terningen i mellem 1 og 6
                bool winner = players[i].GetComponent<Player>().DecideAndMovePiece(dice); //Spilleren ruller terningen og flytter brikken
                if (winner)
                {
                    winnerFound = i; //Sætter vinderen til den nuværende spiller
                    Debug.Log("Winner is Player " + (i + 1)); //Udskriver vinderen i consollen
                    break; // Stopper game loop
                }
            }
        }
    }
}