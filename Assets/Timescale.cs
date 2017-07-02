using UnityEngine;
using System.Collections;

public class Timescale : MonoBehaviour {

    public float timescale;
	// Use this for initialization
	void Start () {
        Time.timeScale = timescale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
