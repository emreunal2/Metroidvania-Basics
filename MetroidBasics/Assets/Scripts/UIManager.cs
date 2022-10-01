using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Slider slider;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateUI(int maxHp, int currentHP)
    {
        slider.maxValue = maxHp;
        slider.value = currentHP;
    }
}
