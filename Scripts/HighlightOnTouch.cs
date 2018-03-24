using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tile;

//this class highlightes the tile if it is touched 
public class HighlightOnTouch : MonoBehaviour
{
    Material m_Material; // tile's material
    public bool isHighlighted = false; //if the tile is highlighted or not

    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    // updates the boolean value so if the color was changed outside
    void Update()
    {
        if (m_Material.color == Color.green)
        {
            isHighlighted = false;
        }
        else
        {
            isHighlighted = true;
        }

    }

    //summons the right function on touch
    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<TouchDisHighlight>().DisAll(); //dishighlight all via the gameboards functions
                                                                               //(check: Assets/Scripts/BoardScript/TouchDisHighlight)
        if (!isHighlighted)
        {
            Highlight();
        }
        else
        {
            DisHighlight();
        }


    }
    // function to highLight Tile(changes the tiles color to yellow)
    public void Highlight()
    {
        isHighlighted = true;
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = new Color(255, 255, 0);

    }

    //function to DisHighlighte Tile(changes the tiles color to green)
    public void DisHighlight()
    {
        isHighlighted = false;
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.green;
    }
}