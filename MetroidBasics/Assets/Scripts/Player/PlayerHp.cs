using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp instance;

    [SerializeField] int currentHp, MaxHp;

    public int CurrentHp { get => currentHp; set => currentHp = value; }
    public int MaxHp1 { get => MaxHp; set => MaxHp = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHp = MaxHp;
        UIManager.instance.UpdateUI(MaxHp, CurrentHp);
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
        UIManager.instance.UpdateUI(MaxHp, CurrentHp);
    }
}
