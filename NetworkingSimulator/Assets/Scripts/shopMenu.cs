using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shopMenu : MonoBehaviour {
	private bool shopOpen; // This is to check if the shop has been opened and ready to show it to the user
	private GameObject player; // This is to check for player manipulation, cash, levels etc.
	private int security_one_cost; // This is the amount the player has to pay for security level 1 upgrade
	private int security_two_cost; // This is the amount the player has to pay for security level 2 upgrade
	private int security_three_cost; // This is the amount the player has to pay for security level 2 upgrade
	

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

	// String value which will detect what type of security it is. The range can be L1, L2, L3
	private string securityType;

	// These are the values for car color that it will detect what car colors are allowed
	public bool red;
	public bool blue;
	public bool green;
    public bool yellow;

	// These are the values for the size of the car which the gate will detect
	public bool large;
	public bool median;
	public bool small;

	// Bool if upgrade chosen
	public bool upgradeChosen;

	// This is the toggle boolean variables for the different types of car user can choose from
	public bool ambulance;
	public bool fireTruck;
	public bool Tanker;
	public bool Truck;
	public bool Hearse;
	public bool IceCream;
	public bool policeCar;
	public bool Taxi;

	public int playerCash;

    public List<string> honeyFlags = new List<string>();
    public int honeyLevel = 1;

	public List<string> securityFlags = new List<string>();



	// Use this for initialization
	void Start () {
		// This is going to initialize all of the variables at the get go
		shopOpen = false; // The shop will be closed from the very beginning unless otherwise noted
		security_one_cost = 75; // This is the amount the player has to pay for security level 1 upgrade
		security_two_cost = 75*2; // This is the amount the player has to pay for security level 2 upgrade
		security_three_cost = 75*3; // This is the amount the player has to pay for security level 2 upgrade

		playerCash = 0;




		// Initialize the images
		securityOneImage = 	(Texture2D) Resources.Load ("Images/FirewallIcon");
		securityTwoImage = (Texture2D)Resources.Load ("Images/HoneyPotIcon");
		securityThreeImage = (Texture2D)Resources.Load ("Images/Security");

		securityOneImageContainer = new GUIContent();
		securityOneImageContainer.image = securityOneImage;

		securityTwoImageContainer = new GUIContent();
		securityTwoImageContainer.image = securityTwoImage;

		securityThreeImageContainer = new GUIContent();
		securityThreeImageContainer.image = securityThreeImage;

		// String value is set to a default value
		securityType = " ";

		// Set default values as false
		red = false;;
		blue = false;
		green = false;
        yellow = false;
		large = false;
		median = false;
		small = false;
		upgradeChosen = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){

		int upgradeOneGUIRow =  75;
		int upgradeTwoGUIRow = 345;
		int upgradeThreeGUIRow  = 615;
		
		int upgradeOneGUICol = 50;
		int upgradeTwoGUICol = 250;
		int upgradeThreeGUICol = 450;

		GUI.skin = Resources.Load ("Buttons/ShopSkin") as GUISkin;
		GUIStyle guiStyle = GUI.skin.GetStyle ("Shop");


        int offset = 20;
        float Twidth = GUI.skin.toggle.fixedWidth;
        float Theight = 30f;


		if (shopOpen == true) {

			// Otherwise, place an interactable GUI button onto the screen called OpenShop
			GUI.BeginGroup(new Rect((Screen.width/2)-400, Screen.height/2 -300, 800, 750));

			if (upgradeChosen) {
				if (securityType == "FL1") {

					GUI.Box (new Rect (0, 0, 0, 0), "Purchase Options");

					ambulance  = GUI.Toggle (new Rect (10, 80, GUI.skin.toggle.fixedWidth, 30), ambulance, "Ambulance");
					fireTruck = GUI.Toggle (new Rect (10, 155, GUI.skin.toggle.fixedWidth, 30), fireTruck, "Fire Truck");
					Tanker = GUI.Toggle (new Rect (10, 230, GUI.skin.toggle.fixedWidth, 30), Tanker, "Tanker");
					Truck =GUI.Toggle (new Rect (10, 305, GUI.skin.toggle.fixedWidth, 30), Truck, "Truck"); 
					Hearse = GUI.Toggle (new Rect (10, 380, GUI.skin.toggle.fixedWidth, 30), Hearse, "Hearse");
					IceCream = GUI.Toggle (new Rect (10, 455, GUI.skin.toggle.fixedWidth, 30), IceCream, "Ice Cream");
					policeCar = GUI.Toggle (new Rect (10, 530, GUI.skin.toggle.fixedWidth, 30), policeCar, "Police Car");
					Taxi = GUI.Toggle (new Rect (10, 605, GUI.skin.toggle.fixedWidth, 30), Taxi, "Taxi");

					if (
						(ambulance && !fireTruck && !Tanker && !Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && fireTruck && !Tanker && !Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && Tanker && !Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && !Hearse && IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && !Hearse && !IceCream && policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && !Hearse && !IceCream && !policeCar && Taxi )) {
						// This is to check for what type of color the security gate will look for
						red = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth+20, 80, GUI.skin.toggle.fixedWidth, 30), red, "Red");
						green = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth+20, 155, GUI.skin.toggle.fixedWidth, 30), green, "Green");
						blue = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth+20, 230, GUI.skin.toggle.fixedWidth, 30), blue, "Blue");
						yellow = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth+20, 305, GUI.skin.toggle.fixedWidth, 30), yellow, "Yellow");

						// This checks if at least one of the option for each of the things has been checked
						if ((red && !blue && !green && !yellow) || (!red && blue && !green && !yellow) || (!red && !blue && green &&!yellow) || (!red && !blue && !green && yellow)) {
							// This is the toggle gui button that will check what size to check for based on user preferance
							small = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth*2+20, 80, GUI.skin.toggle.fixedWidth, 30), small, "Small");
							median = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth*2+20, 155, GUI.skin.toggle.fixedWidth, 30), median, "Medium");
							large = GUI.Toggle (new Rect (GUI.skin.toggle.fixedWidth*2+20, 230, GUI.skin.toggle.fixedWidth, 30), large, "Large");

							// This checks if an option is picked
							if ((small && !median && !large) || (!small && median && !large) || (!small && !median && large)) {
								{
									if (GUI.Button (new Rect (540, upgradeThreeGUICol + 50, GUI.skin.button.fixedWidth, 50), "Purchase")) {
										if (playerCash >= security_one_cost) {
											upgradeChosen = false;
											shopOpen = false;
											playerCash -= security_one_cost;
											Time.timeScale = 1;
										}
									}
								}
							}
						}
					}
					if (GUI.Button (new Rect (540, upgradeThreeGUICol + 118, GUI.skin.button.fixedWidth, 50), "Cancel Purchase")) {
						clear ();
						upgradeChosen = false;
						Time.timeScale = 1;

					}
				}

				if (securityType == "FL2") {
					GUI.Box (new Rect (0, 0, 700, 800), "Purchase Options");

                    ambulance = GUI.Toggle(new Rect(10, 80, GUI.skin.toggle.fixedWidth, 30), ambulance, "Ambulance");
                    fireTruck = GUI.Toggle(new Rect(10, 155, GUI.skin.toggle.fixedWidth, 30), fireTruck, "Fire Truck");
                    Tanker = GUI.Toggle(new Rect(10, 230, GUI.skin.toggle.fixedWidth, 30), Tanker, "Tanker");
                    Truck = GUI.Toggle(new Rect(10, 305, GUI.skin.toggle.fixedWidth, 30), Truck, "Truck");
                    Hearse = GUI.Toggle(new Rect(10, 380, GUI.skin.toggle.fixedWidth, 30), Hearse, "Hearse");
                    IceCream = GUI.Toggle(new Rect(10, 455, GUI.skin.toggle.fixedWidth, 30), IceCream, "Ice Cream");
                    policeCar = GUI.Toggle(new Rect(10, 530, GUI.skin.toggle.fixedWidth, 30), policeCar, "Police Car");
                    Taxi = GUI.Toggle(new Rect(10, 605, GUI.skin.toggle.fixedWidth, 30), Taxi, "Taxi");

					if (
						// For ambulances and anything matching with that one
						(ambulance && fireTruck && !Tanker && !Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(ambulance && !fireTruck && Tanker && !Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(ambulance && !fireTruck && !Tanker && Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(ambulance && !fireTruck && !Tanker && !Truck && Hearse && !IceCream && !policeCar && !Taxi) ||
						(ambulance && !fireTruck && !Tanker && !Truck && !Hearse && IceCream && !policeCar && !Taxi) ||
						(ambulance && !fireTruck && !Tanker && !Truck && !Hearse && !IceCream && policeCar && !Taxi) ||
						(ambulance && !fireTruck && !Tanker && !Truck && !Hearse && !IceCream && !policeCar && Taxi) ||
						// For firetrucks
						(!ambulance && fireTruck && Tanker && !Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && fireTruck && !Tanker && Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && fireTruck && !Tanker && !Truck && Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && fireTruck && !Tanker && !Truck && !Hearse && IceCream && !policeCar && !Taxi) ||
						(!ambulance && fireTruck && !Tanker && !Truck && !Hearse && !IceCream && policeCar && !Taxi) ||
						(!ambulance && fireTruck && !Tanker && !Truck && !Hearse && !IceCream && !policeCar && Taxi) ||

						// For tanker
						(!ambulance && !fireTruck && Tanker && Truck && !Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && Tanker && !Truck && Hearse && !IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && Tanker && !Truck && !Hearse && IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && Tanker && !Truck && !Hearse && !IceCream && policeCar && !Taxi) ||
						(!ambulance && !fireTruck && Tanker && !Truck && !Hearse && !IceCream && !policeCar && Taxi) ||

						// For truck
						(!ambulance && !fireTruck && !Tanker && Truck && Hearse && !IceCream && !policeCar && !Taxi) || 
						(!ambulance && !fireTruck && !Tanker && Truck && !Hearse && IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && Truck && !Hearse && !IceCream && policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && Truck && !Hearse && !IceCream && !policeCar && Taxi) ||

						// For Hearse
						(!ambulance && !fireTruck && !Tanker && !Truck && Hearse && IceCream && !policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && Hearse && !IceCream && policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && Hearse && !IceCream && !policeCar && Taxi) ||

						// For icecream
						(!ambulance && !fireTruck && !Tanker && !Truck && !Hearse && IceCream && policeCar && !Taxi) ||
						(!ambulance && !fireTruck && !Tanker && !Truck && !Hearse && !IceCream && policeCar && Taxi)) {

                            red = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 20, 80, GUI.skin.toggle.fixedWidth, 30), red, "Red");
                            green = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 20, 155, GUI.skin.toggle.fixedWidth, 30), green, "Green");
                            blue = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 20, 230, GUI.skin.toggle.fixedWidth, 30), blue, "Blue");
                            yellow = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 20, 305, GUI.skin.toggle.fixedWidth, 30), yellow, "Yellow");

						if ((red && blue && !green && !yellow) || (red && !blue && green && !yellow) || (red && !blue &&  !green && yellow)||
										(!red && blue && green && !yellow) || (!red && blue && !green && yellow)
                                        || (!red && !blue && green && yellow))
                        {
                            small = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 20, 80, GUI.skin.toggle.fixedWidth, 30), small, "Small");
                            median = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 20, 155, GUI.skin.toggle.fixedWidth, 30), median, "Medium");
                            large = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 20, 230, GUI.skin.toggle.fixedWidth, 30), large, "Large");

							if ((small && median && !large) || (!small && median && large) || (small && !median && large)) {
								{
									if (GUI.Button (new Rect (540, upgradeThreeGUICol + 50, GUI.skin.button.fixedWidth, 50), "Purchase")) {
										if (playerCash >= security_two_cost) {
											playerCash -= security_two_cost;
											upgradeChosen = false;
											shopOpen = false;
											Time.timeScale = 1;
										}
									}
								}
							}
						}
					}
					if (GUI.Button (new Rect (540, upgradeThreeGUICol + 118, GUI.skin.button.fixedWidth, 50), "Cancel Purchase")) {
						clear ();
						upgradeChosen = false;
						Time.timeScale = 1;

					}

				}


				if (securityType == "FL3") {
					GUI.Box (new Rect (0, 0, 400, 300), " ");
					red =  blue =  green = yellow = large = median =  small = ambulance = fireTruck= Tanker= Truck=  Hearse= IceCream= policeCar=  Taxi= true;

					if (GUI.Button (new Rect (540, upgradeThreeGUICol + 50, GUI.skin.button.fixedWidth, 50), "Purchase")) {
								if (playerCash >= security_three_cost) {
									playerCash -= security_three_cost;
									upgradeChosen = false;
									shopOpen = false;
									Time.timeScale = 1;
								}
							}
						
					if (GUI.Button (new Rect (540, upgradeThreeGUICol + 118, GUI.skin.button.fixedWidth, 50), "Cancel Purchase")) {
						clear ();
						upgradeChosen = false;
						Time.timeScale = 1;

					}

				}

                if (securityType == "HL1" || securityType == "HL2"  || securityType == "HL3"){
                    GUI.Box(new Rect(0, 0, 0, 0), "Purchase Options");
                    honeyLevel = 1;

                    red    = GUI.Toggle(new Rect(offset, 80, Twidth, Theight), red, "Red");
                    green  = GUI.Toggle(new Rect(offset, 155, Twidth, Theight), green, "Green");
                    blue   = GUI.Toggle(new Rect(offset, 230, Twidth, Theight), blue, "Blue");
                    yellow = GUI.Toggle(new Rect(offset, 305, Twidth, Theight), yellow, "Yellow");

                    //This is to check for what type of color the security gate will look for
                    if (red && !honeyFlags.Contains("Red")) honeyFlags.Add("Red");
                    else if (!red && honeyFlags.Contains("Red")) honeyFlags.Remove("Red");

                    else if (green && !honeyFlags.Contains("Green")) honeyFlags.Add("Green");
                    else if (!green && honeyFlags.Contains("Green")) honeyFlags.Remove("Green");

                    else if (blue && !honeyFlags.Contains("Blue")) honeyFlags.Add("Blue");
                    else if (!blue && honeyFlags.Contains("Blue")) honeyFlags.Remove("Blue");

                    else if (yellow && !honeyFlags.Contains("Yellow")) honeyFlags.Add("Yellow");
                    else if (!yellow && honeyFlags.Contains("Yellow")) honeyFlags.Remove("Yellow");

                    if (securityType == "HL2" || securityType == "HL3"){
                        honeyLevel = 2;

                        small  = GUI.Toggle(new Rect(Twidth + offset, 80, Twidth, Theight), small, "Small");
                        median = GUI.Toggle(new Rect(Twidth + offset, 155, Twidth, Theight), median, "Meduim");
                        large  = GUI.Toggle(new Rect(Twidth + offset, 230, Twidth, Theight), large, "Large");

                        //This is to check for what type of color the security gate will look for
                        if (small && !honeyFlags.Contains("Small")) honeyFlags.Add("Small");
                        else if (!small && honeyFlags.Contains("Small")) honeyFlags.Remove("Small");

                        else if (median && !honeyFlags.Contains("Medium")) honeyFlags.Add("Medium");
                        else if (!median && honeyFlags.Contains("Medium")) honeyFlags.Remove("Medium");

                        else if (large && !honeyFlags.Contains("Large")) honeyFlags.Add("Large");
                        else if (!large && honeyFlags.Contains("Large")) honeyFlags.Remove("Large");

                    }

                    if (securityType == "HL3"){
                        honeyLevel = 3;

                        ambulance = GUI.Toggle(new Rect(Twidth * 2 + offset, 80, Twidth, Theight), ambulance, "Ambulance");
                        fireTruck = GUI.Toggle(new Rect(Twidth * 2 + offset, 155, Twidth, Theight), fireTruck, "Fire Truck");
                        Tanker    = GUI.Toggle(new Rect(Twidth * 2 + offset, 230, Twidth, Theight), Tanker, "Oil Truck");
                        Truck     = GUI.Toggle(new Rect(Twidth * 2 + offset, 305, Twidth, Theight), Truck, "Truck");
                        Hearse    = GUI.Toggle(new Rect(Twidth * 2 + offset, 380, Twidth, Theight), Hearse, "Hearse");
                        IceCream  = GUI.Toggle(new Rect(Twidth * 2 + offset, 455, Twidth, Theight), IceCream, "Ice Cream");
                        policeCar = GUI.Toggle(new Rect(Twidth * 2 + offset, 530, Twidth, Theight), policeCar, "Police Car");

                        //This is to check for what type of color the security gate will look for
                        if (ambulance && !honeyFlags.Contains("Ambulance")) honeyFlags.Add("Ambulance");
                        else if (!ambulance && honeyFlags.Contains("Ambulance")) honeyFlags.Remove("Ambulance");

                        else if (fireTruck && !honeyFlags.Contains("Fire Truck")) honeyFlags.Add("Fire Truck");
                        else if (!fireTruck && honeyFlags.Contains("Fire Truck")) honeyFlags.Remove("Fire Truck");

                        else if (Tanker && !honeyFlags.Contains("Tanker")) honeyFlags.Add("Tanker");
                        else if (!Tanker && honeyFlags.Contains("Tanker")) honeyFlags.Remove("Tanker");

                        else if (Truck && !honeyFlags.Contains("Truck")) honeyFlags.Add("Truck");
                        else if (!Truck && honeyFlags.Contains("Truck")) honeyFlags.Remove("Truck");

                        else if (Hearse && !honeyFlags.Contains("Hearse")) honeyFlags.Add("Hearse");
                        else if (!Hearse && honeyFlags.Contains("Hearse")) honeyFlags.Remove("Hearse");

                        else if (IceCream && !honeyFlags.Contains("Ice Cream")) honeyFlags.Add("Ice Cream");
                        else if (!IceCream && honeyFlags.Contains("Ice Cream")) honeyFlags.Remove("Ice Cream");

                        else if (policeCar && !honeyFlags.Contains("Police Car")) honeyFlags.Add("Police Car");
                        else if (!policeCar && honeyFlags.Contains("Police Car")) honeyFlags.Remove("Police Car");
                    }

                  if (GUI.Button(new Rect(540, upgradeThreeGUICol + 125, GUI.skin.button.fixedWidth, 50), "Purchase")){
                     upgradeChosen = false;
                     shopOpen = false;
                     Time.timeScale = 1;
                  }

                 if (GUI.Button(new Rect(540, upgradeThreeGUICol + 185, GUI.skin.button.fixedWidth, 50), "Cancel Purchase")){
                            honeyFlags.Clear();
                            clear();
                            upgradeChosen = false;
                            Time.timeScale = 1;
                 }
               }
			}

			else {
				// This is to contain all of the different buying options
				GUI.Box (new Rect (0, 0, 800, 1000), "Shop");

				// First set of upgrades for the security for the pictures
				GUI.Label (new Rect (upgradeOneGUIRow, upgradeOneGUICol, 128, 128), securityOneImageContainer);
				GUI.Label (new Rect (upgradeOneGUIRow, upgradeTwoGUICol, 128, 128), securityTwoImageContainer);

				// This is the second set of upgrades for the pictures
				GUI.Label (new Rect (upgradeTwoGUIRow, upgradeOneGUICol, 128, 128), securityOneImageContainer);
				GUI.Label (new Rect (upgradeTwoGUIRow, upgradeTwoGUICol, 128, 128), securityTwoImageContainer);

				// This is the third set of upgrades for the pictures
				GUI.Label (new Rect (upgradeThreeGUIRow, upgradeOneGUICol, 128, 128), securityOneImageContainer);
				GUI.Label (new Rect (upgradeThreeGUIRow, upgradeTwoGUICol, 128, 128), securityTwoImageContainer);



				// This button is here for upgrading to security option 1
				if (GUI.Button (new Rect (10, upgradeOneGUICol + 128, GUI.skin.button.fixedWidth, 50), "Firewall One")) {
					securityType = "FL1";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 2
				if (GUI.Button (new Rect (10, upgradeTwoGUICol + 128,GUI.skin.button.fixedWidth, 50), "HoneyPot One")) {
					securityType = "HL1";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 1
				if (GUI.Button (new Rect (270, upgradeOneGUICol + 128, GUI.skin.button.fixedWidth, 50), "Firewall Two")) {
					securityType = "FL2";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 2
				if (GUI.Button (new Rect (270, upgradeTwoGUICol + 128, GUI.skin.button.fixedWidth, 50), "HoneyPot Two")) {
					securityType = "HL2";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 1
				if (GUI.Button (new Rect (540, upgradeOneGUICol + 128, GUI.skin.button.fixedWidth, 50), "Firewall Three")) {
					securityType = "FL3";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 2
				if (GUI.Button(new Rect(540, upgradeTwoGUICol + 128, GUI.skin.button.fixedWidth, 50), "HoneyPot Three")){
                    securityType = "HL3";
                    upgradeChosen = true;
				}

				// This button is here to close down the shop and place the old GUI buttons on the screen
				if (GUI.Button (new Rect (540, upgradeThreeGUICol + 118, GUI.skin.button.fixedWidth, 50), "Close Shop")) {
					shopOpen = false;
					upgradeChosen = false;
					clear ();
					print (securityType);
					Time.timeScale = 1;
					print ("Closing down Shop");
				}
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

	public string getSecurityType(){
		return securityType;
	}

	public void clear(){
		ambulance = fireTruck = Tanker = Truck = Hearse = IceCream = policeCar = red = green = blue = small = median = yellow =  large = Taxi = false;
		securityType = " ";
	}
}