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
    public List<Car> activeCars = new List<Car>();
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

	// This is a boolean to check if the game manager should load the data
	bool userFound;

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

		userFound = false;
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

		// This checks if the loaded level is 4, which should be tutorial 01
		if (Application.loadedLevel == 4 && userFound == true) {
			print("Working");
			loadSave ();
			userFound = false;
		}
	}


    void OnGUI() {

    }

	// Function that saves and loads the user information to a file
	public bool loadSave(){
		// This variable will be used to read the information form the file
		StreamReader read = new StreamReader(username + ".txt", false);
		string text = " ";

		// Read only one thing, which is the x value of the honeypot, do the same for the y and z
		string [] seperators = {"," , " "};

		// Read through each thing one at a time

		// Read in the username and assign it
		text = read.ReadLine ();
		username = text;

		// Read in the password
		text = read.ReadLine();
		password = text;

		// Read in the cash amount
		text = read.ReadLine();
		cash = int.Parse(text);

		// This should read in the HoneyPots word
		text = read.ReadLine ();

		if (text == "HoneyPots") {
			int amount = 0;
			int.TryParse(read.ReadLine(), out amount);

			for (int i = 0; i < amount; i++) {
				// Instantiate a game object that will be used to instantiate other stuff
				GameObject obj;



				//Instantiate the HoneyPot once 
				obj = Instantiate(Resources.Load("Prefabs/HoneySpoon", typeof(GameObject))) as GameObject;

				text = read.ReadLine();
				string[] ssize = text.Split (seperators, StringSplitOptions.RemoveEmptyEntries);
					

				int x = 0, y = 0, z = 0;
				for(var o = 0; o < ssize.Length; o+=1)
				{
					if (o == 0) {
						int.TryParse (ssize [o], out x);

					}

					if (o == 1) {
						int.TryParse (ssize [o], out y);

					}


					if (o == 2) {
						int.TryParse (ssize [o], out z);

					}
				}

				// Set the position of the newly instantiated honeypot to the one gained from the file
				obj.transform.position = new Vector3(x, y, z);
				text = read.ReadLine();

				// Check if the thing is car pids in order to know when to loop
				if(text =="CarPids"){
					int pids = 0;
					int.TryParse (read.ReadLine (), out pids);

					// Loop through the amount of pids
					for (int p = 0; p < pids; p++) {
						// Variable that will store key from the file
						int key = 0;

						// Will place what was read from the file into key variable
						int.TryParse (read.ReadLine (), out key);

						// Instantiate a new car object to store in the data from file
						Car tmp = new Car();

						// This is used to store the all of the different strings for carPids
						string txt = " ";

						// This will grab the colorString
						txt = read.ReadLine ();

						// Sets the car color string
						tmp.colorString = txt;

						// Sets the size
						txt = read.ReadLine ();

						// Sets the car size string
						tmp.sizeString = txt;

						// This will store the route. carColor and carPid
						int r = 0;

						// Get the route
						int.TryParse (read.ReadLine (), out r);

						// Set the route of the tmp object
						tmp.route = r;

						// Get the carColor
						int.TryParse (read.ReadLine (), out r);

						tmp.carColor = r;

						// Get the carPid
						int.TryParse (read.ReadLine (), out r);

						//Set it
						tmp.carPID = r;


						obj.GetComponent<HoneyPot> ().carPIDS.Add (key, tmp);
					}

					text = read.ReadLine ();
					
					if(text == "Strings"){
						// Variable that will store size of list of strings
						int s = 0;

						// Will place what was read from the file into key variable
						int.TryParse (read.ReadLine (), out s);

						for (int l = 0; l < s; l++) {
							text = read.ReadLine ();
							obj.GetComponent<HoneyPot> ().Keys.Add (text);
						}
					}

					// Read the level, pid, and upgrade
					text = read.ReadLine();

					ssize = text.Split (seperators, StringSplitOptions.RemoveEmptyEntries);
	
					// Loop through the array of ssize and then set the ones for level pid and upgrade
					for(var o = 0; o < ssize.Length; o+=1)
					{
						if (o == 0) {
							int.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().level);

						}

						if (o == 1) {
							int.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().PID);

						}
							
						if (o == 2) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().upgrade);

						}
					}

					// Do the same for colors
					text = read.ReadLine();

					ssize = text.Split (seperators, StringSplitOptions.RemoveEmptyEntries);

					for(var o = 0; o < ssize.Length; o+=1)
					{
						if (o == 0) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().red);

						}

						if (o == 1) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().blue);

						}

						if (o == 2) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().yellow);

						}

						if (o == 3) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().green);

						}
					}

					// Do the same thing for sizes
					text = read.ReadLine();

					ssize = text.Split (seperators, StringSplitOptions.RemoveEmptyEntries);

					for(var o = 0; o < ssize.Length; o+=1)
					{
						if (o == 0) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().small);

						}

						if (o == 1) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().median);

						}

						if (o == 2) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().large);

						}
							
					}

					// Do the same thing for sizes
					text = read.ReadLine();

					ssize = text.Split (seperators, StringSplitOptions.RemoveEmptyEntries);


					for(var o = 0; o < ssize.Length; o+=1)
					{
						if (o == 0) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().ambulance);

						}

						if (o == 1) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().fireTruck);

						}

						if (o == 2) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().Tanker);

						}

						if (o == 3) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().Truck);

						}

						if (o == 4) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().Hearse);

						}

						if (o == 5) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().policeCar);

						}
							
						if (o == 6) {
							bool.TryParse (ssize [o], out obj.GetComponent<HoneyPot> ().IceCream);

						}

					}

					// Do the same thing for sizes
					text = read.ReadLine();

					bool.TryParse(text, out obj.GetComponent<HoneyPot> ().first);
				}


