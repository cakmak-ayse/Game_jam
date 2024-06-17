using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    
    // public Rigidbody2D myRigidBody;
    // public float jumoStrength = 5;      // to change flap play with this and gravity scale on rigid-body2d
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     //jump ( make sure it can jump only once later on lol now its a flappy bird)
    //     if(Input.GetKeyDown(KeyCode.Space) == true){
    //         myRigidBody.velocity = Vector2.up * jumoStrength;
    //     }
    //     // go right
    //     if(Input.GetKey(KeyCode.RightArrow) == true){
    //         myRigidBody.velocity = Vector2.right;
    //     }
    //     // go left
    //     if(Input.GetKey(KeyCode.LeftArrow) == true){
    //         myRigidBody.velocity = Vector2.left;
    //     }
    // }

    //Movement

    // private Animator animate;
    // //public float moveSpeed = 6f;
    // public float jump = 8f;
    // bool isLookingRight = true;
    // private Rigidbody2D rb;
    // private bool grounded = true;
    // public float speed;
    // float moveVelocity;

    // Vector2 movement;

    // private void Start()
    // {
    //     animate = gameObject.GetComponent<Animator>();
    //     rb = gameObject.GetComponent<Rigidbody2D>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     movement.x = Input.GetAxisRaw("Horizontal");
    //     animate.SetFloat("Speed", Mathf.Abs(movement.x));
    // }

    // void FixedUpdate()
    // {
    //     moveVelocity = 0;
    //     //Flipping and left and right movement
    //     if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
    //     {
    //         if(isLookingRight){
    //             gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    //             isLookingRight = false;
    //         }
    //         moveVelocity = -speed;
    //     } 
    //     if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
    //     {
    //         if(!isLookingRight){
    //             gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    //             isLookingRight = true;
    //         }
    //         moveVelocity = speed;
    //     }

    //     //Jumping
    //     if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
    //     {
    //         if(grounded)
    //         {
    //             GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
    //         }
    //     }

    //     rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);
    // }

    // //Check if Grounded
    // void OnCollisionEnter2D()
    // {
    //     grounded = true;
    // }
    // void OnCollisionExit2D()
    // {
    //     grounded = false;
    // }

    public float speed;      // Movement speed of the player
    public float jump;       // Jump force applied when jumping
    float moveVelocity;      // Horizontal velocity of the player

    // Grounded flag
    bool grounded = true;

    // For sprite flipping
    private bool facingRight = true;  // Flag to track if the player is facing right

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                // Apply jump force if grounded
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        // Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Move left
            moveVelocity = -speed;
            if (facingRight)
            {
                // If facing right, flip to face left
                Flip();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Move right
            moveVelocity = speed;
            if (!facingRight)
            {
                // If not facing right, flip to face right
                Flip();
            }
        }

        // Apply horizontal velocity
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Check if Grounded
    void OnCollisionEnter2D()
    {
        grounded = true;  // Set grounded to true when collision occurs
    }

    void OnCollisionExit2D()
    {
        grounded = false;  // Set grounded to false when exiting collision
    }

    // Flip the player sprite horizontally
    void Flip()
    {
        facingRight = !facingRight;  // Toggle the facingRight flag
        Vector3 theScale = transform.localScale;  // Get the current scale of the player
        theScale.x *= -1;  // Flip the x scale by multiplying it by -1
        transform.localScale = theScale;  // Apply the new scale to flip the player sprite
    }
}
