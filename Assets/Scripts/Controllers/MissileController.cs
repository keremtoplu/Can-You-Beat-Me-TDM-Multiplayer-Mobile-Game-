using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MissileController : Singleton<MissileController>
{
    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private int missilePoolLenght;

    [SerializeField]
    private Vector3 missileDesiredPos;

    private Queue<GameObject> missilePool = new Queue<GameObject>();

    public void InıtMissile()
    {
        for (int i = 0; i < missilePoolLenght; i++)
        {
            var missile = PhotonNetwork.Instantiate(missilePrefab.name, Vector3.zero, Quaternion.identity);
            missilePool.Enqueue(missile);
        }
    }

    public void Fire()
    {
        var missile = missilePool.Dequeue();
        missile.transform.position = missileDesiredPos;
        missile.SetActive(true);
        missilePool.Enqueue(missile);
    }
}
