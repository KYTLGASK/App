using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightMoveOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        Debug.Log("mouse down");
        if (transform.parent != null)// if there is a parent
        {
            Debug.Log("there is a parent");
            //GameObject[] tiles = transform.parent.parent.Get    
            int tilesNum = transform.parent.parent.childCount;
            Debug.Log(tilesNum);
            for (int i = 0; i < tilesNum; i++)// walks through every tile
            {
                //Debug.Log("tile num: " + i);
                if (transform.parent.GetComponent<Distance>().InRange(transform.GetComponent<BasicUnitProperties>().GetSpeed(), transform.parent.parent.GetChild(i).gameObject))//if the tile is in range of the unit speed
                {
                    //Debug.Log("is in range");
                    transform.parent.parent.GetChild(i).GetComponent<HighlightOnTouch>().Highlight();//highlights the tile
                }
            }
        }
        
    }
}
