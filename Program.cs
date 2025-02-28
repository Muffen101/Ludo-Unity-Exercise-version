Player[] players = new Player[4];
for (int i = 0; i < players.Length; i++)
{
    players[i] = new Player();
}
int winnerFound = -1;
Dice dice = new Dice();
while (winnerFound < 0)
{
    for (int i = 0; i < players.Length;i++)
    {
        int diceRoll = dice.RollDice();
        bool winner = players[i].DecideAndMovePiece(diceRoll);
        if (winner)
        {
            winnerFound = i;
            break;
        }
    }
}
Console.WriteLine("winner is player " + winnerFound);

public class GamePiece
{
    private int position=0;

    public int Position { get => position; }

    public void Move(int x)
    {
        position += x;
    }
    
}
public class Dice
{
    private Random random = new Random();
    public int RollDice()
    {
        return random.Next(1,7);
    }
}
public class Player
{
    GamePiece[] pieces = new GamePiece[4];
    public Player()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = new GamePiece();
        }
    }
    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position == 0)
                {
                    pieces[i].Move(1);
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].Position+rollValue <= 40 && pieces[i].Position > 0)
                {
                    pieces[i].Move(rollValue);
                    return false;
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++) {
            if (pieces[i].Position < 40 && pieces[i].Position > 0)
            {
                pieces[i].Move(rollValue);
                return false;
            }
        }
        return true;
    }
}