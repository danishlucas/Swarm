using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBody;
    public float moveForce = 3;
    public float dashForce = 2;
    // Use this for initialization
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        bool isBoosting = CrossPlatformInputManager.GetButton("Dash");

        myBody.velocity = (moveVec * (isBoosting ? dashForce : 1));
        //myBody.velocity = (moveVec * dashForce);



    }
    public void adjustMoveForce(float change)
    {
        Debug.Log("bing bong speed change!");
        moveForce += change;
    }


}


