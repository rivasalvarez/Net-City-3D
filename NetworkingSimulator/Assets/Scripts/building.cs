using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {
	// The name of the building
	public string BuildingName;
    gameManager gameMgr;

    public List<string> carTags = new List<string>();

	// Use this for initialization
	void Start () {
	
    gameMgr = GameObject.Find("GameObject").GetComponent<gameManager>();

    carTags.Add("Ambulance");
    carTags.Add("FireTruck");
    carTags.Add("Hearse");
    carTags.Add("IceCream");
    carTags.Add("PoliceCar");
    carTags.Add("Tanker");
    carTags.Add("Taxi");
    carTags.Add("Truck");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        //Check tag to see if colliding with building
        if (carTags.Contains(col.gameObject.tag)) {
            // if it is then destroy the car because it has reached its destination
            Destroy(col.gameObject);
            gameMgr.cash += 300;
        } 
    }

}
