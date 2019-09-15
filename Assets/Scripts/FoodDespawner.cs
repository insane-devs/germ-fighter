using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDespawner : MonoBehaviour
{

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 30;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}