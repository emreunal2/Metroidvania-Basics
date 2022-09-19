using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] BulletController bullet;
    [SerializeField] Transform shotPoint;
    
    [SerializeField] float moveSpeed, jumpForce;

    [SerializeField] LayerMask ground;
    private bool isOnGround;
    [SerializeField] Transform groundPoint;
    private int jumpCount;

    [SerializeField] Animator anim;
    [SerializeField] Animator ballAnim;

    [SerializeField] float dashSpeed, dashTime;
    private float dashCounter;
    [SerializeField] float dashCooldown;
    private float dashCooldownCounter;

    [SerializeField] GameObject standing, ball;
    [SerializeField] float ballCooldown, ballCooldownCounter;

    [SerializeField] Transform bombPoint;
    [SerializeField] GameObject bomb;
    [SerializeField] PlayerAbilities abilities;

    void Start()
    {
        abilities = GetComponent<PlayerAbilities>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }
        else
        {
            PlayerDash();
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);
        }
        else
        {
            PlayerMove();
        }


        PlayerJump();

        PlayerFire();

        if (abilities.CanTurnBall)
        {
            PlayerTurnBall();
        }
        
        anim.SetBool("isOnGround", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (ball.activeSelf)
        {
            ballAnim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }

    }

    private void PlayerTurnBall()
    {
        if (ballCooldownCounter > 0)
        {
            ballCooldownCounter -= Time.deltaTime;
        }
        if (!ball.activeSelf)
        {
            if (Input.GetAxisRaw("Vertical") < -.9f)
            {
                if (ballCooldownCounter <= 0)
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                    ballCooldownCounter = ballCooldown;
                }
            }
        }
        else
        {
            if (!standing.activeSelf)
            {
                if (Input.GetAxisRaw("Vertical") > .9f)
                {
                    if (ballCooldownCounter <= 0)
                    {
                        ball.SetActive(false);
                        standing.SetActive(true);
                        ballCooldownCounter = ballCooldown;
                    }
                }
            }
        }
    }

    private void PlayerDash()
    {
        if (Input.GetButtonDown("Fire2") && abilities.CanDash)
        {
            dashCounter = dashTime;
            dashCooldownCounter = dashCooldown;
        }
    }

    private void PlayerMove()
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
    }

    private void PlayerFire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (standing.activeSelf)
            {
                anim.SetTrigger("isShooting");
                Instantiate(bullet, shotPoint.position, shotPoint.rotation).MoveDir = new Vector2(transform.localScale.x, 0f);
            }else if (ball.activeSelf && abilities.CanDropBomb)
            {
                Instantiate(bomb, bombPoint.position,bombPoint.rotation);
            }
        }
    }

    private void PlayerJump()
    {
        if (isOnGround)
        {
            jumpCount = 0;
        }
        if (Input.GetButtonDown("Jump") && jumpCount < 1 && abilities.CanDoubleJump)
        {
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (jumpCount == 1)
            {
                anim.SetTrigger("isDoubleJump");
            }
        }
    }
}
