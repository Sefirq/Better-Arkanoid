using UnityEngine;
using System.Collections;

public class BallCollisions : MonoBehaviour {

    Rigidbody2D ballRigidbody;
    Renderer playerRenderer;
    Win winner;
    void Start ()
    {        
        ballRigidbody = GetComponent<Rigidbody2D>();
        winner = GameObject.Find("Main Camera").GetComponent<Win>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(ballRigidbody.velocity.x);
        Debug.Log(ballRigidbody.velocity.y);
        if (other.gameObject.tag == "Frame" && transform.position.y < -4.4f)
        {
            Destroy(this.gameObject);
            Application.LoadLevel("Game Over");
        }
        else if (other.gameObject.tag == "Brick")
        {
            winner.denominate();                    
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            playerRenderer = other.gameObject.GetComponent<Renderer>();
            float x = other.transform.position.x;
            float extentsX = playerRenderer.bounds.extents.x;
            if (x - 0.15f < transform.position.x && transform.position.x < x + 0.15f)
            {
                Debug.Log("Wyprost");
                ballRigidbody.AddForce(new Vector2((ballRigidbody.velocity.x + (Random.value - 0.5f)) * -50, 0));
            }
            else if (transform.position.x < x-0.15f || transform.position.x > x + 0.15f)
            {
                Debug.Log("tr<x");
                if (ballRigidbody.velocity.y > 6)
                {
                    ballRigidbody.AddForce(new Vector2((transform.position.x - x)*100, -Mathf.Abs((transform.position.x - x) * 25)));
                }
                else if (ballRigidbody.velocity.y < -6)
                {
                    ballRigidbody.AddForce(new Vector2((transform.position.x - x) * 100, Mathf.Abs((transform.position.x - x) * 25)));
                }
                else if (ballRigidbody.velocity.y > -4.5f || ballRigidbody.velocity.y < 4.5f)
                    ballRigidbody.AddForce(new Vector2((transform.position.x - x) * 100, Mathf.Abs((transform.position.x - x) * 25)));
                else
                    ballRigidbody.AddForce(new Vector2((transform.position.x - x) * 100, 0));
            }
            /*else if(transform.position.x > x+0.15f)
            {
                Debug.Log("tr>x");
                if (ballRigidbody.velocity.y > 6)
                    ballRigidbody.AddForce(new Vector2((transform.position.x - x) * 50, -(transform.position.x - x) * 25));
                else
                    ballRigidbody.AddForce(new Vector2((transform.position.x - x) * 50, 0));
            }*/
            
        }
        
    }
    // Update is called once per frame
    void Update () {
	
	}
}
