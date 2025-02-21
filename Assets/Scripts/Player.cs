using UnityEngine;

public class Player : MonoBehaviour
{
    public GamePiece[] pieces = new GamePiece[4];

    public void Initialize(GameObject gamePiecePrefab, Transform startPosition)
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            Vector3 piecePosition = startPosition.position + new Vector3(i * 0.5f, 0, 0); // Offset pieces slightly
            GameObject pieceObj = Instantiate(gamePiecePrefab, piecePosition, Quaternion.identity);
            pieces[i] = pieceObj.GetComponent<GamePiece>();
            pieceObj.name = $"{gameObject.name}_Piece{i + 1}";
            pieceObj.transform.SetParent(transform); // Set player as parent
        }
    }

    public bool DecideAndMovePiece(int rollValue)
    {
        if (rollValue == 6)
        {
            foreach (var piece in pieces)
            {
                if (piece.Position == 0)
                {
                    piece.Move(1);
                    return false;
                }
            }
        }
        else
        {
            foreach (var piece in pieces)
            {
                if (piece.Position + rollValue <= 40)
                {
                    piece.Move(rollValue);
                    return false;
                }
            }
        }

        foreach (var piece in pieces)
        {
            if (piece.Position < 40)
            {
                piece.Move(rollValue);
                return false;
            }
        }

        return true; // Player wins
    }
}
