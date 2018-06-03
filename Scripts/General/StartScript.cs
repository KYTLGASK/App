using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject board = GameObject.Find("Board");
        GameObject[] units = GameObject.FindGameObjectsWithTag("unit");
        GameObject generalScriptsObject = GameObject.Find("GeneralScriptsObject");


        board.transform.GetComponent<PopulateBoard>().StartPopulateBoard();
        foreach (GameObject unit in units)// for each unit start its basic activities and special ones
        {
            
            if (unit.transform.GetComponent<WarriorActivities>() != null)
            {
                unit.transform.GetComponent<WarriorActivities>().StartWarriorActivities();
            }
            else if (unit.transform.GetComponent<ArcherActivities>() != null)
            {
                unit.transform.GetComponent<ArcherActivities>().StartArcherActivities();
            }
            else if (unit.transform.GetComponent<PikeManActivities>() != null)
            {
                unit.transform.GetComponent<PikeManActivities>().StartPikeManActivities();
            }
            unit.transform.GetComponent<BasicUnitProperties>().StartBasicUnitProperties();
        }
        //board.transform.GetComponent<Turns>().StartTurns();
        generalScriptsObject.GetComponent<Turns>().StartTurns();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
