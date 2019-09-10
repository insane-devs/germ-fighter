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

    public LayerMask playerLayer;
    public Collider[] nearPlayer;
    public float checkRadius;

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
        nearPlayer = Physics.OverlapSphere(transform.position, checkRadius, playerLayer);
        Debug.Log(nearPlayer.Length);
        if (nearPlayer.Length >= 1)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                System.Random rand = new System.Random();
                player.HurtPlayer(rand.Next(minDamage, maxDamage + 1));
            }

        }
        
        /*
        Debug.Log(obj);
        if (collided && obj != null && obj.gameObject.tag == "Player")
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                Debug.Log("hi or sumn");
                attackCounter = timeBetweenAttacks;
                System.Random rand = new System.Random();
                player.HurtPlayer(rand.Next(minDamage, maxDamage + 1));
            }

        }*/
    }
}
