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
    public float speed;
    public float jump;
    float moveVelocity;

    //Grounded Vars
    bool grounded = true;

    void Update () 
    {
        //Jumping
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
        {
            if(grounded)
            {
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

    }
    //Check if Grounded
    void OnTriggerEnter2D()
    {
        grounded = true;
    }
    void OnTriggerExit2D()
    {
        grounded = false;
    }
}