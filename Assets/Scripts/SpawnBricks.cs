using UnityEngine;
using System.Collections;

public class SpawnBricks : MonoBehaviour {

    public Transform prefab;
    private Renderer rend;
    public int numOfBricks;
	// Use this for initialization
	void Start () {
        rend = prefab.GetComponent<Renderer>();
        numOfBricks = 10;
        for (int i = -5; i < numOfBricks-5; i++)
            Instantiate(prefab, new Vector3(i+rend.bounds.size.x,1,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
