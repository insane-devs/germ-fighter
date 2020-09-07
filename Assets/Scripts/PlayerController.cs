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

    public VirtualJoystick moveJoystick;
    public VirtualJoystick shootJoystick;
    private Vector3 moveVelocity2;

    public GunController theGun;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        moveJoystick = GameObject.Find("BGIMGJoystick").GetComponent<VirtualJoystick>();
        shootJoystick = GameObject.Find("BGIMGShootButton").GetComponent<VirtualJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = moveJoystick.Horizontal();
        moveDir.z = moveJoystick.Vertical();

        moveVelocity2 = moveDir * moveSpeed;


        Vector3 lookDir = Vector3.zero;
        lookDir.x = shootJoystick.Horizontal();
        lookDir.z = shootJoystick.Vertical();


        if (lookDir == new Vector3(0, 0, 0))
        {
            transform.LookAt(new Vector3(moveDir.x + transform.position.x, transform.position.y, moveDir.z + transform.position.z));
        }
        else
        {
            transform.LookAt(new Vector3(lookDir.x + transform.position.x, transform.position.y, lookDir.z + transform.position.z));
        }


        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

    }

    void FixedUpdate()
    {
        playerRigidbody.velocity = moveVelocity;
        playerRigidbody.velocity = moveVelocity2;
    }
}
