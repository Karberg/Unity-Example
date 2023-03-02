using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public LayerMask jumpableGround;
    public string inputNameHorizontal;
    public string jumpKey;
    public Transform attackPoint;


    public float runSpeed = 2f;
    public int jumpForce;

    private float attackPointHeight = 0.773f;
    private float attackPointHorizontal = 0.33f;
    float x;

    // Shortcuts
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum MovementState { idle, running, jumping, attack, hurt, recover }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        x = Input.GetAxisRaw(inputNameHorizontal)* runSpeed;
        float y = rb.velocity.y;
        rb.velocity = new Vector2(x, y);

        if (Input.GetKeyDown(jumpKey) && isGrounded())
        {
            rb.velocity = new Vector2(0, jumpForce);
        }

        UpdateAnimationState();
        
    
    
    }
    

    private void UpdateAnimationState()
    {
        MovementState state;
        if (x < 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            attackPoint.localPosition = new Vector2(-attackPointHorizontal, attackPointHeight);
            
        }
        else if (x > 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            attackPoint.localPosition = new Vector2(attackPointHorizontal, attackPointHeight);
        }
        else state = MovementState.idle;

        if (!isGrounded())
        {
            state = MovementState.jumping;
        }
        

        anim.SetInteger("AnimState", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
