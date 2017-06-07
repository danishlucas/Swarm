using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyStats : MonoBehaviour {

    public List<float> StraferFiring = new List<float>();
    public List<float> StraferMovement = new List<float>();
    public List<float> TankFiring = new List<float>();
    public List<float> TankMovement = new List<float>();
    public List<float> OmniFiring = new List<float>();
    public float straferDrop;
    public float tankDrop;
    public float omniDrop;


    void Start () {
        Invoke("Updateroni", 2.5f);
	
	}
	
	// Update is called once per frame
	void Updateroni () {
        int floor = GameObject.Find("ScoreObject").GetComponent<Score>().floor;
        Debug.Log("Fix");
        //ShotDelay, RepeatRate, ShotSpeed
        StraferFiring[1] -= 0.05f * floor;
        StraferFiring[2] += 0.25f * floor;
        TankFiring[1] -= 0.5f * floor;
        straferDrop -= .02f * floor;
        tankDrop -= 0.02f * floor;
        omniDrop -= 0.02f * floor;
    }
}
