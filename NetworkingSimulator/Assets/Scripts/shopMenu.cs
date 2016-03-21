using UnityEngine;
using System.Collections;

public class shopMenu : MonoBehaviour {
	private bool shopOpen; // This is to check if the shop has been opened and ready to show it to the user
	private GameObject player; // This is to check for player manipulation, cash, levels etc.
	private int security_one_cost; // This is the amount the player has to pay for security level 1 upgrade
	private int security_two_cost; // This is the amount the player has to pay for security level 2 upgrade
	private int security_three_cost; // This is the amount the player has to pay for security level 2 upgrade
	private GUIStyle guiStyle; // This will hold the type of GUI options for the buttons and etc

	// This is for the location of the button only for upgrades and for the purpose of organization
	private int upgradeOneGUIRow;
	private int upgradeGUICol;
	private int upgradeTwoGUIRow;
	private int upgradeThreeGUIRow;

	// This will be for the size of the GUI buttons
	private int guiWidth;
	private int guiHeight;

	// This is the images for each of the different security types
	Texture2D securityOneImage;
	Texture2D securityTwoImage;
	Texture2D securityThreeImage;

	// This is the content for which the images will be held to
	GUIContent securityOneImageContainer;
	GUIContent securityTwoImageContainer;
	GUIContent securityThreeImageContainer;

	// Use this for initialization
	void Start () {
		// This is going to initialize all of the variables at the get go
		shopOpen = false; // The shop will be closed from the very beginning unless otherwise noted
		security_one_cost = 400; // This is the amount the player has to pay for security level 1 upgrade
		security_two_cost = 800; // This is the amount the player has to pay for security level 2 upgrade
		security_three_cost = 1200; // This is the amount the player has to pay for security level 2 upgrade
		guiStyle = new GUIStyle(); // Allocate memory to the gui Style Variable


		// Change the font size to 20
		guiStyle.fontSize = 20;

		// Change the color to white
		guiStyle.normal.textColor = Color.white;

		upgradeOneGUIRow = (Screen.width/2)-500;
		upgradeGUICol = (Screen.height/2)-150;
		upgradeTwoGUIRow = (Screen.width/2)-300;
		upgradeThreeGUIRow  = (Screen.width/2)- 100;

		// Initialize the images
		securityOneImage = 	(Texture2D) Resources.Load ("Images/security");

		securityOneImageContainer = new GUIContent();
		securityOneImageContainer.image = securityOneImage;
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

			// This is for the image of the first security gate upgrade
			GUI.Button (new Rect (upgradeOneGUIRow, upgradeGUICol-150, 128, 128), securityOneImageContainer);

			// This is for the image of the second security gate upgrade
			GUI.Button (new Rect (upgradeTwoGUIRow, upgradeGUICol-150, 128, 128), securityOneImageContainer);

			// This is for the image of the third security gate upgrade
			GUI.Button (new Rect (upgradeThreeGUIRow, upgradeGUICol-150, 128, 128), securityOneImageContainer);

			// This button is here for upgrading to security option 1
			if (GUI.Button (new Rect (upgradeOneGUIRow, upgradeGUICol, 100,50), "Firewall")) {
				print ("This is working");
			}

			// This button is here for upgrading to security option 2
			if (GUI.Button (new Rect (upgradeTwoGUIRow, upgradeGUICol, 100,50), "Honey Pot")) {
				print ("This is working");
			}

			// This button is here for upgrading to security option 3
			if (GUI.Button (new Rect (upgradeThreeGUIRow, upgradeGUICol, 100,50), "IDS")) {
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
