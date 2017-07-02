using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    private GameObject scoreObject;
    private Score score;
    private GameObject mainCamera;
    // Use this for initialization
    void Start()
    {
        scoreObject = GameObject.Find("ScoreObject");
        score = scoreObject.GetComponent<Score>();
        mainCamera = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PLAYER" || other.name == "PCPLAYER")
        {
            mainCamera.transform.position = new Vector3(0, 0, 10);
            //need to copy original player stats over to the new player
            other.name = "PLAYER2";
            Attributes ogAtts = other.GetComponent<Attributes>();
            //Same for score
            GameObject.Find("ScoreObject").name = "OldScore";
            SceneManager.LoadScene(2);
        }
    }
}
