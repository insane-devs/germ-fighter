using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;

    public PlayerHealthManager player;

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
        collided = false;
    }

    void Update()
    {
        if (collided && obj != null && obj.gameObject.tag == "Player")
        {
            //Debug.Log("check");
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                //Debug.Log("attack!");
                attackCounter = timeBetweenAttacks;
                System.Random rand = new System.Random();
                player.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(rand.Next(minDamage, maxDamage + 1));
            }

        }
    }
}
