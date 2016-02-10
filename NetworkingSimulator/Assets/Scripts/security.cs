using UnityEngine;
using System.Collections;

public class security : MonoBehaviour {
	Vector3 Position;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection (Vector3.left) * 30;
		Vector3 fd = transform.TransformDirection (Vector3.left);
		Vector3 wd = transform.TransformDirection (Vector3.forward);


		if (Physics.Raycast (transform.position, fd, 80)) {
			print ("f");
			Debug.DrawRay (transform.position, fwd, Color.green);
			transform.Translate(new Vector3 (0, 0, 0)) ;
		}

	
	
	}

	public Vector3 getPosition(){
		return Position;
	}

	public void setPosition(Vector3 inVect){
		Position = inVect;
	}
}

