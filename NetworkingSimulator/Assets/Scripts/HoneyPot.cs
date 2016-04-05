using UnityEngine;
using System.Collections.Generic;

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



	// Use this for initialization
	void Start () {
      gameMgr = GameObject.Find("GameObject").GetComponent<gameManager>();
      main = GameObject.Find("Main Camera").GetComponent<mainGame>();
      PID = gameMgr.honeyCount++;
        
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

	void OnCollisionEnter(Collision col){
        if( carTags.Contains(col.gameObject.tag) ){
           Car colCar = col.gameObject.GetComponent<Car>();
              if (Keys.Contains(colCar.colorString) || Keys.Contains(colCar.carTypeString) || Keys.Contains(colCar.sizeString) ){

                if (!carPIDS.ContainsKey(colCar.carPID)){
                    carPIDS.Add(colCar.carPID, colCar);
                    Debug.Log("Added");
                }
             }
        }
	}

    void OnMouseDown(){
        upgrade = true;
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

    void OnGUI(){
        if (upgrade == true)
        {
            Time.timeScale = 0;


            if (level == 1)
            {
                GUI.Box(new Rect(500, 100, 700, 700), "Upgrade Options");

                red = GUI.Toggle(new Rect(510, 140, 100, 30), red, "Red");
                green = GUI.Toggle(new Rect(510, 240, 100, 30), green, "Green");
                blue = GUI.Toggle(new Rect(510, 340, 100, 30), blue, "Blue");
                yellow = GUI.Toggle(new Rect(510, 440, 100, 30), yellow, "Yellow");

                //This is to check for what type of color the security gate will look for
                if (red && !Keys.Contains("Red")) { Keys.Add("Red"); Debug.Log("on"); }
                else if (!red && Keys.Contains("Red")) { Keys.Remove("Red"); Debug.Log("off"); }

                else if (green && !Keys.Contains("Green")) { Keys.Add("Green"); Debug.Log("on"); }
                else if (!green && Keys.Contains("Green")) { Keys.Remove("Green"); Debug.Log("off"); }

                else if (blue && !Keys.Contains("Blue")) { Keys.Add("Blue"); Debug.Log("on"); }
                else if (!blue && Keys.Contains("Blue")) { Keys.Remove("Blue"); Debug.Log("off"); }

                else if (yellow && !Keys.Contains("Yellow")) { Keys.Add("Yellow"); Debug.Log("on"); }
                else if (!yellow && Keys.Contains("Yellow")) { Keys.Remove("Yellow"); Debug.Log("off"); }


                if (GUI.Button(new Rect(840, 400 - (128 * 2) + 128, 128, 50), "Purchase"))
                {
                    upgrade = false;
                    Time.timeScale = 1;
                }

                if (GUI.Button(new Rect(840, 400 - 128 + 128, 128, 50), "Cancel Purchase"))
                {
                    //clear();
                    upgrade = false;
                    Time.timeScale = 1;

                }

            }


            if (level == 2)
            {
                GUI.Box(new Rect(500, 100, 700, 700), "Upgrade Options");

                red = GUI.Toggle(new Rect(510, 140, 100, 30), red, "Red");
                green = GUI.Toggle(new Rect(510, 240, 100, 30), green, "Green");
                blue = GUI.Toggle(new Rect(510, 340, 100, 30), blue, "Blue");
                yellow = GUI.Toggle(new Rect(510, 440, 100, 30), yellow, "Yellow");

                small = GUI.Toggle(new Rect(640, 140, 100, 30), small, "Small");
                median = GUI.Toggle(new Rect(640, 240, 100, 30), median, "Meduim");
                large = GUI.Toggle(new Rect(640, 340, 100, 30), large, "Large");


                //This is to check for what type of color the security gate will look for
                if (red && !Keys.Contains("Red")) { Keys.Add("Red"); Debug.Log("on"); }
                else if (!red && Keys.Contains("Red")) { Keys.Remove("Red"); Debug.Log("off"); }

                else if (green && !Keys.Contains("Green")) { Keys.Add("Green"); Debug.Log("on"); }
                else if (!green && Keys.Contains("Green")) { Keys.Remove("Green"); Debug.Log("off"); }

                else if (blue && !Keys.Contains("Blue")) { Keys.Add("Blue"); Debug.Log("on"); }
                else if (!blue && Keys.Contains("Blue")) { Keys.Remove("Blue"); Debug.Log("off"); }

                else if (yellow && !Keys.Contains("Yellow")) { Keys.Add("Yellow"); Debug.Log("on"); }
                else if (!yellow && Keys.Contains("Yellow")) { Keys.Remove("Yellow"); Debug.Log("off"); }

                else if (small && !Keys.Contains("Small")) { Keys.Add("Small"); Debug.Log("on"); }
                else if (!small && Keys.Contains("Small")) { Keys.Remove("Small"); Debug.Log("off"); }

                else if (median && !Keys.Contains("Medium")) { Keys.Add("Medium"); Debug.Log("on"); }
                else if (!median && Keys.Contains("Medium")) { Keys.Remove("Medium"); Debug.Log("off"); }

                else if (large && !Keys.Contains("Large")) { Keys.Add("Large"); Debug.Log("on"); }
                else if (!large && Keys.Contains("Large")) { Keys.Remove("Large"); Debug.Log("off"); }


                if (GUI.Button(new Rect(840, 400 - (128 * 2) + 128, 128, 50), "Purchase"))
                {
                    upgrade = false;
                    Time.timeScale = 1;
                }

                if (GUI.Button(new Rect(840, 400 - 128 + 128, 128, 50), "Cancel Purchase"))
                {
                    //clear();
                    upgrade = false;
                    Time.timeScale = 1;

                }

            }



            if (level == 3)
            {
                GUI.Box(new Rect(500, 100, 700, 700), "Upgrade Options");

                red = GUI.Toggle(new Rect(510, 140, 100, 30), red, "Red");
                green = GUI.Toggle(new Rect(510, 240, 100, 30), green, "Green");
                blue = GUI.Toggle(new Rect(510, 340, 100, 30), blue, "Blue");
                yellow = GUI.Toggle(new Rect(510, 440, 100, 30), yellow, "Yellow");

                small = GUI.Toggle(new Rect(640, 140, 100, 30), small, "Small");
                median = GUI.Toggle(new Rect(640, 240, 100, 30), median, "Meduim");
                large = GUI.Toggle(new Rect(640, 340, 100, 30), large, "Large");

                ambulance = GUI.Toggle(new Rect(740, 140, 100, 30), ambulance, "Ambulance");
                fireTruck = GUI.Toggle(new Rect(740, 240, 100, 30), fireTruck, "Fire Truck");
                Tanker = GUI.Toggle(new Rect(740, 340, 100, 30), Tanker, "Oil Truck");
                Truck = GUI.Toggle(new Rect(740, 440, 100, 30), Truck, "Truck");
                Hearse = GUI.Toggle(new Rect(740, 540, 100, 30), Hearse, "Hearse");
                IceCream = GUI.Toggle(new Rect(740, 640, 100, 30), IceCream, "Ice Cream Truck");
                policeCar = GUI.Toggle(new Rect(740, 740, 100, 30), policeCar, "Police Car");


                //This is to check for what type of color the security gate will look for
                if (red && !Keys.Contains("Red")) { Keys.Add("Red"); Debug.Log("on"); }
                else if (!red && Keys.Contains("Red")) { Keys.Remove("Red"); Debug.Log("off"); }

                else if (green && !Keys.Contains("Green")) { Keys.Add("Green"); Debug.Log("on"); }
                else if (!green && Keys.Contains("Green")) { Keys.Remove("Green"); Debug.Log("off"); }

                else if (blue && !Keys.Contains("Blue")) { Keys.Add("Blue"); Debug.Log("on"); }
                else if (!blue && Keys.Contains("Blue")) { Keys.Remove("Blue"); Debug.Log("off"); }

                else if (yellow && !Keys.Contains("Yellow")) { Keys.Add("Yellow"); Debug.Log("on"); }
                else if (!yellow && Keys.Contains("Yellow")) { Keys.Remove("Yellow"); Debug.Log("off"); }

                else if (small && !Keys.Contains("Small")) { Keys.Add("Small"); Debug.Log("on"); }
                else if (!small && Keys.Contains("Small")) { Keys.Remove("Small"); Debug.Log("off"); }

                else if (median && !Keys.Contains("Medium")) { Keys.Add("Medium"); Debug.Log("on"); }
                else if (!median && Keys.Contains("Medium")) { Keys.Remove("Medium"); Debug.Log("off"); }

                else if (large && !Keys.Contains("Large")) { Keys.Add("Large"); Debug.Log("on"); }
                else if (!large && Keys.Contains("Large")) { Keys.Remove("Large"); Debug.Log("off"); }

                else if (ambulance && !Keys.Contains("Ambulance")) { Keys.Add("Ambulance"); Debug.Log("on"); }
                else if (!ambulance && Keys.Contains("Ambulance")) { Keys.Remove("Ambulance"); Debug.Log("off"); }

                else if (fireTruck && !Keys.Contains("Fire Truck")) { Keys.Add("Fire Truck"); Debug.Log("on"); }
                else if (!fireTruck && Keys.Contains("Fire Truck")) { Keys.Remove("Fire Truck"); Debug.Log("off"); }

                else if (Tanker && !Keys.Contains("Tanker")) { Keys.Add("Tanker"); Debug.Log("on"); }
                else if (!Tanker && Keys.Contains("Tanker")) { Keys.Remove("Tanker"); Debug.Log("off"); }

                else if (Truck && !Keys.Contains("Truck")) { Keys.Add("Truck"); Debug.Log("on"); }
                else if (!Truck && Keys.Contains("Truck")) { Keys.Remove("Truck"); Debug.Log("off"); }

                else if (Hearse && !Keys.Contains("Hearse")) { Keys.Add("Hearse"); Debug.Log("on"); }
                else if (!Hearse && Keys.Contains("Hearse")) { Keys.Remove("Hearse"); Debug.Log("off"); }

                else if (IceCream && !Keys.Contains("Ice Cream")) { Keys.Add("Ice Cream"); Debug.Log("on"); }
                else if (!IceCream && Keys.Contains("Ice Cream")) { Keys.Remove("Ice Cream"); Debug.Log("off"); }

                else if (policeCar && !Keys.Contains("Police Car")) { Keys.Add("Police Car"); Debug.Log("on"); }
                else if (!policeCar && Keys.Contains("Police Car")) { Keys.Remove("Police Car"); Debug.Log("off"); }


                if (GUI.Button(new Rect(840, 400 - (128 * 2) + 128, 128, 50), "Purchase"))
                {
                    upgrade = false;
                    Time.timeScale = 1;
                }

                if (GUI.Button(new Rect(840, 400 - 128 + 128, 128, 50), "Cancel Purchase"))
                {
                    //clear();
                    upgrade = false;
                    Time.timeScale = 1;

                }

            }



        }
    }
}
