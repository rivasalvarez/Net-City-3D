using UnityEngine;
using System.Collections;

public class HoneyPot : MonoBehaviour {

  GameObject playerMemory;
  gameManager playerScript;


	// Use this for initialization
	void Start () {
	  playerMemory = GameObject.Find ("GameObject");
	  playerScript = playerMemory.GetComponent<gameManager> ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Ambulance" || col.gameObject.tag == "PoliceCar" ||
		   col.gameObject.tag == "FireTruck" || col.gameObject.tag == "Hearse" ||
		   col.gameObject.tag == "IceCream" || col.gameObject.tag == "Tanker" ||
		   col.gameObject.tag == "Taxi" || col.gameObject.tag == "Truck"){

			Debug.Log("WTF");
		}
	}

}
