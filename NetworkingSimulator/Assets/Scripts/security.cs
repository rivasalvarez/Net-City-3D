using UnityEngine;
using System.Collections;

public class Security : MonoBehaviour {
	Vector3 Position;
	Animator animation;
	bool objectDetected;

	// Use this for initialization
	void Start () {
		animation = GetComponent<Animator> ();
		objectDetected = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Three different vectors for different angles the object is placed
		Vector3 fwd = transform.TransformDirection (Vector3.left) * 80;
		Vector3 fd = transform.TransformDirection (Vector3.left);
		Vector3 wd = transform.TransformDirection (Vector3.forward) * 80;


		if (objectDetected != true) {
			// If a car is not detected it will stay in it's idle animation
			animation.Play ("Cylinder|idle");
		}

		RaycastHit hit;
		Ray landingRay = new Ray (transform.position, Vector3.back);

		// Check for the rotation of the object
		//if(transform.eulerAngles.y == )
		//{
		// Check if the measurement is not-changed, then shoot out a raycast straight
		Debug.DrawRay (transform.position, wd, Color.red);
			
		if (Physics.Raycast (landingRay, out hit, 20f  )) {
			//objectDetected = true;
				
			//print ("Object detected");

			print (hit);	
			if(hit.collider.gameObject.tag == "car")
			{
				print ("Car detected");
			animation.Play ("Cylinder|liftUp");

			//transform.Translate(new Vector3 (90,20,30)) ;
				}
				
	
	
		}
	}

	public Vector3 getPosition(){
		return Position;
	}

	public void setPosition(Vector3 inVect){
		Position = inVect;
	}
}

