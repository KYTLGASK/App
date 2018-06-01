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
    public Material archerTargetedTeam1; //This value is the material when this unit is targeted, you will enter it in UnitArcher prefab through the inspector by drag and drop
    public Material archerTargetedTeam2;
    // Use this for initialization
    public Material archerTeam1;
    public Material archerTeam2;

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
        transform.GetComponent<BasicUnitProperties>().unitTargetedTeam1 = archerTargetedTeam1;
        transform.GetComponent<BasicUnitProperties>().unitTargetedTeam2 = archerTargetedTeam2;
        transform.GetComponent<BasicUnitProperties>().unitTeam1 = archerTeam1;
        transform.GetComponent<BasicUnitProperties>().unitTeam2 = archerTeam2;
        if (team == 1)
        {
            transform.GetComponent<Renderer>().material = archerTeam1;
        }
        else
        {
            transform.GetComponent<Renderer>().material = archerTeam2;
        }
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

       // if (transform.GetComponent<BasicUnitProperties>().isTargeted)
        //{
        //    Debug.Log("targeted");
       //     SetTargeted();
      //  }
    }

   
}