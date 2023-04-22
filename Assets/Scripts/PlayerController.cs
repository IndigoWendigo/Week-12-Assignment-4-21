using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 2;
    public CoinManager cm;
    Animator frogAnim;
    public SpriteRenderer frogSprite;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {
        frogAnim = GetComponentInChildren<Animator>();
        //frogSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // This code checks to see if the ground check object's radius is overlapping an object on the game's ground layer.
        // If it is, then the bool is set to true and the player will be allowed to jump.

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // This code gives the player their horizontal movement and their animations that correlate to it.

        float h = Input.GetAxis("Horizontal");

        frogAnim.SetFloat("speed",Mathf.Abs(h));

        frogSprite.flipX = h < 0;

        //transform.Translate(Vector3.right * h * Time.deltaTime * speed);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector3 vel = new Vector3();

        vel.x = h * speed;
        vel.y = rb.velocity.y;
        vel.z = 0;

        // This code checks to see if both the jump button is pressed, and if the player is touching the ground. If they are, the player can jump.
        // This was made in order to prevent the player from getting infinite jumps and trivializing the game.

        if(Input.GetButtonDown("Jump") && isTouchingGround == true)
        {
            //rb.AddForce(Vector2.up * jumpForce);
            SoundManager.instance.PlaySound(1);
            vel.y = jumpForce;
        }

        rb.velocity = vel;
    }

    // This code checks to see if the player touches a coin. If they are, the coin is collected and removed from the game.

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            SoundManager.instance.PlaySound(0);
            cm.coinCount++;
        }
    }
}
