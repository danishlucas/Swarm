using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Score : MonoBehaviour {

    public int score;
    //private Scene menu;
    public Text countText;
	// Use this for initialization
	void Start () {
        score = 0;
        //menu = SceneManager.GetSceneByPath("Scenes/MenuScene.unity");
        //Debug.Log(menu.name);
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MenuScene")
        {
            Destroy(GameObject.Find("ScoreObject"));
        }
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
        
	}

    public void changeScore(int number)
    {
        score += number;
    }
}
