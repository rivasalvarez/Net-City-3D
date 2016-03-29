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
			if (hit.collider.tag != "Hearse") {
				//animation.Play ("Cylinder|idle");
				print (hit.collider.tag + " is found");
				Destroy (hit.transform.gameObject);
			} else {
				if (hit.collider.tag == "Hearse") {
					//animation.Play ("Cylinder|liftUpIdle");

					print ("I found a " + hit.collider.tag);
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
}

