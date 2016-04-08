using UnityEngine;
using System.Collections;

public class newUserScript : MonoBehaviour {
	public string name = "";
	public string pass = "";

	GameObject playerMemory;
	gameManager playerScript;

	bool sameUserName;

	// Use this for initialization
	void Start () {
		//assigns playerManager which is not destroyed throughout scenes
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<gameManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//sets up UI and also inputs
	void OnGUI()
	{
		float width = 300.0f;
		float height = 35.0f;
		float t = 20.0f;

		GUI.skin = Resources.Load ("Buttons/ButtonSkin") as GUISkin;
		//to check if the user has actually inputted things in user and password
		bool unInput = false;
		bool pInput = false;

		//create the labels and textfields for username and password

		GUI.Label (new Rect ((Screen.width / 2)-width/2, (Screen.height / 4)-50,width, height), "Create Username");


		name = GUI.TextField (new Rect ((Screen.width / 2)-width/2, (Screen.height / 4)+height+5-50, width, height), name.Trim (), 30);

		GUI.Label (new Rect ((Screen.width / 2)-width/2, (Screen.height / 4)+(2*height)+5-50, width, height), "Create a Password");

		pass = GUI.TextField (new Rect ((Screen.width / 2)-width/2, (Screen.height / 4)+(3*height)+5-50, width, height), pass, 30);
	
		//check if the user has inputted the username
		//if they have don't display line prompting for username
		if (name != "") {
			unInput = true;
		}
		//else show text that prompts for the username
		else {
			unInput = false;
			GUI.Label (new Rect ((Screen.width / 2)-width/2, (Screen.height / 4)+(4*height)+5-50, width+200, height), "Please enter a valid username");
		}

		//check if the user has inputted the password
		//if they have don't display text prompting for password
		if (pass != "") {

			pInput = true;
		} 
		//else do display the text
		else {	
			pInput = false;
			GUI.Label (new Rect ((Screen.width / 2)-width/2, (Screen.height / 4)+(5*height)+5-50, width+200, height), "Please enter a valid password");

		}

		GUI.color = Color.white;

		// This button is for create Profile
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 105, GUI.skin.button.fixedWidth, GUI.skin.button.fixedHeight), "Create Profile")) {
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
		if (GUI.Button (new Rect ((Screen.width )/10, (Screen.height )/10 , GUI.skin.button.fixedWidth, GUI.skin.button.fixedHeight), "Main Menu")) {
			Application.LoadLevel("StartMenu");
			
		}
	}
}
