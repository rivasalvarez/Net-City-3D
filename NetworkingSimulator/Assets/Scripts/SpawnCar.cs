using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {
	GameObject obj;
	Vector3 pos = new Vector3 (203.0f, 0.6f, -2.0f);
	playerManager playerScript;
	float timer = 10;
	GameObject playerMemory;
    int carType;

	// Use this for initialization
	void Start () {
		playerMemory = GameObject.Find ("GameObject");
		playerScript = playerMemory.GetComponent<playerManager> ();	
	}
	
	// Update is called once per frame
	void Update () {

	   timer -= Time.deltaTime;
       if(timer < 0){
          timer = 10;
		  carType = Random.Range(0,8);
		  obj = Resources.Load (playerScript.carTypeArray[carType]) as GameObject;
		  Instantiate (obj, pos,Quaternion.identity ); 
       }   
	}

}
