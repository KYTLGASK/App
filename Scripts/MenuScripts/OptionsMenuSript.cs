using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuSript : MonoBehaviour {

	public void Back()
    {
        GameObject.Find("OptionsMenu").SetActive(false);
        //GameObject.Find("MainMenu").SetActive(true);
    }
}