/*

				writer.WriteLine (honey.level + " " + honey.PID + " " + honey.upgrade);
				writer.WriteLine (honey.red + " " + honey.blue + " " + honey.yellow + " " + honey.green);
				writer.WriteLine(honey.small + " " + honey.median + " " + honey.large);
				writer.WriteLine (honey.ambulance + " " + honey.fireTruck + " " + honey.Tanker + " " + honey.Truck + " " + honey.Hearse + " " + honey.policeCar + " " + honey.IceCream);
				writer.WriteLine (honey.first);
				*/

			}

		}
		print ("reached");
		read.Close ();


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
				// This is to record how many carpids there are
				writer.WriteLine (honey.carPIDS.Count);
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

				// Write how many strings are within each honeypot
				writer.WriteLine (honey.Keys.Count);

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
				writer.WriteLine(gates.red + " " + gates.green + " " + gates.blue + " " + gates.yellow);
				writer.WriteLine(gates.small + " " + gates.medium + " " + gates.large);
				writer.WriteLine(gates.ambulance + " " + gates.fireTruck + " " + gates.Tanker + " " + gates.Hearse + " " + gates.IceCream + " " + gates.policeCar + " " + gates.taxi);
				writer.WriteLine(gates.upgrade + " " + gates.level);

				// Save each of the security flags
				foreach(var i in gates.securityFlags){
					writer.WriteLine(i);
				}
			}

			// This portion is for the active cars list
			writer.WriteLine("Cars");



			foreach (var car in activeCars) {
				// This is to write the waypoint list to a file
				foreach( var i in car.wayPointList){
					writer.WriteLine (i);
				}

				writer.WriteLine (car.currentWayPoint);

				writer.WriteLine (car.targetWayPoint);


				writer.WriteLine (car.colorString);
				writer.WriteLine (car.carTypeString);
				writer.WriteLine (car.sizeString);
				writer.WriteLine (car.position.x + " " +  car.position.y + " " + car.position.z);
				writer.WriteLine (car.route);
				writer.WriteLine (car.carColor);
				writer.WriteLine (car.speed);
				writer.WriteLine (car.carPID);
				writer.WriteLine (car.honeyPotIn);
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

	public void setUserFound(bool found){
		userFound = found;
	}


}
