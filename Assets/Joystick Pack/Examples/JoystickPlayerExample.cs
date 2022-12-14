using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}