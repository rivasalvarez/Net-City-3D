using UnityEngine;
using System.Collections;

public class cars : MonoBehaviour {
	//public movementspeed of car that can be altered in editor
	public float movementSpeed = 5.0f;
	//public rigidbody for car
	public Rigidbody rb;
	//private bool flag: true, car moves forward, false:car stands still
	private bool flag = true;
	GameObject playerMemory;
	playerManager playerScript;

	string name; // This is if the car is a potential attacker
	Vector3 position; // The position of the vehicle

	// Use this for initialization
	void Start () {
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<playerManager> ();	
		//assign the rigid body of the car to use in collisions
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// if flag true move car forward
		if (flag) {
			transform.position +=  transform.right * Time.deltaTime * movementSpeed;
		} 
		//else the car is stationary
		else {
			rb.velocity = Vector3.zero;
		}
	}

	//Called when two objects touch
	void OnCollisionEnter(Collision other){
		//Check tag to see if colliding with building
		if (other.gameObject.tag == "corporatePre") {
			// if it is then destroy the car because it has reached its destination
			Destroy (gameObject);
			playerScript.addCash(300);
			//flag = false;
		} 


		// Check tag to see if colliding with the gate
		else if (other.gameObject.tag == "gatePre")  
		{
			//set flag so the car won't move and also start coroutine
			flag = false;
			StartCoroutine(moveGate(other));
		}
	}

	//calls a timer and then moves gate to the side and lets car pass
	IEnumerator moveGate(Collision other){
		//set timer for 5secs
		yield return new WaitForSeconds (5);
		//move gate
		other.gameObject.transform.position += new Vector3(10,0,0);
		//set flag to move car forward
		flag = true;
	}

	//gets and sets of car
	public string getName(){
		return name;
	}

	public void setName(string inName){
		name = inName;
	}

	public Vector3 getPosition(){
		return position;
	}

	public void setPosition(Vector3 newPosition){
		position = newPosition;
	}
}
