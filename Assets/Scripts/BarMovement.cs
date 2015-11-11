using UnityEngine;
using System.Collections;

public class BarMovement : MonoBehaviour
{
    void Move()
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * 10, transform.position.y);
    }
    void Update()
    {
        if (transform.position.x <= -8.2f && Input.GetAxis("Horizontal") > 0)
            Move();
        else if (transform.position.x >= 8.2f && Input.GetAxis("Horizontal") < 0)
            Move();
        else if (transform.position.x < 8.2f && transform.position.x > -8.2f)
            Move();

    }
}
