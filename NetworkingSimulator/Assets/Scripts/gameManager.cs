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


		/**
	 * Function to load the file from the computer based on the user
	 * @param: A string which is the name of the user
	 * @pre: Has to have a name of a user.
	 * @post: Checks to see if profile exist, and loads the data specific to the save file
	 * @return: returns true if successful, otherwise, reads out false.
	 * @algorithm: Checks to see if the user's file exist, if so, read in the data accurately, and return true. Otherwise, return false, meaning the user does not exist in the current computer
	 */ 
	// Function that saves and loads the user information to a file
	public bool loadSave(string name){

		return true;

	}

	/**
	 * Function to save the users data to a file based on the users name
	 * @param: None
	 * @pre: Has to have accurate data and syntax?
	 * @post: Saves accurate data to a file
	 * @return: returns true if successful, otherwise, reads out false.
	 * @algorithm: Called from the gui save button in which it gets the username of the player after being set somewhere else. Opens the file, writes the different things for the different levels
	 */ 
	public bool saveData(){
        return true;
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
	public bool checkForUser(string name)
	{
		fileName = name + ".txt";

		if (File.Exists (fileName)) {
			return true;
		} 
		return false;
	}
}
