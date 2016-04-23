using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {
	// The name of the building
    gameManager gameMgr;

    public List<string> badCars = new List<string>();

    public int badNumberCars = 0;

	// Use this for initialization
	void Start () {
	
    gameMgr = GameObject.Find("GameObject").GetComponent<gameManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        int amount = 300;
        if ( col.gameObject.tag == "car" ) {
            Car colCar = col.gameObject.GetComponent<Car>();

            if (badCars.Contains(colCar.carTypeString)) {
                badNumberCars++;
                print("That's a Bad Car!!!!!!!");
                amount = amount - (100 * badNumberCars);
                print(amount);
            }

            Destroy(col.gameObject);
            gameMgr.cash += amount;
        } 
    }

}