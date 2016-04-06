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

	public List<string> securityFlags = new List<string>();


	// Use this for initialization
	void Start () {
		animation = GetComponent<Animator> ();
		objectDetected = false;
	}

	// Update is called once per frame
		void Update () {
		Vector3 fwd = transform.TransformDirection (Vector3.back);
			RaycastHit hit;

			Vector3 newPos = new Vector3 (transform.position.x-4.5f, transform.position.y + 3, transform.position.z);

		Debug.DrawRay (newPos, fwd*10.0f,Color.green);
		if (Physics.SphereCast (newPos, 3.0f, fwd, out hit, 10.0F)) {
			if (hit.collider.tag != "Building") {
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
					if (securityFlags.Contains(hit.collider.tag))
						{
					print ("security Type: " + securityType);
						print ("car detected: " + hit.collider.tag);

						if (securityFlags.Contains(hit.collider.GetComponent <Car> ().colorString)) {
							print (hit.collider.GetComponent <Car> ().colorString);

								Destroy (hit.transform.gameObject);
							}

					}
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

	/*
	// This is to set the things the security gate will detect
	public void getColors(out bool r, out bool g, out bool b,out bool y){
		red = r;
		green = g;
		blue = b;
		yellow = y;
	}
	*/

	public void setSize(bool s, bool m, bool l){
		small = s;
		medium = m;
		large = l;
	}

	/*
	public void getSize(out bool s, out bool m, out bool l){
		small = s;
		medium = m;
		large = l;
	}
	*/

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
	/*
	public void getTypes(out bool a, out bool f,out bool t, out bool tr,out bool h,out bool i,out bool p,out bool ta){
		ambulance = a;
		fireTruck = f;
		Tanker = t;
		Truck = tr ;
		Hearse = h; 
		IceCream = i;
		policeCar = p;
		taxi = ta;
	}
*/

	public void setSecurityType(string st){
		//securityType = st;
	}
	/*
	public void getSecurityType(out string st){
		//securityType = st;
	}
	*/
}

