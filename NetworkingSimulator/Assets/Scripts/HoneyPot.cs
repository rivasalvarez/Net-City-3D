using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class HoneyPot : MonoBehaviour {

  gameManager gameMgr;
  mainGame main;
  public Dictionary<int, Car> carPIDS = new Dictionary<int, Car>();
  public List<string> Keys = new List<string>();
  public List<string> carTags = new List<string>();

  int level = 1;
  int PID;

  bool upgrade = false;
  bool red = false;
  bool blue = false;
  bool yellow = false;
  bool green = false;
  bool small = false;
  bool median = false;
  bool large = false;
  bool ambulance = false;
  bool fireTruck = false;
  bool Tanker = false;
  bool Truck = false;
  bool Hearse = false;
  bool policeCar = false;
  bool IceCream = false;
  public bool first = true;

  public Camera myCam; // The camera object
  private Vector3 screenPoint; private Vector3 offset; private float _lockedYPosition;

	// Use this for initialization
	void Start () {
      gameMgr = GameObject.Find("GameObject").GetComponent<gameManager>();
      main = GameObject.Find("Main Camera").GetComponent<mainGame>();
      PID = gameMgr.honeyCount++;
      myCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        carTags.Add("Ambulance");
        carTags.Add("FireTruck");
        carTags.Add("Hearse");
        carTags.Add("IceCream");
        carTags.Add("PoliceCar");
        carTags.Add("Tanker");
        carTags.Add("Taxi");
        carTags.Add("Truck");
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseOver(){
        if ( Input.GetMouseButtonDown(1))
        upgrade = true;
    }

	void OnCollisionEnter(Collision col){
        if( carTags.Contains(col.gameObject.tag) ){

           Car colCar = col.gameObject.GetComponent<Car>();
              if (Keys.Contains(colCar.colorString) || Keys.Contains(colCar.carTypeString) || Keys.Contains(colCar.sizeString) ){

                if (!carPIDS.ContainsKey(colCar.carPID)){
                    colCar.honeyPotIn = main.time;
                    carPIDS.Add(colCar.carPID, colCar);
                    Debug.Log("Added");
                }
             }
        }
	}


    void OnMouseDrag()
    {

            Ray vRay = myCam.ScreenPointToRay(Input.mousePosition);

            // Create a hit variable that will store the value of whatever it hits
            RaycastHit hit;
            int layerMask = 1 << 8;

            // Cast a raycast from the starting position of the mouse down infinitely
            if (Physics.Raycast(vRay, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject);
                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.tag == "Terrain" || hit.collider.tag == "Honey")
                {
                    if(hit.point.x > 0 && hit.point.x < 300 && hit.point.z > 0 && hit.point.z < 300){
                    // This is a variable that will hold the position of where the hit is detected for the mouse
                    Vector3 placePosition;

                    // Store the hit position into the placePosition
                    placePosition = hit.point;

                    // This will round the x and z variable, not sure if this is needed though since accuracy is much better than inaccuracy for object placement
                    placePosition.x = Mathf.Round(placePosition.x);
                    placePosition.z = Mathf.Round(placePosition.z);


                    // Change the position of it so it will be placed a little bit above the road level
                    transform.position = new Vector3(placePosition.x, 0.6f, placePosition.z);
                    }
                }

            }

        
    }

    public void setList(List<string> purchasedList){
        Keys.AddRange(purchasedList);
    }

    public void setLevel(int l)
    {
        level = l;
    }

    public void setMenuBools(bool r, bool g, bool b, bool y, bool s, bool m, bool l, bool a, bool f, bool ta, bool tr, bool h, bool p, bool i)
    {
      red = r;
      blue = b;
      yellow = y;
      green = g;

      small = s;
      median = m;
      large = l;

      ambulance = a;
      fireTruck = f;
      Tanker = ta;
      Truck = tr;
      Hearse = h;
      policeCar = p;
      IceCream = i;
    }

    public void writeToLog(StreamWriter fout)
    {
        fout.WriteLine("Log for HoneyPot {0} (Level {1}):", PID, level);

        foreach (KeyValuePair<int, Car> kvp in carPIDS)
        {
            int i = 1;
            if (level == 1)
            {
                fout.WriteLine("Car Color: {0},  Time: {1}", kvp.Value.colorString, kvp.Value.honeyPotIn);
            }

            if (level == 2)
            {
                fout.WriteLine("Car Color: {0}, Car Size: {1}, Time: {2}", kvp.Value.colorString, kvp.Value.sizeString, kvp.Value.honeyPotIn);
            }

            if (level == 3)
            {
                fout.WriteLine("Car Color: {0}, Car Size: {1}, Car Type: {2}, Time: {3}", kvp.Value.colorString, kvp.Value.sizeString, kvp.Value.carTypeString, kvp.Value.honeyPotIn);
            }
        }
            fout.WriteLine();
            fout.WriteLine();
    }

    void OnGUI(){

		
		GUI.skin = Resources.Load ("Buttons/ShopSkin") as GUISkin;
		GUIStyle guiStyle = GUI.skin.GetStyle ("Shop");

        if (upgrade == true)
        {
            Time.timeScale = 0;


            if (level == 1)
            {
                GUI.Box(new Rect(500, 100, 700, 700), "Upgrade Options");
				
				red = GUI.Toggle(new Rect(510, 140, GUI.skin.toggle.fixedWidth, 30), red, "Red");
				green = GUI.Toggle(new Rect(510, 215, GUI.skin.toggle.fixedWidth, 30), green, "Green");
				blue = GUI.Toggle(new Rect(510, 290, GUI.skin.toggle.fixedWidth, 30), blue, "Blue");
				yellow = GUI.Toggle(new Rect(510, 365, GUI.skin.toggle.fixedWidth, 30), yellow, "Yellow");

                //This is to check for what type of color the security gate will look for
                if (red && !Keys.Contains("Red")) Keys.Add("Red"); 
                else if (!red && Keys.Contains("Red")) Keys.Remove("Red");

                else if (green && !Keys.Contains("Green")) Keys.Add("Green"); 
                else if (!green && Keys.Contains("Green")) Keys.Remove("Green");

                else if (blue && !Keys.Contains("Blue"))  Keys.Add("Blue");
                else if (!blue && Keys.Contains("Blue"))  Keys.Remove("Blue"); 

                else if (yellow && !Keys.Contains("Yellow"))  Keys.Add("Yellow");
                else if (!yellow && Keys.Contains("Yellow"))  Keys.Remove("Yellow");


				if (GUI.Button(new Rect(510, 550, GUI.skin.button.fixedWidth, 50), "Purchase"))
                {
                    upgrade = false;
                    Time.timeScale = 1;
                }

				if (GUI.Button(new Rect(510, 650, GUI.skin.button.fixedWidth, 50), "Cancel Purchase"))
                {
                    //clear();
                    upgrade = false;
                    Time.timeScale = 1;

                }

            }


            if (level == 2)
            {
                GUI.Box(new Rect(500, 100, 700, 700), "Upgrade Options");

                red = GUI.Toggle(new Rect(510, 140, GUI.skin.toggle.fixedWidth, 30), red, "Red");
                green = GUI.Toggle(new Rect(510, 215, GUI.skin.toggle.fixedWidth, 30), green, "Green");
                blue = GUI.Toggle(new Rect(510, 290, GUI.skin.toggle.fixedWidth, 30), blue, "Blue");
                yellow = GUI.Toggle(new Rect(510, 365, GUI.skin.toggle.fixedWidth, 30), yellow, "Yellow");

                small = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 530, 140, GUI.skin.toggle.fixedWidth, 30), small, "Small");
                median = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 530, 215, GUI.skin.toggle.fixedWidth, 30), median, "Meduim");
                large = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 530, 290, GUI.skin.toggle.fixedWidth, 30), large, "Large");



                if (red && !Keys.Contains("Red"))  Keys.Add("Red");
                else if (!red && Keys.Contains("Red"))  Keys.Remove("Red");

                else if (green && !Keys.Contains("Green"))  Keys.Add("Green");
                else if (!green && Keys.Contains("Green"))  Keys.Remove("Green"); 

                else if (blue && !Keys.Contains("Blue")) Keys.Add("Blue"); 
                else if (!blue && Keys.Contains("Blue")) Keys.Remove("Blue"); 

                else if (yellow && !Keys.Contains("Yellow"))  Keys.Add("Yellow"); 
                else if (!yellow && Keys.Contains("Yellow"))  Keys.Remove("Yellow"); 

                else if (small && !Keys.Contains("Small"))  Keys.Add("Small"); 
                else if (!small && Keys.Contains("Small"))  Keys.Remove("Small");

                else if (median && !Keys.Contains("Medium"))  Keys.Add("Medium"); 
                else if (!median && Keys.Contains("Medium"))  Keys.Remove("Medium"); 

                else if (large && !Keys.Contains("Large"))  Keys.Add("Large");
                else if (!large && Keys.Contains("Large"))  Keys.Remove("Large");


				if (GUI.Button(new Rect(510, 550, GUI.skin.button.fixedWidth, 50), "Purchase"))
                {
                    upgrade = false;
                    Time.timeScale = 1;
                }

				if (GUI.Button(new Rect(510, 650, GUI.skin.button.fixedWidth, 50), "Cancel Purchase"))
                {
                    //clear();
                    upgrade = false;
                    Time.timeScale = 1;

                }

            }



            if (level == 3)
            {
                GUI.Box(new Rect(500, 100, 700, 700), "Upgrade Options");
				
				red = GUI.Toggle(new Rect(510, 140, GUI.skin.toggle.fixedWidth, 30), red, "Red");
				green = GUI.Toggle(new Rect(510, 215, GUI.skin.toggle.fixedWidth, 30), green, "Green");
				blue = GUI.Toggle(new Rect(510, 290, GUI.skin.toggle.fixedWidth, 30), blue, "Blue");
				yellow = GUI.Toggle(new Rect(510, 365, GUI.skin.toggle.fixedWidth, 30), yellow, "Yellow");
				
				small = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 530, 140, GUI.skin.toggle.fixedWidth, 30), small, "Small");
				median = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 530, 215, GUI.skin.toggle.fixedWidth, 30), median, "Meduim");
				large = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth + 530, 290, GUI.skin.toggle.fixedWidth, 30), large, "Large");

                ambulance = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 140, GUI.skin.toggle.fixedWidth, 30), ambulance, "Ambulance");
                fireTruck = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 215, GUI.skin.toggle.fixedWidth, 30), fireTruck, "Fire Truck");
                Tanker = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 290, GUI.skin.toggle.fixedWidth, 30), Tanker, "Oil Truck");
                Truck = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 365, GUI.skin.toggle.fixedWidth, 30), Truck, "Truck");
                Hearse = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 440, GUI.skin.toggle.fixedWidth, 30), Hearse, "Hearse");
                IceCream = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 515, GUI.skin.toggle.fixedWidth, 30), IceCream, "Ice Cream");
                policeCar = GUI.Toggle(new Rect(GUI.skin.toggle.fixedWidth * 2 + 530, 590, GUI.skin.toggle.fixedWidth, 30), policeCar, "Police Car");



                if (red && !Keys.Contains("Red"))  Keys.Add("Red"); 
                else if (!red && Keys.Contains("Red"))  Keys.Remove("Red"); 

                else if (green && !Keys.Contains("Green"))  Keys.Add("Green"); 
                else if (!green && Keys.Contains("Green"))  Keys.Remove("Green"); 

                else if (blue && !Keys.Contains("Blue"))  Keys.Add("Blue");
                else if (!blue && Keys.Contains("Blue"))  Keys.Remove("Blue"); 

                else if (yellow && !Keys.Contains("Yellow"))  Keys.Add("Yellow"); 
                else if (!yellow && Keys.Contains("Yellow"))  Keys.Remove("Yellow"); 

                else if (small && !Keys.Contains("Small"))  Keys.Add("Small"); 
                else if (!small && Keys.Contains("Small"))  Keys.Remove("Small"); 

                else if (median && !Keys.Contains("Medium"))  Keys.Add("Medium");
                else if (!median && Keys.Contains("Medium"))  Keys.Remove("Medium"); 

                else if (large && !Keys.Contains("Large"))  Keys.Add("Large"); 
                else if (!large && Keys.Contains("Large"))  Keys.Remove("Large"); 

                else if (ambulance && !Keys.Contains("Ambulance")) Keys.Add("Ambulance"); 
                else if (!ambulance && Keys.Contains("Ambulance")) Keys.Remove("Ambulance");

                else if (fireTruck && !Keys.Contains("Fire Truck"))  Keys.Add("Fire Truck");
                else if (!fireTruck && Keys.Contains("Fire Truck"))  Keys.Remove("Fire Truck");

                else if (Tanker && !Keys.Contains("Tanker"))  Keys.Add("Tanker");
                else if (!Tanker && Keys.Contains("Tanker"))  Keys.Remove("Tanker");

                else if (Truck && !Keys.Contains("Truck"))  Keys.Add("Truck");
                else if (!Truck && Keys.Contains("Truck"))  Keys.Remove("Truck");

                else if (Hearse && !Keys.Contains("Hearse"))  Keys.Add("Hearse");
                else if (!Hearse && Keys.Contains("Hearse"))  Keys.Remove("Hearse"); 

                else if (IceCream && !Keys.Contains("Ice Cream"))  Keys.Add("Ice Cream");
                else if (!IceCream && Keys.Contains("Ice Cream"))  Keys.Remove("Ice Cream"); 

                else if (policeCar && !Keys.Contains("Police Car"))  Keys.Add("Police Car");
                else if (!policeCar && Keys.Contains("Police Car"))  Keys.Remove("Police Car"); 


				if (GUI.Button(new Rect(510, 550, GUI.skin.button.fixedWidth, 50), "Purchase"))
                {
                    upgrade = false;
                    Time.timeScale = 1;
                }

				if (GUI.Button(new Rect(510, 650, GUI.skin.button.fixedWidth, 50), "Cancel Purchase"))
                {
                    //clear();
                    upgrade = false;
                    Time.timeScale = 1;

                }

            }



        }
    }
}
