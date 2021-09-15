using UnityEngine;

public class Paddle : MonoBehaviour
{
    //TODO
    // Move paddle left and right using keyboard keys, mapping is up to you
    // Paddle should be able to launch the ball upon space bar being pressed
    // A launched ball will then bounce around, changing its direction upon any collision

    [SerializeField] private float speed = 2.50f;
    [SerializeField] Ball ballPrefab;
    [SerializeField] GameObject ballLaunchPad;
    private float speedI;
    private float speedIncreaseRate = 0.1f;
    [SerializeField]
    private bool haveBall = true;
    public Ball ball;
    private void Start()
    {
        speedI = speed;
        
    }
    private void Update()
    {
        //if the paddle "has" the ball, then you can press space to launch one from the starting platform.
        //then it removes the ball from the paddle.
        //uses the position of the launch platform to spawn the ball at.
        if (haveBall && Input.GetKeyDown(KeyCode.Space)){
            ball = Instantiate(ballPrefab, new Vector3(ballLaunchPad.transform.position.x, ballLaunchPad.transform.position.y, ballLaunchPad.transform.position.z),Quaternion.identity);
            haveBall = false;
        }
        //movement for the paddle, left and right.
        //i added this code to make the paddle increase its speed the longer you held the button because i
        //dont like when the paddle is too slow to not be able to catch up to the ball.
        //resets to its SpeedI (initial) after you let go of left or right and is capped at 25.0f.
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            speed += speedIncreaseRate;
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            speed += speedIncreaseRate;
        }
        #region StuffIAddedForFun
        if (Input.GetKeyUp(KeyCode.A))
        {
            speed = speedI;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            speed = speedI;
        }
        speed = Mathf.Clamp(speed, 0.0f, 25.0f);
        #endregion
        //paddle cannot leave the bounds of the screen where the ball bounces off of. roughly at 
        //x= -5.5f and 5.5f
        var xPosition = Mathf.Clamp(transform.position.x, -5.5f, 5.5f);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
    //helper method to be called by other objects so that the ball may be launched again.
    public void GiveBall()
    {
        haveBall = true;
    }



}
