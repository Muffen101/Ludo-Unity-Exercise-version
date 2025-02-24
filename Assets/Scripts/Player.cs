using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject[] pieces = new GameObject[4];

    public void Start()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = transform.GetChild(i).gameObject;
        }
    }

    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x == 0)
                {
                    pieces[i].GetComponent<GamePiece>().Move(1);
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position.x + rollValue <= 40)
                {
                    pieces[i].GetComponent<GamePiece>().Move(rollValue);
                    return false;
                }
            }
        }
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].transform.position.x < 40)
            {
                pieces[i].GetComponent<GamePiece>().Move(rollValue);
                return false;
            }
        }
        return true;
    }
}
