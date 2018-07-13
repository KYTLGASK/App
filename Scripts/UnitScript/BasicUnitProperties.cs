using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnitProperties : MonoBehaviour
{
    public int team , attack, health, initiative, speed, range;//{ get; set; }
    public int numOfColumnsForPlayersUnits;
    public bool isSelected = false;
    public bool attacked = false;
    public bool moved = false;
    public bool finishedTurn = false;
    public string unitType;
    public string unitName;
    public bool isTargeted = true;
    public Material unitTargetedTeam1;
    public Material unitTargetedTeam2;

    public Material unitTeam1;
    public Material unitTeam2;

    public Material unitTurnTeam1;//this material is used when it is this unit's turn
    public Material unitTurnTeam2;
    //public string name;
    // Use this for initialization
    public void StartBasicUnitProperties()
    {
        RandomStartPos();
    }

    void RandomStartPos()//to start at a random positon
    {
       
        GameObject board = GameObject.Find("Board");
        while (transform.parent == null)
        {
            numOfColumnsForPlayersUnits = board.transform.GetComponent<PopulateBoard>().numOfColumnsForPlayersUnits;
            //THE X AND THE Y ARE RETARDED(MESSED UP)
            int xPos;
            int yPos = (int)Random.Range(1, board.transform.GetComponent<PopulateBoard>().gridY+1);//decides the random y position
            if (team == 1)
            {
                xPos = Random.Range(1, numOfColumnsForPlayersUnits+1);//decides the random y position
                
            }
            else
            {
                xPos = Random.Range(board.transform.GetComponent<PopulateBoard>().gridX + 1 - numOfColumnsForPlayersUnits, board.transform.GetComponent<PopulateBoard>().gridX+1);//decides the random y position
            }
            string tileName = (yPos - 1) + "," + (xPos - 1);//the names of tile are 0 based
           
            GameObject tile = GameObject.Find(tileName);
            if (tile != null && tile.transform.childCount < 6)// if there is no other units(5 other children are the borders and center)
            {
                transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.005f, tile.transform.position.z);
                transform.SetParent(tile.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (isSelected)
       {

           SetTurnMaterial();
       }
       else
       {
              //SetFinishedTurnMaterial();
       }
    }

    
    public bool HasAttacked()
    {
        return attacked;
    }
    public bool HasMoved()
    {
        return moved;
    }
    public bool HasFinished()
    {
        return finishedTurn;
    }

    public void SetAttack(int attack)
    {
        this.attack = attack;
    }

    public void SetUnitType(string unitType)
    {
        this.unitType = unitType;
    }

    public void SetUnitName(string unitName)
    {
        this.unitName = unitName;
    }

    public void SetRange(int range)
    {
        this.range = range;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetTeam(int team)
    {
        this.team = team;
    }

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }

    public void SetInitiative(int initiative)
    {
        this.initiative = initiative;
    }



    public int GetAttack()
    {
        return attack;
    }

    public int GetRange()
    {
        return range;
    }

    public string GetUnitType()
    {
        return unitType;
    }

    public string GetUnitName()
    {
        return unitName;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetTeam()
    {
        return team;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetInitiative()
    {
        return initiative;
    }

    public bool IsBeingAttacked()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attacking unit
        if ((invisible != (null)) && (attackingUnit != (null)) && !attackingUnit.transform.GetComponent<BasicUnitProperties>().HasAttacked())//if they both are not null
        {
            return (invisible.GetComponent<SelectedUnitMove>().isSelected &&
            attackingUnit.GetComponent<BasicUnitProperties>().GetTeam() != team && attackingUnit.transform.parent.GetComponent<Distance>().InRange(attackingUnit.GetComponent<BasicUnitProperties>().GetRange(), transform.parent.gameObject));// if there was a selected unit with different team number and this one is in range of the attacking unit's range

        }
        else
        {
            return false;
        }
    }

    //if there was a unit selected and it's team number is not the same this unit gets hit
    //this function checks if the unit was attacked and then does the right action
    public void Attacked()
    {
        GameObject invisible = GameObject.Find("SelectedUnit");//the invisible 
        GameObject attackingUnit = GameObject.Find(invisible.GetComponent<SelectedUnitMove>().CurrUnitName);//the attcking unit
        if ((invisible != null) && (attackingUnit != null))
        {
            if (IsBeingAttacked())//if there was a unit selected and is not on the same team 
            {
                attackingUnit.GetComponent<BasicUnitProperties>().attacked = true;
                transform.GetComponent<BasicUnitProperties>().GotHit(attackingUnit.GetComponent<BasicUnitProperties>().GetAttack());//the unit gets hit by the other unit's attack
                attackingUnit.GetComponent<BasicUnitProperties>().isSelected = false;// the attacking unit is no more selected
                invisible.GetComponent<SelectedUnitMove>().isSelected = false;//the invisible unit no more stores unit's data
                invisible.GetComponent<SelectedUnitMove>().CurrUnitName = "";//the invisible unit no more stores unit's data
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


    public bool IsSelected()
    {
        return isSelected;
    }

    public void Move()
    {
        if (!IsBeingAttacked())//if unit is not being attacked 
        {
            isSelected = true;//if was selected now is not, if was not selected it is now.
            GameObject selected = GameObject.Find("SelectedUnit");//get the "inviseble" unit
            if (GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName) != null && GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName) != transform.gameObject)//if there was a friendly unit selected and is not the same unit
            {
                GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName).GetComponent<BasicUnitProperties>().isSelected = false;
            }
            if (isSelected)
            {
                //changes the isSelected in the selected unit before
                selected.GetComponent<SelectedUnitMove>().CurrUnitName = transform.name;//if this unit is selected store it's name in the "invisible" one
            }

            selected.GetComponent<SelectedUnitMove>().isSelected = isSelected;//changes the boolean value in the "invisible" unit
           
        }
    }




    public List<GameObject> EnemyUnitsInRange()
    {
        List<GameObject> enemyUnitsInRange = new List<GameObject>();
        GameObject board = GameObject.Find("Board");
        List<GameObject> tiles = new List<GameObject>();//all the tiles
        for (int i = 0; i < board.transform.childCount; i++)
        {
            tiles.Add(board.transform.GetChild(i).gameObject);
        }
        foreach (GameObject tile in tiles) {
            if (transform.parent.GetComponent<Distance>().InRange(range, tile))//if the tile is in range
            {
                if(tile.transform.childCount > 5)//if the tile has more than 5 children(4 borders and center)
                {
                    for (int i = 5; i < tile.transform.childCount; i++)//i dont if we really need this
                    {
                        if (tile.transform.GetChild(i).tag == "unit" && tile.transform.GetChild(i).GetComponent<BasicUnitProperties>().GetTeam() != team)//checking if it is a tile(maybe in the terrain there will be game objects that are tile's children too) and team numbers are different
                        {
                            enemyUnitsInRange.Add(tile.transform.GetChild(i).gameObject);
                        }
                    }
                }
            }

        }
        return enemyUnitsInRange;
    }


    public void SetTargeted()
    {
        if (!isSelected) {
            if (team == 1)
            {
                transform.GetComponent<Renderer>().material = unitTargetedTeam1;
            }
            else
            {
                Debug.Log("unitTargetedTeam2");
                transform.GetComponent<Renderer>().material = unitTargetedTeam2;
            }
            isTargeted = true;
        }
    }

    public void SetUnTargeted()
    {
        if (!isSelected)
        {
            if (team == 1)
            {
                transform.GetComponent<Renderer>().material = unitTeam1;
            }
            else
            {
                transform.GetComponent<Renderer>().material = unitTeam2;
            }
            isTargeted = false;
        }
    }



    public void SetTurnMaterial()
    {
        if (team == 1)
        {
            Debug.Log("hello");
            transform.GetComponent<Renderer>().material = unitTurnTeam1;
        }
        else
        {
            transform.GetComponent<Renderer>().material = unitTurnTeam2;
        }
    }

    public void SetFinishedTurnMaterial()
    {
        if (team == 1)
        {
            transform.GetComponent<Renderer>().material = unitTeam1;
        }
        else
        {
            transform.GetComponent<Renderer>().material = unitTeam2;
        }
    }





}