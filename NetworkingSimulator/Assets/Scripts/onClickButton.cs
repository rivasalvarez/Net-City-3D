// @author:Sajid, Ortega, Rivas
// This script is intended to load the different buttons in the main menu scene
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class onClickButton : MonoBehaviour {

	float buttonWidth = 200.0f;
	float buttonHeight = 100.0f;

	// Use this for initialization
	void Start () {

	}

	void OnGUI()
	{
		GUI.skin = Resources.Load ("Buttons/ButtonSkin") as GUISkin;
		// This button is for creating a new game with a new user
		if (GUI.Button (
				new Rect (
					(Screen.width / 2)-(buttonWidth/2), 
					(Screen.height / 2)-(buttonHeight/2), 
					GUI.skin.button.fixedWidth, 
					GUI.skin.button.fixedHeight
					), 
				"New Game")
		    ) {
			Application.LoadLevel("CreateNewUser");
		}
		
		/* This button is for loading an existing profile
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 65, 100, 50), "Load Profile")) {
			Application.LoadLevel ("SearchMenu");
		}	*/
		// This button is for quitting the game, upon click it quits the game
		if (GUI.Button (
				new Rect (
				(Screen.width / 2)-(buttonWidth/2),
				(Screen.height / 2)-(buttonHeight/2)+ buttonHeight,
			GUI.skin.button.fixedWidth,
			GUI.skin.button.fixedHeight
				), 
			"Quit Game")
		    ) {
			Application.Quit ();
		}	
	}
	
}
