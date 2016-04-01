using UnityEngine;
using System.Collections;

public class Security : MonoBehaviour {
	Vector3 Position;
	Animator animation;
	bool objectDetected;

	// This is the type of security gate it is
	private string securityType;

	// This is the set of colors that it can detect
	private bool red;
	private bool green;
	private bool blue;

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

	// Use this for initialization
	void Start () {
		animation = GetComponent<Animator> ();
		objectDetected = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;

		Vector3 newPos = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
	
		Debug.DrawRay (newPos, fwd);
		if (Physics.Raycast (newPos, fwd, out hit, 100.0F)) {
			//print (hit.collider.tag);
			// Check if it is security type 1, 2, or 3
			if (securityType == "L1" || securityType == "L2" || securityType == "L3") {
				// This will go through all the different possible tags, and check if the incoming boolean is the same
				if ((hit.collider.tag == "Hearse" && Hearse == true) ||
				   (hit.collider.tag == "ambulance" && ambulance == true) ||
				   (hit.collider.tag == "FireTruck" && fireTruck == true) ||
				   (hit.collider.tag == "Tanker" && Tanker == true) ||
				   (hit.collider.tag == "Truck" && Truck == true) ||
				   (hit.collider.tag == "IceCream" && IceCream == true) ||
				   (hit.collider.tag == "car" && policeCar == true)) {
					Destroy (hit.transform.gameObject);
						
				}



					
			}

/*			if (hit.collider.tag != "Hearse" ) {
				//animation.Play ("Cylinder|idle");
				print (hit.collider.tag + " is found");
				Destroy (hit.transform.gameObject);
			} else {
				if (hit.collider.tag == "Hearse") {
					//animation.Play ("Cylinder|liftUpIdle");

					print ("I found a " + hit.collider.tag);
				}
			}
		*/
		}

	}

	public Vector3 getPosition(){
		return Position;
	}

	public void setPosition(Vector3 inVect){
		Position = inVect;
	}

		
	// This is to set the things the security gate will detect
	public void setColors(bool r, bool g, bool b){
		red = r;
		green = g;
		blue = b;
	}

	public void setSize(bool s, bool m, bool l){
		small = s;
		medium = m;
		large = l;
	}

	public void setTypes(bool a, bool f, bool t, bool tr, bool h, bool i, bool p){
		ambulance = a;
		fireTruck = f;
		Tanker = t;
		Truck = tr ;
		Hearse = h; 
		IceCream = i;
		policeCar = p;
	}

	public void setSecurityType(string st){
		securityType = st;
	}
}

