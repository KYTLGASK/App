using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorActivities : MonoBehaviour
{
    int attack = 50;//attack of the unit
    int health = 100;//unit's health
    int speed = 3;// unit's speed
    int team = 1;// will be team 1 or team 2
    int initiative = 8;
    int range = 1; 
    bool attacked = false;
    bool moved = false;
    
    // Use this for initialization
    BasicUnitProperties GetBasicUnitProps()
    {
        return transform.GetComponent<BasicUnitProperties>();
    }
    void Start()
    {
        //BasicUnitProperties bp = GetBasicUnitProps();

        transform.GetComponent<BasicUnitProperties>().SetAttack(attack);
        transform.GetComponent<BasicUnitProperties>().SetRange(range);
        transform.GetComponent<BasicUnitProperties>().SetHealth(health);
        transform.GetComponent<BasicUnitProperties>().SetTeam(team);
        transform.GetComponent<BasicUnitProperties>().SetSpeed(speed);
        transform.GetComponent<BasicUnitProperties>().SetInitiative(initiative);
    }

    // Update is called once per frame
    void Update()
    {
        this.attack = transform.GetComponent<BasicUnitProperties>().GetAttack();
        this.health = transform.GetComponent<BasicUnitProperties>().GetHealth();
        this.team = transform.GetComponent<BasicUnitProperties>().GetTeam();
        this.speed = transform.GetComponent<BasicUnitProperties>().GetSpeed();
        this.initiative = transform.GetComponent<BasicUnitProperties>().GetInitiative();
        if (transform.GetComponent<BasicUnitProperties>().attacked && transform.GetComponent<BasicUnitProperties>().moved)
        {
            transform.GetComponent<BasicUnitProperties>().finishedTurn = true;
        }
    }
}