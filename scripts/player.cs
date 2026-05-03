using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*this script gives the player a 'flappy-bird' style movement, so i kept it for debugging purposes*/
public class Player : MonoBehaviour
{
    public float speed = 5f;
    [Header("Movement")]
    public Rigidbody2D rb;
    public float jumpForce = 5f;

    [Header("Jumping")]
    public float jumpPower = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move();
        jump();
    }

    public void move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

}
