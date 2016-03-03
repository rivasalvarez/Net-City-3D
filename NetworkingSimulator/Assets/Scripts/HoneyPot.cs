using UnityEngine;
using System.Collections;

public class HoneyPot : MonoBehaviour {

  GameObject playerMemory;
  gameManager gameMgr;

  GameObject main;
  mainGame gameWorld;

	// Use this for initialization
	void Start () {
	  playerMemory = GameObject.Find ("GameObject");
	  gameMgr = playerMemory.GetComponent<gameManager> ();

	  main = GameObject.Find ("Main Camera");
	  gameWorld = main.GetComponent<mainGame> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Ambulance" || col.gameObject.tag == "PoliceCar" ||
		   col.gameObject.tag == "FireTruck" || col.gameObject.tag == "Hearse" ||
		   col.gameObject.tag == "IceCream" || col.gameObject.tag == "Tanker" ||
		   col.gameObject.tag == "Taxi" || col.gameObject.tag == "Truck"){

           Car colCar = col.gameObject.GetComponent<Car>();
            
			string info = "Color: " + colCar.colorString + "  Size: " + colCar.sizeString 
                      + "  Type: " + colCar.carTypeString + "  Time: " + gameWorld.time;
			//Debug.Log(info);
		} 
	} 

}
