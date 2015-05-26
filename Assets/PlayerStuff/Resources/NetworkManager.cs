using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	SpawnSpot[] spawnSpots;
	bool connecting = false;
	public int team = 0;
	public int health = 100;
	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
		PhotonNetwork.player.name = "Name";
	}
	
	void Connect() {
		PhotonNetwork.ConnectUsingSettings( "CPGAME v0.1" );
	}
	
	void OnGUI() {
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString() );
		if(PhotonNetwork.connected == false && connecting == false)
		{
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();


			GUILayout.BeginHorizontal();
			GUILayout.Label("Username");
			//GUILayout.TextField("Username:");
			PhotonNetwork.player.name = GUILayout.TextField(PhotonNetwork.player.name);
			GUILayout.EndHorizontal();


			if(GUILayout.Button("SinglePlayer"))
			{
				connecting = true;
				PhotonNetwork.offlineMode = true;
				OnJoinedLobby();
			}
			if(GUILayout.Button("MultiPlayer"))
			{
				connecting = true;
				Connect ();
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();

			if(GUILayout.Button("Team1"))
			{
				team = 1;
			}
			if(GUILayout.Button("Team0"))
			{
				team = 0;
			}
		}
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}
	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom ( null );
	}

	void SpawnMyPlayer()
	{
		SpawnSpot MySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
		if(team == 1)
		{
			GameObject MyPlayer = (GameObject)PhotonNetwork.Instantiate("Team1PlayerController", MySpawnSpot.transform.position, MySpawnSpot.transform.rotation, 0);
			((MonoBehaviour)MyPlayer.GetComponent("FirstPersonController")).enabled = true;
			MyPlayer.GetComponent<RangedWeapon>().enabled = true;
			MyPlayer.GetComponentInChildren<Camera>().enabled = true;
		}
		if(team == 0)
		{
			GameObject MyPlayer = (GameObject)PhotonNetwork.Instantiate("Team0PlayerController", MySpawnSpot.transform.position, MySpawnSpot.transform.rotation, 0);
			((MonoBehaviour)MyPlayer.GetComponent("FirstPersonController")).enabled = true;
			MyPlayer.GetComponent<RangedWeapon>().enabled = true;
			MyPlayer.GetComponentInChildren<Camera>().enabled = true;
		}

	}
	void OnJoinedRoom()
	{
		connecting = false;
		Debug.Log ("Joined Room");
		SpawnMyPlayer();
	}
	// Update is called once per frame
	void Update () {
	}
}
