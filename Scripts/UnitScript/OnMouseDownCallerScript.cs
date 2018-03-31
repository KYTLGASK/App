using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownCallerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnMouseDown()
    {
        /*if(!transform.GetComponent<BasicUnitProperties>().moved)//if the unit did not move
        {
            transform.GetComponent<MoveScript>().Move();//give the invisible its data
            transform.GetComponent<HighLightMoveOptions>().HighlightMoveOptions();//highlights the move options
        }
        if(!transform.GetComponent<BasicUnitProperties>().attacked)//if the unit did not attack
        {
            transform.GetComponent<BasicUnitProperties>().Attacked();//if attacked gets attacked
        }*/
        transform.GetComponent<MoveScript>().Move();//give the invisible its data
        transform.GetComponent<HighLightMoveOptions>().HighlightMoveOptions();//highlights the move options
        transform.GetComponent<BasicUnitProperties>().Attacked();//if attacked gets attacked
    }
}
