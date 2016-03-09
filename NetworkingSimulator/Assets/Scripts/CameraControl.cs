using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public float speed = 0.10F;
	public float rotationSpeed = 100.0F;
	Vector3 startPos = new Vector3(0f,0f,0f);
	Quaternion startRot;

	GameObject building;
	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		startRot = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {


		// 'W' key moves camera forward
		if (Input.GetKey (KeyCode.R)) {
			float translation = this.transform.position.z * speed;
			translation *= Time.deltaTime;
			this.transform.Translate(0, 0, translation);
		}

		// 'S' key moves camera back
		if (Input.GetKey (KeyCode.F)) {
			float translation = this.transform.position.z * speed;
			translation *= Time.deltaTime;
			this.transform.Translate(0, 0, -translation);
		}

		// 'D' key moves camera right
		if (Input.GetKey (KeyCode.W)) {
			float translation = this.transform.position.y * speed;
			translation *= Time.deltaTime;
			this.transform.Translate(0, translation, 0);
		}
		
		// 'A' key moves camera left
		if (Input.GetKey (KeyCode.S)) {
			float translation = this.transform.position.y * speed;
			translation *= Time.deltaTime;
			this.transform.Translate(0, -translation ,0);
		}
		// 'D' key moves camera right
		if (Input.GetKey (KeyCode.D)) {
			float translation = this.transform.position.x * speed;
			translation *= Time.deltaTime;
			this.transform.Translate(translation, 0, 0);
		}

		// 'A' key moves camera left
		if (Input.GetKey (KeyCode.A)) {
			float translation = this.transform.position.x * speed;
			translation *= Time.deltaTime;
			this.transform.Translate(-translation, 0, 0);
		}

		// 'E' controls the pitch clockwise
		if (Input.GetKey (KeyCode.L)) {
			float translation = this.transform.position.y * speed;
			translation *= Time.deltaTime;
			this.transform.Rotate(0, translation, 0);
		}

		// 'R' controls the pitch counter clockwise
		if (Input.GetKey (KeyCode.J)) {
			float translation = this.transform.position.y * speed;
			translation *= Time.deltaTime;
			this.transform.Rotate(0, -translation, 0);
		}

		// 'Q' controls the roll clockwise
		if (Input.GetKey (KeyCode.K)) {
			float translation = this.transform.position.x * speed;
			translation *= Time.deltaTime;
			this.transform.Rotate( translation, 0, 0);
			
		}

		// 'Z' controls the roll counter clockwise
		if (Input.GetKey (KeyCode.I)) {
			float translation = this.transform.position.x * speed;
			translation *= Time.deltaTime;
			this.transform.Rotate( -translation, 0,0);
		}

		// 'X' controls the yaw clockwise
		if (Input.GetKey (KeyCode.Y)) {
			float translation = this.transform.position.z * speed;
			translation *= Time.deltaTime;
			this.transform.Rotate( 0, 0, translation);
			
		}

		//'C' controls the yaw counter clockwise
		if (Input.GetKey (KeyCode.H)) {
			float translation = this.transform.position.z * speed;
			translation *= Time.deltaTime;
			this.transform.Rotate(  0, 0, -translation);
		}

		//space bar reset position
		if (Input.GetKey (KeyCode.Space)) {
			this.transform.position = startPos;
			this.transform.rotation = startRot;
		}

	}
}
