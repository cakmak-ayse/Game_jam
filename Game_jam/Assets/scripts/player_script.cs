// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class player_script : MonoBehaviour
// {
    
//     // public Rigidbody2D myRigidBody;
//     // public float jumoStrength = 5;      // to change flap play with this and gravity scale on rigid-body2d
//     // // Start is called before the first frame update
//     // void Start()
//     // {
        
//     // }

//     // // Update is called once per frame
//     // void Update()
//     // {
//     //     //jump ( make sure it can jump only once later on lol now its a flappy bird)
//     //     if(Input.GetKeyDown(KeyCode.Space) == true){
//     //         myRigidBody.velocity = Vector2.up * jumoStrength;
//     //     }
//     //     // go right
//     //     if(Input.GetKey(KeyCode.RightArrow) == true){
//     //         myRigidBody.velocity = Vector2.right;
//     //     }
//     //     // go left
//     //     if(Input.GetKey(KeyCode.LeftArrow) == true){
//     //         myRigidBody.velocity = Vector2.left;
//     //     }
//     // }

//     //Movement

//     private Animator animate;
//     //public float moveSpeed = 6f;
//     public float jump = 8f;
//     bool isLookingRight = true;
//     private Rigidbody2D rb;
//     private bool grounded = true;
//     public float speed;
//     float moveVelocity;

//     Vector2 movement;

//     private void Start()
//     {
//         animate = gameObject.GetComponent<Animator>();
//         rb = gameObject.GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         movement.x = Input.GetAxisRaw("Horizontal");
//         animate.SetFloat("Speed", Mathf.Abs(movement.x));
//     }

//     void FixedUpdate()
//     {
//         moveVelocity = 0;
//         //Flipping and left and right movement
//         if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
//         {
//             if(isLookingRight){
//                 gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
//                 isLookingRight = false;
//             }
//             moveVelocity = -speed;
//         } 
//         if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
//         {
//             if(!isLookingRight){
//                 gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
//                 isLookingRight = true;
//             }
//             moveVelocity = speed;
//         }

//         //Jumping
//         if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
//         {
//             if(grounded)
//             {
//                 GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
//             }
//         }

//         rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);
//     }

//     //Check if Grounded
//     void OnCollisionEnter2D()
//     {
//         grounded = true;
//     }
//     void OnCollisionExit2D()
//     {
//         grounded = false;
//     }

//     // Betul movement code
//     // public float speed;
//     // public float jump;
//     // float moveVelocity;

//     // //Grounded Vars
//     // bool grounded = true;

//     // void Update () 
//     // {
//     //     //Jumping
//     //     if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
//     //     {
//     //         if(grounded)
//     //         {
//     //             GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
//     //         }
//     //     }

//     //     moveVelocity = 0;

//     //     //Left Right Movement
//     //     if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
//     //     {
//     //         moveVelocity = -speed;
//     //     }
//     //     if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
//     //     {
//     //         moveVelocity = speed;
//     //     }

//     //     GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

//     // }
    
//     //Check if Grounded
//     // void OnCollisionEnter2D()
//     // {
//     //     grounded = true;
//     // }
//     // void OnCollisionExit2D()
//     // {
//     //     grounded = false;
//     // }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isLookingRight = true;

    public float moveSpeed = 6f; // Movement speed of the player
    public float jumpForce = 8f; // Jump force of the player

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Reset velocity if no movement key is pressed
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("IsWalking", false);
        }

        // Check for left and right movement keys
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (isLookingRight)
            {
                Flip();
            }
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (!isLookingRight)
            {
                Flip();
            }
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            animator.SetBool("IsWalking", true);
        }

        // Check for jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && animator.GetBool("IsGrounded"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsGrounded", false);
        }
    }

    // Flip the player's sprite
    private void Flip()
    {
        isLookingRight = !isLookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Check if the player is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsGrounded", false);
        }
    }
}

