using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGerms : MonoBehaviour
{
    public GameObject pabidangGerm;
    public GameObject pacuteNaGerm;

    private int numObjects;
    public int pabidangGermCount;
    public int pacuteNaGermCount;

    private GameObject germPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGerm(pabidangGerm, pabidangGermCount);
        SpawnGerm(pacuteNaGerm, pacuteNaGermCount);
    }

    void SpawnGerm(GameObject germPrefab, int numObjects)
    {
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 center = transform.position;
            Vector3 pos = ProduceCircle(center, 25.0f);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(germPrefab, pos, rotation);
        }
    }

    Vector3 ProduceCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
