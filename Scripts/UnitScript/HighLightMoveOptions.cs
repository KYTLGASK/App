using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightMoveOptions : MonoBehaviour
{
    public void HighlightMoveOptions()
    {
        //if (transform.parent != null && transform.GetComponent<BasicUnitProperties>().isSelected)// if there is a parent and the unit is selected
        if (transform.parent != null)
        {
            int tilesNum = transform.parent.parent.childCount;
            GameObject.Find("Board").GetComponent<TouchDisHighlight>().DisAll();//dishighlights all tiles
            for (int i = 0; i < tilesNum; i++)// walks through every tile
            {
                if (transform.parent.GetComponent<Distance>().InRange(transform.GetComponent<BasicUnitProperties>().GetSpeed(), transform.parent.transform.parent.GetChild(i).gameObject))//if the tile is in range of the unit speed
                {
                    transform.parent.parent.GetChild(i).GetComponent<HighlightOnTouch>().Highlight();//highlights the tile
                }
            }
        }
        /*else if (transform.parent != null && !transform.GetComponent<BasicUnitProperties>().isSelected)//basically if the unit was double clicked  dishighlight all
        {
            GameObject.Find("Board").GetComponent<TouchDisHighlight>().DisAll();//dishighlights all tiles
        }*/

    }
}