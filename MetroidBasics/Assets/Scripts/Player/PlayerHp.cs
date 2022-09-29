using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp instance;

    [SerializeField] int currentHp, MaxHp;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
