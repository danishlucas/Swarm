﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Score : MonoBehaviour {

    public float score;
    public int floor;
    public Text countText;
    bool done;
	// Use this for initialization
	void Start () {
        GameObject oldScoreObject = GameObject.Find("OldScore");
        if (oldScoreObject == null)
        {
            floor = 0;
            score = 0;
        }
        else
        {
            Score oldScore = oldScoreObject.GetComponent<Score>();
            floor = oldScore.floor + 1;
            score = oldScore.score;
            Destroy(oldScoreObject);
        }
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
        done = true;
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MenuScene")
        {
            //saves the high score if the game is quit
            PlayerPrefs.DeleteKey("Temp Score");
            PlayerPrefs.Save();
            Destroy(GameObject.Find("ScoreObject"));
        }
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
        if (scene.name == "DeathScene")
        {
            if (PlayerPrefs.GetFloat("Temp Score") > PlayerPrefs.GetFloat("High Score") && done)
            {
                PlayerPrefs.SetFloat("High Score", PlayerPrefs.GetFloat("Temp Score"));
                done = false;
            }
            GameObject.FindWithTag("HighScore").GetComponent<Text>().text = PlayerPrefs.GetFloat("High Score").ToString();
        }
        if (scene.name == "MenuScene")
        {
            done = true;
        }
	}

    public void changeScore(float number)
    {
        score += number;
        PlayerPrefs.SetFloat("Temp Score", score);
    }
}
