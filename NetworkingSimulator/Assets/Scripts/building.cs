using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	// The position of the building in the scene
	private Vector3 position;

	// The name of the building
	private string name;

	// Monetary value of the building 
	private int monetary;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Get functions
	public  int getMonetary(){
		return monetary ;
	}
	
	public string getName(){
		return name;
	}
	
	public Vector3 getPosition(){
		return position ;
	}


	// Set function
	public  void setMonetary(int money){
		monetary = money;
	}

	public void setName(string buildingName){
		name = buildingName;
	}

	public void setPosition(Vector3 loc){
		position = new Vector3(loc.x, loc.y, loc.z);
	}
}
