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
    public int bestDifference;

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

        idealNumber = 100;

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
        else if (Math.Abs(idealNumber - carboCounter) < bestDifference)
        {
            //increase speed
            moveSpeed = 12;
        } else
        {
            //normal speed
            moveSpeed = 8;
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
        else if (Math.Abs(idealNumber - proteinCounter) < bestDifference)
        {
            //increase regen
            regenRate = 3;
        } else
        { 
            //normal regen
            regenRate = 1;
        }

        //vitamins
        if (Math.Abs(idealNumber - vitaminsCounter) > idealDifference)
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
        else if(Math.Abs(idealNumber-vitaminsCounter) < bestDifference)
        {
            //increase defense
            defense = 5;
        } else
        {
            //normal defense
            defense = 2;
        }

        //all 3
        if (Math.Abs(idealNumber - carboCounter) < bestDifference && Math.Abs(idealNumber - proteinCounter) < bestDifference && Math.Abs(idealNumber - vitaminsCounter) < bestDifference)
        {
            //boost strength (damage)
            damageToGive = 10;
        } else if(Math.Abs(idealNumber - carboCounter) < idealDifference && Math.Abs(idealNumber - proteinCounter) < idealDifference && Math.Abs(idealNumber - vitaminsCounter) < idealDifference)
        {
            //normal strength (damage)
            damageToGive = 5;
        } else
        {
            damageToGive = 2;
        }

    }
}
