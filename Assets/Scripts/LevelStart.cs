using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {

    public bool levelStart;
	// Use this for initialization
	void Start () {
        levelStart = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
            levelStart = true;	
	}
}
