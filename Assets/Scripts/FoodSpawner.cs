using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<Transform> foodList;

    private Transform foodInstance;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 0.0f, 10f);
    }

    void SpawnFood()
    {
        List<Transform> spawnList = new List<Transform>();
        System.Random rand = new System.Random();
        while (spawnList.Count < 5) spawnList.Add(foodList[rand.Next(0, foodList.Count)]);

        foreach (Transform food in spawnList)
        {
            float randomX = 5 * Random.Range(-transform.localScale.x, transform.localScale.x);
            float randomZ = 5 * Random.Range(-transform.localScale.z, transform.localScale.z);
            Vector3 randomPosition = new Vector3(randomX, 1, randomZ);
            Instantiate(food, randomPosition, transform.rotation);
        }
    }
}
