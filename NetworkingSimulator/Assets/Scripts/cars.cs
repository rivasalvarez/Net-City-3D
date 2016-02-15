using UnityEngine;
using System.Collections;

public class cars : MonoBehaviour {

	public Rigidbody rb;
	private bool flag = true;
	GameObject playerMemory;
	playerManager playerScript;

	//WavePoint Stuff
	private Transform[] wayPointList;
	private int currentWayPoint = 0;
	Transform targetWayPoint;
	private float speed = 15f;

    //Car Details
    private string color;
	public int route;
    public int carColor;
	public float movementSpeed = 5.0f;

	string name; // This is if the car is a potential attacker
	Vector3 position; // The position of the vehicle

	// Use this for initialization
	void Start () {
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<playerManager> ();	

		//assign the rigid body of the car to use in collisions
		rb = GetComponent<Rigidbody>();

		//Random Path for now
		route = Random.Range(0,4);
		carColor = Random.Range(0,4);
		gameObject.GetComponent<Renderer>().material.color = playerScript.colorArray[carColor];
		setWavePoints (route);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentWayPoint < this.wayPointList.Length)
			drive();
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

	void drive(){
		transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
		transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
		
		if (transform.position == targetWayPoint.position)
			currentWayPoint++;
		
		if(currentWayPoint < this.wayPointList.Length)
			targetWayPoint = wayPointList[currentWayPoint];
		
	} 

	void setWavePoints(int ro){
  
		switch( ro ){
		case 0:
			wayPointList = new Transform[5];
			wayPointList[0] = GameObject.Find ("WayPoint1").transform;
			wayPointList[1] = GameObject.Find ("WayPoint2").transform;
			wayPointList[2] = GameObject.Find ("WayPoint3").transform;
			wayPointList[3] = GameObject.Find ("WayPoint4").transform;
			wayPointList[4] = GameObject.Find ("WayPoint5").transform;
			break;

		case 1:
			wayPointList = new Transform[4];
			wayPointList[0] = GameObject.Find ("WayPoint1").transform;
			wayPointList[1] = GameObject.Find ("WayPoint2").transform;
			wayPointList[2] = GameObject.Find ("WayPoint8").transform;
			wayPointList[3] = GameObject.Find ("WayPoint9").transform;
			break;

		case 2:
			wayPointList = new Transform[8];
			wayPointList[0] = GameObject.Find ("WayPoint1").transform;
			wayPointList[1] = GameObject.Find ("WayPoint2").transform;
			wayPointList[2] = GameObject.Find ("WayPoint6").transform;
			wayPointList[3] = GameObject.Find ("WayPoint10").transform;
			wayPointList[4] = GameObject.Find ("WayPoint11").transform;
			wayPointList[5] = GameObject.Find ("WayPoint12").transform;
			wayPointList[6] = GameObject.Find ("WayPoint13").transform;
			wayPointList[7] = GameObject.Find ("WayPoint14").transform;
			break;

		case 3:
			wayPointList = new Transform[8];
			wayPointList[0] = GameObject.Find ("WayPoint1").transform;
			wayPointList[1] = GameObject.Find ("WayPoint2").transform;
			wayPointList[2] = GameObject.Find ("WayPoint3").transform;
			wayPointList[3] = GameObject.Find ("WayPoint15").transform;
			wayPointList[4] = GameObject.Find ("WayPoint16").transform;
			wayPointList[5] = GameObject.Find ("WayPoint17").transform;
			wayPointList[6] = GameObject.Find ("WayPoint18").transform;
			wayPointList[7] = GameObject.Find ("WayPoint19").transform;
			break;
		}

		targetWayPoint = wayPointList[currentWayPoint];
	}
}
