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
    public GameObject originalModel;
    public GameObject hurtModel;

    private Text scoreLabel;

    public float timeBetweenRegen;
    private float regenCounter;
    public int regenRate;

    public AudioSource deathSFX;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<Timer>().StopTimer();
            gameObject.SetActive(false);
            deathSFX.Play();
            postGameObject.SetActive(true);
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Music").GetComponent<Ambience>().StopMusic();

            int newHighScore = gameObject.GetComponent<PlayerScoreManager>().GetScore();
            int bestWave = FindObjectOfType<Timer>().GetWave();
            scoreLabel = GameObject.Find("Post-Game/Final Score").GetComponent<Text>();
            scoreLabel.text = string.Format("Score: {0}", newHighScore);

            int oldHighScore = PlayerPrefs.GetInt("highscore", 0);
            if (newHighScore > oldHighScore) PlayerPrefs.SetInt("highscore", newHighScore);
            int oldWave = PlayerPrefs.GetInt("bestwave", 0);
            if (bestWave > oldWave) PlayerPrefs.SetInt("bestwave", bestWave);
            PlayerPrefs.Save();
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
                originalModel.SetActive(true);
                hurtModel.SetActive(false);
            }
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        flashCounter = flashTime;
        hurtModel.SetActive(true);
        originalModel.SetActive(false);
    }
}
