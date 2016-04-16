using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class Security : MonoBehaviour {
	Vector3 Position;
	Animator animation;
	bool objectDetected;

	public List<string> Keys = new List<string>();

	// This is the type of security gate it is
	private string securityType;

	// This is the set of colors that it can detect
	private bool red;
	private bool green;
	private bool blue;
	private bool yellow;

	// This is the set of sizes that it can detect
	private bool small;
	private bool medium;
	private bool large;

	// This is the type of cars the security gate has to detect and destroy
	private bool ambulance;
	private bool fireTruck;
	private bool Tanker;
	private bool Truck;
	private bool Hearse;
	private bool IceCream;
	private bool policeCar;
	private bool taxi;
	bool upgrade = false;

	public List<string> securityFlags = new List<string>();
	public int level; // This is the level
	public Camera myCam; // The camera object


	// Use this for initialization
	void Start () {
		myCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		animation = GetComponent<Animator> ();
		objectDetected = false;
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("Works");
			upgrade = true;
		}
	}

	// Update is called once per frame
		void Update () {
			Vector3 fwd = transform.TransformDirection (Vector3.back);
			RaycastHit hit;
		
			Vector3 newPos = new Vector3 (transform.position.x-4.5f, transform.position.y + 3, transform.position.z);
		Debug.DrawRay (newPos, fwd*10.0f,Color.green);
		if (Physics.SphereCast (newPos, 3.0f, fwd, out hit, 10.0F)) {
			if (hit.collider.tag != "Terrain") {
				// Check for if ambulance is good, if so, add ambulance to list
				if (ambulance && !securityFlags.Contains ("Ambulance"))
					securityFlags.Add ("Ambulance");
				// Otherwise, remove it
				else if (!ambulance && securityFlags.Contains ("Ambulance"))
					securityFlags.Remove ("Ambulance");

				// Rinse and repeat for everything else
				if (Hearse && !securityFlags.Contains ("Hearse"))
					securityFlags.Add ("Hearse");
				else if (!ambulance && securityFlags.Contains ("Hearse"))
					securityFlags.Remove ("Hearse");
				
				if (fireTruck && !securityFlags.Contains ("FireTruck"))
					securityFlags.Add ("FireTruck");
				else if (!fireTruck && securityFlags.Contains ("FireTruck"))
					securityFlags.Remove ("FireTruck");
				
				if (Tanker && !securityFlags.Contains ("Tanker"))
					securityFlags.Add ("Tanker");
				else if (!Tanker && securityFlags.Contains ("Tanker"))
					securityFlags.Remove ("Tanker");


				if (Truck && !securityFlags.Contains ("Truck"))
					securityFlags.Add ("Truck");
				else if (!Truck && securityFlags.Contains ("Truck"))
					securityFlags.Remove ("Truck");


				if (IceCream && !securityFlags.Contains ("IceCream"))
					securityFlags.Add ("IceCream");
				else if (!IceCream && securityFlags.Contains ("IceCream"))
					securityFlags.Remove ("IceCream");
				
				if (policeCar && !securityFlags.Contains ("PoliceCar"))
					securityFlags.Add ("PoliceCar");
				else if (!policeCar && securityFlags.Contains ("PoliceCar"))
					securityFlags.Remove ("PoliceCar");

				if (taxi && !securityFlags.Contains ("Taxi"))
					securityFlags.Add ("Taxi");
				else if (!taxi && securityFlags.Contains ("Taxi"))
					securityFlags.Remove ("Taxi");
			
				// Add the colors this time around
				if (red && !securityFlags.Contains("Red"))  securityFlags.Add("Red");
				else if (!red && securityFlags.Contains("Red"))  securityFlags.Remove("Red"); 

				else if (green && !securityFlags.Contains("Green"))  securityFlags.Add("Green"); 
				else if (!green && securityFlags.Contains("Green"))  securityFlags.Remove("Green"); 

				else if (blue && !securityFlags.Contains("Blue"))  securityFlags.Add("Blue");
				else if (!blue && securityFlags.Contains("Blue"))  securityFlags.Remove("Blue"); 

				else if (yellow && !securityFlags.Contains("Yellow"))  securityFlags.Add("Yellow"); 
				else if (!yellow && securityFlags.Contains("Yellow"))  securityFlags.Remove("Yellow"); 

				// Check if it is security type 1, 2, or 3
				if (securityFlags.Contains(hit.collider.tag ) || securityFlags.Contains(hit.collider.GetComponent <Car> ().colorString))
						{
						print ("security Type: " + securityType);
							print ("car detected: " + hit.collider.tag);

						Destroy(hit.transform.transform.gameObject);
					}
			}
		}
	}

	void OnMouseDrag(){

		Ray vRay = myCam.ScreenPointToRay(Input.mousePosition);

		// Create a hit variable that will store the value of whatever it hits
		RaycastHit hit;

		// Cast a raycast from the starting position of the mouse down infinitely
		if (Physics.Raycast(vRay, out hit, Mathf.Infinity)){
			Debug.Log(hit.collider.gameObject);
			Debug.Log(hit.collider.gameObject.tag);
			if (hit.collider.tag == "Terrain" || hit.collider.tag == "tollPre") {
				if(hit.point.x > 0 && hit.point.x < 300 && hit.point.z > 0 && hit.point.z < 300){
					// This is a variable that will hold the position of where the hit is detected for the mouse
					Vector3 placePosition;

					// Store the hit position into the placePosition
					placePosition = hit.point;

					// This will round the x and z variable, not sure if this is needed though since accuracy is much better than inaccuracy for object placement
					placePosition.x = Mathf.Round(placePosition.x);
					placePosition.z = Mathf.Round(placePosition.z);

					// Change the position of it so it will be placed a little bit above the road level
					transform.position = new Vector3(placePosition.x, 0.6f, placePosition.z);
				}
			}

		}    
	}

	void OnGUI(){

		GUI.skin = Resources.Load ("Buttons/ShopSkin") as GUISkin;
		GUIStyle guiStyle = GUI.skin.GetStyle ("Shop");

		int offset = 360;
		float Twidth = GUI.skin.toggle.fixedWidth;
		float Theight = 30f;

		if (upgrade == true){
			Debug.Log ("This is working");
			Time.timeScale = 0;
			GUI.Box(new Rect(350, 100, 700, 700), "Upgrade Options");


			red = GUI.Toggle(new Rect(offset, 140, Twidth, Theight), red, "Red");
			green = GUI.Toggle(new Rect(offset, 215, Twidth, Theight), green, "Green");
			blue = GUI.Toggle(new Rect(offset, 290, Twidth, Theight), blue, "Blue");
			yellow = GUI.Toggle(new Rect(offset, 365, Twidth, Theight), yellow, "Yellow");

			//This is to check for what type of color the security gate will look for
			if (red && !securityFlags.Contains("Red")) securityFlags.Add("Red"); 
			else if (!red && securityFlags.Contains("Red")) securityFlags.Remove("Red");

			else if (green && !securityFlags.Contains("Green")) securityFlags.Add("Green"); 
			else if (!green && securityFlags.Contains("Green")) securityFlags.Remove("Green");

			else if (blue && !securityFlags.Contains("Blue"))  securityFlags.Add("Blue");
			else if (!blue && securityFlags.Contains("Blue"))  securityFlags.Remove("Blue"); 

			else if (yellow && !securityFlags.Contains("Yellow"))  securityFlags.Add("Yellow");
			else if (!yellow && securityFlags.Contains("Yellow"))  securityFlags.Remove("Yellow");


			if (level >= 2){

				small = GUI.Toggle(new Rect(Twidth + offset, 140, Twidth, Theight), small, "Small");
				medium = GUI.Toggle(new Rect(Twidth + offset, 215, Twidth, Theight), medium, "Medium");
				large = GUI.Toggle(new Rect(Twidth + offset, 290, Twidth, Theight), large, "Large");

				if (small && !securityFlags.Contains("Small"))  securityFlags.Add("Small"); 
				else if (!small && securityFlags.Contains("Small"))  securityFlags.Remove("Small");

				else if (medium && !securityFlags.Contains("Medium"))  securityFlags.Add("Medium"); 
				else if (!medium && securityFlags.Contains("Medium"))  securityFlags.Remove("Medium"); 

				else if (large && !securityFlags.Contains("Large"))  securityFlags.Add("Large");
				else if (!large && securityFlags.Contains("Large"))  securityFlags.Remove("Large");
			}



			if (level >= 3){
				ambulance = GUI.Toggle(new Rect(Twidth * 2 + offset, 140, Twidth, Theight), ambulance, "Ambulance");
				fireTruck = GUI.Toggle(new Rect(Twidth * 2 + offset, 215, Twidth, Theight), fireTruck, "Fire Truck");
				Tanker = GUI.Toggle(new Rect(Twidth * 2 + offset, 290, Twidth, Theight), Tanker, "Oil Truck");
				Truck = GUI.Toggle(new Rect(Twidth * 2 + offset, 365, Twidth, Theight), Truck, "Truck");
				Hearse = GUI.Toggle(new Rect(Twidth * 2 + offset, 440, Twidth, Theight), Hearse, "Hearse");
				IceCream = GUI.Toggle(new Rect(Twidth * 2 + offset, 515, Twidth, Theight), IceCream, "Ice Cream");
				policeCar = GUI.Toggle(new Rect(Twidth * 2 + offset, 590, Twidth, Theight), policeCar, "Police Car");


				if (ambulance && !securityFlags.Contains("Ambulance")) securityFlags.Add("Ambulance"); 
				else if (!ambulance && securityFlags.Contains("Ambulance")) securityFlags.Remove("Ambulance");

				else if (fireTruck && !securityFlags.Contains("Fire Truck"))  securityFlags.Add("Fire Truck");
				else if (!fireTruck && securityFlags.Contains("Fire Truck"))  securityFlags.Remove("Fire Truck");

				else if (Tanker && !securityFlags.Contains("Tanker"))  securityFlags.Add("Tanker");
				else if (!Tanker && securityFlags.Contains("Tanker"))  securityFlags.Remove("Tanker");

				else if (Truck && !securityFlags.Contains("Truck"))  securityFlags.Add("Truck");
				else if (!Truck && securityFlags.Contains("Truck"))  securityFlags.Remove("Truck");

				else if (Hearse && !securityFlags.Contains("Hearse"))  securityFlags.Add("Hearse");
				else if (!Hearse && securityFlags.Contains("Hearse"))  securityFlags.Remove("Hearse"); 

				else if (IceCream && !securityFlags.Contains("Ice Cream"))  securityFlags.Add("Ice Cream");
				else if (!IceCream && securityFlags.Contains("Ice Cream"))  securityFlags.Remove("Ice Cream"); 

				else if (policeCar && !securityFlags.Contains("Police Car"))  securityFlags.Add("Police Car");
				else if (!policeCar && securityFlags.Contains("Police Car"))  securityFlags.Remove("Police Car"); 
			}

			if (GUI.Button(new Rect(offset, 550, GUI.skin.button.fixedWidth, 50), "Change")){
				upgrade = false;
				Time.timeScale = 1;
			}

			if (GUI.Button(new Rect(offset, 650, GUI.skin.button.fixedWidth, 50), "Cancel Change")){
				//clear();
				upgrade = false;
				Time.timeScale = 1;

			}
		}
	}
	public Vector3 getPosition(){
		return Position;
	}

	public void setPosition(Vector3 inVect){
		Position = inVect;
	}

		
	// This is to set the things the security gate will detect
	public void setColors(bool r, bool g, bool b, bool y){
		red = r;
		green = g;
		blue = b;
		yellow = y;
	}

	public void setSize(bool s, bool m, bool l){
		small = s;
		medium = m;
		large = l;
	}

	public void setTypes(bool a, bool f, bool t, bool tr, bool h, bool i, bool p, bool ta){
		ambulance = a;
		fireTruck = f;
		Tanker = t;
		Truck = tr ;
		Hearse = h; 
		IceCream = i;
		policeCar = p;
		taxi = ta;
	}

	public void setSecurityType(string st){
		//securityType = st;
	}
}

