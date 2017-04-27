using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public int score;

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
        countText = GameObject.FindWithTag("CountText").GetComponent<Text>();
        countText.text = score.ToString();
	}

    public void changeScore(int number)
    {
        score += number;
    }
}
