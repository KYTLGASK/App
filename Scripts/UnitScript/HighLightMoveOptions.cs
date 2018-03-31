using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightMoveOptions : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HighlightMoveOptions()
    {
        if (transform.parent != null && transform.GetComponent<MoveScript>().isSelected)// if there is a parent and the unit is selected
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
        else if (transform.parent != null && !transform.GetComponent<MoveScript>().isSelected)//basically if the unit was double clicked  dishighlight all
        {
            GameObject.Find("Board").GetComponent<TouchDisHighlight>().DisAll();//dishighlights all tiles
        }

    }
}