using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            paddle.GiveBall();
        }
    }
}
