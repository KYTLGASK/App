using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPropertiesOnHoldScript : MonoBehaviour {
   /* 
    public static ShowPropertiesOnHoldScript instance;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    public Text unitProperties;
    void Start () {
        unitProperties.text = "";

    }

    // Update is called once per frame
    private float holdTime = 0.8f; //or whatever
    private float acumTime = 0;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            acumTime += Input.GetTouch(0).deltaTime;

            if (acumTime >= holdTime)
            {
                //Long tap
                unitProperties.text = "team" + transform.GetComponent<BasicUnitProperties>().GetTeam() + "\n" +
                                        "attack: " + transform.GetComponent<BasicUnitProperties>().GetAttack() + "\n" +
                                        "health: " + transform.GetComponent<BasicUnitProperties>().GetHealth() + "\n" +
                                        "speed: " + transform.GetComponent<BasicUnitProperties>().GetSpeed() + "\n" +
                                        "range: " + transform.GetComponent<BasicUnitProperties>().GetRange() + "\n" +
                                        "initiative: " + transform.GetComponent<BasicUnitProperties>().GetInitiative() + "\n" ;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended) 
            {
                acumTime = 0;
                unitProperties.text = "";
            }
        }
    }   */
}
