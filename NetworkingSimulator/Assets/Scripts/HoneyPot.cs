using UnityEngine;
using System.Collections.Generic;

public class HoneyPot : MonoBehaviour {

  gameManager gameMgr;
  mainGame main;
  public Dictionary<int, Car> carPIDS = new Dictionary<int, Car>();
  public List<string> Keys = new List<string>();


	// Use this for initialization
	void Start () {
      gameMgr = GameObject.Find("GameObject").GetComponent<gameManager>();
      main = GameObject.Find("Main Camera").GetComponent<mainGame>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "car"){
           Car colCar = col.gameObject.GetComponent<Car>();
           foreach (var flag in Keys){
              if (colCar.colorString == flag || colCar.carTypeString == flag || colCar.sizeString == flag){

                if (!carPIDS.ContainsKey(colCar.carPID)){
                    carPIDS.Add(colCar.carPID, colCar);
                    Debug.Log("Added");
                }
             }
           }
        }
	}

    void OnMouseDown(){
        Debug.Log("click");
    }
}
