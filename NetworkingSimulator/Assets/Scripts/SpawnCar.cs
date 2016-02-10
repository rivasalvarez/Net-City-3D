using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {
	GameObject obj;
	Vector3 pos = new Vector3 (203.0f, 0.6f, -2.0f);
    int i = 0;
	// Use this for initialization
	void Start () {
		//obj = Resources.Load ("Prefabs/policeCar") as GameObject;
		Instantiate ((Resources.Load ("Prefabs/policeCar") as GameObject), pos,Quaternion.identity );
	}
	
	// Update is called once per frame
	void Update () {
	i++;
       if(i == 500){
        i = 0;
			obj = Resources.Load ("Prefabs/policeCar") as GameObject;
			Instantiate (obj, pos,Quaternion.identity ); 
       }   
	}
}
