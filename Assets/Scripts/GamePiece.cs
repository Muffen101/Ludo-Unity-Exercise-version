
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public void Move(int v)
    {
        transform.position = transform.position + new Vector3(v, 0, 0);
    }
}
