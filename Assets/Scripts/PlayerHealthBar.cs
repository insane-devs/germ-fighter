using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealthManager playerHealthManager;
    private int currentHealth;

    Quaternion rotation;

    void Start()
    {
        currentHealth = playerHealthManager.currentHealth;
    }
    void Update()
    {
        currentHealth = playerHealthManager.currentHealth;
        healthBar.value = (float)currentHealth/100;
    }

    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
