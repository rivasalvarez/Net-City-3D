using UnityEngine;
using System.Collections;

public class Security : MonoBehaviour {
	Vector3 Position;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection (Vector3.left) * 80;
		Vector3 fd = transform.TransformDirection (Vector3.left);
		Vector3 wd = transform.TransformDirection (Vector3.forward) * 80;


		Debug.DrawRay (transform.position, wd, Color.green);
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position, Vector3.forward);
		if (Physics.Raycast (landingRay, out hit, Mathf.Infinity)) {
			print (hit);
			Debug.DrawRay (transform.position , wd, Color.green);

			transform.Translate(new Vector3 (90,20,30)) ;
		}

	
	
	}

	public Vector3 getPosition(){
		return Position;
	}

	public void setPosition(Vector3 inVect){
		Position = inVect;
	}
}

