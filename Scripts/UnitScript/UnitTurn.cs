using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTurn : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // this highlights the units options(tergets and movement options)
    public void UnitTurnPossibilities()
    {

        List<GameObject> enemyUnits = transform.GetComponent<BasicUnitProperties>().EnemyUnitsInRange();//list of the enemy units which are in range
        //Turns.allowTouch = true;

        if (!transform.GetComponent<BasicUnitProperties>().IsSelected()){ //if the unit is selected store it's data in the invisible one
            transform.GetComponent<BasicUnitProperties>().Move();    
        }

        if (!transform.GetComponent<BasicUnitProperties>().HasMoved()) {// if the unit did not move highlight move options
            transform.GetComponent<HighLightMoveOptions>().HighlightMoveOptions();
        }


        if (!transform.GetComponent<BasicUnitProperties>().HasAttacked())// if the unit did not attack set units in range targeted
        {

            foreach (GameObject enemyUnit in enemyUnits)
            {
                if (enemyUnit != null)
                {
                   enemyUnit.GetComponent<BasicUnitProperties>().SetTargeted();
                }
            }
        }
       

    }
}
