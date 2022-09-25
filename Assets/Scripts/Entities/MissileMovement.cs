using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField]
    private int missileSpeed;

    [SerializeField]
    private int missileHit;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 distance = PlayerController.Instance.MissileDesiredPos.position - PlayerController.Instance.MissilePoint.position;
        rb.velocity = distance * missileSpeed;

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            player.Damage(missileHit);
        }
    }
}
