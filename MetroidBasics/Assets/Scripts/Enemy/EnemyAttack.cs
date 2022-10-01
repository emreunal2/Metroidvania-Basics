using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damageAmount;
    [SerializeField] bool destroyOnDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage();
        }
    }

    void DealDamage()
    {
        PlayerHp.instance.TakeDamage(damageAmount);
        if (destroyOnDamage)
        {
            Destroy(gameObject);
        }
    }
}
