// @Author: Sajid, Ortega, Rivas
// This is the main class which calls the different classes such as security, road, highway, etc
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
public class playerManager : MonoBehaviour {

	// These variables will be used for file I/O in terms of C#
	private string fileName ; // The name of the file that will be created, it will be the same name as the user, except with a .txt at the end
	private string username; // This will be used to show the name of the user
	private string password; // This will be used to check if the user is who he says it is, after getting the first line from the file

	// These are the different list for each and everything within that specific level
	
	public List<building> buildingsInThisScene = new List<building>() ;
	public List<road> roadsInThisScene = new List<road> ();
	public List<security> securityInThisScene = new List<security>();
	public List<cars> carsInThisScene = new List<cars>();

	public List<Vector3> buildings;
	public List<Vector3> roads;
	public List<Vector3> security;
	public List<Vector3> car;


	// Player variable information pertaining to the level
	int cash;
	int material;
	int securityLevel;

	// Current level within the game
	string currentLevel; // Used to determine what level the user was playing at last, it saved to a file upon save and used upon load
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
		// Check to see if the application last loaded level was 2, if so, that means the player is new
		if (Application.loadedLevel == 2) {
			Application.LoadLevel ("tutorial01");
		}
	}
	
	// Update is called once per frame, this will not be used for this project as far as my knowledge
	void Update () {
	
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

		string a;
		if (File.Exists (fileName)) {
			setUserName(name);
			StreamReader sr = File.OpenText(fileName);
			Debug.Log (fileName + " Exist");

			string input;
			int level;
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

				setCurrentLevel(input);

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

					building obj = new building();
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
					
					road obj = new road();
					obj.setPosition(new Vector3(x, y, z));
					//roadsInThisScene = new List<road>();
					roadsInThisScene.Add(obj);
					
					print (roadsInThisScene[0].getPosition());
					roads.Add(obj.getPosition());
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
					
					security obj = new security();
					obj.setPosition(new Vector3(x, y, z));
					securityInThisScene = new List<security>();
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
					
					cars obj = new cars();
					obj.setPosition(new Vector3(x, y, z));
					carsInThisScene = new List<cars>();
					carsInThisScene.Add(obj);
					
					car.Add(obj.getPosition());
					print (carsInThisScene[0].getPosition());
				}


				sr.Close();
				loadLevel();
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

		// Save the name of the current level the user is on
		writer.WriteLine ( currentLevel);

		writer.WriteLine (cash);
		writer.WriteLine ("Buildings");
		
		writer.WriteLine (buildingsInThisScene.Count);
		for (int i = 0; i < buildingsInThisScene.Count; i++) {
			//writer.WriteLine (buildingsInThisScene [i].getMonetary ());
			writer.WriteLine (buildingsInThisScene [i].getPosition ());
		}	

		writer.WriteLine ("Roads");
		writer.WriteLine (roadsInThisScene.Count);
		for (int i = 0; i < roadsInThisScene.Count; i++) {
			writer.WriteLine (roadsInThisScene [i].getPosition ());
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

	public void setCurrentLevel(string levelName){
		currentLevel = levelName;
	}

	public string getCurrentLevel(){
		return currentLevel;
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

	//this will load the level
	private void loadLevel()
	{
		Application.LoadLevel (currentLevel);
	}

	//will returnt he level loaded
	public bool getLevelLoaded()
	{
		return levelLoaded;
	}

}
