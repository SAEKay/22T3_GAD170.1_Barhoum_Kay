using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KayBarhoum
{
    /// <summary>
    /// This class holds all the variables and functionality for moving our character around our game world.
    /// </summary>

    public class SimpleCharacterController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D rbody2D;
        private Rigidbody2D player;




        [SerializeField] private float horizontalInputValue; // The value of our horizontal input axis.
        [SerializeField] private SpriteRenderer spriteRenderer; // Our character's sprite.


        // TODO Movement 1/8: Declare a variable for a reference to our 2D rigidbody, for physics stuff.
        [Header("Character Stats")]
        [SerializeField] private float runSpeed = 3f;
        [SerializeField] private float jumpStrength = 5f;


        [Header("Player Input")]
        private float xInput = 0f;
        private bool isJumping = false;
        public float JumpSpeed = 8f;


        void start()
        {
            // TODO Movement 2/8: Declare a variable for the speed we can run at in Unity-units-per-second.


            // TODO Movement 3/8: Declare a variable for the strength of our jump.



            void Update()
            {
                xInput = Input.GetAxisRaw("Horizontal");
                isJumping = Input.GetButtonDown("Jump"); 

                {
                    transform.position += new Vector3(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * 3f;
                    transform.position += new Vector3(xInput * runSpeed, 0, 0) * Time.deltaTime;

                    if (isJumping)
                    {
                        rbody2D.velocity = Vector2.up * jumpStrength;
                    }

                    if (Input.GetButtonDown("Jump"))
                    {
                        player.velocity = new Vector2(player.velocity.x, JumpSpeed);

                    }
                }
            }
        }
    }
}
// TODO Movement 4/8: Store our horizontal player input value so we can access it later on.

// TODO Movement 5/8: Transform our character's position on the X axis. (Reference our stored horizontal input value here!)

// TODO Movement 6/8: Check if the player presses the "Jump" button (by default, the space bar on the keyboard).

// TODO Movement 7/8: If they do, then add vertical velocity to our rigidbody to make our character "jump"!

// TODO Movement 8/8: Add this script to a game object and make a new prefab from it, and explore the level!

// TODO Movement Final: Add code comments describing what you hope your code is doing throughout this script.

// TODO Movement Bonus 1: Ensure that our character can only jump if they are "grounded". (Hint: You can use a boolean as a part of this!)

// TODO Movement Bonus 2: Flip our character's sprite so that it faces left/right if we are moving left/right. (Hint: A SpriteRenderer reference, and changing its FlipX = true/false will help!)


public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody2D;

    [Header("CharacterMovement")]
    [Range(1, 50)]
    [SerializeField] private float walkSpeed; // Walk/run speed
    [Range(1, 50)]
    [SerializeField] public float jumpSpeed; // Jump speed

    [Header("CharacterSprite")]
    [SerializeField] private SpriteRenderer spriteRenderer; // choose your sprite
    public Animator animator; // animation reference

    [Header("CharacterVaribles")]
    private bool jump; // says yes or no when the player can jump

    private void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>(); // Physics for Character
    }

    void Update()
    {
        // Movement Controller

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * walkSpeed;
        if (Input.GetButtonDown("Horizontal"))
        {
            animator.GetFloat("Speed");
            Debug.Log("Moving");
        }
        // Jump Controller Start every frame
        fixedupdate();
    }

    // Jump Controller
    void fixedupdate()
    {
        if (Input.GetButtonDown("Jump") && !jump)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            jump = true; Debug.Log("Jumping");
            animator.SetBool("IsJumping", true);


        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    { // collides with the Ground tag it can jump. If not it will not jump.
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }

    }




}

