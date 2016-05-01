using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutorials : MonoBehaviour {
	public MovieTexture[] tutTextures;
	public string[] tutStrings;
	public int currentTut;



	// Use this for initialization
	void Start () {
		tutStrings[0]= "Bunny short vid";
		tutStrings[1] = "Bunny longer vid";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

		GUI.skin = Resources.Load ("Buttons/ShopSkin") as GUISkin;
		GUI.skin.box.fixedWidth = 800;
		GUI.skin.box.fixedHeight = 3*Screen.height/4;
		GUI.Box(new Rect((Screen.width/2)-(GUI.skin.box.fixedWidth/2), (Screen.height/2)-(GUI.skin.box.fixedHeight/2), 0, 0), "Tutorials");
		GUI.skin = Resources.Load ("Buttons/ButtonSkin") as GUISkin;
		GUI.skin.box.fixedWidth = 500;
		GUI.skin.box.fixedHeight = 250;
		GUI.Box (new Rect ((Screen.width / 2) - (GUI.skin.box.fixedWidth / 2), Screen.height/6, 0, 0),tutTextures[currentTut] as MovieTexture);
		tutTextures[currentTut].Play();
		tutTextures[currentTut].loop = true;
		GUI.skin.textField.fixedWidth = 500;
		GUI.skin.textField.fixedHeight = 250;
		GUI.TextField (new Rect ((Screen.width / 2) - (GUI.skin.box.fixedWidth / 2),Screen.height/6+250, 0, 0), tutStrings [currentTut]);

		// This button is to go to skip tutorials and start game
		if (GUI.Button (new Rect ((Screen.width/2)-GUI.skin.button.fixedWidth/2, (3*Screen.height/4 ) , GUI.skin.button.fixedWidth, GUI.skin.button.fixedHeight), "Skip Tutorials")) {
			Application.LoadLevel("SelectionMenu");			
		}

		// This button is to go to start game
		if (GUI.Button (new Rect ((Screen.width/2)+GUI.skin.button.fixedWidth/2, (3*Screen.height/4 ) , GUI.skin.button.fixedWidth, GUI.skin.button.fixedHeight), "Next")) {
			currentTut++;
			currentTut %= tutTextures.Length;
			if(tutTextures[currentTut].isPlaying){
				tutTextures[currentTut].Stop ();
			}
		}
	}
}
