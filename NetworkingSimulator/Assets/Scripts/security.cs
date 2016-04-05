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
				print (hit.collider.tag);
				// Check if it is security type 1, 2, or 3
				if (securityType == "FL1" ) {
							if (
								// This is only for hearse
								((hit.collider.tag == "Hearse" && Hearse == true) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  (hit.collider.tag == "ambulance" && ambulance ==  true) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && (hit.collider.tag == "FireTruck" && fireTruck ==  true) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								(hit.collider.tag == "Tanker" && Tanker ==  true) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && (hit.collider.tag == "Truck" && Truck ==  true) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && (hit.collider.tag == "IceCream" && IceCream ==  true)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& (hit.collider.tag == "PoliceCar" && policeCar ==  true) && !(hit.collider.tag == "Taxi" && taxi == false))
								||
								(!(hit.collider.tag == "Hearse" && Hearse == false) &&  !(hit.collider.tag == "ambulance" && ambulance ==  false) && !(hit.collider.tag == "FireTruck" && fireTruck ==  false) &&	
								!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
								&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && (hit.collider.tag == "Taxi" && taxi == true))
								)
							{
								print ("car detected");
							if (red ) {
									if ("Red" == hit.collider.GetComponent <Car> ().colorString) {
										Destroy (hit.transform.gameObject);
									}
							 else if (blue) {
								if ("Blue" == hit.collider.GetComponent <Car> ().colorString || "Yellow" == hit.collider.GetComponent <Car> ().colorString ) {
									print ("trying to stop car");
										// This will stop the car for further surveillance
										hit.collider.GetComponent <Car> ().setStop();
									}
								} 
							else {
							// Let the car pass
								if ("Green" == hit.collider.GetComponent <Car> ().colorString) {
									print ("Speeding car up");
									hit.collider.GetComponent <Car> ().speed += 500;
								}					
						}
					}
				}
			}

			if (securityType == "FL2" ) {
				if (
					/*
					// This is only for hearse
					((hit.collider.tag == "Hearse" && Hearse == true || (hit.collider.tag == "ambulance" && ambulance ==  true) &&  fireTruck ==  false && Tanker ==  false && Truck ==  false && IceCream ==  false &&  policeCar ==  false && taxi == false))
					||
					(hit.collider.tag == "Hearse" && Hearse == true || (hit.collider.tag == "ambulance" && ambulance ==  true) &&  fireTruck ==  false && Tanker ==  false && Truck ==  false && IceCream ==  false &&  policeCar ==  false && taxi == false))
					||
						((hit.collider.tag == "Hearse" && Hearse == true || ( hit.collider.tag == "FireTruck" && fireTruck ==  true) && !(hit.collider.tag == "ambulance" && ambulance ==  false)  &&	
						!(hit.collider.tag == "Tanker" && Tanker ==  false) && !(hit.collider.tag == "Truck" && Truck ==  false) && !(hit.collider.tag == "IceCream" && IceCream ==  false)
						&& !(hit.collider.tag == "PoliceCar" && policeCar ==  false) && !(hit.collider.tag == "Taxi" && taxi == false))
						||
						*/
						true
					)
				{
					print ("car detected");
					if (red ) {
						if ("Red" == hit.collider.GetComponent <Car> ().colorString) {
							Destroy (hit.transform.gameObject);
						}
						else if (blue) {
							if ("Blue" == hit.collider.GetComponent <Car> ().colorString || "Yellow" == hit.collider.GetComponent <Car> ().colorString ) {
								print ("trying to stop car");
								// This will stop the car for further surveillance
								hit.collider.GetComponent <Car> ().setStop();
							}
						} 
						else {
							// Let the car pass
							if ("Green" == hit.collider.GetComponent <Car> ().colorString) {
								print ("Speeding car up");
								hit.collider.GetComponent <Car> ().speed += 500;
							}					
						}
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
		securityType = st;
	}
}

