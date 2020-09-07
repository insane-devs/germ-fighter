using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.3f;

    public float height;
    public float zOffset;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        player = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.y = player.position.y + height;
        pos.z = player.position.z - zOffset;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
