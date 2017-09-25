using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class player_identity : NetworkBehaviour {

	[SyncVar] public string playerUniqueName;
	private NetworkInstanceId playerNetId;
	private Transform mytransform;
	// Use this for initialization
	public override void OnStartLocalPlayer () {
		GetNetId();
		SetId();
		
	}
	void Awake()
	{
		mytransform = transform;
	}
	// Update is called once per frame
	void Update () {

		if (mytransform.name == "" || mytransform.name == "Player(Clone)") {
		
			SetId();
		}

	}
	[Client]
	void GetNetId()
	{
		playerNetId = GetComponent<NetworkIdentity> ().netId;
		CmdTellServerMyName (MakeUniqueIdentity ());

	}
	[Client]
	void SetId()
	{
	if (!isLocalPlayer) {
		
			mytransform.name = playerUniqueName;
		} 
		else {
			mytransform.name = MakeUniqueIdentity();
		
		}
	
	}
	string MakeUniqueIdentity ()
	{
		string uname = "Playeris" + playerNetId.ToString ();
		return uname;


	}
	[Command]
	void CmdTellServerMyName (string name)
	{
		playerUniqueName = name;

	}
}
