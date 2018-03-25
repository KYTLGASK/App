using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this return the unit(child) on the tile(if there is any)
public class UnitOnTileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // checks if there is a unit(child)
    bool IsUnitOn() {
        if (transform.childCount == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    GameObject GetUnit() {
        if (IsUnitOn())
        {
            //return transform.GetChild(0);
            //GameObject.Find(transform.name).GetChild(0);
            return GameObject.Find(transform.name).transform.GetChild(0).gameObject; 
        }

        return null;
    }
}
