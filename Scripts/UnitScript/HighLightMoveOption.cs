using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightMoveOption : MonoBehaviour {
    public int row = -1;
    public int column = -1;
    public int moveNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetMoveNum()
    {
        moveNum = 2;
    }

    void HihglightMoveOptions()
    {// alot of ifs 
        GameObject Tile = GameObject.Find("Cube" + row+1 + "," + column);
    }


    public void FindPos()
    {

        string parentName = transform.parent.transform.name;

        for (int i = 0; i < parentName.Length; i++)
        {
            if (char.IsDigit(parentName[i]))
                if (row == -1)
                {
                    row = (int)char.GetNumericValue(parentName[i]);
                }
                else
                {
                    column = (int)char.GetNumericValue(parentName[i]);
                }
        }
    } 
}
