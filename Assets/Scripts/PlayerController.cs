using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed;
    private Rigidbody playerRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public VirtualJoystick joystick;
    private Vector3 moveVelocity2;

    public GunController theGun;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        moveVelocity2 = dir * moveSpeed;

        transform.LookAt(new Vector3(dir.x + transform.position.x, transform.position.y, dir.z + transform.position.z));

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

    }

    void FixedUpdate()
    {
        playerRigidbody.velocity = moveVelocity;
        playerRigidbody.velocity = moveVelocity2;
    }
}
