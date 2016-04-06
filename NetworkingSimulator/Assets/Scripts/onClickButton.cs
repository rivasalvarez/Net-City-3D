// @author:Sajid, Ortega, Rivas
// This script is intended to load the different buttons in the main menu scene
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class onClickButton : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	void OnGUI()
	{
		GUI.skin = Resources.Load ("Buttons/ButtonSkin") as GUISkin;
		// This button is for creating a new game with a new user
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 50), "New Game")) {
			Application.LoadLevel("CreateNewUser");
		}

		// This button is for loading an existing profile
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 65, 100, 50), "Load Profile")) {
			Application.LoadLevel ("SearchMenu");
		}	

		// This button is for quitting the game, upon click it quits the game
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 65+65, 100, 50), "Quit Game")) {
			Application.Quit ();
		}	
	}
	
}
