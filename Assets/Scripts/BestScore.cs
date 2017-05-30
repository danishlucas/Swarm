using UnityEngine;
using System.Collections;

public class BestScore : MonoBehaviour {

    public int highScore;

	// Use this for initialization
	void Start () {
        highScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    DontDestroyOnLoad(this);
	}
}
