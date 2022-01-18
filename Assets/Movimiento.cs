using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

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
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(rb.velocity.x, 16f);
        }

        UpdateAnimationState(dirX);
    }

    private void UpdateAnimationState(float dirX)
    {
        if (dirX > 0f)
        {
            anim.SetBool("corre", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("corre", true);
            sprite.flipX = true;
        }
        else anim.SetBool("corre", false);
    }
}
