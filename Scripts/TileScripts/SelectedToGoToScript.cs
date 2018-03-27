using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this is for tile that is selected to move to
public class SelectedToGoToScript : MonoBehaviour
{

    private void OnMouseDown()
    {
        GameObject selected = GameObject.Find("SelectedUnit");//selectedUnit is the "invisible"
        if (selected.GetComponent<SelectedUnitMove>().isSelected)//if there was a unit selected
        {
            GameObject unitToMove = GameObject.Find(selected.GetComponent<SelectedUnitMove>().CurrUnitName);//the unit which is supposed to move
            unitToMove.GetComponent<MoveScript>().isSelected = !unitToMove.GetComponent<MoveScript>().isSelected;//inform the real unit that he is no more selected                                                                                      //(basically GameObject.find("name"))
            unitToMove.transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);//moves the unit to the x and y position of the tile and adds a little to z so it will be in front of the tile
            selected.GetComponent<SelectedUnitMove>().isSelected = false;//there is no more a selected unit
            if (transform.childCount < 6)//if there no unit on this tile(apparently there are 5 children which are the borders and the center)
            {
                unitToMove.transform.SetParent(transform);
                Debug.Log("parent: " + unitToMove.transform.parent);
            }
            else
            {
                //Debug.Log("no children" + transform.childCount+"  "+transform.GetChild(4));
            }

        }
    }
}
