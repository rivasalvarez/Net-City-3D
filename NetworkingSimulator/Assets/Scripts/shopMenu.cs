using UnityEngine;
using System.Collections;

public class shopMenu : MonoBehaviour {
	private bool shopOpen; // This is to check if the shop has been opened and ready to show it to the user
	private GameObject player; // This is to check for player manipulation, cash, levels etc.
	private int security_one_cost; // This is the amount the player has to pay for security level 1 upgrade
	private int security_two_cost; // This is the amount the player has to pay for security level 2 upgrade
	private int security_three_cost; // This is the amount the player has to pay for security level 2 upgrade
	private Vector2 button_size; // This is the size of the buttons for each of the security upgrades
	private GUIStyle guiStyle; // This will hold the type of GUI options for the buttons and etc

	// Use this for initialization
	void Start () {
		// This is going to initialize all of the variables at the get go
		shopOpen = false; // The shop will be closed from the very beginning unless otherwise noted
		security_one_cost = 400; // This is the amount the player has to pay for security level 1 upgrade
		security_two_cost = 800; // This is the amount the player has to pay for security level 2 upgrade
		security_three_cost = 1200; // This is the amount the player has to pay for security level 2 upgrade
		button_size = new Vector2(30,30); // This is the size of the buttons for each of the security upgrades
		guiStyle = new GUIStyle(); // Allocate memory to the gui Style Variable

		// Change the font size to 20
		guiStyle.fontSize = 20;

		// Change the color to white
		guiStyle.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (shopOpen == true) {
			// Otherwise, place an interactable GUI button onto the screen called OpenShop
			GUI.BeginGroup(new Rect(Screen.width/2 - 400, Screen.height/2 -300, 800, 600));

			// This is to contain all of the different buying options
			GUI.Box (new Rect (0, 0, 800, 600), "Shop");

			// This button is here for upgrading to security option 1
			if (GUI.Button (new Rect (Screen.width/2 - 500, Screen.height/2 -150, 100,50), "Clickable")) {
				print ("This is working");
			}

			// This button is here for upgrading to security option 2
			if (GUI.Button (new Rect (Screen.width/2 - 300, Screen.height/2 -150, 100,50), "Clickable")) {
				print ("This is working");
			}

			// This button is here for upgrading to security option 3
			if (GUI.Button (new Rect (Screen.width/2 - 100, Screen.height/2 -150, 100,50), "Clickable")) {
				print ("This is working");
			}

			// This button is here to close down the shop and place the old GUI buttons on the screen
			if (GUI.Button (new Rect ( Screen.width/2, Screen.height -100, 100,50), "Close Shop")) {
				setShopOpen (false);
				print ("Closing down Shop");
			}

			// necessary function call for beginGroup
			GUI.EndGroup ();	
		}
	}


	/**
	 * Function that sets the boolean value for shopOpen
	 * @param: Requires a boolean to be set to
	 * @pre: None, requires initialized boolean variable of true or false
	 * @post: Sets shopOpen to if the user clicked on the gui
	 * @algorithm: Sets whatever came in from the parameter to true or false 
	 */ 
	public void setShopOpen(bool set){
		shopOpen = set;
	}


	/**
	 * Function that gets the boolean value for shopOpen
	 * @param: None
	 * @pre: None, requires initialized boolean variable of true or false
	 * @post: None
	 * @algorithm: Gets whatever shopOpen was set to 
	 */ 
	public bool getShopOpen(){
		return shopOpen;
	}
}
