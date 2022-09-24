using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKillable
{
    private Team team;
    private int health = 100;

    public Team Team
    {
        get { return team; }
        set { team = value; }
    }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void Damage(int Hit)
    {
        health -= Hit;
        if (health <= 0)
        {
            PlayerController.Instance.Reborn(this);
        }
    }

}
