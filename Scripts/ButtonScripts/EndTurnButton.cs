using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour {
    //GameObject GeneralScriptsObject = GameObject.Find("GeneralScriptsObject");

    public Button yourButton;

    void Start()
    {
        //Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(NextUnitTurn);
    }

    

    public void NextUnitTurn()
    {
        GameObject currUnit = transform.GetComponent<Turns>().units[0];
        //here you will move on in the array or whatever Yaniv did
        currUnit.GetComponent<BasicUnitProperties>().moved = false;
        currUnit.GetComponent<BasicUnitProperties>().attacked = false;
        currUnit.GetComponent<BasicUnitProperties>().finishedTurn = false;
        transform.GetComponent<Turns>().EndTurn();
        /*if (transform.GetComponent<Turns>().player1Turn)
        {
            transform.GetComponent<Turns>().NextUnitTurn(transform.GetComponent<Turns>().p1Units);
            transform.GetComponent<Turns>().player1FinishedTurn = true;
        }
        else
        {
            transform.GetComponent<Turns>().NextUnitTurn(transform.GetComponent<Turns>().p2Units);
            transform.GetComponent<Turns>().player1FinishedTurn = false;
            transform.GetComponent<Turns>().player2FinishedTurn = true;
        }

        currUnit.GetComponent<BasicUnitProperties>().finishedTurn = false;
        */
        //if (transform.GetComponent<Turns>().player1Turn)
        //{
        //    transform.GetComponent<Turns>().EndTurn(transform.GetComponent<Turns>().p1Units);
        //}
        //else
        //{
        //    transform.GetComponent<Turns>().EndTurn(transform.GetComponent<Turns>().p2Units);
        //}
    }
}
