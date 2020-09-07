using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public int carboCounter;
    public int proteinCounter;
    public int vitaminsCounter;
    public int consumeTime;
    public float consumeCounter;

    private PickUpItems pickUpItems;

    // Start is called before the first frame update
    void Start()
    {
        pickUpItems = FindObjectOfType<PickUpItems>();
        carboCounter = 100;
        proteinCounter = 100;
        vitaminsCounter = 100;
    }

    // Update is called once per frame
    void Update()
    {
        consumeCounter -= Time.deltaTime;
        if (consumeCounter < 0)
        {
            consumeCounter = consumeTime;
            carboCounter -= 1;
            proteinCounter -= 1;
            vitaminsCounter -= 1;
        }
    }

    public void ItemCounter(int ItemType)
    {
        switch (ItemType)
        {
            case 0: carboCounter += 2;
                break;

            case 1: proteinCounter += 2;
                break;

            case 2: vitaminsCounter += 2;
                break;
        }
    }
}
