using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is for all units, to show the unit's properties when you touch it for specific duration of time
public class ShowPropertiesOnHoldScript : MonoBehaviour {
    
    public Text unitProperties;//this is the text object in the game
    void Start () {
        unitProperties = GameObject.Find("UnitProperties").GetComponent<Text>();//this is the text object in the game
    }

    // Update is called once per frame
    private float holdTime = 0.8f; //the time you have to touch the unit to show the properties
    public static float acumTime = 0;//current touch duration
    public void OnMouseOverFunction()//this is for the touch too +-
    {
        if (Input.touchCount != 0)
        {
            
                //Debug.Log("true " + acumTime);
                acumTime += Input.GetTouch(0).deltaTime;
                if (acumTime > holdTime )//100 seconds for debugging
                {
                //Long tap, set the string of the text obj to the properties
              
               
                    unitProperties.text = "team: " + transform.GetComponent<BasicUnitProperties>().GetTeam() + "\n" +
                                         "attack: " + transform.GetComponent<BasicUnitProperties>().GetAttack() + "\n" +
                                         "health: " + transform.GetComponent<BasicUnitProperties>().GetHealth() + "\n" +
                                         "speed: " + transform.GetComponent<BasicUnitProperties>().GetSpeed() + "\n" +
                                         "range: " + transform.GetComponent<BasicUnitProperties>().GetRange() + "\n" +
                                         "initiative: " + transform.GetComponent<BasicUnitProperties>().GetInitiative() + "\n";
                
                    
                }

                

                if (Input.GetTouch(0).phase == TouchPhase.Ended)// if you no longer hold
                {
                    Debug.Log("true2");
                    if (acumTime < holdTime)
                    {
                        Debug.Log("true3");
                        transform.GetComponent<BasicUnitProperties>().Attacked();
                    }
                    acumTime = 0;
                    unitProperties.text = "";
                }
            
        }
        //acumTime = 0;
    }   
}
