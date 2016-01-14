using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public float speed = 0.00000000000000000000000000010F;
	public float rotationSpeed = 100.0F;

	GameObject building;
	// Use this for initialization
	void Start () {
		building = GameObject.Find("corporatePre(Clone)");

	}
	
	// Update is called once per frame
	void Update () {
		if (building == null) {
			building = GameObject.Find ("corporatePre(Clone)");
			transform.position = new Vector3 (building.transform.position.x , building.transform.position.y+30, building.transform.position.z+20);

		}


		//will be focused on the building gameObject
		transform.LookAt (building.transform.position);

		// 'W' key moves camera forward
		if (Input.GetKey (KeyCode.W)) {
			
			float translation = transform.position.z * speed;
			translation *= Time.deltaTime;
			transform.Translate(0, 0, translation);


		}

		// 'S' key moves camera back
		if (Input.GetKey (KeyCode.S)) {
			
			float translation = transform.position.z * speed;
			translation *= Time.deltaTime;
			transform.Translate(0, 0, -translation);
			
			
		}

		// 'D' key moves camera right
		if (Input.GetKey (KeyCode.D)) {
			float translation = transform.position.x * speed;
			translation *= Time.deltaTime;
			transform.Translate(translation, 0, 0);

		}

		// 'A' key moves camera left
		if (Input.GetKey (KeyCode.A)) {
			float translation = transform.position.x * speed;
			translation *= Time.deltaTime;
			transform.Translate(-translation, 0, 0);
			
		}

		// 'E' controls the pitch clockwise
		if (Input.GetKey (KeyCode.E)) {
			float translation = transform.position.y * speed;
			translation *= Time.deltaTime;
			transform.Rotate(0, translation, 0);
			
		}

		// 'R' controls the pitch counter clockwise
		if (Input.GetKey (KeyCode.R)) {
			float translation = transform.position.y * speed;
			translation *= Time.deltaTime;
			transform.Rotate(0, -translation, 0);
		}

		// 'Q' controls the roll clockwise
		if (Input.GetKey (KeyCode.Q)) {
			float translation = transform.position.y * speed;
			translation *= Time.deltaTime;
			transform.Rotate( translation, 0, 0);
			
		}

		// 'Z' controls the roll counter clockwise
		if (Input.GetKey (KeyCode.Z)) {
			float translation = transform.position.y * speed;
			translation *= Time.deltaTime;
			transform.Rotate( -translation, 0,0);
		}

		// 'X' controls the yaw clockwise
		if (Input.GetKey (KeyCode.X)) {
			float translation = transform.position.y * speed;
			translation *= Time.deltaTime;
			transform.Translate( 0, 0, translation);
			
		}

		//'C' controls the yaw counter clockwise
		if (Input.GetKey (KeyCode.C)) {
			float translation = transform.position.y * speed;
			translation *= Time.deltaTime;
			transform.Translate(  0, 0, -translation);
		}

	}
}
