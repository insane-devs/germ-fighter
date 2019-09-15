using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public int defense;

    private int damageTaken;

    private PlayerHealthManager player;

    public float timeBetweenAttacks;
    private float attackCounter;

    private bool collided;

    private Collider[] nearPlayer;

    public void OnTriggerEnter(Collider other)
    {
        collided = true;
        
    }

    public void OnTriggerExit(Collider other)
    {
        collided = false;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerHealthManager>();
        collided = false;
        defense = player.defense;
    }

    void Update()
    {
        collided = false;
        nearPlayer = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider collider in nearPlayer)
        {
            if (collider.gameObject.tag == "Player")
            {
                collided = true;
                break;
            } else
            {
                continue;
            }
        }
        
        if (collided)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                System.Random rand = new System.Random();
                damageTaken = rand.Next(minDamage, maxDamage + 1);
                if(defense != 0)
                {
                    damageTaken = damageTaken - (damageTaken*rand.Next(defense-1, defense+1)/100);
                }
                player.HurtPlayer(damageTaken);
            }

        }
    }
}
