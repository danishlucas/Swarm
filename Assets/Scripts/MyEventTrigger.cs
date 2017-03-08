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
            SceneManager.LoadScene("Dane'sTestScene");
        } else if (gameObject.name == "Continue?")
        {
            SceneManager.LoadScene("MenuScene");
        }
        
    }
}
