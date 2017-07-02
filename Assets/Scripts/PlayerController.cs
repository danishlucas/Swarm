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
    public float deltaTime1 = 0;
    public float deltaTime2;
    public bool isDashing;
    public bool buttonAvailable = true;
    private Animator animation;
    public GameObject joystick;
    public GameObject button;
    public float fillAmount;
    public Image cooldown;



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

        float xPos = joystick.GetComponent<RectTransform>().anchoredPosition.x;
        float yPos = joystick.GetComponent<RectTransform>().anchoredPosition.y;

        float xRotation = (float)(Math.Atan2(xPos, yPos)*(180/3.1415)*-1);
       // Debug.Log(xRotation);
        //Vector3 rotation = new Vector3(0,0 , xRotation);
        transform.localEulerAngles = new Vector3(0, 0, xRotation);
        //transform.Rotate(rotation);


        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        bool isBoosting = CrossPlatformInputManager.GetButton("Dash");
        bool keyboardDash = Input.GetButtonDown("KeyboardDashButton");
        if (deltaTime1 == 0)
        {
            buttonAvailable = true;
        }
        if ((isBoosting || keyboardDash) && buttonAvailable)
        {
            deltaTime1 += 1;
            animation.SetTrigger("Dash");
            cooldown.fillAmount = 0;


        }
        if (deltaTime1 >= 1 && deltaTime1 <= 1.25)
        {
            deltaTime1 += Time.fixedDeltaTime;
            isDashing = true;
            buttonAvailable = false;
            cooldown.fillAmount = (deltaTime1 - 1) / 1.5f;
            
            
        }
        else if (deltaTime1 > 1.25 && deltaTime1 < 2)
        {
            isDashing = false;
            buttonAvailable = false;
            deltaTime1+= Time.fixedDeltaTime;
            cooldown.fillAmount = (deltaTime1 - 1) / 1.5f;
        }
        if (deltaTime1 >= 2)
        {
            deltaTime1 = 0;
            cooldown.fillAmount = 1;

        }
        myBody.velocity = (moveVec * (isDashing ? dashForce : 1));
        //myBody.velocity = (moveVec * dashForce);


    }
}
