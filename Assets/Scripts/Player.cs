using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject[] pieces = new GameObject[4]; //Array til at holde spil objekterne

    public void Start()
    {
        //Initialiser spillerens spilobjekter ved at få children af GameLogic objektet
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = transform.GetChild(i).gameObject;
        }
    }

    public bool DecideAndMovePiece(int rollValue)
    {
        //Hvis terningen bliver en 6'er så flyttes den første brik der ikke er flyttet
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x == 0)
                {
                    pieces[i].GetComponent<GamePiece>().Move(1);
                    return false; //Returner false hvis der ikke er fundet en vinder
                }
            }
        }
        else
        {
            //Flytter brikken hvis den kan flyttes uden at gå over 40
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x + rollValue <= 40 && pieces[i].transform.position.x > 0)
                {
                    pieces[i].GetComponent<GamePiece>().Move(rollValue);
                    return false; //Brikken flytter og ingen vinder er fundet endnu
                }
            }
        }
        //Hvis ingen brikker flyttes så prøver den at flytte en random brik
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].transform.position.x < 40 && pieces[i].transform.position.x > 0)
            {
                pieces[i].GetComponent<GamePiece>().Move(rollValue);
                return false; //Brikken flyttes og ingen vinder er fundet endnu
            }
        }

        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].transform.position.x < 40)
            {
                return false;
            }
        }
        return true; //Ingen brikker kan flyttes og der er fundet en vinder
    }
}
