using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainGame : MonoBehaviour {
	gameManager gameMgr; // This gets the players information
	shopMenu shopScript; // This gets the information for the shop class, and lets player manipulate their stuff using the shop class
	GUIStyle guiCash;
	GUIStyle guiStyle;
	GUIStyle boxInformation;

	bool openingShop;  // This is a bool to open up the shop
	bool placingSecurity; // This is a bool to check for if placing security, this is ok
	public bool showSettings; // This is a bool to check for if it is on show setting

	public Camera myCam; // The camera object
	public GameObject obj; // This is for Save Menu!!!!! TODO
    public GameObject tmpObj; // This is for Save Menu!!!!! TODO

	float timer = 60; // A timer to calculate how long the user has been playing for
	public string time; // String of the amount of time overall that has passed
	string mins; // String of the amount of minutes that has passed
	string secs; // String of the amount of seconds that has passed

	// Use this for initialization
	void Start () {

		// This gets the component known as gameManager and sets it to the variable
		gameMgr = GameObject.Find ("GameObject").GetComponent<gameManager> ();

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
  
		boxInformation = new GUIStyle ();
		boxInformation.fontSize = 14;
		boxInformation.normal.textColor = Color.gray;

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

        HoneyPot hp;
        hp = GameObject.Find("HoneySpoon").GetComponent<HoneyPot>();
        hp.Keys.Add("Yellow");
        hp.Keys.Add("Blue");
        gameMgr.honeyPots.Add(hp);

	}
	// Update is called once per frame
	void Update () {
		// This is the timer, calculates the minutes, seconds, and the overall time.
	    timer -= Time.deltaTime;
		mins = Mathf.Floor(timer / 60).ToString("00");
		secs = Mathf.Floor(timer % 60).ToString("00");
		time = mins + ":" + secs;

        if (timer < 0){
            timer = 60;
            foreach (var hp in gameMgr.honeyPots)
                hp.carPIDS.Clear();
        }
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
			Car tempScript;
			// Create a ray object, and have it trace the mousePosition from top down
			Ray ray = myCam.ScreenPointToRay (Input.mousePosition);

			// Create a hit variable that will store the value of whatever it hits
			RaycastHit hitDetected;

			Physics.Raycast (ray, out hitDetected, Mathf.Infinity);

			if (Physics.Raycast (ray, out hitDetected, Mathf.Infinity)) {
			if (hitDetected.collider.tag != "Building" && hitDetected .collider.tag  != "Untagged") {
					// This gets the script from the object that it hits. 
					tempScript = hitDetected.collider.GetComponent <Car>();
					
				GUI.Box (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 150, 150), "Car Information \n");					
					GUI.Label (new Rect (Input.mousePosition.x, Screen.height-Input.mousePosition.y + 20, 100, 100), 
					"Car Type: " + tempScript.carTypeString +
					" \nCar Color: "  + tempScript.colorString +
					" \nCar Size : "  + tempScript.sizeString, boxInformation);
				} 
			}
	

		// This is going to create a label with a rectangle size with the appropriate guiStyle along with the current time after retreiving it from update
        GUI.Label(new Rect(Screen.width / 2, 0, 150, 20), time, guiStyle);
        // This displays cash on GUI
        string moneyString = "$" + gameMgr.cash;
        GUI.Label(new Rect(Screen.width - 100, 0, 150, 20), moneyString, guiCash);
 
		// This outside if statement checks for if the GUI buttons should be shown onto the screen or not.
		// This checks if the security button was not pressed
		if ( (shopScript.getShopOpen() == false) && (shopScript.getSecurityType() == " ")){
			// This checks if the showSettings button was not pushed
			if (showSettings == false) 	{
						
					// Otherwise, place an interactable GUI button onto the screen called OpenShop
					if (GUI.Button (new Rect (Screen.width - 100, 35, 100, 50), "Open Shop")) {
						// This will set the shopMenu Script to be true, in which it will display the appropriate GUI
						shopScript.setShopOpen (true);
						
					}

					// Or check if the user interacts with the GUI button called settings on the screen
					if (GUI.Button (new Rect (5, 5, 75, 50), "Settings")) {
						
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

					// Calls the save functionality for the gameMgr
					gameMgr.saveData ();					
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

		if (shopScript.getSecurityType () == "FL1" || shopScript.getSecurityType() == "FL2") {
			placingSecurity = true;
			// This will branch into placing a security gate onto the map
			if (placingSecurity == true) {
				// This checks if the user pressed the G key on the keyboard
				if (Input.GetMouseButtonDown(1)) {
					// Create a ray object, and have it trace the mousePosition from top down
					Ray vRay = myCam.ScreenPointToRay (Input.mousePosition);

					// Create a hit variable that will store the value of whatever it hits
					RaycastHit hit;
						
					// Cast a raycast from the starting position of the mouse down infinitely
					if (Physics.Raycast (vRay, out hit, Mathf.Infinity)) {

						if (hit.collider.tag == "Building") {
							// These are the values for car color that it will detect what car colors are allowed
							bool red = shopScript.red;
							bool blue = shopScript.blue;
							bool green = shopScript.green;

							// These are the values for the size of the car which the gate will detect
							bool large = shopScript.large;
							bool median = shopScript.median;
							bool small = shopScript.small;

							// This is the toggle boolean variables for the different types of car user can choose from
							bool ambulance = shopScript.ambulance;
							bool fireTruck= shopScript.fireTruck;
							bool Tanker= shopScript.Tanker;
							bool Truck= shopScript.Truck;
							bool Hearse= shopScript.Hearse;
							bool IceCream= shopScript.IceCream;
							bool policeCar= shopScript.policeCar;


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

							obj.GetComponent <Security> ().setTypes (ambulance, fireTruck, Tanker, Truck, Hearse, IceCream, policeCar);
							obj.GetComponent <Security> ().setColors (red, green, blue);
							obj.GetComponent <Security> ().setSize (small, median, large);
							obj.GetComponent <Security> ().setSecurityType (shopScript.getSecurityType());

							// Change the position of it so it will be placed a little bit above the road level
							obj.transform.position = new Vector3 (placePosition.x, 0.6f, placePosition.z);	
								
							// Set the placing security to false, in which it won't let the user keep pressing g for more security gates
							placingSecurity = false;
							shopScript.clear ();
						}
					}
				}	
			}
		}



        if (shopScript.getSecurityType() == "HL1"){
           
        }



		if (shopScript.getShopOpen () == true) {
			Time.timeScale = 0;
		}
	}
}

