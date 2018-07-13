using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleData : MonoBehaviour {

    public static bool OverheadCamera = true;
    public static bool sideCamera = false;

    public void ValueChanged()
    {
        sideCamera = !sideCamera;
        OverheadCamera = !OverheadCamera;
    }

    public void Start()
    {
        OverheadCamera = true;
        sideCamera = false;
}
}
