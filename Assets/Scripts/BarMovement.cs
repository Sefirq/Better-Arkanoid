using UnityEngine;
using System.Collections;

public class BarMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime*10, transform.position.y);
    }
}
