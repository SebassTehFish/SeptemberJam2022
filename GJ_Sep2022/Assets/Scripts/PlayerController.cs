using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float JumpForce;
    private bool isJumping;
    private float moveHorizontal = 1;
    private float moveVertical = 1; 
    GameController gameController;

    void FindReferences()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        FindReferences();

        moveSpeed = 1f;
        JumpForce = 20f;
        isJumping = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if(gameController.getFoodCount() == 5)
        {
            moveSpeed = 0.5f;
            JumpForce = 10f;
        }
    }
    void FixedUpdate()
    {
        if(moveHorizontal > 0.01f || moveHorizontal < -0.01f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if((!isJumping) && (moveVertical > 0.01f))
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * JumpForce), ForceMode2D.Impulse);
        }


    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = true;
        }
    }


/*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            //Debug.Log(isJumping);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            isJumping = true; 
    }
    */
}