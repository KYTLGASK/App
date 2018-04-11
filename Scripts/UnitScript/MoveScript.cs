using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is for the unit, when it is pressed the "invisible " unit stores its data
public class MveScript : MonoBehaviour
{

    public bool isSelected = false;//was the unit selected

    // Update is called once per frame
    void Update()
    {

    }

    /*public void Move()
    {
        if (!transform.GetComponent<BasicUnitProperties>().IsBeingAttacked() && !transform.GetComponent<BasicUnitProperties>().HasMoved())
        {//if unit is not being attacked 
            isSelected = !isSelected;//if was selected now is not, if was not selected it is now.
            GameObject selected = GameObject.Find("SelectedUnit");//get the "inviseble" unit
            if (GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName) != null && GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName) != transform.gameObject)//if there was a friendly unit selected and is not the same unit
            {
                GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName).GetComponent<MoveScript>().isSelected = false;
            }
            if (isSelected)
            {
                //changes the is selected in the selected unit before
                selected.GetComponent<SelectedUnitMove>().CurrUnitName = transform.name;//if this unit is selected store it's name in the "invisible" one
            }

            selected.GetComponent<SelectedUnitMove>().isSelected = isSelected;//changes the boolean value in the "invisible" unit
            //selected.GetComponent<SelectedUnitMove>().name = "";//changes the name 
        }
    }*/
}