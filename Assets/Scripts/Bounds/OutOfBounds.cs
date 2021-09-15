using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //anything with this script that will delete the ball if it finds it.
        //additionally though it will give the paddle the ball back.
        //it could be better to put the paddle.GiveBall() on the ball itself when it is destroyed
        //but alas.
        if (collision.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            paddle.GiveBall();
        }
    }
}
