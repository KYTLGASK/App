using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    GameObject[] units;
    public List<GameObject> p1Units;
    public List<GameObject> p2Units;
    public bool player1FinishedTurn = false;
    public bool player2FinishedTurn = false;
    public bool player1Turn;
    //this script will be placed on board or on an empty gameobject in the scene;

    //Units are a child of a tile.
    //they don't need to be a child of the empty object "player" as they are in the scene "Turn_System_Test", that is for orginizational purposes only.

    public void Update()
    {
        if(player1FinishedTurn)//if player one finished turn
        {
            player1Turn = false;// it is now player one's turn anymore
            player2FinishedTurn = false;// now it is player two's turn and it is not finished
            p1Units = KeepAliveOnly(p1Units);
            p2Units = KeepAliveOnly(p2Units); //keep only units that are alive
        }
        else if(player2FinishedTurn)//if player two finished turn
        {
            player1Turn = true;
            player1FinishedTurn = false;// it is now player one's turn and he is not finished
           
            p1Units = KeepAliveOnly(p1Units);
            p2Units = KeepAliveOnly(p2Units); //keep only units that are alive
        }


        if (player1Turn)// if it is player one's turn 
        {
            if (p1Units[0].GetComponent<BasicUnitProperties>().HasFinished()) // if the unit finished his turn
            {
                //Debug.Log("player1FinishedTurn = true");
                player1FinishedTurn = true;//player one finished turn
                p1Units[0].GetComponent<BasicUnitProperties>().finishedTurn = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
                p1Units[0].GetComponent<BasicUnitProperties>().attacked = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
                p1Units[0].GetComponent<BasicUnitProperties>().moved = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
                NextUnitTurn(p1Units);// changes the order of p1 units
                //DiselectAllUnits();//We may need this if shit goes crazy
            }
            else if (p1Units.Count != 0 && p2Units.Count != 0)//if the unit did not end his turn    
            {
                p1Units[0].GetComponent<UnitTurn>().UnitTurnPossibilities();//highlight move options and store his data in the invisible unit
            }
           
        }
        else if (!player1Turn)//same goes here does p2 turn
        {
            if (p2Units[0].GetComponent<BasicUnitProperties>().HasFinished())
            {
                //Debug.Log("player2FinishedTurn = true");
                player1FinishedTurn = false;
                player2FinishedTurn = true;
               
                p2Units[0].GetComponent<BasicUnitProperties>().finishedTurn = false;
                p2Units[0].GetComponent<BasicUnitProperties>().attacked = false;
                p2Units[0].GetComponent<BasicUnitProperties>().moved = false;
                NextUnitTurn(p2Units);
                //DiselectAllUnits();//We may need this if shit goes crazy
            }
            else if (p1Units.Count != 0 && p2Units.Count != 0)
            {
                p2Units[0].GetComponent<UnitTurn>().UnitTurnPossibilities();
            }
        }
    }
    // Use this for initialization
    // this is called from the StartScripts
    public void StartTurns()
    {
        //?? 0. take info from "tactics mode" ??
        p1Units = new List<GameObject>(); //a list for all of player 1's units;
        p2Units = new List<GameObject>(); //a list for all of player 2's units;

        units = GameObject.FindGameObjectsWithTag("unit");
        //Debug.Log(units.Length);

        foreach (GameObject unit in units)// for each unit in all the units
        {
            Debug.Log("unit's team: " + unit.transform.GetComponent<BasicUnitProperties>().GetTeam());
            //insert units into matching list (acording to which team they are on)
            if (unit.transform.GetComponent<BasicUnitProperties>().GetTeam() == 1)
            {
                p1Units.Add(unit);
                Debug.Log("p1Units count: " + p1Units.Count);
            }
            else
            {
                p2Units.Add(unit);
                Debug.Log("p2Units count: " + p1Units.Count);
            }
        }

        //sort the units according to initiative.
        p1Units.Sort((y, x) => x.transform.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));
        p2Units.Sort((y, x) => x.transform.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));
        //Debug.Log(p2Units);
        //PrintList(p1Units);
        //PrintList(p2Units); //print the order.

        //determine who goes first.
        if (p1Units[0].transform.GetComponent<BasicUnitProperties>().GetInitiative() >= p2Units[0].GetComponent<BasicUnitProperties>().GetInitiative())
        {
            player1Turn = true;
            player2FinishedTurn = true;
        }
        else
        {
            player1Turn = false;
            player1FinishedTurn = true;
        }
        
        //3. auto select unit whose turn it is.

        //4. turn ends when unit's "Did_Action flag is set to True."

        //5. option to skip unit's turn 

        //6. Itreate over all the players' units until they all had their turn, then let second player play

        //7. repeat (3-6) until all of a players' units are dead.

        //8. end game.

    }
    

    private List<GameObject> KeepAliveOnly(List<GameObject> unitsToCheck)
    {
        //returns the list, but if a gameobject was removed (meaning the unit has died in this context) it removes it from the list
        List<GameObject> alive = new List<GameObject>();

        foreach (GameObject unit in unitsToCheck)
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
            //print(unit.name + ": " + unit.GetComponent<BasicUnitProperties>().GetInitiative());
        }
    }
    // moves the unit that finished his turn to the end of the list and moves all the others one step closer
    public void NextUnitTurn(List<GameObject> units)
    {
        if (units.Count > 1) {
            GameObject[] copyUnits = units.ToArray();
            for (int i = 0; i < copyUnits.Length; i++)
            {
                GameObject currUnit = units[i];
                if (i == copyUnits.Length - 1)
                {
                    units[copyUnits.Length - 1] = copyUnits[0];
                }
                else
                {
                    units[i] = copyUnits[i + 1];
                }
            }
        }

    }
    //diselects all units and the invisible one too(not sure if we need this tho)
    void DiselectAllUnits()
    {
        foreach (GameObject unitTeam1 in p1Units)
        {
            unitTeam1.transform.GetComponent<BasicUnitProperties>().isSelected = false;
        }
        foreach (GameObject unitTeam2 in p2Units)
        {
            unitTeam2.transform.GetComponent<BasicUnitProperties>().isSelected = false;
        }

        GameObject selectedUnit = GameObject.Find("SelectedUnit");
        selectedUnit.GetComponent<SelectedUnitMove>().isSelected = false;

    }
}