using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    public List<GameObject> units;
    //public List<GameObject> p1Units;
    //public List<GameObject> p2Units;

    public Image pauseMenu;

    //public bool player1Turn;
    //this script will be placed on board or on an empty gameobject in the scene;

    //Units are a child of a tile.
    //they don't need to be a child of the empty object "player" as they are in the scene "Turn_System_Test", that is for orginizational purposes only.


    /*
                HOW THE SCRIPT WORKS:
                    1) StartTurns creats lists[p1units, p2units](sorts them by initiative and ofcourse team number) and the list units which will store all the units because working on two lists is hard
                    2) Update runs according to the falg "player1Turn" determines whos turn it is and if the unit did not finish it's turn runs UnitTurnPossibilities from the script "UnitTurn"(a script on each unit) which shows what the unit can do
                     //if the unit finished it's turn EndTurn is called
                    3) EndTurn called and it ends the turn(deletes dead units, current unit's attacked,moved,finishedTurn is false now, change units' order, toggle player1Turn)

    */
















    // Use this for initialization
    // this is called from the StartScripts ONCE
    public void StartTurns()
    {
        //pauseMenu.enabled = true;//there is update

        //p1Units = new List<GameObject>(); //a list for all of player 1's units;
        //p2Units = new List<GameObject>(); //a list for all of player 2's units;

        units = new List<GameObject>(GameObject.FindGameObjectsWithTag("unit"));

        //foreach (GameObject unit in units)// for each unit in all the units
        //{
        //    //insert units into matching list (acording to which team they are on)
        //    if (unit.transform.GetComponent<BasicUnitProperties>().GetTeam() == 1)
        //    {
        //        p1Units.Add(unit);
        //    }
        //    else
        //    {
        //        p2Units.Add(unit);
        //    }
        //}

        //sort the units according to initiative.
        units.Sort((y, x) => x.transform.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));
        //p1Units.Sort((y, x) => x.transform.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));
        //p2Units.Sort((y, x) => x.transform.GetComponent<BasicUnitProperties>().GetInitiative().CompareTo(y.GetComponent<BasicUnitProperties>().GetInitiative()));

        //determine who goes first.
        //if (p1Units[0].transform.GetComponent<BasicUnitProperties>().GetInitiative() >= p2Units[0].GetComponent<BasicUnitProperties>().GetInitiative())
        //{
        //    player1Turn = true;
        //}
        //else
        //{
        //    player1Turn = false;
        //
        //}
    }



    //this function ends the turn(deletes dead units, current units attacked,moved,finished turn is false now, change units' order, toggle player1Turn)
    //public void EndTurn(List<GameObject> currUnitsTeam)//the parameter is the unit list of the team that ended it's turn now 
    public void EndTurn()
    {
        //KeepAliveOnly(p1Units);//keep only units that are alive if any were dead
        //KeepAliveOnly(p2Units);

        KeepAliveOnly(units);
        units[0].GetComponent<BasicUnitProperties>().finishedTurn = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        units[0].GetComponent<BasicUnitProperties>().attacked = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        units[0].GetComponent<BasicUnitProperties>().moved = false;//p1 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 

        //p2Units[0].GetComponent<BasicUnitProperties>().finishedTurn = false;//p2 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        //p2Units[0].GetComponent<BasicUnitProperties>().attacked = false;//p2 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 
        //p2Units[0].GetComponent<BasicUnitProperties>().moved = false;//p2 current unit's(the one that just finished his turn) finished attacked and moved flags shall be negative 

        SetUntargetedAll();//not sure if we need this(just makin sure)
        //if (currUnitsTeam.Equals(p1Units))//if p1 ended his turn
        //{
        //    NextUnitTurn(p1Units);//moves the p1units order
        //    player1Turn = false;//player one finished turn
        //}
        //else if (currUnitsTeam.Equals(p2Units))//if p2 ended his turn
        //{
        //    NextUnitTurn(p2Units);//moves the p2units order
        //    player1Turn = true;// its player one's turn
        //}
        NextUnitTurn(units);
        DiselectAllUnits();//We may need this if shit goes crazy (i think this will fix the bug that goes off every 10-20 turns)
    }




    //here the game runs 
    public void Update()
    {
        //KeepAliveOnly(p1Units);
        //KeepAliveOnly(p2Units); //keep only units that are alive
        KeepAliveOnly(units);

        //AddToUnitsList(p1Units, p2Units);//fusing into one list
        if (!(returnNumOfTeamUnits(1) == 0 || returnNumOfTeamUnits(2) == 0))
        {
            if(units[0].GetComponent<BasicUnitProperties>().HasFinished())
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
            //pauseMenu.enabled = false;//stops the update
            if (returnNumOfTeamUnits(1) == 0 || returnNumOfTeamUnits(2) != 0)
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
        //if (!(p1Units.Count == 0 || p2Units.Count == 0))
        //{
        //    //pauseMenu.enabled = false;//stops the update
        //    if (player1Turn)// if it is player one's turn 
        //    {
        //
        //        if (p1Units[0].GetComponent<BasicUnitProperties>().HasFinished()) // if the unit finished his turn
        //        {
        //            EndTurn(p1Units);//calls the end turn function
        //        }
        //        else if (p1Units.Count != 0 && p2Units.Count != 0)//if the unit did not end his turn    
        //        {
        //            SetUntargetedAll();// sets all units untargeted
        //            p1Units[0].GetComponent<UnitTurn>().UnitTurnPossibilities();//highlight move and attack options(unit turn possibilities)
        //        }
        //
        //    }
        //    else if (!player1Turn)//if it is player two's turn 
        //    {
        //        if (p2Units[0].GetComponent<BasicUnitProperties>().HasFinished()) // if the unit finished his turn
        //        {
        //            EndTurn(p2Units); //calls the end turn function
        //        }
        //        else if (p1Units.Count != 0 && p2Units.Count != 0)//if the unit did not end his turn    
        //        {
        //            SetUntargetedAll();// sets all units untargeted
        //            p2Units[0].GetComponent<UnitTurn>().UnitTurnPossibilities();//highlight move and attack options(unit turn possibilities)
        //        }
        //    }
        //
        //}
        //else
        //{
        //    //pauseMenu.enabled = false;//stops the update
        //    if (p1Units.Count == 0 && p2Units.Count != 0)
        //    {
        //        Debug.Log("player 2 wins");
        //    }
        //    else if (p1Units.Count != 0 && p2Units.Count == 0)
        //    {
        //        Debug.Log("player 1 wins");
        //    }
        //    else
        //    {
        //        Debug.Log("draw");
        //    }
        //
        //}
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
        //foreach (GameObject unitTeam2 in p2Units)
        //{
        //    unitTeam2.transform.GetComponent<BasicUnitProperties>().isSelected = false;
        //}

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