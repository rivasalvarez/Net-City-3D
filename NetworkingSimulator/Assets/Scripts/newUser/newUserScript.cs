using UnityEngine;
using System.Collections;

public class newUserScript : MonoBehaviour {
	public string name = "";
	public string pass = "";

	GameObject playerMemory;
	playerManager playerScript;

	bool sameUserName;

	// Use this for initialization
	void Start () {
		//assigns playerManager which is not destroyed throughout scenes
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<playerManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//sets up UI and also inputs
	void OnGUI()
	{
		//to check if the user has actually inputted things in user and password
		bool unInput = false;
		bool pInput = false;

		//create the labels and textfields for username and password
		GUI.color = Color.black;
		GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 20), "Create Username");

		GUI.color = Color.red;
		name = GUI.TextField (new Rect (Screen.width / 2, (Screen.height / 2) + 25, 200, 20), name.Trim (), 25);

		GUI.color = Color.black;
		GUI.Label (new Rect (Screen.width / 2, (Screen.height / 2) + 50, 150, 20), "Create a Password");

		GUI.color = Color.red;
		pass = GUI.TextField (new Rect (Screen.width / 2, (Screen.height / 2) + 75, 200, 20), pass, 25);



		//check if the user has inputted the username
		//if they have don't display line prompting for username
		if (name != "") {
			unInput = true;
		}
		//else show text that prompts for the username
		else {
			unInput = false;
			GUI.Label (new Rect (Screen.width / 2, (Screen.height / 2) + 165, 190, 60), "Please enter a valid username");
		}

		//check if the user has inputted the password
		//if they have don't display text prompting for password
		if (pass != "") {

			pInput = true;
		} 
		//else do display the text
		else {	
			pInput = false;
			GUI.Label (new Rect (Screen.width / 2, (Screen.height / 2) + 185, 190, 40), "Please enter a valid password");

		}

		GUI.color = Color.white;

		// This button is for create Profile
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 105, 100, 50), "Create Profile")) {
			//check if username is taken or not
			if(playerScript.checkForUser( name))
			{ 		
					GUI.Label (new Rect (Screen.width / 2, (Screen.height / 2) + 195, 190, 60), "Username is already taken");

			}

			else
			{
				//if user has inputted the password and username then go to next scene
				if(unInput == true && pInput == true )
				{	

					playerScript.setUserName (name);
					playerScript.setPassword (pass);
				
					Application.LoadLevel("SelectionMenu");
				}
				//else don't do anything until they do
			}
		}

		// This button is for going back to the mainMenu
		if (GUI.Button (new Rect ((Screen.width )/10, (Screen.height )/10 , 100, 50), "Main Menu")) {
			Application.LoadLevel("StartMenu");
			
		}
	}
}
