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
        direction = new Vector2(Random.Range(-0.7f, 0.7f), Random.Range(0.5f, 1.0f));
    }
   
    private void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
        
    }
   
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
