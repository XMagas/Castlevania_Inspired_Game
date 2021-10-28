using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    private string currentState;

    bool isGrounded;

    private float xAxis;
    private float yAxis;
    private bool isJumpPressed;
    
    [SerializeField]
    private float JumpForce = 6;
   
    private bool isAttackPressed;
    private bool isAttacking;

    
    [SerializeField]
    Transform  groundCheck;
    [SerializeField]
    private float runspeed = 2;


    // Animation States 

    const string PLAYER_IDLE = "Player_idle";
    const string PLAYER_WALK = "Player_walk";
    const string PLAYER_JUMP = "Player_jump";
    const string PLAYER_ATTACK = "Player_attack";



    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        

    }


    void ChangeAnimationState(string newState)
    {
        // Stop Animation from interrupting itself
        if (currentState == newState) return;
        
        // play animation 
        animator.Play(newState);

        // reassign the current state 
        currentState = newState;
         

    }

     
    void Update()
    {

        

        if (Input.GetKey("space"))
        {
            isJumpPressed = true;

            
        }


        if (isGrounded) { 
        
            if(runspeed != 0)
            {
                ChangeAnimationState(PLAYER_WALK);



            }
            else 
            {
                ChangeAnimationState(PLAYER_IDLE);
            }


 
        }



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


        if (isJumpPressed && isGrounded)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x,JumpForce);

            ChangeAnimationState(PLAYER_JUMP);
            isJumpPressed = false;


        }
      
   
        












    }   
}
