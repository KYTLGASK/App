using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the "invisible unit which stores last clicked unit"
public class SelectedUnitMove : MonoBehaviour {
    public string CurrUnitName;//last clicked unit's object name
    public bool isSelected = false;//is a unit currently selected
}
