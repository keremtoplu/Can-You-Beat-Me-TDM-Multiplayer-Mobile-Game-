using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * PlayerController.Instance.FixedJoystick.Vertical + Vector3.right * PlayerController.Instance.FixedJoystick.Horizontal;
        rb.velocity = direction * speed;
        transform.LookAt(transform.position + new Vector3(PlayerController.Instance.FixedJoystick.Direction.x, 0, PlayerController.Instance.FixedJoystick.Direction.y));
    }
}
