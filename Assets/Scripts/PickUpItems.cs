using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public enum item
    {
        carbo, protein, vitamins
    };

    public item typeOfItem;

    private ItemsManager itemsManager;

    // Start is called before the first frame update
    void Start()
    {
        itemsManager = FindObjectOfType<ItemsManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            itemsManager.ItemCounter((int)typeOfItem);
            gameObject.SetActive(false);
        }
    }
}
