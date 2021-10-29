using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    public Healthbar healthbar;

    public int maxHealth = 100;
    public int currentHealth;

    private string currentState;

    bool isGrounded;

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

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);


    }



    void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

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

        
        // to check if jump is pressed
        if (Input.GetKey("space"))
        {
            isJumpPressed = true;

            
        }

        // to make a more fluid transistion to the walking animation 
       if (runspeed == 0.1)
       {

            ChangeAnimationState(PLAYER_WALK);


       }
       else if (runspeed == -0.1)
       {

            ChangeAnimationState(PLAYER_WALK);

       }

       // to prevent the controller from auto jumping and to also check if the player has jumped
       if(isJumpPressed == true && isGrounded == false)
       {

            isJumpPressed = false;



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
        // Were the movement is updated based on what button is pressed and also updates the animation state
        if (Input.GetKey("d") || (Input.GetKey("right"))){

            rb2d.velocity = new Vector2(runspeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;

            if (isGrounded)
                ChangeAnimationState(PLAYER_WALK);

        }
        else if (Input.GetKey("a") || (Input.GetKey("left")))
        {

            rb2d.velocity = new Vector2(-runspeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
            
            if (isGrounded)
            ChangeAnimationState(PLAYER_WALK);



        }
        else
        {

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            if (isGrounded)
                ChangeAnimationState(PLAYER_IDLE);

        }

        // checks if the conditions are met to initiate the jump
        if (isJumpPressed == true && isGrounded)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce);

            ChangeAnimationState(PLAYER_JUMP);
            


        }
      
   
        












    }   
}
