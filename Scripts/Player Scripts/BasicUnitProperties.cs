using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnitProperties : MonoBehaviour
{
    public int team, attack, health, initiative, speed;

    bool didAction;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetAttack(int attack)
    {
        this.attack = attack;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetTeam(int team)
    {
        this.team = team;
    }

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }

    public void SetInitiative(int initiative)
    {
        this.initiative = initiative;
    }



    public int GetAttack()
    {
        return attack;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetTeam()
    {
        return team;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetInitiative()
    {
        return initiative;
    }
}