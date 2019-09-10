using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            System.Random rand = new System.Random();
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(rand.Next(minDamage, maxDamage + 1));
        }
    }
}
