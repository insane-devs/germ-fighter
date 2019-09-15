using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public int carboCounter;
    public int proteinCounter;
    public int vitaminsCounter;

    private PickUpItems pickUpItems;

    // Start is called before the first frame update
    void Start()
    {
        pickUpItems = FindObjectOfType<PickUpItems>();
        carboCounter = 1;
        proteinCounter = 1;
        vitaminsCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemCounter(int ItemType)
    {
        switch (ItemType)
        {
            case 0: carboCounter += 1;
                break;

            case 1: proteinCounter += 1;
                break;

            case 2: vitaminsCounter += 1;
                break;
        }
    }
}
