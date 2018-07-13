using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    public List<GameObject> units;

    // Use this for initialization
    // this is called from the StartScripts ONCE
    public void StartTurns()
    {
        units = new List<GameObject>(GameObject.FindGameObjectsWithTag("unit"));//gets all the objects tagged as unit
        units.Sort((y, x) => x.transform.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));//sorts all the units by initiative
    }



    //this function ends the turn(deletes dead units, current units attacked,moved,finished turn is false now, change units' order, toggle player1Turn)
    //public void EndTurn(List<GameObject> currUnitsTeam)//the parameter is the unit list of the team that ended it's turn now 
    public void EndTurn()
    {
        KeepAliveOnly(units);
        units[0].GetComponent<BasicUnitProperties>().finishedTurn = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        units[0].GetComponent<BasicUnitProperties>().attacked = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        units[0].GetComponent<BasicUnitProperties>().moved = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        //SetUntargetedAll();//not sure if we need this(just makin sure)
        NextUnitTurn(units);
        DiselectAllUnits();//We may need this if shit goes crazy (i think this will fix the bug that goes off every 10-20 turns)
    }




    //here the game runs 
    public void Update()
    {
        KeepAliveOnly(units);//keeps only units that are alive
        if (!(returnNumOfTeamUnits(1) == 0 || returnNumOfTeamUnits(2) == 0))// if there are units in each team
        {
            if(units[0].GetComponent<BasicUnitProperties>().HasFinished())//if the unit finished it's turn
            {
                EndTurn();
            }
            else if (!(returnNumOfTeamUnits(1) == 0 || returnNumOfTeamUnits(2) == 0))//if the unit did not end his turn    
            {
                SetUntargetedAll();// sets all units untargeted
                units[0].GetComponent<UnitTurn>().UnitTurnPossibilities();//highlight move and attack options(unit turn possibilities)
            }
        }
        else
        {
            if (returnNumOfTeamUnits(1) == 0 || returnNumOfTeamUnits(2) != 0)//yes
            {
                Debug.Log("player 2 wins");
            }
            else if (returnNumOfTeamUnits(1) != 0 || returnNumOfTeamUnits(2) == 0)
            {
                Debug.Log("player 1 wins");
            }
            else
            {
                Debug.Log("draw");
            }

        }
    }





    //removes the dead units
    private void KeepAliveOnly(List<GameObject> unitsToCheck)
    {
        foreach (GameObject unit in unitsToCheck)
        {
            try
            {
                if (GameObject.Find(unit.name) != null)
                {
                    //alive.Add(unit);
                }

            }
            catch
            {
                unitsToCheck.Remove(unit);
            }
        }

    }



    //using this for debuging
    void PrintList(List<GameObject> units)
    {
        foreach (GameObject unit in units)
        {
            //print(unit.name + ": " + unit.GetComponent<BasicUnitProperties>().GetInitiative());
        }
    }
   
    
    // moves the unit that finished his turn to the end of the list and moves all the others one step closer
    public void NextUnitTurn(List<GameObject> units1)
    {
        if (units1.Count > 1) {
            GameObject[] copyUnits = units1.ToArray();
            for (int i = 0; i < copyUnits.Length; i++)
            {
                GameObject currUnit = units1[i];
                if (i == copyUnits.Length - 1)
                {
                    units1[copyUnits.Length - 1] = copyUnits[0];
                }
                else
                {
                    units1[i] = copyUnits[i + 1];
                }
            }
        }

    }
    
    
    //diselects all units and the invisible one too(not sure if we need this tho) *not using*
    void DiselectAllUnits()
    {
        foreach (GameObject unitTeam1 in units)
        {
            unitTeam1.transform.GetComponent<BasicUnitProperties>().isSelected = false;
        }
        GameObject selectedUnit = GameObject.Find("SelectedUnit");
        selectedUnit.GetComponent<SelectedUnitMove>().isSelected = false;

    }

    // untargets all units
    void SetUntargetedAll()
    {
        foreach (GameObject unit in units)
        {
            unit.transform.GetComponent<BasicUnitProperties>().SetUnTargeted();
        }
    }

    //the list "units" copies units from both lists(used to copy from p1units and p2units) its not easy working on 2 lists so i fused them into one
    void AddToUnitsList(List<GameObject> unitsFromTeam1, List<GameObject> unitsFromTeam2)
    {
        units = new List<GameObject>();
        foreach (GameObject unit1 in unitsFromTeam1)
        {
            units.Add(unit1);
        }
        foreach (GameObject unit2 in unitsFromTeam2)
        {
            units.Add(unit2);
        }
    }

    //return the num of units from team number: unitsTeam
    int returnNumOfTeamUnits(int unitsTeam)
    {
        int teamUnits = 0;
        foreach (GameObject unit in units)
        {
            if (unit.GetComponent<BasicUnitProperties>().team == unitsTeam)
            {
                teamUnits++;
            }
        }
        return teamUnits; 
    }
}