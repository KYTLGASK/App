using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script which contains all sorts of distance measuring fucntions.
/// 
/// 
/// some ways to use this script:
/// 
/// Debug.Log(Distance.Dist(0, 0, this.row, this.column)); //A test to see if distance function works. (measures distance to 0,0)
/// Debug.Log(Distance.Dist(0, 0, gameObject)); //A test to see if distance function works. (measures distance to 0,0)
/// 
/// GameObject board = transform.parent.gameObject; 
/// Distance d = board.GetComponent<Distance>();        //we must do both of these line so that the function Dist knows which board to scan
/// List<GameObject> withinRange = d.Dist(2, 0, 0);   //this, z.b, will return a list of all tiles that are whitin a two-move range of the tile 0,0
/// foreach (GameObject tile in withinRange)
/// {
///    Debug.Log(tile.name);
/// }
/// </summary>
public class Distance : MonoBehaviour {
    private GameObject board;



    public static int Dist(int rowA, int colA, int rowB, int colB)
    {
        int dist = 0;
        int currRow = Mathf.Min(rowA, rowB);
        int currCol = Mathf.Min(colA, colB);

        while (currRow < Mathf.Max(rowA, rowB))
        {
            dist++;
            currRow++;
        }

        while (currCol < Mathf.Max(colA, colB))
        {
            dist++;
            currCol++;
        }

        return dist;
    }

    public static int Dist(int rowA, int colA, GameObject go)
    {
        try
        {
            int rowB = go.GetComponent<Name>().GetRow();
            int colB = go.GetComponent<Name>().GetColumn();

            return Dist(rowA, colA, rowB, colB);
        }
        catch
        {
            Debug.Log("GameObject selected is not a tile!");
            return -1;
        }
    }

    public static int Dist(GameObject goA, GameObject goB)
    {
        try
        {
            int rowA = goA.GetComponent<Name>().GetRow();
            int colA = goA.GetComponent<Name>().GetColumn();

            int rowB = goB.GetComponent<Name>().GetRow();
            int colB = goB.GetComponent<Name>().GetColumn();

            return Dist(rowA, colA, rowB, colB);
        }
        catch
        {
            Debug.Log("GameObject selected is not a tile!");
            return -1;
        }
    }

    /// <summary>
    /// Return a list of all GameObjects which are whithin 'dist' moves of tile (row,col).
    /// </summary>
    /// <param name="dist">The range</param>
    /// <param name="row">The row of the tile from which the range is measured</param>
    /// <param name="col">The column of the tile from which the range is measured</param>
    /// <returns></returns>
    public List<GameObject> Dist(int dist, int row, int col)
    {   
        board = this.gameObject;

        List<GameObject> withinRange = new List<GameObject>();

        foreach (Transform tile in board.GetComponentInChildren<Transform>()){
            if (Dist(row, col, tile.gameObject) <= dist)
                withinRange.Add(tile.gameObject);
        }

        return withinRange;
    }
}
