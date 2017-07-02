using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MyEventTrigger : EventTrigger {

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Enter the Dungeon")
        {
            Debug.Log("Click");
            SceneManager.LoadScene(2);
        }
        else if (gameObject.name == "Continue?")
        {
            SceneManager.LoadScene("MenuScene");
        }
        else if (gameObject.name == "Reset") { 
            PlayerPrefs.SetFloat("High Score", 0);
        }
        
    }
}
