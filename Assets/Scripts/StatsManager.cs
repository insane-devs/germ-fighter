using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Text playerStatsText;

    public PlayerHealthManager playerHealth;
    public ItemsManager itemsManager;

    public int currentHealth;
    public int carboCounter;
    public int proteinCounter;
    public int vitaminsCounter;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth.currentHealth;
        carboCounter = itemsManager.carboCounter;
        proteinCounter = itemsManager.proteinCounter;
        vitaminsCounter = itemsManager.vitaminsCounter;
    }

    // Update is called once per frame
    void Update()
    {
        //SUM VALUES
        currentHealth = playerHealth.currentHealth;
        carboCounter = itemsManager.carboCounter;
        proteinCounter = itemsManager.proteinCounter;
        vitaminsCounter = itemsManager.vitaminsCounter;

        //UI STATS
        playerStatsText.text = ("HP: " + currentHealth.ToString("0") + 
            "\nCarbo: "+ carboCounter.ToString("0") +
            "\nProtein: " + proteinCounter.ToString("0") +
            "\nVitamin: " + vitaminsCounter.ToString("0"));
    }
}
