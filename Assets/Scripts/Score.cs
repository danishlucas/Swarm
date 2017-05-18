using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Score : MonoBehaviour {

    public float score;
    public Text countText;
	// Use this for initialization
	void Start () {
        score = 0;
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MenuScene")
        {
            PlayerPrefs.Save();
            Destroy(GameObject.Find("ScoreObject"));
        }
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
        if (scene.name == "DeathScene")
        {
            if (PlayerPrefs.GetFloat("Temp Score") > PlayerPrefs.GetFloat("High Score"))
            {
                PlayerPrefs.SetFloat("High Score", PlayerPrefs.GetFloat("Temp Score"));
            }  
            Text highScore = GameObject.FindWithTag("HighScore").GetComponent<Text>();
            highScore.text = PlayerPrefs.GetFloat("High Score").ToString();
        }
	}

    public void changeScore(float number)
    {
        score += number;
        PlayerPrefs.SetFloat("Temp Score", score);
        Debug.Log(PlayerPrefs.GetFloat("Temp Score"));
    }
}
