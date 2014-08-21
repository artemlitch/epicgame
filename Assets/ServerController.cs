using UnityEngine;
using System.Collections;

public class ServerController : MonoBehaviour{

	public string gameName = "Artem_Mash_Game";
	public string serverName = "TestServer";
	public string serverDescription = "Super sick server";
	//string serverPassword = "TopSecret";
	public bool useNat;

	public double serverTime;
	public int playersConnected;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
		useNat = !Network.HavePublicAddress();
	}
	
	void Update(){
		playersConnected = Network.connections.Length;
	}

	public void startServer(){
		Network.InitializeSecurity();
		//Network.incomingPassword = serverPassword;
		Network.InitializeServer(32, 25000, useNat); //(Connections, Port, useNat)
		MasterServer.RegisterHost(gameName, serverName, serverDescription);
		Debug.Log("Server Started");
	}
	
	
	public void closeServer(){	
		MasterServer.UnregisterHost();
		Network.Disconnect();
		Debug.Log("Server Closed");
	}

	void OnPlayerConnected() {
		Debug.Log("Player Connected");
	} 

	void OnPlayerDisconnected() {
		Debug.Log("Player Disconnected");
	} 


	public void LoadGame(){
		Debug.Log ("RPC Call");
		networkView.RPC("LoadLevel", RPCMode.Others, "Mash", 1);
	}
	
	public void LoadMenu(){
		Debug.Log ("RPC Call");
		networkView.RPC("LoadLevel", RPCMode.Others, "Client", 0);
	}



	//Functions to call for clients (these need to be here xD)
	[RPC] void LoadLevel (string level, int levelPrefix){}

}
