using UnityEngine;
using System.Collections;

public class LoaderUser : MonoBehaviour {
	public string name = "username ";
	public string password = "password ";

	GameObject playerMemory;
	gameManager playerScript;

	// Use this for initialization
	void Start () {
		//to access playerManager which is not destroyed throughout scenes
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<gameManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//sets up buttons for loading user
	void OnGUI()
	{
		GUI.skin = Resources.Load ("Buttons/ButtonSkin") as GUISkin;
		//set color and create label
		GUI.color = Color.white;
		GUI.Label(new Rect (Screen.width / 2, (Screen.height / 2) - 30,150,60), "Please Insert Username to load checkpoint");
		
		GUI.Label(new Rect (Screen.width / 2, Screen.height / 2,150,20), "Please Insert Username to load checkpoint");

		//create textfields to insert username and password
		GUI.color = Color.white;
		name = GUI.TextField(new Rect(Screen.width / 2, (Screen.height / 2) + 25, 200, 20), name.Trim(), 25);

		password = GUI.TextField(new Rect(Screen.width / 2, (Screen.height / 2) + 50, 200, 20), password.Trim(), 25);

		GUI.color= Color.white;
		
		// This button is to load the profile
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 75, 100, 50), "Find profile")) {
			playerScript.setPassword(password);

			// Load tutorial 01, but then make sure that the game manager realizes that a user is loaded
			Application.LoadLevel("Tutorial01");

			playerScript.setUserFound (true);
		}

		// This button is to return to mainMenu
		if (GUI.Button (new Rect ((Screen.width )/10, (Screen.height )/10 , 100, 50), "Main Menu")) {
			Application.LoadLevel("StartMenu");

		}
	}

}
