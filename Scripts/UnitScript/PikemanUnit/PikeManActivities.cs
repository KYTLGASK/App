using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeManActivities : MonoBehaviour {
    int attack = 40;//attack of the unit
    int health = 100;//unit's health
    int speed = 2;// unit's speed
    int team = 2;// will be team 1 or team 2
    int initiative = 8;
    int range = 2;
    //bool moved = false;
    //bool attacked = false;
    string unitType = "PikeManActivities";
    string unitName = "";
    public Material pikeManTargetedTeam1;//This value is the material when this unit is targeted, you will enter it in UnitPikeMan prefab through the inspector by drag and drop
    public Material pikeManTargetedTeam2;

    public Material pikeManTeam1;
    public Material pikeManTeam2;
    // Use this for initialization this goes first
    public void StartPikeManActivities()
    {
        unitName = transform.name;
        transform.GetComponent<BasicUnitProperties>().SetAttack(attack);
        transform.GetComponent<BasicUnitProperties>().SetRange(range);
        transform.GetComponent<BasicUnitProperties>().SetHealth(health);
        transform.GetComponent<BasicUnitProperties>().SetTeam(team);
        transform.GetComponent<BasicUnitProperties>().SetSpeed(speed);
        transform.GetComponent<BasicUnitProperties>().SetInitiative(initiative);
        transform.GetComponent<BasicUnitProperties>().SetUnitType(unitType);
        transform.GetComponent<BasicUnitProperties>().SetUnitName(unitName);
        transform.GetComponent<BasicUnitProperties>().unitTargetedTeam1 = pikeManTargetedTeam1;
        transform.GetComponent<BasicUnitProperties>().unitTargetedTeam2 = pikeManTargetedTeam2;
        transform.GetComponent<BasicUnitProperties>().unitTeam1 = pikeManTeam1;
        transform.GetComponent<BasicUnitProperties>().unitTeam2 = pikeManTeam2;
        if (team == 1)
        {
            transform.GetComponent<MeshRenderer>().material = pikeManTeam1;
        }
        else
        {
            transform.GetComponent<MeshRenderer>().material = pikeManTeam2;
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
        if (transform.GetComponent<BasicUnitProperties>().HasAttacked() && transform.GetComponent<BasicUnitProperties>().HasMoved())
        {
            transform.GetComponent<BasicUnitProperties>().finishedTurn = true;
        }
    }

    
}