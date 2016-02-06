using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	public Transform[] wayPointList;
	public int currentWayPoint = 0;
	Transform targetWayPoint;
	public float speed = 4f;

	// Use this for initialization
	void Start (){
	}
	
	// Update is called once per frame
	void Update (){
	  
		if (currentWayPoint < this.wayPointList.Length){
          if(targetWayPoint == null)
             targetWayPoint = wayPointList[currentWayPoint];
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