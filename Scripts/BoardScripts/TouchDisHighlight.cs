using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Board Script disHighLights every child(every Tile)
public class TouchDisHighlight : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnMouseDown()
    {
        DisAll();
    }
    public void DisAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            (transform.GetChild(i)).GetComponent<Renderer>().material.color = Color.green;
        }
    }
}