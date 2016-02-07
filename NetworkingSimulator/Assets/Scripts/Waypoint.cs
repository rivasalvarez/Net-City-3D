using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public Transform[] wayPointList = new Transform[5];
	public int currentWayPoint = 0;
	Transform targetWayPoint;
	public float speed = 4f;

	// Use this for initialization
	void Start (){
		wayPointList[0] = GameObject.Find ("WayPoint1").transform;
		wayPointList[1] = GameObject.Find ("WayPoint2").transform;
		wayPointList[2] = GameObject.Find ("WayPoint3").transform;
		wayPointList[3] = GameObject.Find ("WayPoint4").transform;
		wayPointList[4] = GameObject.Find ("WayPoint5").transform;
        targetWayPoint = wayPointList[currentWayPoint];
	}
	
	// Update is called once per frame
	void Update (){
	  
		if (currentWayPoint < this.wayPointList.Length){

          walk();
		}
	}

    void walk(){
      transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
      transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
      if(transform.position == targetWayPoint.position){
        currentWayPoint++;
        targetWayPoint = wayPointList[currentWayPoint];
      }
    }   
}