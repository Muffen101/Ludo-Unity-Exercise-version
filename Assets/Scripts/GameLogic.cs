using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{
    public GameObject gamePiecePrefab;

    private Player[] players;
    private Dice dice;
    private int winnerFound = -1;

    public Transform[] playerStartPositions; // Assign Player1Start, Player2Start, etc. in the Inspector
    public int numberOfPlayers = 4;

    private void Start()
    {
        dice = new Dice();
        players = new Player[numberOfPlayers];

        // Create Players Dynamically
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject playerObj = new GameObject($"Player {i + 1}");
            Player player = playerObj.AddComponent<Player>();

            // Initialize player's game pieces at correct starting position
            player.Initialize(gamePiecePrefab, playerStartPositions[i]);

            players[i] = player;
        }

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (winnerFound < 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                int diceRoll = dice.RollDice();
                Debug.Log($"Player {i + 1} rolled a {diceRoll}");
                bool winner = players[i].DecideAndMovePiece(diceRoll);
                if (winner)
                {
                    winnerFound = i;
                    Debug.Log("Winner is Player " + (i + 1));
                    yield break; // Stop game loop
                }

                yield return new WaitForSeconds(1f); // Delay for better visualization
            }
        }
    }
}

public class Dice
{
    private System.Random random = new System.Random();

    public int RollDice()
    {
        return random.Next(1, 7);
    }
}
