using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public int defense;

    public float flashTime;
    private float flashCounter;

    public GameObject postGameObject;

    private Renderer rend;
    private Color storedColor;

    private Text scoreLabel;

    public float timeBetweenRegen;
    private float regenCounter;
    public int regenRate;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<Timer>().StopTimer();
            gameObject.SetActive(false);
            postGameObject.SetActive(true);
            Time.timeScale = 0;
            scoreLabel = GameObject.Find("Post-Game/Final Score").GetComponent<Text>();
            scoreLabel.text = string.Format("Score: {0}", gameObject.GetComponent<PlayerScoreManager>().GetScore());
        } else if (currentHealth < 100)
        {
            regenCounter -= Time.deltaTime;
            if (regenCounter <= 0)
            {
                regenCounter = timeBetweenRegen;
                currentHealth += regenRate;
            }
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        flashCounter = flashTime;
        rend.material.SetColor("_Color", Color.red);
    }
}
