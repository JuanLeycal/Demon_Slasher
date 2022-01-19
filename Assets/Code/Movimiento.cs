using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField]private float speed = 7f;
    [SerializeField] private float jump = 16f;

    private enum MovementState { idle, running, jumping, falling}
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            if(rb.position.y > .1f)
            {

            }
            else
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        UpdateAnimationState(dirX);
    }

    private void UpdateAnimationState(float dirX)
    {

        MovementState State;

        if (dirX > 0f)
        {
            State = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            State = MovementState.running;
            sprite.flipX = true;
        }
        else State = MovementState.idle;

        if(rb.velocity.y > .1f){
            
            State = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }

        anim.SetInteger("State", (int)State);


    }
}
