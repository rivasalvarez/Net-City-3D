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
		if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2 ) , 100, 50), "Start Game")) {
			
			Application.LoadLevel("tutorial01");			
		}

	}
}
