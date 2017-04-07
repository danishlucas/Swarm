 using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBody;
    public float moveForce = 3;
    public float dashForce = 50;
    public int deltaTime1 = 0;
    public int deltaTime2;
    public bool isDashing;
    //public bool buttonAvailable = true;
    private Animator animation;
    //public GameObject joystick;
    //public GameObject button;
    //public float fillAmount;
    //private Image cooldown;



    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animator>();

        myBody = this.GetComponent<Rigidbody2D>();
        //cooldown = button.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        //float xPos = joystick.GetComponent<RectTransform>().anchoredPosition.x;
        //float yPos = joystick.GetComponent<RectTransform>().anchoredPosition.y;

        //float xRotation = (float)(Math.Atan2(xPos, yPos)*(180/3.1415)*-1);
        transform.localEulerAngles = new Vector3(0, 0, 0/*xRotation*/);


        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        bool keyboardDash = Input.GetButtonDown("KeyboardDashButton");
        //if (deltaTime1 == 0)
        //{
          //  buttonAvailable = true;
        //}
        if (keyboardDash)
        {
            deltaTime1 += 1;
            animation.SetTrigger("Dash");


        }
        if (deltaTime1 >= 1 && deltaTime1 <= 20)
        {
            deltaTime1++;
            isDashing = true;           
        }
        else if (deltaTime1 > 20 && deltaTime1 < 50)
        {
            isDashing = false;
            deltaTime1++;
        }
        if (deltaTime1 == 50)
        {
            deltaTime1 = 0;

        }
        myBody.velocity = (moveVec * (isDashing ? dashForce : 1));
        //myBody.velocity = (moveVec * dashForce);


    }
}
