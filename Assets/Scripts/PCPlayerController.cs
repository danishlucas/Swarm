using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;

public class PCPlayerController : PlayerController {
    Rigidbody2D myBody;
    private Animator animation;
    /*public float moveForce = 3;
    public float dashForce = 50;
    public int deltaTime1 = 0;
    public int deltaTime2;
    public bool isDashing;
    public bool buttonAvailable = true;
    
    //public GameObject joystick;
    //public GameObject button;
    //public float fillAmount;
    //private Image cooldown;*/



    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animator>();

        myBody = this.GetComponent<Rigidbody2D>();
        cooldown = button.GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * moveForce * Time.fixedDeltaTime;
        transform.up = myBody.velocity;
        //float xPos = joystick.GetComponent<RectTransform>().anchoredPosition.x;
        //float yPos = joystick.GetComponent<RectTransform>().anchoredPosition.y;

        //float xRotation = (float)(Math.Atan2(xPos, yPos) * (180 / 3.1415) * -1);
        // Debug.Log(xRotation);
        //Vector3 rotation = new Vector3(0,0 , xRotation);
       // transform.localEulerAngles = new Vector3(0, 0, xRotation);
        //transform.Rotate(rotation);


       // Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        //bool isBoosting = CrossPlatformInputManager.GetButton("Dash");
        bool keyboardDash = Input.GetButtonDown("KeyboardDashButton");
        if (deltaTime1 == 0)
        {
            buttonAvailable = true;
        }
        if (keyboardDash && buttonAvailable)
        {
            deltaTime1 += 1;
            animation.SetTrigger("Dash");
            cooldown.fillAmount = 0;


        }
        if (deltaTime1 >= 1 && deltaTime1 <= 1.6)
        {
            deltaTime1 += Time.fixedDeltaTime;
            isDashing = true;
            buttonAvailable = false;
            cooldown.fillAmount = (deltaTime1 - 1) / 1.5f;

        }
        else if (deltaTime1 > 1.6 && deltaTime1 < 2.5)
        {
            isDashing = false;
            buttonAvailable = false;
            deltaTime1 += Time.fixedDeltaTime;
            cooldown.fillAmount = (deltaTime1 - 1) / 1.5f;
        }
        if (deltaTime1 >= 2.5)
        {
            deltaTime1 = 0;
            cooldown.fillAmount = 1;

        }
        myBody.velocity = (move * (isDashing ? dashForce : 1));
        //myBody.velocity = (moveVec * dashForce);


    }
}
