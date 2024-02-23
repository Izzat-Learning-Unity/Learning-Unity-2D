using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*    public float moveForce = 10f;//default value
        public float jumpForce = 11f;*/

    [SerializeField]//allows the private variables to be accessed from within the insepctor
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "walk"; 

    private bool isGrounded = true;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate() { 
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
       
    }

    void AnimatePlayer()
    {

        if (movementX > 0f)//moving to the right side
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0f) // if going to the left
        { 
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else //if no movement
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButton("Jump")&&isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2 (0f, jumpForce),ForceMode2D.Impulse);
       
           

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            // transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
           // myBody.angularVelocity =  0;

        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
