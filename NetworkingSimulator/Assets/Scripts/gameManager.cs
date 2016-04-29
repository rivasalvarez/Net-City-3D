// @Author: Sajid, Ortega, Rivas
// This is the main class which calls the different classes such as security, road, highway, etc
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;


public class gameManager : MonoBehaviour {
	
    // Dictionaries
	public Dictionary<int, string> carSizeDict = new Dictionary<int, string>();
	public Dictionary<int, string> carTypeDict = new Dictionary<int, string>();
	public Dictionary<int, string> carColorDict = new Dictionary<int, string>();
	public Dictionary<int, string> carPrefabDict = new Dictionary<int, string>();
	public Dictionary<string, int> carMoneyDict = new Dictionary<string, int>();

    // Car Spawn obj, pos, timer, type
	public Vector3[] carStartPosArray;
	float timer = 10;
	public int carStartIndex;
	public int carType;
    public Color[] colorArray;

	// These variables will be used for file I/O in terms of C#
	private string fileName ; // The name of the file that will be created, it will be the same name as the user, except with a .txt at the end
	private string username; // This will be used to show the name of the user
	private string password; // This will be used to check if the user is who he says it is, after getting the first line from the file

	// These are the different list for each and everything within that specific level
	public List<Security> securityGates = new List<Security>() ;
    public List<HoneyPot> honeyPots = new List<HoneyPot>();
    public int honeyCount = 0;

	// Player variable information pertaining to the level
	public int cash = 300;
	int securityLevel;
    public bool gameIsStarted = false;
    public int count = 0;

	bool levelLoaded; // This is used to tell the different tutorial that a profile has been loaded

	// These are the values for the car color that might be bad based on the professor preference
	public bool red;
	public bool blue;
	public bool green;
	public bool yellow;

	// These are the values for the car size that might be bad based on the professor preference	\
	public bool large;
	public bool median;
	public bool small;

	// Bool if the bad car upgrades have been chosen
	public bool badCarsChosen;

	// These variables are used for toggling what the professor wants in terms of the type of car it is
	public bool ambulance;
	public bool fireTruck;
	public bool Tanker;
	public bool Truck;
	public bool Hearse;
	public bool IceCream;
	public bool policeCar;
	public bool Taxi;

    AudioSource Background;


	// Function that makes sure the script that the object is attached to stays alive
	void Awake(){
		// Don't destroy this object, self explanatory
		DontDestroyOnLoad (this);
	}

	/**
	 * Starting function for the player manager class, in which it guides the overall game. Loads thing based on circumstances received from the file
	 * @param: None
	 * @pre: None, initial object
	 * @post: Loads the specific tutorial based on new user or old user
	 * @algorithm: Checks to see if at the selection menu, if so, loads the first level possible within the game, otherwise, it loads the level the user was at last 
	 */ 
	void Start () {
        cash = 300;

        Background = gameObject.AddComponent<AudioSource>();
        Background.clip = Resources.Load("Audio/Background") as AudioClip;
        Background.loop = true;
        Background.Play();

		carStartPosArray = new Vector3[3];
		carStartPosArray[0] = new Vector3 (157f, 0.6f, 0f);
		carStartPosArray[1] = new Vector3 (0f, 0.6f, 137.7f);
		carStartPosArray[2] = new Vector3 (300f, 0.6f, 152.1f);


		colorArray = new Color[4];

		colorArray[0] = Color.green;
		colorArray[1] = Color.yellow;
		colorArray[2] = Color.blue;
		colorArray[3] = Color.red;
		
		carColorDict.Add(0,"Green");
		carColorDict.Add(1,"Yellow");
		carColorDict.Add(2,"Blue");
		carColorDict.Add(3,"Red");

		carPrefabDict.Add(0,"Prefabs/Ambulance");
		carPrefabDict.Add(1,"Prefabs/FireTruck");
		carPrefabDict.Add(2,"Prefabs/Hearse");
		carPrefabDict.Add(3,"Prefabs/IceCream");
		carPrefabDict.Add(4,"Prefabs/PoliceCar");
		carPrefabDict.Add(5,"Prefabs/Tanker");
		carPrefabDict.Add(6,"Prefabs/Taxi");
		carPrefabDict.Add(7,"Prefabs/Truck");

		carTypeDict.Add(0,"Ambulance");
		carTypeDict.Add(1,"FireTruck");
		carTypeDict.Add(2,"Hearse");
		carTypeDict.Add(3,"IceCream");
		carTypeDict.Add(4,"PoliceCar");
		carTypeDict.Add(5,"Tanker");
		carTypeDict.Add(6,"Taxi");
		carTypeDict.Add(7,"Truck");

		carSizeDict.Add(0,"Meduim");
		carSizeDict.Add(1,"Large");
		carSizeDict.Add(2,"Small");
		carSizeDict.Add(3,"Meduim");
		carSizeDict.Add(4,"Small");
		carSizeDict.Add(5,"Large");
		carSizeDict.Add(6,"Small");
		carSizeDict.Add(7,"Small");

	}
	
