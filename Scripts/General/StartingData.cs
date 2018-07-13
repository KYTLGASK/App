using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingData : MonoBehaviour {
    public Camera overHead;
    public Camera side;
    public static Toggle overheadToggle;
    bool overheadCamera = ToggleData.OverheadCamera;

    public void StartData()
    {
        //Debug.Log("Hello1");
        if (!overheadCamera)
        {
            //Debug.Log("Hello2");
            overHead.enabled = false;
            side.enabled = true;
        }

        else
        {
            overHead.enabled = true;
            side.enabled = false;
        }
    }

    public void SetOverheadCamera(bool isOverhead)
    {
        overheadCamera = isOverhead;
    }

    //public void Update()
    //{
    //    if (overheadToggle.isOn)
    //    {
    //        overheadCamera = true;
    //    }
    //
    //    else
    //    {
    //        overheadCamera = false;
    //    }
    //    
    //}
}
