using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class Duck : MonoBehaviour
{
    [SerializeField] float runSpeed = 15f;//Специальные поля, которыми можно управлять внутри юнити
    public int health = 3;
    public int maxNumberOfHealth;
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;
    private Rigidbody2D myRigidBody2D;
    private Animator myAnimator;
    private void FixedUpdate()
    {
        if (health > maxNumberOfHealth)
        {
            health = maxNumberOfHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < maxNumberOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    private void Move()
    {
        float controlThrowY= CrossPlatformInputManager.GetAxis("Horizontal");
        float controlThrowX = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 duckVelocity = new Vector2(controlThrowY* runSpeed/2, controlThrowX * runSpeed/2);
        myRigidBody2D.velocity = duckVelocity;
     
   
    }
    private void ChangeMovingSprite()
    {
        float horizontalRight= CrossPlatformInputManager.GetAxis("Horizontal");
        if (horizontalRight > Mathf.Epsilon)
        {
            myAnimator.SetBool("rightMoveBool", true);
        }
        else
            myAnimator.SetBool("rightMoveBool", false);


        float horizontalLeft = CrossPlatformInputManager.GetAxis("Horizontal");
        if (horizontalLeft < -Mathf.Epsilon)
        {
            myAnimator.SetBool("leftMoveBool", true);
        }
        else
            myAnimator.SetBool("leftMoveBool", false);


        float verticalUp = CrossPlatformInputManager.GetAxis("Vertical");
        if (verticalUp > Mathf.Epsilon)
        {
            myAnimator.SetBool("upMoveBool", true);
        }
        else
            myAnimator.SetBool("upMoveBool", false);


        float verticalDown = CrossPlatformInputManager.GetAxis("Vertical"); ;
        if (verticalDown < -Mathf.Epsilon)
        {
            myAnimator.SetBool("downMoveBool", true);
        }
        else
            myAnimator.SetBool("downMoveBool", false);

        //bool horizontalRight = (myRigidBody2D.velocity.x) > Mathf.Epsilon;
        //if (horizontalRight)
        //{
        //    myAnimator.SetBool("rightMoveBool", true);
        //}
        //else
        //myAnimator.SetBool("rightMoveBool", false);


        //bool horizontalLeft = (myRigidBody2D.velocity.x) < - Mathf.Epsilon;
        //if (horizontalLeft)
        //{
        //    myAnimator.SetBool("leftMoveBool", true);
        //}
        //else
        //    myAnimator.SetBool("leftMoveBool", false);


        //bool verticalUp = (myRigidBody2D.velocity.y) > Mathf.Epsilon;
        //if (verticalUp)
        //{
        //    myAnimator.SetBool("upMoveBool", true);
        //}
        //else
        //    myAnimator.SetBool("upMoveBool", false);


        //bool verticalDown = (myRigidBody2D.velocity.y) < - Mathf.Epsilon;
        //if (verticalDown)
        //{
        //    myAnimator.SetBool("downMoveBool", true);
        //}
        //else
        //    myAnimator.SetBool("downMoveBool", false);

    }
    void Update()
    {
        Move();
        ChangeMovingSprite();
    }
}