	// Update is called once per frame, this will not be used for this project as far as my knowledge
	void Update () {
        // Spawn Car
		timer -= Time.deltaTime;
        // If game is started and car spawn timer is < 0 car will spawn
		if(timer < 0 && gameIsStarted){

            //reset timer, random type, and spawn car
			timer = UnityEngine.Random.Range(3,9);
			carType = UnityEngine.Random.Range(0,8);
			carStartIndex= UnityEngine.Random.Range(0,3);
            Instantiate(Resources.Load(carPrefabDict[carType]) as GameObject, carStartPosArray[carStartIndex], Quaternion.identity);
            count++;
		}

	}


    void OnGUI() {

    }

	// Function that saves and loads the user information to a file
	public bool loadSave(string name){

		return true;

	}

	public bool saveData(){
		if (!File.Exists (username + ".txt")) {
			// Create the text file
			StreamWriter writer = File.CreateText (username + ".txt");

			// Write the username, and then the password
			writer.WriteLine (username);
			writer.WriteLine (password);

			// Write the cash
			writer.WriteLine(cash);

			// Write that the honeyPot information is starting
			writer.WriteLine("HoneyPots");


			// Write how many honey pots were seen
			writer.WriteLine(honeyPots.Count);
			// Iterate through the list of honey pots and save its data
			foreach (var honey in honeyPots) {
				writer.WriteLine (honey.Position.x + " " + honey.Position.y + " " + honey.Position.z);

				writer.WriteLine ("CarPids");
				// This is looping through the set of car pids
				foreach (var i in honey.carPIDS) {
					writer.WriteLine( i.Key); 
					writer.WriteLine(i.Value.colorString); 
					writer.WriteLine(  i.Value.sizeString); 

					writer.WriteLine(  i.Value.carTypeString);
					writer.WriteLine(  i.Value.route);
					writer.WriteLine(  i.Value.carColor);
					writer.WriteLine(  i.Value.speed);
					writer.WriteLine(  i.Value.carPID);						
				}

				writer.WriteLine ("Strings");
				// This is looping through the list of strings
				foreach (var i in honey.Keys) {
					writer.WriteLine (i);
				}

				writer.WriteLine (honey.level + " " + honey.PID + " " + honey.upgrade);
				writer.WriteLine (honey.red + " " + honey.blue + " " + honey.yellow + " " + honey.green);
				writer.WriteLine(honey.small + " " + honey.median + " " + honey.large);
				writer.WriteLine (honey.ambulance + " " + honey.fireTruck + " " + honey.Tanker + " " + honey.Truck + " " + honey.Hearse + " " + honey.policeCar + " " + honey.IceCream);
				writer.WriteLine (honey.first);
			}

			writer.WriteLine ("SecurityGates");

			foreach (var gates in securityGates) {
				// Save the list of keys
				foreach(var i in gates.Keys){
				writer.WriteLine(i);
				}

				// Save all of the booleans
				writer.WriteLine(gates.securityType);

				writer.WriteLine(gates.red + " " + gates.green + " " + gates.blue + " " + gates.yellow);
				writer.WriteLine(gates.small + " " + gates.medium + " " + gates.large);
				writer.WriteLine(gates.ambulance + " " + gates.fireTruck + " " + gates.Tanker + " " + gates.Hearse + " " + gates.IceCream + " " + gates.policeCar + " " + gates.taxi);
				writer.WriteLine(gates.upgrade + " " + gates.level);

				// Save each of the security flags
				foreach(var i in gates.securityFlags){
					writer.WriteLine(i);
				}
			}

			writer.Close();


			print ("File saved");
			return true;
		} 
		else {
			return false;
		}
	}

	//sets and gets of user attributes
	public void setUserName(string name){
		username = name;
	}

	public void setPassword(string inPassword){
		password = inPassword;
	}

	public int getSecurityLevel (){
		return securityLevel;
	}

	public void setSecurityLevel(int newSecurityLevel){
		securityLevel = newSecurityLevel;
	}

	public int getSecurityLevelCash(){
		if (securityLevel == 0) {
			// Just provide a firewall security of sort
			return 50;
		} else if (securityLevel == 1) {
			return 90;
		} else if (securityLevel == 2) {
			return 150;
		} else   {
			return 220;
		}
			
	}

	//will check if the user exists
	public bool checkForUser(string name){
		fileName = name + ".txt";

		if (File.Exists (fileName)) {
			return true;
		} 
		return false;
	}
		
	// Set the professor information bools
	public void setGameMangerBools(bool r, bool g, bool b, bool y, bool s, bool m, bool l, bool a, bool f, bool ta, bool tr, bool h, bool p, bool i) {
		red = r; blue = b; yellow = y; green = g;
		small = s; median = m; large = l;
		ambulance = a; fireTruck = f; Tanker = ta; Truck = tr;
		Hearse = h; policeCar = p; IceCream = i;

	}


}
