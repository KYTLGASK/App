using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is for the unit, when it is pressed the "invisible " unit stores its data
public class MoveScript : MonoBehaviour {

    public bool isSelected = false;//was the unit selected
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        isSelected = !isSelected;//if was selected now is not, if was not selected it is now.
        GameObject selected = GameObject.Find("SelectedUnit");//get the "inviseble" unit
        if (isSelected) {
            
            selected.GetComponent<SelectedUnitMove>().CurrUnitName = transform.name;//if this unit is selected store it's name in the "invisible" one
        }
        selected.GetComponent<SelectedUnitMove>().isSelected = isSelected;//changes the boolean value in the "invisible" unit
    }
}
