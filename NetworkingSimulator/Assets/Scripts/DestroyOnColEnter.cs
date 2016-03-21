using UnityEngine;
using System.Collections;

public class DestroyOnColEnter : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		/*
		if (col.gameObject.name != "Terrain") {
			Destroy (col.gameObject);
		}*/
		Debug.Log (col.gameObject.tag);
	}
}
