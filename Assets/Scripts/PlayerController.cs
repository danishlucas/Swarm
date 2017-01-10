using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBody;
    public float moveForce = 3;
    public float dashForce = 50;
    public int deltaTime1 = 0;
    public int deltaTime2;
    public bool isDashing;
    public bool buttonAvailable = true;
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
        if (deltaTime1 == 0)
        {
            buttonAvailable = true;
        }
        if (isBoosting == true && buttonAvailable == true)
        {
            deltaTime1 += 1;
        }
        if (deltaTime1 >= 1 && deltaTime1 <= 20)
        {
            deltaTime1++;
            isDashing = true;
            buttonAvailable = false;
        }
        else if (deltaTime1 > 20 && deltaTime1 < 50)
        {
            isDashing = false;
            buttonAvailable = false;
            deltaTime1++;
        }
        if (deltaTime1 == 50)
        {
            deltaTime1 = 0;

        }

        Debug.Log(deltaTime1);
        Debug.Log(isDashing);

        myBody.velocity = (moveVec * (isDashing ? dashForce : 1));
        //myBody.velocity = (moveVec * dashForce);


    }
    public void adjustMoveForce(float change)
    {
        Debug.Log("bing bong speed change!");
        moveForce += change;
    }

}
