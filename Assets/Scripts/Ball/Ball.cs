using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;
    [SerializeField]
    private Vector2 direction = Vector2.zero;
    private float speed = 5.0f;

    //TODO: Add code to move ball along with code to delete pieces upon colliding with one
    //Ball should only move once its been launched
    
    private void Start()
    {
        //on start, the ball chooses a direction to head in
        direction = new Vector2(Random.Range(-0.7f, 0.7f), Random.Range(0.5f, 1.0f));
    }
   
    private void FixedUpdate()
    {
        //moves the ball forward in the direction it is facing.
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
        
    }
   
    //when it collides with anything, it will turn around and head the other way. 
    //if it is a piece, then it will destroy the piece after it collides and turns away.
    //also for fun i made it so the ball speeds up as it destroys blocks, and this gets reset every
    //time the ball gets respawned bc it is always a new ball.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        if (collision.collider.CompareTag("Piece"))
        {
            Destroy(collision.gameObject);
            speed += 0.33f;
        }
        
    }
}
