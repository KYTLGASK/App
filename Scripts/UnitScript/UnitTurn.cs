using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnitTurnPossibilities()
    {
        if (!transform.GetComponent<BasicUnitProperties>().IsSelected()){ 
            transform.GetComponent<BasicUnitProperties>().Move();
            
        }
        if (!transform.GetComponent<BasicUnitProperties>().HasMoved()) {
            transform.GetComponent<HighLightMoveOptions>().HighlightMoveOptions();
        }
    }
}
