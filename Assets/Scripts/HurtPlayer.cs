using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;

    private PlayerHealthManager player;

    public float timeBetweenAttacks;
    private float attackCounter;

    private bool collided;
    private Collider obj;

    public void OnTriggerEnter(Collider other)
    {
        collided = true;
        obj = other;
        
    }

    public void OnTriggerExit(Collider other)
    {
        collided = false;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerHealthManager>();
        collided = false;
    }

    void Update()
    {
        if (collided && obj != null && obj.gameObject.tag == "Player")
        {
            Debug.Log("yayayay YEET");
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                Debug.Log("hi or sumn");
                attackCounter = timeBetweenAttacks;
                System.Random rand = new System.Random();
                player.HurtPlayer(rand.Next(minDamage, maxDamage + 1));
            }

        }
    }
}
