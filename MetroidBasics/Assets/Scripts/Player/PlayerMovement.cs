using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] LayerMask ground;
    private bool isOnGround;
    [SerializeField] Transform groundPoint;
    private int jumpCount;
    [SerializeField] Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, ground);

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        if(isOnGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        anim.SetBool("isOnGround", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
