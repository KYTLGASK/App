using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this is for tile that is selected to move to
public class SelectedToGoToScript : MonoBehaviour
{

    private void OnMouseDown()
    {
        GameObject selected = GameObject.Find("SelectedUnit");//selectedUnit is the "invisible"
        if (selected.GetComponent<SelectedUnitMove>().isSelected )//if there was a unit selected
        {
            
                GameObject unitToMove = GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName);//the unit which is supposed to move
            if (unitToMove != null) {//if unit to move is not null
                unitToMove.GetComponent<BasicUnitProperties>().isSelected = !unitToMove.GetComponent<BasicUnitProperties>().isSelected;//inform the real unit that he is no more selected                                                                                      
            }    
                selected.GetComponent<SelectedUnitMove>().isSelected = false;//there is no more a selected unit
                if ((transform.childCount < 6 && unitToMove.transform.parent == null) //if there is no unit on this tile(apparently there are 5 children which are the borders and the center) and the unit is in the start  of the game
                ||(transform.childCount < 6 && transform.GetComponent<Distance>().InRange(unitToMove.GetComponent<BasicUnitProperties>().GetSpeed(), unitToMove.transform.parent.gameObject)) 
                && !(unitToMove.GetComponent<BasicUnitProperties>().moved)) //or there is no unit on this tile and the unit doesn't have a parent(is not on a tile)                    //and unit's tile is in range of unit's speed
                {
                unitToMove.transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);//moves the unit to the x and y position of the tile and adds a little to z so it will be in front of the tile
                unitToMove.transform.SetParent(transform);// set unit's parent to this tile 
                unitToMove.transform.GetComponent<BasicUnitProperties>().moved = true;// unit moved true
                Debug.Log("I moved");
                }
        }
    }
}
