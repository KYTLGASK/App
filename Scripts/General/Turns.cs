using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour {
    //this script will be placed on board or on an empty gameobject in the scene;

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

        PrintList(p1Units);
        PrintList(p2Units); //print the order.

        //determine who goes first.
        if (p1Units[0].GetComponent<BasicUnitProperties>().GetInitiative() >= p2Units[0].GetComponent<BasicUnitProperties>().GetInitiative())
        {
            Debug.Log("Player 1 starts with unit " + p1Units[0].name.Split(' ')[3]);
            while (p1Units.Count != 0 && p2Units.Count != 0)
            {
                P1DoTurn(p1Units);

                p1Units = KeepAliveOnly(p1Units);
                p2Units = KeepAliveOnly(p2Units); //keep only units that are alive

                if (p1Units.Count != 0 && p2Units.Count != 0)
                {
                    P2DoTurn(p2Units);

                    p1Units = KeepAliveOnly(p1Units);
                    p2Units = KeepAliveOnly(p2Units); //keep only units that are alive
                }
            }
        }
        else
        {
            Debug.Log("Player 2 starts with unit " + p2Units[0].name.Split(' ')[3]);
            while (p1Units.Count != 0 && p2Units.Count != 0)
            {
                P2DoTurn(p2Units);
                
                p1Units = KeepAliveOnly(p1Units);
                p2Units = KeepAliveOnly(p2Units); //keep only units that are alive

                if (p1Units.Count != 0 && p2Units.Count != 0)
                {
                    P1DoTurn(p1Units);
                    
                    p1Units = KeepAliveOnly(p1Units);
                    p2Units = KeepAliveOnly(p2Units); //keep only units that are alive
                }
            }
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

    private void P1DoTurn(List<GameObject> units)
    {
        //for debugging purposes, this function removes a gameobject, simulating a kill in the real game.
        print("P1DoTurn");

        foreach(GameObject unit in units)
        {
            bool didAction = false;

            while (!didAction)
            {
                print("Removing: " + units[0]);
                GameObject.DestroyImmediate(units[0]);
                didAction = true;
            }
        }
    }

    private void P2DoTurn(List<GameObject> units)
    {
        //for debugging purposes, this function removes a gameobject, simulating a kill in the real game.
        print("P2DoTurn");

        foreach (GameObject unit in units)
        {
            bool didAction = false;

            while (!didAction)
            {
                print("Removing: " + units[0]);
                GameObject.DestroyImmediate(units[0]);
                didAction = true;
            }
        }
    }

    private List<GameObject> KeepAliveOnly(List<GameObject> units)
    {
        //returns the list, but if a gameobject was removed (meaning the unit has died in this context) it removes it from the list
        List<GameObject> alive = new List<GameObject>();

        foreach (GameObject unit in units)
        {
            try
            {
                if (GameObject.Find(unit.name) != null)
                {
                    alive.Add(unit);
                }
                
            }
            catch
            {
                Debug.Log("Some unit was destroyed");
            }
        }
        return alive;
    }

    void PrintList(List<GameObject> units)
    {
        foreach (GameObject unit in units)
        {
            print(unit.name + ": " + unit.GetComponent<BasicUnitProperties>().GetInitiative());
        }
    }
}
