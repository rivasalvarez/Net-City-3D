using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {
	GameObject obj;
    int i = 0;
	// Use this for initialization
	void Start () {
		obj = Instantiate (Resources.Load ("Models/Cars/carPrefab/police_car", typeof(GameObject))) as GameObject;
		obj.GetComponent<cars>().setPosition(new Vector3(157.1f, 0.6f, 11.58f));
	}
	
	// Update is called once per frame
	void Update () {
	i++;
       if(i == 500){
        i = 0;
		obj = Instantiate (Resources.Load ("Models/Cars/carPrefab/police_car", typeof(GameObject))) as GameObject;
		obj.GetComponent<cars>().setPosition(new Vector3(157.1f, 0.6f, 11.58f));
       }
	}
}
