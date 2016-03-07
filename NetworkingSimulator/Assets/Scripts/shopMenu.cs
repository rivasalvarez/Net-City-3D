using UnityEngine;
using System.Collections;

public class shopMenu : MonoBehaviour {
	private bool shopOpen; // This is to check if the shop has been opened and ready to show it to the user
	private GameObject player; // This is to check for player manipulation, cash, levels etc.
	private int security_one_cost; // This is the amount the player has to pay for security level 1 upgrade
	private int security_two_cost; // This is the amount the player has to pay for security level 2 upgrade
	private int security_three_cost; // This is the amount the player has to pay for security level 2 upgrade
	private Vector2 button_size; // This is the size of the buttons for each of the security upgrades


	// Use this for initialization
	void Start () {
		// This is going to initialize all of the variables at the get go
		shopOpen = false; // The shop will be closed from the very beginning unless otherwise noted
	//	player = new LoaderUser(); // This is to check for player manipulation, cash, levels etc.
		security_one_cost = 400; // This is the amount the player has to pay for security level 1 upgrade
		security_two_cost = 800; // This is the amount the player has to pay for security level 2 upgrade
		security_three_cost = 1200; // This is the amount the player has to pay for security level 2 upgrade
		button_size = new Vector2(30,30); // This is the size of the buttons for each of the security upgrades


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (shopOpen == true) {


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
