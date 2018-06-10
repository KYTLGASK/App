using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WarriorActivities : MonoBehaviour
{
    public int attack = 50;//attack of the unit
    public int health = 100;//unit's health
    public int speed = 3;// unit's speed
    public int team = 1;// will be team 1(blue) or team 2(red)
    public int initiative = 80;
    public int range = 1; 
    string unitType = "WarriorActivities";
    string unitName = "";
    
    public Material warriorTargetedTeam1;//This value is the material when this unit is targeted, you will enter it in UnitWarrior prefab through the inspector by drag and drop
    public Material warriorTargetedTeam2;

    public Material warriorTeam1;
    public Material warriorTeam2;

    // Use this for initialization
    
    public void StartWarriorActivities()
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
        transform.GetComponent<BasicUnitProperties>().unitTargetedTeam1 = warriorTargetedTeam1;
        transform.GetComponent<BasicUnitProperties>().unitTargetedTeam2 = warriorTargetedTeam2;
        transform.GetComponent<BasicUnitProperties>().unitTeam1 = warriorTeam1;
        transform.GetComponent<BasicUnitProperties>().unitTeam2 = warriorTeam2;
        if (team == 1)
        {
            transform.GetComponent<Renderer>().material = warriorTeam1;
        }
        else
        {
            transform.GetComponent<Renderer>().material = warriorTeam2;
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
        if (transform.GetComponent<BasicUnitProperties>().attacked && transform.GetComponent<BasicUnitProperties>().moved)
        {
            transform.GetComponent<BasicUnitProperties>().finishedTurn = true;
        }
    }

   
}