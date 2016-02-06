using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {
	GameObject obj;

	// Use this for initialization
	void Start () {
		obj = Instantiate (Resources.Load ("Models/Cars/carPrefab/firetruckPre 1", typeof(GameObject))) as GameObject;
		obj.GetComponent<cars>().setPosition(new Vector3(157.1f, 0.6f, 11.58f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
