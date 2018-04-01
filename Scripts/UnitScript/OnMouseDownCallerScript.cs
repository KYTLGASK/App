﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownCallerScript : MonoBehaviour {
    public void OnMouseDown()
    {
        transform.GetComponent<MoveScript>().Move();//give the invisible its data
        transform.GetComponent<HighLightMoveOptions>().HighlightMoveOptions();//highlights the move options
        transform.GetComponent<BasicUnitProperties>().Attacked();//if attacked gets attacked
    }
}
