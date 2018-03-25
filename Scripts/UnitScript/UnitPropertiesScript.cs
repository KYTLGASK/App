using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPropertiesScript : MonoBehaviour {
    int attack = 40;
    int health = 100;
    int speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void GotHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(GameObject.Find(transform.name));
        }
    }
}
