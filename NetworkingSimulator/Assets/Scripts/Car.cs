using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
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

	Vector3 position; // The position of the vehicle
    public string honeyPotIn;

	// Use this for initialization
	void Start () {
        gameMgr = GameObject.Find("GameObject").GetComponent<gameManager>();	

		//Random Path for now
		route = Random.Range(0,7);
		carColor = Random.Range(0,4);

		carTypeString = gameMgr.carTypeDict[gameMgr.carType];
        sizeString = gameMgr.carSizeDict[gameMgr.carType];
        colorString = gameMgr.carColorDict[carColor];
        carPID = gameMgr.count;
		setWavePoints (route);

        gameObject.GetComponent<Renderer>().material.color = gameMgr.colorArray[carColor];
        //gameObject.GetComponent<Renderer>().material = Resources.Load("Materials/IceCream") as Material;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentWayPoint < this.wayPointList.Length)
			drive();
	}

	//Called when two objects touch
	void OnCollisionEnter(Collision col){

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

}
