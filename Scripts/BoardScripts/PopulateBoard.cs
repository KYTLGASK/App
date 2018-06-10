using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBoard : MonoBehaviour {


    public int numOfColumnsForPlayersUnits = 3;
    int numOfMagmaTiles = 10;// must be between 0 and (gridX*gridY-numOfColumnsForPlayersUnits*gridY) or else while forever biatch
    public int gridX;
    public int gridY;
    public float spacingW; //Width spacing (Y axis)
    public float spacingL; //Length spacing (X axis)

    public GameObject tile;
    public GameObject x_terrain_tile;
    public Camera FirstPersonCam, ThirdPersonCam;
    public KeyCode TKey;
    public bool camSwitch = true;

    public Material magmaTerrain;

    private float height;
    private float width;   
    private float length;

    private float initialX = 0f;
    private float initialY = 0f;

    private float x;
    private float y;

    private GameObject currentTile;

	// Use this for initialization, this goes FIRST
	public void StartPopulateBoard () {
        TKey = KeyCode.Space;
        height = tile.transform.localScale.y;
        width = tile.transform.localScale.z;
        length = tile.transform.localScale.x;
        
        float sumX = gridX * length + (gridX - 1) * spacingL;
        initialX = (initialX - sumX / 2) + length / 2;

        float sumY = gridY * width + (gridY - 1) * spacingW;
        initialY = (initialY - sumY / 2) + width / 2;


        x = initialX;
        y = initialY;

        for (int i=0; i < gridY; i++)
        {
            for (int j=0; j < gridX; j++)
            {
                currentTile = (GameObject)Instantiate(tile, new Vector3(x, height/2, y), Quaternion.identity, transform);
                currentTile.name = i + "," + j;
                currentTile.GetComponent<Name>().SetRow(i);
                currentTile.GetComponent<Name>().SetColumn(j);

                x += length + spacingL;
            }
            y += (width + spacingW); // (+) if initializing board from bottom up, (-) otherwise 
            x = initialX;
        }
        PutXTerrainInNumTiles(numOfMagmaTiles);

    }
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TKey))
        {
            camSwitch = !camSwitch;
            FirstPersonCam.gameObject.SetActive(camSwitch);
            ThirdPersonCam.gameObject.SetActive(!camSwitch);
        }
    }

    void PutXTerrainInNumTiles(int numOfTiles)
    {
        GameObject board = GameObject.Find("Board");
        
        while (numOfTiles != 0)
        {
            int yPos = (int)Random.Range(0, board.transform.GetComponent<PopulateBoard>().gridY + 1);//decides the random y position
            int xPos = (int)Random.Range(numOfColumnsForPlayersUnits + 1, board.transform.GetComponent<PopulateBoard>().gridX + 1 - numOfColumnsForPlayersUnits);//decides the random y position
            string tileName = (yPos - 1) + "," + (xPos - 1);//the names of tile are 0 based
            GameObject tile = GameObject.Find(tileName);
            if (tile != null)
            {
                if (tile.transform.childCount < 6 && !(tile.transform.GetComponent<HighlightOnTouch>().isXTerrain))
                {
                    tile.transform.GetComponent<HighlightOnTouch>().isXTerrain = true;
                    tile.transform.GetComponent<Renderer>().material = magmaTerrain;
                    numOfTiles--;
                }
            }
        }
            
    }
}
