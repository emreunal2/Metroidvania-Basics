using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] float bulletSpeed;
    private Rigidbody2D rb;

    [SerializeField] Vector2 moveDir;

    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }
    [SerializeField] GameObject impactEffect;
    [SerializeField] int damageAmount = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = moveDir * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
