using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;
    private int scoreToAdd;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy Boss") scoreToAdd = 30;
            else scoreToAdd = 10;
            FindObjectOfType<PlayerScoreManager>().AddScore(scoreToAdd);
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
