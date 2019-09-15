using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatsManager : MonoBehaviour
{
    public Text foodCounterText;
    public Text playerStatsText;
    public Text score;
    public PlayerHealthManager playerHealth;
    public PlayerScoreManager playerScore;
    public ItemsManager itemsManager;

    public int currentHealth;
    public int carboCounter;
    public int proteinCounter;
    public int vitaminsCounter;

    public int moveSpeed;
    public int damageToGive;
    public int defense;
    public int regenRate;

    private int idealNumber;
    public int idealDifference;

    public PlayerHealthManager playerHealthManager;
    public BulletController bulletController;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth.currentHealth;
        carboCounter = itemsManager.carboCounter;
        proteinCounter = itemsManager.proteinCounter;
        vitaminsCounter = itemsManager.vitaminsCounter;

        moveSpeed = playerController.moveSpeed;
        damageToGive = bulletController.damageToGive;
        defense = playerHealthManager.defense;
        regenRate = playerHealthManager.regenRate;
    }

    // Update is called once per frame
    void Update()
    {
        //SUM VALUES
        currentHealth = playerHealth.currentHealth;
        carboCounter = itemsManager.carboCounter;
        proteinCounter = itemsManager.proteinCounter;
        vitaminsCounter = itemsManager.vitaminsCounter;

        //UI PLAYERSTATS
        score.text = string.Format("{0}", playerScore.GetScore());
        playerStatsText.text = ("HP: " + currentHealth.ToString("0") + 
            "\nMove Speed: "+ moveSpeed.ToString("0") +
            "\nDamage: " + damageToGive.ToString("0") +
            "\nDefense: " + defense.ToString("0"));

        //UI FOODCOUNTER
        foodCounterText.text = ("\nCarbo: " + carboCounter.ToString("0") +
            "\nProtein: " + proteinCounter.ToString("0") +
            "\nVitamin: " + vitaminsCounter.ToString("0"));

        idealNumber = (int)((carboCounter + proteinCounter + vitaminsCounter) / 3);

        //carbo
        if (Math.Abs(idealNumber - carboCounter) > idealDifference)
        {
            if (carboCounter > idealNumber)
            {
                //decrease regen
                regenRate = 0;
            }
            else
            {
                //decrease speed
                moveSpeed = 5;
            }
        }
        else
        {
            //increase speed
            moveSpeed = 12;
        }

        //protein
        if (Math.Abs(idealNumber - proteinCounter) > idealDifference)
        {
            if (proteinCounter > idealNumber)
            {
                //decrease defense
                defense = 0;
            }
            else
            {
                //decrease regen
                regenRate = 0;
            }
        }
        else
        {
            //increase regen
            regenRate = 3;
        }

        //vitamins
        if (Math.Abs(idealNumber - carboCounter) > idealDifference)
        {
            if (carboCounter > idealNumber)
            {
                //decrease speed
                moveSpeed = 5;
            }
            else
            {
                //decrease defense
                defense = 0;
            }
        }
        else
        {
            //increase defense
            defense = 5;
        }

        if (carboCounter >= idealNumber-1 && carboCounter <= idealNumber+1 && proteinCounter >= idealNumber-1 && proteinCounter <= idealNumber+1 && vitaminsCounter >= idealNumber-1 && vitaminsCounter <= idealNumber+1)
        {
            //boost strength (damage)
            damageToGive = 10;
        } else
        {
            //normal strength (damage)
            damageToGive = 5;
        }

    }
}
