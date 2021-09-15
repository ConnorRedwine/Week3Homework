using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float ROW_HEIGHT = 0.48f;
    public const int PIECE_COUNT_PER_ROW = 13;
    public const float PIECE_LENGTH = 0.96f;
    public const int TOTAL_ROWS = 10;
    public const int PIECE_COUNT = PIECE_COUNT_PER_ROW * TOTAL_ROWS;
    private int counter = 0;
    [SerializeField]
    private Transform pieces = null;

    [SerializeField]
    private GameObject piecePrefab = null;

    [SerializeField]
    private EdgeCollider2D border;


    //TODO
    //Using const data defined above "Instantiate" new pieces to fill the view with
    private void Awake()
    {
      
        while (counter < PIECE_COUNT)
        {
            Instantiate(piecePrefab, new Vector3(
                (pieces.position.x + (PIECE_LENGTH * counter) % (PIECE_COUNT_PER_ROW * PIECE_LENGTH))
                , pieces.position.y - ((ROW_HEIGHT * counter) % (TOTAL_ROWS * ROW_HEIGHT))
                , pieces.position.z), Quaternion.identity);
            counter++;
        }
    }
}
