using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public CharacterController2D controller;
    public LayerMask jumpableGround;

    public float runSpeed = 2f;
    
    float x;
    bool jump = false;

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

        x = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown("w"))
        {
            jump = true;
        }
        UpdateAnimationState();
        
    
    
    }
    void FixedUpdate()
    {
        controller.Move(x * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (x != 0f)
        {
            state = MovementState.running;
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
