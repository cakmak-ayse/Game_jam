using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    
    public Rigidbody2D myRigidBody;
    public float jumoStrength = 5;      // to change flap play with this and gravity scale on rigid-body2d
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //jump ( make sure it can jump only once later on lol now its a flappy bird)
        if(Input.GetKeyDown(KeyCode.Space) == true){
            myRigidBody.velocity = Vector2.up * jumoStrength;
        }
        // go right
        if(Input.GetKeyDown(KeyCode.RightArrow) == true){
            myRigidBody.velocity = Vector2.right;
        }
        // go left
        if(Input.GetKeyDown(KeyCode.LeftArrow) == true){
            myRigidBody.velocity = Vector2.left;
        }
    }
}