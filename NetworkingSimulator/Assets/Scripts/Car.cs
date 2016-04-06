using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	public bool stop; // This variable is to make sure that the car is stopped before the security gate
	public Rigidbody rb;
	private bool flag = true;
	GameObject playerMemory;
	gameManager gameMgr;

	//WavePoint Stuff
	private Transform[] wayPointList;
	private int currentWayPoint = 0;
	Transform targetWayPoint;

    //Car Details
    public string colorString;
    public string sizeString;
    public string carTypeString;

	public int route;
    public int carColor;
	public float speed = 10.0f;
    public int carPID;

    string name; // This is if the car is a potential attacker
	Vector3 position; // The position of the vehicle
    public string honeyPotIn;

	// Use this for initialization
	void Start () {
		playerMemory = GameObject.Find ("GameObject");
		gameMgr = playerMemory.GetComponent<gameManager> ();	

		//assign the rigid body of the car to use in collisions
		rb = GetComponent<Rigidbody>();

		//Random Path for now
		route = Random.Range(0,7);
		carColor = Random.Range(0,4);
		gameObject.GetComponent<Renderer>().material.color = gameMgr.colorArray[carColor];


		carTypeString = gameMgr.carTypeDict[gameMgr.carType];
        sizeString = gameMgr.carSizeDict[gameMgr.carType];
        colorString = gameMgr.carColorDict[carColor];
        carPID = gameMgr.count;
		setWavePoints (route);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentWayPoint < this.wayPointList.Length)
			drive();
	}

	//Called when two objects touch
	void OnCollisionEnter(Collision col){

		//Check tag to see if colliding with building
		if (col.gameObject.tag == "Building") {
			// if it is then destroy the car because it has reached its destination
			Destroy (gameObject);
			gameMgr.cash += 300;
            Debug.Log("collision");
		} 

/*
		// Check tag to see if colliding with the gate
		else if (col.gameObject.tag == "gatePre")  
		{
			//set flag so the car won't move and also start coroutine
			flag = false;
			StartCoroutine(moveGate(col));
		}
*/
	}

	//calls a timer and then moves gate to the side and lets car pass
	/*IEnumerator moveGate(Collision other){

		//set timer for 5secs
		yield return new WaitForSeconds (5);
		//move gate
		other.gameObject.transform.position += new Vector3(10,0,0);
		//set flag to move car forward
		flag = true;
		
	}
*/
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
			transform.forward = Vector3.RotateTowards (transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
			transform.position = Vector3.MoveTowards (transform.position, targetWayPoint.position, speed * Time.deltaTime);
			
			if (transform.position == targetWayPoint.position)
				currentWayPoint++;
			
			if (currentWayPoint < this.wayPointList.Length)
				targetWayPoint = wayPointList [currentWayPoint];
		
	} 

	void setWavePoints(int ro){
  
		switch( ro ){

            case 0:
                 wayPointList = new Transform[4];
  			     wayPointList[0] = GameObject.Find ("WayPoint1").transform;
  			     wayPointList[1] = GameObject.Find ("WayPoint2").transform;
  			     wayPointList[2] = GameObject.Find ("WayPoint3").transform;
 			     wayPointList[3] = GameObject.Find ("BankPoint").transform;
                 break;

            case 1:
                 wayPointList = new Transform[4];
                 wayPointList[0] = GameObject.Find("WayPoint1").transform;
                 wayPointList[1] = GameObject.Find("WayPoint5").transform;
                 wayPointList[2] = GameObject.Find("WayPoint6").transform;
                 wayPointList[3] = GameObject.Find("HousePoint").transform;
                 break;

            case 2:
 			    wayPointList = new Transform[3];
 			    wayPointList[0] = GameObject.Find ("WayPoint1").transform;
 			    wayPointList[1] = GameObject.Find ("WayPoint8").transform;
 		    	wayPointList[2] = GameObject.Find ("PolicePoint").transform;
 		    	break;
 
 		    case 3:
 		    	wayPointList = new Transform[3];
                wayPointList[0] = GameObject.Find ("WayPoint1").transform;
  			    wayPointList[1] = GameObject.Find ("WayPoint10").transform;
                wayPointList[2] = GameObject.Find ("StorePoint").transform;
 		    	break;
 
 	    	case 4:
 		    	wayPointList = new Transform[2];
 		    	wayPointList[0] = GameObject.Find ("WayPoint1").transform;
 			    wayPointList[1] = GameObject.Find ("PharmacyPoint").transform;
                break;
  
 	    	case 5:
 		    	wayPointList = new Transform[4];
 		    	wayPointList[0] = GameObject.Find ("WayPoint1").transform;
 		    	wayPointList[1] = GameObject.Find ("WayPoint5").transform;
 		    	wayPointList[2] = GameObject.Find ("WayPoint6").transform;
 		    	wayPointList[3] = GameObject.Find ("SchoolPoint").transform;
 		    	break;
 
 		    case 6:
 			    wayPointList = new Transform[4];
                wayPointList[0] = GameObject.Find ("WayPoint1").transform;
  			    wayPointList[1] = GameObject.Find ("WayPoint2").transform;
 		    	wayPointList[2] = GameObject.Find ("WayPoint14").transform;
 		    	wayPointList[3] = GameObject.Find ("HospitalPoint").transform;
                break;

		}

		targetWayPoint = wayPointList[currentWayPoint];
	}

	public void setStop(){
		stop = true;
	}

}
