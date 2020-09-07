using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;
    private int scoreToAdd;

    public float flashTime;
    private float flashCounter;

    public GameObject originalModel;
    public GameObject hurtModel;

    public AudioSource deathSFX;

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

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                originalModel.SetActive(true);
                hurtModel.SetActive(false);
            }
        }
    }

    public void HurtEnemy(int damage)
    {
        deathSFX.Play();
        currentHealth -= damage;
        flashCounter = flashTime;
        hurtModel.SetActive(true);
        originalModel.SetActive(false);
    }
}
