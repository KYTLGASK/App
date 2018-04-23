using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherActivities : MonoBehaviour
{
    int attack = 20;//attack of the unit
    int health = 100;//unit's health
    int speed = 1;// unit's speed
    int team = 2;// will be team 1 or team 2
    int initiative = 10;
    int range = 5;
    //bool attacked = false;
    //bool moved = false;
    string unitType = "ArcherActivities";
    string unitName = "";

    // Use this for initialization
    public void StartArcherActivities()
    {
        unitName = transform.name;
        transform.GetComponent<BasicUnitProperties>().SetAttack(attack);
        transform.GetComponent<BasicUnitProperties>().SetRange(range);
        transform.GetComponent<BasicUnitProperties>().SetHealth(health);
        transform.GetComponent<BasicUnitProperties>().SetTeam(team);
        transform.GetComponent<BasicUnitProperties>().SetSpeed(speed);
        transform.GetComponent<BasicUnitProperties>().SetInitiative(initiative);
        transform.GetComponent<BasicUnitProperties>().SetUnitType(unitType);
    }

    // Update is called once per frame
    void Update()
    {
        this.attack = transform.GetComponent<BasicUnitProperties>().GetAttack();
        this.health = transform.GetComponent<BasicUnitProperties>().GetHealth();
        this.team = transform.GetComponent<BasicUnitProperties>().GetTeam();
        this.speed = transform.GetComponent<BasicUnitProperties>().GetSpeed();
        this.initiative = transform.GetComponent<BasicUnitProperties>().GetInitiative();
        if (transform.GetComponent<BasicUnitProperties>().HasAttacked() || transform.GetComponent<BasicUnitProperties>().HasMoved())
        {
            transform.GetComponent<BasicUnitProperties>().finishedTurn = true;
        }
    }
}