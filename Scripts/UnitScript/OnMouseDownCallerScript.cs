using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownCallerScript : MonoBehaviour
{
    public void OnMouseDown()
    {
        //transform.GetComponent<BasicUnitProperties>().Move();//give the invisible its data
        //transform.GetComponent<HighLightMoveOptions>().HighlightMoveOptions();//highlights the move options
        /*if (Input.touchCount != 0)
        {
            float acumTime = Input.GetTouch(0).deltaTime;
            if ( acumTime<0.8f && ) {
                transform.GetComponent<BasicUnitProperties>().Attacked();//if attacked gets attacked
            }
        }*/
        //transform.GetComponent<BasicUnitProperties>().Attacked();//if attacked gets attacked
    }
    void OnMouseOver()//this is for the touch too +-
    {
        transform.GetComponent<ShowPropertiesOnHoldScript>().OnMouseOverFunction();
    }
}
