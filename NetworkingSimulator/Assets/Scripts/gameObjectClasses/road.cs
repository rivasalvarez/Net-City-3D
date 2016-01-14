using UnityEngine;
using System.Collections;

public class road : MonoBehaviour {
	private Vector3 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//gets and sets
	public Vector3 getPosition(){
		return position;

	}

	public void setPosition(Vector3 inPosition){
		position = inPosition;
	}
}
