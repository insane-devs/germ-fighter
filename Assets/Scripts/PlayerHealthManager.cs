using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public float flashTime;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    private Text scoreLabel;
    private GameObject postGameObject;

    // Start is called before the first frame update
    void Start()
    {
        postGameObject = GameObject.Find("Post-Game");
        postGameObject.SetActive(false);
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
            scoreLabel = GameObject.Find("Post-Game/Final Score").GetComponent<Text>();
            scoreLabel.text = string.Format("Score: {0}", gameObject.GetComponent<PlayerScoreManager>().GetScore());
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
