using UnityEngine;
using System.Collections;

public class selectionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	void OnGUI()
	{
		
		
		// This button is to go to first tutorial
		if (GUI.Button (new Rect (0, (Screen.height/2 ) , 100, 50), "Tutorial 1")) {
			
			Application.LoadLevel("tutorial01");			
		}

	}
}
