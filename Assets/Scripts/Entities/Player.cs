using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Team team;
    private int health;

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
    void Start()
    {

    }

}
