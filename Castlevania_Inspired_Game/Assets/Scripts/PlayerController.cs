using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    
    [SerializeField]
    Transform  groundCheck;
    [SerializeField]
    private float runspeed = 2;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

      

    }

    // This the movement and input code for moving front and back and also for animations for Idle and Walking 
    void FixedUpdate()
    {
      // To Check if the Player on the Ground or not
      if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))){

            isGrounded = true;


      }  
      else
      {

            isGrounded = false;

        }
        
        if (Input.GetKey("d") || (Input.GetKey("right"))){

            rb2d.velocity = new Vector2(runspeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;


    
        }
        else if (Input.GetKey("a") || (Input.GetKey("left")))
        {

            rb2d.velocity = new Vector2(-runspeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;



        }
        else
        {

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }


        if (Input.GetKey("space") && isGrounded)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, 6d );



        }
      
   
        












    }   
}
