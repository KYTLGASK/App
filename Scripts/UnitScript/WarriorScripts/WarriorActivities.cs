using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorActivities : MonoBehaviour {
    public int attack = 40;//attack of the unit
    public int health = 100;//unit's health
    public int speed = 2;// unit's speed
    public int team = 1;// will be team 1 or team 2
    public int range = 1;
    // Use this for initialization
    void Start()
    {
        attack = 40;
        health = 100;//unit's health
        speed = 2;// unit's speed
        team = 1;// will be team 1 or team 2

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeAttackBy()//if there will be an option to change the attack(spells, hero powers etc)
    {

    }

    public void ChangeSpeedBy()//if there will be an option to change the speed(spells, hero powers etc)
    {

    }
    public void Move()//distance will be used
    {

    }

    public void OnMouseDown()
    {
        Attacked();//calls the "Attacked" function which checks if the unit is attacked through the "IsBeingAttacked" function, 
                   //the "Attacked" function if the unit really was attacked deletes the data from the invisible unit 
    }

    //boolean function returns if the unit is being attacked;
    public bool IsBeingAttacked()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attacking unit
        if ((invisible != (null)) && (attackingUnit != (null)))//if they both are not null
        {
            return (invisible.GetComponent<SelectedUnitMove>().isSelected &&
            attackingUnit.GetComponent<WarriorActivities>().team != team);// if there was a selected unit with different team number

        }
        else
        {
            return false;
        }
    }

    //if there was a unit selected and it's team number is not the same this unit gets hit
    public void Attacked()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attcking unit
        if ((invisible != null) && (attackingUnit != null))
        {
            //Debug.Log(IsBeingAttacked());
            if (IsBeingAttacked())//if there was a unit selected and is not on the same team 
            {
                transform.GetComponent<WarriorActivities>().GotHit(attackingUnit.GetComponent<WarriorActivities>().attack);//the unit gets hit by the other unit's attack
                attackingUnit.GetComponent<MoveScript>().isSelected = false;// the attacking unit is no more selected
                invisible.GetComponent<SelectedUnitMove>().isSelected = false;//the invisible unit no more stores unit's data
                invisible.GetComponent<SelectedUnitMove>().CurrUnitName = "";//the invisible unit no more stores unit's data
            }
            if (!IsBeingAttacked() && attackingUnit != null)//if the unit was clicked when there was a selected unit from the same team, this unit becomes selected
            {
                //attackingUnit.GetComponent<MoveScript>().isSelected = !attackingUnit.GetComponent<MoveScript>().isSelected;// the attacking unit is no more selected
                //invisible.GetComponent<SelectedUnitMove>().isSelected = false;//the invisible unit no more stores unit's data
                //invisible.GetComponent<SelectedUnitMove>().CurrUnitName = transform.name;//the invisible unit no more stores unit's data
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
}
