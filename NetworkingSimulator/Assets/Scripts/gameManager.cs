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
	GameObject carPre;
	Vector3 carStartPos = new Vector3 (157f, 0.6f, 0f);
	float timer = 10;
	public int carType;
    public Color[] colorArray;

	// These variables will be used for file I/O in terms of C#
	private string fileName ; // The name of the file that will be created, it will be the same name as the user, except with a .txt at the end
	private string username; // This will be used to show the name of the user
	private string password; // This will be used to check if the user is who he says it is, after getting the first line from the file

	// These are the different list for each and everything within that specific level
	public List<Building> buildingsInThisScene = new List<Building>() ;
	public List<Security> securityInThisScene = new List<Security>();
	public List<Car> carsInThisScene = new List<Car>();


    public List<HoneyPot> honeyPots = new List<HoneyPot>();
    public int honeyCount = 1;

	public List<Vector3> buildings;
	public List<Vector3> security;
	public List<Vector3> car;

	// Player variable information pertaining to the level
	public int cash;
	int securityLevel;
    public bool gameIsStarted = false;
    public int count = 0;

	bool levelLoaded; // This is used to tell the different tutorial that a profile has been loaded

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
		carTypeDict.Add(1,"Fire Truck");
		carTypeDict.Add(2,"Hearse");
		carTypeDict.Add(3,"Ice Cream");
		carTypeDict.Add(4,"Police Car");
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
			carPre = Resources.Load (carPrefabDict[carType]) as GameObject;
            Instantiate(carPre, carStartPos , Quaternion.identity);
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
		fileName = @"C:\Users\murad\SP\NetworkingSimulator\" + name + ".txt";

		if (File.Exists (fileName)) {
			setUserName(name);
			StreamReader sr = File.OpenText(fileName);
			Debug.Log (fileName + " Exist");

			string input;
			float x, y, z;
			x = y =z = 0.0f;
	
			print ("STARTING");

			input = sr.ReadLine();
			char[] delimiterChars =  { ' ', '\t' };
			char[] secondDelimiter = { ',', '\t' };

			string[] words = input.Split(delimiterChars);

			print (words[0]);
			print ('\n');



			if(words[0] == password)
			{
				input = sr.ReadLine();

				print (input);
				levelLoaded = true;

				input = sr.ReadLine();
				input = sr.ReadLine();


				input = sr.ReadLine();
				words = input.Split(delimiterChars);
				int numberOfStuff = 0;
				int.TryParse(words[0], out numberOfStuff);

				for(int i = 0; i < numberOfStuff; i++)
				{

					input = sr.ReadLine();
					words = input.Split(secondDelimiter);

					words[0] = words[0].Trim('(');
					words[2] = words[2].Trim(')');

					float.TryParse(words[0], out x);
					float.TryParse(words[1], out y);
					float.TryParse(words[2], out z);

					Building obj = new Building();
					obj.setPosition(new Vector3(x, y, z));
					//buildingsInThisScene = new List<building>();
					buildingsInThisScene.Add(obj);
					print (buildingsInThisScene[0].getPosition());
					buildings.Add(obj.getPosition());
				}


				input = sr.ReadLine();
				words = input.Split(delimiterChars);
				input = sr.ReadLine();
				words = input.Split(delimiterChars);

				numberOfStuff = 0;
				int.TryParse(words[0], out numberOfStuff);


				input = sr.ReadLine();
				words = input.Split(delimiterChars);
				input = sr.ReadLine();
				words = input.Split(delimiterChars);
				
				numberOfStuff = 0;
				int.TryParse(words[0], out numberOfStuff);
				
				print (words[0]);
				for(int i = 0; i < numberOfStuff; i++)
				{
					
					input = sr.ReadLine();
					words = input.Split(secondDelimiter);
					
					words[0] = words[0].Trim('(');
					words[2] = words[2].Trim(')');
					
					float.TryParse(words[0], out x);
					float.TryParse(words[1], out y);
					float.TryParse(words[2], out z);
					
					Security obj = new Security();
					obj.setPosition(new Vector3(x, y, z));
					securityInThisScene = new List<Security>();
					securityInThisScene.Add(obj);
	
					security.Add(obj.getPosition());
					print (securityInThisScene[0].getPosition());
				}


				input = sr.ReadLine();
				words = input.Split(delimiterChars);
				input = sr.ReadLine();
				words = input.Split(delimiterChars);
				
				numberOfStuff = 0;
				int.TryParse(words[0], out numberOfStuff);
				
				print (words[0]);
				for(int i = 0; i < numberOfStuff; i++)
				{
					
					input = sr.ReadLine();
					words = input.Split(secondDelimiter);
					
					words[0] = words[0].Trim('(');
					words[2] = words[2].Trim(')');
					
					float.TryParse(words[0], out x);
					float.TryParse(words[1], out y);
					float.TryParse(words[2], out z);
					
					Car obj = new Car();
					obj.setPosition(new Vector3(x, y, z));
					carsInThisScene = new List<Car>();
					carsInThisScene.Add(obj);
					
					car.Add(obj.getPosition());
					print (carsInThisScene[0].getPosition());
				}
				sr.Close();
				return true;
			}
		
			else{
				sr.Close();
				print("FILE NOT FOUND");
			return false;
			}
		} 
		else {
			return false;
		}
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
		// Create a stream writer object
		fileName = username + ".txt";
		StreamWriter writer = new StreamWriter (fileName);

	
		password = password.Trim ();
		// Write the password to file
		writer.WriteLine (password);

		writer.WriteLine (cash);
		writer.WriteLine ("Buildings");
		
		writer.WriteLine (buildingsInThisScene.Count);
		for (int i = 0; i < buildingsInThisScene.Count; i++) {
			//writer.WriteLine (buildingsInThisScene [i].getMonetary ());
			writer.WriteLine (buildingsInThisScene [i].getPosition ());
		}		

		writer.WriteLine ("Security");
		writer.WriteLine (securityInThisScene.Count);
		for (int i = 0; i < securityInThisScene.Count; i++) {
			writer.WriteLine(securityInThisScene[i].getPosition());
		}	

		writer.WriteLine ("Cars");
		writer.WriteLine (carsInThisScene.Count);
		for (int i = 0; i < carsInThisScene.Count; i++) {
			writer.WriteLine(carsInThisScene[i].getPosition());
		}	
		writer.Close ();

		return true;
	}

	//sets and gets of user attributes
	public void setUserName(string name){
		username = name;

		print ("UserName: " + username);
	}

	public void setPassword(string inPassword){
		password = inPassword;

		print ("Users password: " + password);
	}

	public void setCash(int money)
	{
		cash = money;
	}

	public int getCash()
	{
		return cash;
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

	//decrement players currency
	public void minusCash(int money)
	{
		cash -= money;
	}

	public void addCash(int money)
	{
		cash += money;
	}

	//will check if the user exists
	public bool checkForUser(string name)
	{
		fileName = @"C:\Users\murad\SP\NetworkingSimulator\" + name + ".txt";

		if (File.Exists (fileName)) {
			return true;
		} 
		return false;
	}
}
