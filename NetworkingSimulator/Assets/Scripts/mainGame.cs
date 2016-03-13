using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainGame : MonoBehaviour {
	string levelName;	// The level the user is currently on
	public GameObject goTerrain;	// The terrain of the object
	public Camera myCam; // The camera object
	GameObject playerMemory; // Not sure why we need this object
	gameManager gameMgr; // This gets the players information
	shopMenu shopScript; // This gets the information for the shop class, and lets player manipulate their stuff using the shop class
	public GameObject obj; // Not sure about this object
	public GameObject tmpObj; // Not sure about this object
	private bool showSettings; // This is a bool to check for if it is on show setting
	bool openingShop;  // This is a bool to open up the shop
	bool placingSecurity; // This is a bool to check for if placing security, this is ok
	GUIStyle guiCash;
	GUIStyle guiStyle;
	public float timer = 300; // A timer to calculate how long the user has been playing for
	string mins; // String of the amount of minutes that has passed
	string secs; // String of the amount of seconds that has passed
	public string time; // String of the amount of time overall that has passed

	// Use this for initialization
	void Start () {
		// This sets the string of the current level
		levelName = "mainGame";

		// This finds a game object and sets to a object called player Memory
		playerMemory = GameObject.Find ("GameObject");

		// This gets the component known as gameManager and sets it to the variable
		gameMgr = playerMemory.GetComponent<gameManager> ();

		// The boolean variable is going to check if the game has started 
        gameMgr.gameIsStarted = true;

		// This is to find the gameObject that holds the shopScript
		shopScript = GameObject.Find("GameObject").GetComponent<shopMenu>();
	
		// This is to allocate new GUISTYLE to the variable and set its appropriate values
		guiStyle =  new GUIStyle();
		guiStyle.fontSize = 20;
		guiStyle.normal.textColor = Color.white;

		// This is to allocate new GUISTYLE to the cash, and set its appropriate information
		guiCash =  new GUIStyle();
		guiCash.fontSize = 20;
		guiCash.normal.textColor = Color.green;
  

		/*
		if (playerScript.getLevelLoaded ()) {
			//begins the player with 3000 dollars of currency
			playerScript.setCash (3000);

			int tmp = playerScript.buildingsInThisScene.Count;
			
			playerScript.buildingsInThisScene.Clear ();
			for(int i = 0; i < tmp; i++)
			{
				obj = Instantiate (Resources.Load ("Prefabs/corporatePre", typeof(GameObject))) as GameObject;
				//obj.transform.position = playerScript.buildingsInThisScene[i].getPosition();
				obj.transform.position = playerScript.buildings[0];
				obj.GetComponent<Building>().setPosition(obj.transform.position);
				playerScript.buildingsInThisScene.Add (obj.GetComponent<Building> ());
			}
				

			tmp = playerScript.securityInThisScene.Count;
			playerScript.securityInThisScene.Clear ();

			for(int i = 0; i < tmp; i++)
			{
				obj = Instantiate (Resources.Load ("Prefabs/gatePre", typeof(GameObject))) as GameObject;
				obj.transform.position = playerScript.security[i];
				obj.GetComponent<Security>().setPosition(obj.transform.position);

				playerScript.securityInThisScene.Add (obj.GetComponent<Security>());
			}

			showSettings = false;
			placingCar = false;
			placingSecurity = false;	


		} else {
			playerScript.setCash (3000);

			// Loop through at starting integer 68 and instantiate roads based on that
			float z = 68;

			obj = Instantiate (Resources.Load ("Prefabs/corporatePre", typeof(GameObject))) as GameObject;
			tmpObj = obj;
			obj.transform.position = new Vector3 (40, 0, 20);
			obj.GetComponent<Building> ().setMonetary (300);
			obj.GetComponent<Building>().setPosition(obj.transform.position);
			playerScript.buildingsInThisScene.Add (obj.GetComponent<Building> ());


			obj = Instantiate (Resources.Load ("Prefabs/gatePre", typeof(GameObject))) as GameObject;
			obj.transform.position = new Vector3 (40.28648f, 2f, 29.05575f);
			obj.GetComponent<Security>().setPosition(obj.transform.position);
			playerScript.securityInThisScene.Add (obj.GetComponent<Security>());

			showSettings = false;
			placingCar = false;
			placingSecurity = false;
			*/



	}
	// Update is called once per frame
	void Update () {
		// This is the timer, calculates the minutes, seconds, and the overall time.
	    timer -= Time.deltaTime;
		mins = Mathf.Floor(timer / 60).ToString("00");
		secs = Mathf.Floor(timer % 60).ToString("00");
		time = mins + ":" + secs;




	}

	/**
	 * Function to calculate all of the GUI stuff for the main portion of the game
	 * @param: None
	 * @pre: None, requires initialized boolean variables
	 * @post: Loads the required GUI stuff.
	 * 		If user wants to place security, they press g and place a security gate at their mouse' designated spot
	 * 		If user presses Open Shop, the call the function to open up the menu
	 * @algorithm: Checks to see if the user clicked on the gui capabilities in the menu, if so, it launches whatever option that they clicked on 
	 */ 
	void OnGUI(){
		// This is going to create a label with a rectangle size with the appropriate guiStyle along with the current time after retreiving it from update
		GUI.Label(new Rect (0, 0, 150, 20), time,guiStyle);
 
		// This outside if statement checks for if the GUI buttons should be shown onto the screen or not.
		// This checks if the security button was not pressed
		if (placingSecurity == false && (shopScript.getShopOpen() == false)){

			// This checks if the showSettings button was not pushed
			if (showSettings == false) 	{
				
					// This will place an interactable GUI button onto the screen called "Create Security"
					if (GUI.Button (new Rect (110, (Screen.height / 1.10f), 100, 50), "Create Security")) {
						
						/* This will check if the player cash value is greater than 30. 
							*NOTE*
							* THIS IS SET TO TRUE AND NEEDS TO BE CHANGED LATER
							*NOTE*
						*/
						if(true){
							
							//Set placingSecurity to be true so the user can place the object onto the map with 'g'
							placingSecurity = true;
						}

					}
						
					// Otherwise, place an interactable GUI button onto the screen called OpenShop
					if (GUI.Button (new Rect (220, (Screen.height / 1.10f), 100, 50), "Open Shop")) {
						// This will set the shopMenu Script to be true, in which it will display the appropriate GUI
						shopScript.setShopOpen (true);
						
					}

					// Or check if the user interacts with the GUI button called settings on the screen
					if (GUI.Button (new Rect (330, (Screen.height / 1.10f), 100, 50), "Settings")) {
						
						// This is a boolean utilized to open up another set of GUI's for loading and saving, settings
						showSettings = true;							
					}
			}

			// If showSettings is true, then a set of different functionalities will be displayed
			else {
				// Interactable GUI button for load game
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2), 100, 50), "Load Game")) {
					/* Saves the game data
					 * *NOTE * shouldn't it be loading?
					 */
					gameMgr.saveData ();					
				}
				// Interactable GUI button for saving the game 
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 50, 100, 50), "Save Game")) {
					// Passes in the current levelName string as an argument
					gameMgr.setCurrentLevel(levelName);

					// Calls the save functionality for the gameMgr
					gameMgr.saveData ();					
				}

				// Interactable GUI button for options 
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 100, 100, 50), "Options")) {


				}
					
				// Interactable GUI button for quitting the game
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 150, 100, 50), "Quit Game")) {
					// Check to see if the user wants to save, if so, then called gameMgr.saveData, or something along those lines

					// Then quit the game entirely

				}

				// Interactable GUI button for back
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 200, 100, 50), "Back ")) {
					// Sets this to false, so the setting gui options will not appear
					showSettings = false;					
				}
			}
		}

		 // This will branch into placing a security gate onto the map
		 if(placingSecurity == true){
					// This checks if the user pressed the G key on the keyboard
					if (Input.GetKeyDown (KeyCode.G)) {
						// Create a ray object, and have it trace the mousePosition from top down
						Ray vRay = myCam.ScreenPointToRay (Input.mousePosition);

						// Create a hit variable that will store the value of whatever it hits
						RaycastHit hit;
						
						// Cast a raycast from the starting position of the mouse down infinitely
						if (Physics.Raycast (vRay, out hit, Mathf.Infinity)) {

						if (hit.collider.tag == "Building") {
								// This is a variable that will hold the position of where the hit is detected for the mouse
								Vector3 placePosition;

								// This removes the amount of cash the user will have from the total
								gameMgr.minusCash (gameMgr.getSecurityLevelCash ());
									
								// Store the hit position into the placePosition
								placePosition = hit.point;

								// This will round the x and z variable, not sure if this is needed though since accuracy is much better than inaccuracy for object placement
								placePosition.x = Mathf.Round (placePosition.x);
								placePosition.z = Mathf.Round (placePosition.z);

								// instantiate a tollgate prefab as gameObject into the world (Will be called tollPre(clone), I think
								obj = Instantiate (Resources.Load ("Prefabs/tollPre", typeof(GameObject))) as GameObject;
								
								// Change the position of it so it will be placed a little bit above the road level
								obj.transform.position = new Vector3 (placePosition.x, 0.6f, placePosition.z);	
								
								// Set the placing security to false, in which it won't let the user keep pressing g for more security gates
								placingSecurity = false;
								}
						}
					}	
				}
		if (shopScript.getShopOpen () == true) {

		}
	}
}

