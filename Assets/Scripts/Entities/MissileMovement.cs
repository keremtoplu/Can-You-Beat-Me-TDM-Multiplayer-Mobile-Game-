using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField]
    private int missileSpeed;

    [SerializeField]
    private int missileHit;
    private Transform directionPathObj;


    private void Start()
    {
        directionPathObj = transform.GetChild(0);
    }
    void FixedUpdate()
    {
        var direction = directionPathObj.position - transform.position;
        transform.position += missileSpeed * direction * Time.fixedDeltaTime;
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
