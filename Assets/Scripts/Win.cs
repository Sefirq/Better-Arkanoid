using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
    public int howManyBricks;
    public SpawnBricks spawnBricks;
    private bool firstTime = true;
	void Start () {
        spawnBricks = GetComponent<SpawnBricks>();
        
	}
	
	public void denominate()
    {
        howManyBricks--;
    }

	void Update () {
	if(firstTime)
        {
            howManyBricks = spawnBricks.numOfBricks;
            Debug.Log(howManyBricks);
            firstTime = !firstTime;
        }
    if(howManyBricks==0)
        {
            Application.LoadLevel("Winner");
        }
	}
}
