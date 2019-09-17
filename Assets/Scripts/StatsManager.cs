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
            "\nMove Speed: " + moveSpeed.ToString("0") +
            "\nDamage: " + damageToGive.ToString("0") +
            "\nDefense: " + defense.ToString("0")) +
            "\nRegen: " + regenRate.ToString("0");

        //UI FOODCOUNTER
        foodCounterText.text = ("\nCarbo: " + carboCounter.ToString("0") +
            "\nProtein: " + proteinCounter.ToString("0") +
            "\nVitamin: " + vitaminsCounter.ToString("0"));

        idealNumber = 100;

        //Normal Stats
        int moveSpeedNormal = 8;
        int damageToGiveNormal = 5;
        int defenseNormal = 2;
        int regenRateNormal = 2;

        int carboDiff = idealNumber - carboCounter;
        int proteinDiff = idealNumber - proteinCounter;
        int vitaminsDiff = idealNumber - vitaminsCounter;

        int moveSpeedCtr = 0;
        int damageToGiveCtr = 0;
        int defenseCtr = 0;
        int regenRateCtr = 0;
        
        switch (carboDiff)
        {
            case int n when (n > 15):
                regenRateCtr -= 1;
                break;
            case int n when (n >= -5 && n <= 5):
                moveSpeedCtr += 4;
                break;
            case int n when (n < -15):
                moveSpeedCtr -= 2;
                break;
        }

        switch (proteinDiff)
        {
            case int n when (n > 15):
                defenseCtr -= 1;
                break;
            case int n when (n >= -5 && n <= 5):
                regenRateCtr += 2;
                break;
            case int n when (n < -15):
                regenRateCtr -= 1;
                break;
        }

        switch (vitaminsDiff)
        {
            case int n when (n > 15):
                moveSpeedCtr -= 2;
                break;
            case int n when (n >= -5 && n <= 5):
                defenseCtr += 3;
                break;
            case int n when (n < -15):
                defenseCtr -= 1;
                break;
        }

        //all 3
        if (Math.Abs(carboDiff) <= bestDifference && Math.Abs(proteinDiff) <= bestDifference && Math.Abs(vitaminsDiff) <= bestDifference)
        {
            //boost strength (damage)
            damageToGiveCtr += 5;
        } else if(Math.Abs(carboDiff) > idealDifference && Math.Abs(proteinDiff) > idealDifference && Math.Abs(vitaminsDiff) > idealDifference)
        {
            //normal strength (damage)
            damageToGive -= 3;
        }

        //Update Stats
        moveSpeed = moveSpeedNormal + moveSpeedCtr;
        damageToGive = damageToGiveNormal + damageToGiveCtr;
        defense = defenseNormal + defenseCtr;
        regenRate = regenRateNormal + regenRateCtr;

    }
}
