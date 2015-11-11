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
    void Start()
    {
        ballCollider = GetComponent<Collider2D>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        forceAtStart = new Vector2(forceX, forceY);
        ifFirstForce = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            float x = other.transform.position.x;
        }
        else if(other.gameObject.tag == "Brick")
        {
            Debug.Log("hahaha");
            Destroy(other.gameObject);
        }
    }
    void Awake()
    {
        cam = GameObject.Find("Main Camera");
        sth = cam.GetComponent<LevelStart>();
        bar = GameObject.Find("Bar");
        barRenderer = bar.GetComponent<SpriteRenderer>();
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
        }
    }
    
}
