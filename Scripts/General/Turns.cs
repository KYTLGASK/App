using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour {
    //this script will be placed on board;
    //Units are a child of a tile.
    //they don't need to be a child of the empty object "player" as they are in the scene "Turn_System_Test", that is for orginizational purposes only.

	// Use this for initialization
	void Start () {
        //?? 0. take info from "tactics mode" ??
        List<GameObject> p1Units = new List<GameObject>(); //a list for all of player 1's units;
        List<GameObject> p2Units = new List<GameObject>(); //a list for all of player 2's units;

        GameObject[] units = GameObject.FindGameObjectsWithTag("unit");
        
        foreach (GameObject unit in units)
        {
            //insert units into matching list (acording to which team they are on)
            if (unit.GetComponent<BasicUnitProperties>().GetTeam() == 1)
                p1Units.Add(unit);
            else
                p2Units.Add(unit);
        }

        //sort the units according to initiative.
        p1Units.Sort((y, x) => x.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));
        p2Units.Sort((y, x) => x.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));
        
        //determine who goes first.
        if (p1Units[0].GetComponent<BasicUnitProperties>().GetInitiative() >= p2Units[0].GetComponent<BasicUnitProperties>().GetInitiative())
        {
            //Debug.Log("Player 1 starts with unit " + p1Units[0].name.Split(' ')[3]);

        }
        else
        {
            //Debug.Log("Player 2 starts with unit " + p2Units[0].name.Split(' ')[3]);

        }

        //3. auto select unit whose turn it is.

        //4. turn ends when unit's "Did_Action flag is set to True."

        //5. option to skip unit's turn 

        //6. Itreate over all the players' units until they all had their turn, then let second player play

        //7. repeat (3-6) until all of a players' units are dead.

        //8. end game.

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
