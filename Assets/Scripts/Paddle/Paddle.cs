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
        if (haveBall && Input.GetKeyDown(KeyCode.Space)){
            ball = Instantiate(ballPrefab, new Vector3(ballLaunchPad.transform.position.x, ballLaunchPad.transform.position.y, ballLaunchPad.transform.position.z),Quaternion.identity);
            haveBall = false;
        }

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
        var xPosition = Mathf.Clamp(transform.position.x, -5.5f, 5.5f);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
    public void GiveBall()
    {
        haveBall = true;
    }



}
