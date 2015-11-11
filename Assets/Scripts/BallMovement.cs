using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public float forceX;
    public float forceY;
    private Vector2 forceAtStart;
    private bool ifFirstForce;
    GameObject cam;
    LevelStart sth;
    GameObject bar;
    SpriteRenderer barRenderer;
    Rigidbody2D ballRigidbody;
    Collider2D ballCollider;
    private Renderer ballRenderer;
    private float ballVeloX;
    private float ballVeloY;
    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
        ballCollider = GetComponent<Collider2D>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        forceAtStart = new Vector2(forceX, forceY);
        ifFirstForce = false;
    }
    
    void Awake()
    {
        cam = GameObject.Find("Main Camera");
        sth = cam.GetComponent<LevelStart>();
        bar = GameObject.Find("Bar");
        barRenderer = bar.GetComponent<SpriteRenderer>();
        Debug.Log(barRenderer.bounds.size.x);
    }
    
    public void checkXSpeed()
    {
        ballVeloX = ballRigidbody.velocity.x;
       // if ((ballVeloX < 2 && ballVeloX> 0)|| (ballVeloX > -2 && ballVeloX < 0))
           // ballRigidbody.AddForce(new Vector2((2 - ballVeloX) * 50, 0));
        if (ballVeloX > 4)
            ballVeloX = 4;
        else if (ballVeloX < -4)
            ballVeloX = -4;
    }
    public void checkYSpeed()
    {
        ballVeloY = ballRigidbody.velocity.y;
        if ((ballVeloY < 3 && ballVeloY > 0)||(ballVeloY > -3 && ballVeloY < 0))
            ballRigidbody.AddForce(new Vector2(0, (3 - ballVeloY) * 50));
        if (ballVeloY > 6.5f)
            ballVeloY = 6.5f;
        else if (ballVeloY < -6.5f)
            ballVeloY = -6.5f;
    }


    void Update()
    {
        if(!sth.levelStart)
        {
            transform.position = new Vector3(bar.transform.position.x, bar.transform.position.y + barRenderer.bounds.size.y * 1.5f, -1);
        }
        else
        {
            if (!ifFirstForce)
            {
                ballRigidbody.AddForce(forceAtStart);
                ifFirstForce = !ifFirstForce;
            }
            checkXSpeed();
            checkYSpeed();
            //Debug.Log(ballVeloX);
            //Debug.Log(ballVeloY);
        }
    }
    
}
