
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    //En metode til at flytte spil objektet ved en specifik værdi
    public void Move(int v)
    {
        // Flytter spil objektet ved at tilføje en ny position til den nuværende position
        transform.position = transform.position + new Vector3(v, 0, 0);
    }
}
