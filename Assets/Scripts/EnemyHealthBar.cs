using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public EnemyHealthManager enemyHealthManager;
    private int currentHealth;
    private int initalHealth;

    Quaternion rotation;

    void Start()
    {
        currentHealth = enemyHealthManager.currentHealth;
        initalHealth = enemyHealthManager.health;
    }
    void Update()
    {
        currentHealth = enemyHealthManager.currentHealth;
        
        healthBar.value = (float)currentHealth / (float)initalHealth;
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
