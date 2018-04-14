using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnitProperties : MonoBehaviour
{
    private int team, attack, health, initiative, speed, range;

    public bool isSelected = false;
    public bool attacked = false;
    public bool moved = false;
    public bool finishedTurn = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public bool HasAttacked()
    {
        return attacked;
    }
    public bool HasMoved()
    {
        return moved;
    }
    public bool HasFinished()
    {
        return attacked;
    }

    public void SetAttack(int attack)
    {
        this.attack = attack;
    }

    public void SetRange(int range)
    {
        this.range = range;
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

    public int GetRange()
    {
        return range;
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


    //boolean function returns if the unit is being attacked;
    /*GameObject GetSelectedUnit()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attacking unit
        return attackingUnit;
    }*/
    public bool IsBeingAttacked()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attacking unit
        if ((invisible != (null)) && (attackingUnit != (null)))//if they both are not null
        {
            return (invisible.GetComponent<SelectedUnitMove>().isSelected &&
            attackingUnit.GetComponent<BasicUnitProperties>().GetTeam() != team && attackingUnit.transform.parent.GetComponent<Distance>().InRange(attackingUnit.GetComponent<BasicUnitProperties>().GetRange(), transform.parent.gameObject));// if there was a selected unit with different team number and this one is in range of the attacking unit's range

        }
        else
        {
            return false;
        }
    }

    //if there was a unit selected and it's team number is not the same this unit gets hit
    //this function checks if the unit was attacked and then does the right action
    public void Attacked()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attcking unit
        if ((invisible != null) && (attackingUnit != null))
        {
            if (IsBeingAttacked())//if there was a unit selected and is not on the same team 
            {
                attackingUnit.GetComponent<BasicUnitProperties>().attacked = true;
                transform.GetComponent<BasicUnitProperties>().GotHit(attackingUnit.GetComponent<BasicUnitProperties>().GetAttack());//the unit gets hit by the other unit's attack
                attackingUnit.GetComponent<BasicUnitProperties>().isSelected = false;// the attacking unit is no more selected
                invisible.GetComponent<SelectedUnitMove>().isSelected = false;//the invisible unit no more stores unit's data
                invisible.GetComponent<SelectedUnitMove>().CurrUnitName = "";//the invisible unit no more stores unit's data
            }
        }
    }

    //function's parameter is the attacking unit's attack;
    public void GotHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(GameObject.Find(transform.name));//destroys this unit if health is 0 or less;
            GameObject.Find("Board").GetComponent<TouchDisHighlight>().DisAll();
        }
    }


    public bool IsSelected()
    {
        return isSelected;
    }

    public void Move()
    {
        Debug.Log("im in");
        if (!IsBeingAttacked())//if unit is not being attacked 
        {
            Debug.Log("im in and this unit is not being attacked");
            isSelected = !isSelected;//if was selected now is not, if was not selected it is now.
            GameObject selected = GameObject.Find("SelectedUnit");//get the "inviseble" unit
            if (GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName) != null && GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName) != transform.gameObject)//if there was a friendly unit selected and is not the same unit
            {
                GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName).GetComponent<BasicUnitProperties>().isSelected = false;
            }
            if (isSelected)
            {
                //changes the isSelected in the selected unit before
                selected.GetComponent<SelectedUnitMove>().CurrUnitName = transform.name;//if this unit is selected store it's name in the "invisible" one
                //moved = true;
            }

            selected.GetComponent<SelectedUnitMove>().isSelected = isSelected;//changes the boolean value in the "invisible" unit
           
        }
    }
}