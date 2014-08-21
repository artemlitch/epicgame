using UnityEngine;
using System.Collections;

public class ClientController : MonoBehaviour{

	public string gameName = "Artem_Mash_Game";
	public string serverName = "TestServer";
	public string serverDescription = "Super sick server";
	public string serverMessage = "";
	//string password = "TopSecret";
	public HostData[] hostData;
	bool refreshing;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}

	public void ConnectToServer() {
		Network.Connect("127.0.0.1", 25000);//, password);
		Debug.Log("Connecting To Server");
	}

	public void DisconnectFromServer() {
		Network.Disconnect();
		Debug.Log("Disconnecting From Server");
	}

	public void FindServer(){
		MasterServer.RequestHostList(gameName);
		if (MasterServer.PollHostList().Length != 0) {
			hostData = MasterServer.PollHostList();
			MasterServer.ClearHostList();
		}
		Debug.Log("Finding Server");
	}

	void OnConnectedToServer() {
		Debug.Log("Connected To Server"); 
	}

	void OnDisconnectedFromServer() {
		Debug.Log("Disconnected From Server"); 
	}

	void OnFailedToConnect() {
		Debug.Log("Failed");
	}


		



	//Functions Called By Server (needs to be in both files)
	[RPC]
	void LoadLevel (string level, int levelPrefix){
		Network.SetSendingEnabled(0, false);    
		Network.isMessageQueueRunning = false;
		Network.SetLevelPrefix(levelPrefix);
		GameManager.instance.GameMode=1;
		GameManager.instance.numberOfPlayers=1;
		GameManager.instance.playerInfo[0].pInput=PlayerInput.InputMethod.SingleplayerMouse;
		Application.LoadLevel(level);
		Network.isMessageQueueRunning = true;
		Network.SetSendingEnabled(0, true); 
	}


}