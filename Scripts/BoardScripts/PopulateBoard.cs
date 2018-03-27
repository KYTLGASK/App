using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBoard : MonoBehaviour {
    
    public int gridX;
    public int gridY;
    public float spacingW; //Width spacing (Y axis)
    public float spacingL; //Length spacing (X axis)

    public GameObject tile;
    public Camera FirstPersonCam, ThirdPersonCam;
    public KeyCode TKey;
    public bool camSwitch = false;



    private float height;
    private float width;   
    private float length;

    private float initialX = 0f;
    private float initialY = 0f;

    private float x;
    private float y;

    private GameObject currentTile;

	// Use this for initialization
	void Start () {

        height = tile.transform.localScale.y;
        width = tile.transform.localScale.z;
        length = tile.transform.localScale.x;
        //height = transform.localScale.y; //added by leon
        //width = transform.localScale.y; //added by leon
        //length = transform.localScale.y; // added by leon

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
}
