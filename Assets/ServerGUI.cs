using UnityEngine;
using System.Collections;

public class ServerGUI : MonoBehaviour {

	public static ServerController ServerCont;

	void Awake(){
		ServerCont = gameObject.AddComponent<ServerController>();
	}

	void OnGUI () {

		GUI.Label(new Rect(10,10,100,90), "Server");
		

		if(GUI.Button(new Rect(20,40,80,20), "Start")) {
			ServerCont.startServer();
		}
		

		if(GUI.Button(new Rect(20,70,80,20), "End")) {
			ServerCont.closeServer();
		}

		if(GUI.Button(new Rect(20,100,80,20), "Load Game")) {
			ServerCont.LoadGame();
		}

		if(GUI.Button(new Rect(20,130,80,20), "Back")) {
			ServerCont.LoadMenu();

		}


		GUI.Label(new Rect(150,10,100,90), "Status: ");
		GUI.Label(new Rect(150,25,200,200), "Players Connected: " + ServerCont.playersConnected);

	}
}