using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shopMenu : MonoBehaviour {
	private bool shopOpen; // This is to check if the shop has been opened and ready to show it to the user
	private GameObject player; // This is to check for player manipulation, cash, levels etc.
	private int security_one_cost; // This is the amount the player has to pay for security level 1 upgrade
	private int security_two_cost; // This is the amount the player has to pay for security level 2 upgrade
	private int security_three_cost; // This is the amount the player has to pay for security level 2 upgrade
	public GUIStyle guiStyle; // This will hold the type of GUI options for the buttons and etc


	// This is for the location of the button only for upgrades and for the purpose of organization
	private int upgradeOneGUIRow;
	private int upgradeTwoGUIRow;
	private int upgradeThreeGUIRow;

	// This is for the y location of the buttons for the upgrades and organization
	private int upgradeOneGUICol;
	private int upgradeTwoGUICol;
	private int upgradeThreeGUICol;

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

	GUIStyle guiCash;


	// Use this for initialization
	void Start () {
		// This is going to initialize all of the variables at the get go
		shopOpen = false; // The shop will be closed from the very beginning unless otherwise noted
		security_one_cost = 75; // This is the amount the player has to pay for security level 1 upgrade
		security_two_cost = 75*2; // This is the amount the player has to pay for security level 2 upgrade
		security_three_cost = 75*3; // This is the amount the player has to pay for security level 2 upgrade
		guiStyle = new GUIStyle(); // Allocate memory to the gui Style Variable

		// This is to allocate new GUISTYLE to the cash, and set its appropriate information
		guiCash =  new GUIStyle();
		guiCash.fontSize = 20;
		guiCash.normal.textColor = Color.green;

		playerCash = 0;

		// Change the font size to 20
		guiStyle.fontSize = 20;

		// Change the color to white
		guiStyle.normal.textColor = Color.white;

		// This is to set the current x and y boundaries of the gui's
		upgradeOneGUIRow =  10;
		upgradeTwoGUIRow = 200;
		upgradeThreeGUIRow  = 400;

		upgradeOneGUICol = 30;
		upgradeTwoGUICol = 230;
		upgradeThreeGUICol = 430;


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


		if (shopOpen == true) {

			// Otherwise, place an interactable GUI button onto the screen called OpenShop
			GUI.BeginGroup(new Rect(Screen.width/2 - 400, Screen.height/2 -300, 800, 800));

			if (upgradeChosen) {
				if (securityType == "FL1") {

					GUI.Box (new Rect (0, 0, 700, 800), "Purchase Options");

					ambulance  = GUI.Toggle (new Rect (10, 40, 100, 30), ambulance, "Ambulance");
					fireTruck = GUI.Toggle (new Rect (10, 140, 100, 30), fireTruck, "fireTruck");
					Tanker = GUI.Toggle (new Rect (10, 240, 100, 30), Tanker, "Tanker");
					Truck =GUI.Toggle (new Rect (10, 340, 100, 30), Truck, "Truck"); 
					Hearse = GUI.Toggle (new Rect (10, 440, 100, 30), Hearse, "Hearse");
					IceCream = GUI.Toggle (new Rect (10, 540, 100, 30), IceCream, "IceCream");
					policeCar = GUI.Toggle (new Rect (10, 640, 100, 30), policeCar, "policeCar");
					Taxi = GUI.Toggle (new Rect (10, 740, 100, 30), Taxi, "Taxi");;

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
						red = GUI.Toggle (new Rect (140, 40, 100, 30), red, "Red");
						green = GUI.Toggle (new Rect (140, 140, 100, 30), green, "Green");
						blue = GUI.Toggle (new Rect (140, 240, 100, 30), blue, "Blue");
						yellow = GUI.Toggle (new Rect (140, 340, 100, 30), yellow, "Yellow");

						// This checks if at least one of the option for each of the things has been checked
						if ((red && !blue && !green && !yellow) || (!red && blue && !green && !yellow) || (!red && !blue && green &&!yellow) || (!red && !blue && !green && yellow)) {
							// This is the toggle gui button that will check what size to check for based on user preferance
							small = GUI.Toggle (new Rect (240, 40, 100, 30), small, "Small");
							median = GUI.Toggle (new Rect (240, 140, 100, 30), median, "Medium");
							large = GUI.Toggle (new Rect (240, 240, 100, 30), large, "Large");

							// This checks if an option is picked
							if ((small && !median && !large) || (!small && median && !large) || (!small && !median && large)) {
								{
									if (GUI.Button (new Rect (240, 400 - (128 * 2) + 128, 128, 50), "Purchase")) {
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
					if (GUI.Button (new Rect (240, 400-128 + 128, 128, 50), "Cancel Purchase")) {
						clear ();
						upgradeChosen = false;
						Time.timeScale = 1;

					}
				}

				if (securityType == "FL2") {
					GUI.Box (new Rect (0, 0, 700, 800), "Purchase Options");

					ambulance  = GUI.Toggle (new Rect (10, 40, 100, 30), ambulance, "Ambulance");
					fireTruck = GUI.Toggle (new Rect (10, 140, 100, 30), fireTruck, "fireTruck");
					Tanker = GUI.Toggle (new Rect (10, 240, 100, 30), Tanker, "Tanker");
					Truck =GUI.Toggle (new Rect (10, 340, 100, 30), Truck, "Truck"); 
					Hearse = GUI.Toggle (new Rect (10, 440, 100, 30), Hearse, "Hearse");
					IceCream = GUI.Toggle (new Rect (10, 540, 100, 30), IceCream, "IceCream");
					policeCar = GUI.Toggle (new Rect (10, 640, 100, 30), policeCar, "policeCar");
					Taxi = GUI.Toggle (new Rect (10, 740, 100, 30), Taxi, "Taxi");;

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

						red = GUI.Toggle (new Rect (140, 40, 100, 30), red, "Red");
						green = GUI.Toggle (new Rect (140, 140, 100, 30), green, "Green");
						blue = GUI.Toggle (new Rect (140, 240, 100, 30), blue, "Blue");
						yellow = GUI.Toggle (new Rect (140, 340, 100, 30), yellow, "Yellow");

						if ((red && blue && !green && !yellow) || (red && !blue && green && !yellow) || (red && !blue &&  !green && yellow)||
										(!red && blue && green && !yellow) || (!red && blue && !green && yellow) 
										|| (!red && !blue && green && yellow)) {
							small = GUI.Toggle (new Rect (240, 40, 100, 30), small, "Small");
							median = GUI.Toggle (new Rect (240, 140, 100, 30), median, "Medium");
							large = GUI.Toggle (new Rect (240, 240, 100, 30), large, "Large");

							if ((small && median && !large) || (!small && median && large) || (small && !median && large)) {
								{
									if (GUI.Button (new Rect (240, 400 - (128 * 2) + 128, 128, 50), "Purchase")) {
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
					if (GUI.Button (new Rect (240, 400-128 + 128, 128, 50), "Cancel Purchase")) {
						clear ();
						upgradeChosen = false;
						Time.timeScale = 1;

					}

				}


				if (securityType == "FL3") {
					GUI.Box (new Rect (0, 0, 400, 300), " ");
					red =  blue =  green = yellow = large = median =  small = ambulance = fireTruck= Tanker= Truck=  Hearse= IceCream= policeCar=  Taxi= true;

					if (GUI.Button (new Rect ( 150,100, 128, 50), "Purchase")) {
								if (playerCash >= security_three_cost) {
									playerCash -= security_three_cost;
									upgradeChosen = false;
									shopOpen = false;
									Time.timeScale = 1;
								}
							}
						
					if (GUI.Button (new Rect (150, 100+ 60, 128, 50), "Cancel Purchase")) {
						clear ();
						upgradeChosen = false;
						Time.timeScale = 1;

					}

				}

				if (securityType == "HL1") {
                    GUI.Box(new Rect(0, 0, 700, 700), "Purchase Options");
                    honeyLevel = 1;

                    red = GUI.Toggle(new Rect(140, 40, 100, 30), red, "Red");
                    green = GUI.Toggle(new Rect(140, 140, 100, 30), green, "Green");
                    blue = GUI.Toggle(new Rect(140, 240, 100, 30), blue, "Blue");
                    yellow = GUI.Toggle(new Rect(140, 340, 100, 30), yellow, "Yellow");


                    //This is to check for what type of color the security gate will look for
                    if (red && !honeyFlags.Contains("Red"))  honeyFlags.Add("Red");
                    else if (!red && honeyFlags.Contains("Red"))  honeyFlags.Remove("Red"); 

                    else if (green && !honeyFlags.Contains("Green"))  honeyFlags.Add("Green"); 
                    else if (!green && honeyFlags.Contains("Green"))  honeyFlags.Remove("Green"); 

                    else if (blue && !honeyFlags.Contains("Blue"))  honeyFlags.Add("Blue");
                    else if (!blue && honeyFlags.Contains("Blue"))  honeyFlags.Remove("Blue"); 

                    else if (yellow && !honeyFlags.Contains("Yellow"))  honeyFlags.Add("Yellow"); 
                    else if (!yellow && honeyFlags.Contains("Yellow"))  honeyFlags.Remove("Yellow"); 

                    if (GUI.Button(new Rect(240, 400 - (128 * 2) + 128, 128, 50), "Purchase")){
                        upgradeChosen = false;
                        shopOpen = false;
                        Time.timeScale = 1;
                    }

                    if (GUI.Button(new Rect(240, 400 - 128 + 128, 128, 50), "Cancel Purchase")){
                        honeyFlags.Clear();
                        upgradeChosen = false;
                        Time.timeScale = 1;

                    }

				}

				if (securityType == "HL2") {
                    GUI.Box(new Rect(0, 0, 700, 700), "Purchase Options");
                    honeyLevel = 2; 

                    red = GUI.Toggle(new Rect(10, 40, 100, 30), red, "Red");
                    green = GUI.Toggle(new Rect(10, 140, 100, 30), green, "Green");
                    blue = GUI.Toggle(new Rect(10, 240, 100, 30), blue, "Blue");
                    yellow = GUI.Toggle(new Rect(10, 340, 100, 30), yellow, "Yellow");

                    small = GUI.Toggle(new Rect(140, 40, 100, 30), small, "Small");
                    median = GUI.Toggle(new Rect(140, 140, 100, 30), median, "Meduim");
                    large = GUI.Toggle(new Rect(140, 240, 100, 30), large, "Large");


                    //This is to check for what type of color the security gate will look for
                    if (red && !honeyFlags.Contains("Red"))  honeyFlags.Add("Red");
                    else if (!red && honeyFlags.Contains("Red"))  honeyFlags.Remove("Red");

                    else if (green && !honeyFlags.Contains("Green"))  honeyFlags.Add("Green"); 
                    else if (!green && honeyFlags.Contains("Green"))  honeyFlags.Remove("Green"); 

                    else if (blue && !honeyFlags.Contains("Blue"))  honeyFlags.Add("Blue"); 
                    else if (!blue && honeyFlags.Contains("Blue"))  honeyFlags.Remove("Blue"); 

                    else if (yellow && !honeyFlags.Contains("Yellow"))  honeyFlags.Add("Yellow"); 
                    else if (!yellow && honeyFlags.Contains("Yellow"))  honeyFlags.Remove("Yellow"); 

                    else if (small && !honeyFlags.Contains("Small"))  honeyFlags.Add("Small");
                    else if (!small && honeyFlags.Contains("Small"))  honeyFlags.Remove("Small"); 

                    else if (median && !honeyFlags.Contains("Medium"))  honeyFlags.Add("Medium"); 
                    else if (!median && honeyFlags.Contains("Medium"))  honeyFlags.Remove("Medium"); 

                    else if (large && !honeyFlags.Contains("Large"))  honeyFlags.Add("Large"); 
                    else if (!large && honeyFlags.Contains("Large"))  honeyFlags.Remove("Large"); 

                    if (GUI.Button(new Rect(240, 400 - (128 * 2) + 128, 128, 50), "Purchase")){
                        upgradeChosen = false;
                        shopOpen = false;
                        Time.timeScale = 1;
                    }

                    if (GUI.Button(new Rect(240, 400 - 128 + 128, 128, 50), "Cancel Purchase")){
                        honeyFlags.Clear();
                        upgradeChosen = false;
                        Time.timeScale = 1;

                    }

				}


                if (securityType == "HL3")
                {
                    GUI.Box(new Rect(0, 0, 700, 700), "Purchase Options");
                    honeyLevel = 3;

                    red = GUI.Toggle(new Rect(10, 40, 100, 30), red, "Red");
                    green = GUI.Toggle(new Rect(10, 140, 100, 30), green, "Green");
                    blue = GUI.Toggle(new Rect(10, 240, 100, 30), blue, "Blue");
                    yellow = GUI.Toggle(new Rect(10, 340, 100, 30), yellow, "Yellow");

                    small = GUI.Toggle(new Rect(140, 40, 100, 30), small, "Small");
                    median = GUI.Toggle(new Rect(140, 140, 100, 30), median, "Meduim");
                    large = GUI.Toggle(new Rect(140, 240, 100, 30), large, "Large");

                    ambulance = GUI.Toggle(new Rect(240, 40, 100, 30), ambulance, "Ambulance");
                    fireTruck = GUI.Toggle(new Rect(240, 140, 100, 30), fireTruck, "Fire Truck");
                    Tanker = GUI.Toggle(new Rect(240, 240, 100, 30), Tanker, "Oil Truck");
                    Truck = GUI.Toggle(new Rect(240, 340, 100, 30), Truck, "Truck");
                    Hearse = GUI.Toggle(new Rect(240, 440, 100, 30), Hearse, "Hearse");
                    IceCream = GUI.Toggle(new Rect(240, 540, 100, 30), IceCream, "Ice Cream Truck");
                    policeCar = GUI.Toggle(new Rect(240, 640, 100, 30), policeCar, "Police Car");


                    //This is to check for what type of color the security gate will look for
                    if (red && !honeyFlags.Contains("Red"))  honeyFlags.Add("Red");
                    else if (!red && honeyFlags.Contains("Red"))  honeyFlags.Remove("Red");

                    else if (green && !honeyFlags.Contains("Green"))  honeyFlags.Add("Green"); 
                    else if (!green && honeyFlags.Contains("Green"))  honeyFlags.Remove("Green"); 

                    else if (blue && !honeyFlags.Contains("Blue")) honeyFlags.Add("Blue"); 
                    else if (!blue && honeyFlags.Contains("Blue")) honeyFlags.Remove("Blue"); 

                    else if (yellow && !honeyFlags.Contains("Yellow"))  honeyFlags.Add("Yellow"); 
                    else if (!yellow && honeyFlags.Contains("Yellow"))  honeyFlags.Remove("Yellow");

                    else if (small && !honeyFlags.Contains("Small"))  honeyFlags.Add("Small"); 
                    else if (!small && honeyFlags.Contains("Small"))  honeyFlags.Remove("Small"); 

                    else if (median && !honeyFlags.Contains("Medium"))  honeyFlags.Add("Medium"); 
                    else if (!median && honeyFlags.Contains("Medium"))  honeyFlags.Remove("Medium"); 

                    else if (large && !honeyFlags.Contains("Large")) honeyFlags.Add("Large"); 
                    else if (!large && honeyFlags.Contains("Large")) honeyFlags.Remove("Large");

                    else if (ambulance && !honeyFlags.Contains("Ambulance"))  honeyFlags.Add("Ambulance"); 
                    else if (!ambulance && honeyFlags.Contains("Ambulance"))  honeyFlags.Remove("Ambulance"); 

                    else if (fireTruck && !honeyFlags.Contains("Fire Truck"))  honeyFlags.Add("Fire Truck"); 
                    else if (!fireTruck && honeyFlags.Contains("Fire Truck"))  honeyFlags.Remove("Fire Truck"); 

                    else if (Tanker && !honeyFlags.Contains("Tanker"))  honeyFlags.Add("Tanker");
                    else if (!Tanker && honeyFlags.Contains("Tanker"))  honeyFlags.Remove("Tanker"); 

                    else if (Truck && !honeyFlags.Contains("Truck"))  honeyFlags.Add("Truck"); 
                    else if (!Truck && honeyFlags.Contains("Truck"))  honeyFlags.Remove("Truck"); 

                    else if (Hearse && !honeyFlags.Contains("Hearse"))  honeyFlags.Add("Hearse"); 
                    else if (!Hearse && honeyFlags.Contains("Hearse"))  honeyFlags.Remove("Hearse"); 

                    else if (IceCream && !honeyFlags.Contains("Ice Cream"))  honeyFlags.Add("Ice Cream"); 
                    else if (!IceCream && honeyFlags.Contains("Ice Cream"))  honeyFlags.Remove("Ice Cream");

                    else if (policeCar && !honeyFlags.Contains("Police Car"))  honeyFlags.Add("Police Car"); 
                    else if (!policeCar && honeyFlags.Contains("Police Car"))  honeyFlags.Remove("Police Car"); 


                    if (GUI.Button(new Rect(340, 400 - (128 * 2) + 128, 128, 50), "Purchase"))
                    {
                        upgradeChosen = false;
                        shopOpen = false;
                        Time.timeScale = 1;
                    }

                    if (GUI.Button(new Rect(340, 400 - 128 + 128, 128, 50), "Cancel Purchase"))
                    {
                        honeyFlags.Clear();
                        upgradeChosen = false;
                        Time.timeScale = 1;

                    }

                }

			}
			else {
				// This is to contain all of the different buying options
				GUI.Box (new Rect (0, 0, 800, 600), "Shop");

				// This displays cash on GUI
				string moneyString = "$" + playerCash;
				GUI.Label(new Rect(Screen.width - 100, 0, 150, 20), moneyString, guiCash);

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
				if (GUI.Button (new Rect (upgradeOneGUIRow, upgradeOneGUICol + 128, 128, 50), "Security One")) {
					securityType = "FL1";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 2
				if (GUI.Button (new Rect (upgradeOneGUIRow, upgradeTwoGUICol + 128, 128, 50), "HoneyPot One")) {
					securityType = "HL1";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 1
				if (GUI.Button (new Rect (upgradeTwoGUIRow, upgradeOneGUICol + 128, 128, 50), "Security Two")) {
					securityType = "FL2";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 2
				if (GUI.Button (new Rect (upgradeTwoGUIRow, upgradeTwoGUICol + 128, 128, 50), "HoneyPot Two")) {
					securityType = "HL2";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 1
				if (GUI.Button (new Rect (upgradeThreeGUIRow, upgradeOneGUICol + 128, 128, 50), "Security Three")) {
					securityType = "FL3";
					upgradeChosen = true;
				}

				// This button is here for upgrading to security option 2
                if (GUI.Button(new Rect(upgradeThreeGUIRow, upgradeTwoGUICol + 128, 128, 50), "HoneyPot Three")){
                    securityType = "HL3";
                    upgradeChosen = true;
				}

				// This button is here to close down the shop and place the old GUI buttons on the screen
				if (GUI.Button (new Rect (800 - 128, upgradeThreeGUICol + 118, 128, 50), "Close Shop")) {
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