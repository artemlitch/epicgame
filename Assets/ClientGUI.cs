using UnityEngine;
using System.Collections;

public class ClientGUI : MonoBehaviour {
	public static ClientController ClientCont;
	void Awake() {
		ClientCont = gameObject.AddComponent<ClientController>();
	}
	void OnGUI () {
		if(Application.loadedLevelName == "Client"){
			GUI.Label(new Rect(10,10,100,90), "Client");
				
				
			if(GUI.Button(new Rect(20,40,80,20), "Connect")) {
				ClientCont.ConnectToServer();
			}
				
				
			if(GUI.Button(new Rect(20,70,80,20), "Disconnect")) {
					ClientCont.DisconnectFromServer();
			}
				
			GUI.Label(new Rect(150,10,100,90), "Message: " + ClientCont.serverMessage);
		}
			
	}
}
