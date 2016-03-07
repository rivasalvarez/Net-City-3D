using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainGame : MonoBehaviour {
	string levelName;
	public GameObject goTerrain;
	public Camera myCam;
	GameObject playerMemory;
	gameManager playerScript;
	public GameObject obj;
	public GameObject tmpObj;
	private bool showSettings;
	bool placingCar;
	bool placingSecurity;
	bool placingHighway;
	GUIStyle guiCash;
	GUIStyle guiStyle;
	public float timer = 300;
	string mins;
	string secs;
	public string time;

	// Use this for initialization
	void Start () {
		levelName = "mainGame";
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<gameManager> ();

		guiStyle =  new GUIStyle();
		guiStyle.fontSize = 20;
		guiStyle.normal.textColor = Color.white;

		
		guiCash =  new GUIStyle();
		guiCash.fontSize = 20;
		guiCash.normal.textColor = Color.green;
  
		if (playerScript.getLevelLoaded ()) {
			//begins the player with 3000 dollars of currency
			playerScript.setCash (3000);

			int tmp = playerScript.buildingsInThisScene.Count;
			
			playerScript.buildingsInThisScene.Clear ();
			for(int i = 0; i < tmp; i++)
			{
				obj = Instantiate (Resources.Load ("Prefabs/corporatePre", typeof(GameObject))) as GameObject;
				//obj.transform.position = playerScript.buildingsInThisScene[i].getPosition();
				obj.transform.position = playerScript.buildings[0];
				obj.GetComponent<Building>().setPosition(obj.transform.position);
				playerScript.buildingsInThisScene.Add (obj.GetComponent<Building> ());
			}
				

			tmp = playerScript.securityInThisScene.Count;
			playerScript.securityInThisScene.Clear ();

			for(int i = 0; i < tmp; i++)
			{
				obj = Instantiate (Resources.Load ("Prefabs/gatePre", typeof(GameObject))) as GameObject;
				obj.transform.position = playerScript.security[i];
				obj.GetComponent<Security>().setPosition(obj.transform.position);

				playerScript.securityInThisScene.Add (obj.GetComponent<Security>());
			}

			showSettings = false;
			placingCar = false;
			placingSecurity = false;	


		} else {
			playerScript.setCash (3000);

			// Loop through at starting integer 68 and instantiate roads based on that
			float z = 68;

			/*
			obj = Instantiate (Resources.Load ("Prefabs/corporatePre", typeof(GameObject))) as GameObject;
			tmpObj = obj;
			obj.transform.position = new Vector3 (40, 0, 20);
			obj.GetComponent<Building> ().setMonetary (300);
			obj.GetComponent<Building>().setPosition(obj.transform.position);
			playerScript.buildingsInThisScene.Add (obj.GetComponent<Building> ());


			obj = Instantiate (Resources.Load ("Prefabs/gatePre", typeof(GameObject))) as GameObject;
			obj.transform.position = new Vector3 (40.28648f, 2f, 29.05575f);
			obj.GetComponent<Security>().setPosition(obj.transform.position);
			playerScript.securityInThisScene.Add (obj.GetComponent<Security>());

			showSettings = false;
			placingCar = false;
			placingSecurity = false;
			*/
		}


	}
	// Update is called once per frame
	void Update () {
	    timer -= Time.deltaTime;
		mins = Mathf.Floor(timer / 60).ToString("00");
		secs = Mathf.Floor(timer % 60).ToString("00");
		time = mins + ":" + secs;


		//if (Input.GetKeyDown (KeyCode.G)) {
		if(Input.GetButtonDown("Fire1")){
		Ray vRay = myCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			//print ("Ray cast is starting");


			if (Physics.Raycast (vRay, out hit, Mathf.Infinity)) {

				//print ("Ray cast found a hit");
				if (hit.collider.tag == "tollPre") {

				}
			}
		}


	}

	void OnGUI()
	{
		//GUI.Label(new Rect (Screen.width - 80, 0 , 150, 20), "$" + playerScript.getCash().ToString(), guiCash);
		GUI.Label(new Rect (0, 0, 150, 20), time,guiStyle);
 
		if (placingCar == false && placingSecurity == false) {
			if (showSettings == false) {
				// This button is for create Profile
				if (GUI.Button (new Rect (0, (Screen.height / 1.10f), 100, 50), "Create Road")) {
					if(playerScript.getCash() >= 30)
					{
						placingCar = true;
					}
				}

				if (GUI.Button (new Rect (110, (Screen.height / 1.10f), 100, 50), "Create Security")) {
					if(playerScript.getCash() >= 30){
						placingSecurity = true;
					}

				}


				
				if (GUI.Button (new Rect (220, (Screen.height / 1.10f), 100, 50), "Create highway")) {
					
					
				}

				if (GUI.Button (new Rect (330, (Screen.height / 1.10f), 100, 50), "Settings")) {
					showSettings = true;
						
				}
			}

			else {
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2), 100, 50), "Load Game")) {
					playerScript.saveData ();
					
				}
				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 50, 100, 50), "Save Game")) {
					playerScript.setCurrentLevel(levelName);
					playerScript.saveData ();
					
				}

				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 100, 100, 50), "Options")) {


				}

				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 150, 100, 50), "Quit Game")) {
								
				}

				if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 200, 100, 50), "Back ")) {
					showSettings = false;
					
				}
			}
		}

		 if(placingSecurity == true && placingCar == false){
					if (Input.GetKeyDown (KeyCode.G)) {
						Ray vRay = myCam.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit;


						if (Physics.Raycast (vRay, out hit, Mathf.Infinity)) {

					//print ("Ray cast found a hit");
					if (hit.collider.tag == "Building") {
						//print ("Ray cast found building");

						//print (hit.collider.tag);
						playerScript.minusCash (playerScript.getSecurityLevelCash ());
						//print (hit);

						Vector3 placePosition;
						placePosition = hit.point;
						//print (placePosition);

						placePosition.y += .0f;
						placePosition.x = Mathf.Round (placePosition.x);
						placePosition.z = Mathf.Round (placePosition.z);

						obj = Instantiate (Resources.Load ("Prefabs/tollPre", typeof(GameObject))) as GameObject;
						obj.transform.position = new Vector3 (placePosition.x, 0.6f, placePosition.z);			
						placingSecurity = false;
					}
							}
					}

				}
	

	}
}

