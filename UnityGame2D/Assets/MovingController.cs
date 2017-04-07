using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour {


    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 500f;
    private bool isGrounded = true;
    private int maxJumps = 1;
    private int jumpCount = 0;
   

    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      
    }

    void Update()
    {

       

        //Обръщане на героя наляво и надясно.
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        //------------------------------------

        //Скок--------------------------------
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            jumpCount++;
            rb2d.AddForce(Vector2.up * jumpPower * 1 / (jumpCount));
            if (this.jumpCount >= maxJumps)
            {
                isGrounded = false;
                jumpCount = 0;
            }
          
        }
        //------------------------------------
    }


    void FixedUpdate()
    {
        //Fake friction / Easing the x speed of our player

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        rb2d.velocity = easeVelocity;


        //Движение на героя.

        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * h);


        //Ограничаване на скоростта на героя.
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        else if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Стъпване върху земя.
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DoubleJump"))
        {
            this.maxJumps = 2;
            Destroy(collision.gameObject);
        }
    }

}
