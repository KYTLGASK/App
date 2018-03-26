using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour {

    public int row;
    public int column;
	
    public void SetRow(int row)
    {
        this.row = row;
    }

    public void SetColumn(int column)
    {
        this.column = column;
    }

    public int GetRow()
    {
        return this.row;
    }

    public int GetColumn()
    {
        return this.column;
    }

    private void OnMouseDown()
    {
        //Debug.Log(this.row + ", " + this.column); //print out the name of the currently selected tile
    }
}
