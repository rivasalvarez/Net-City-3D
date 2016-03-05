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
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;


		Vector3 newPos = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
		Debug.DrawRay (newPos, fwd);
		if (Physics.Raycast (newPos, fwd, out hit, 100.0F)) {
			//print (hit.collider.tag);
			if (hit.collider.tag != "Hearse") {
				print (hit.collider.tag + " is found");
				Destroy (hit.transform.gameObject);
			} else {
				if (hit.collider.tag == "Hearse") {
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

}

