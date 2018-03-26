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

    private void OnMouseDown()
    {
        Debug.Log(this.row + ", " + this.column);
    }
}
