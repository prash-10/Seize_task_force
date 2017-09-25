using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

using UnityEngine;
public class rotation : NetworkBehaviour {

	[SyncVar] private Quaternion syncPlayerRotation;
	[SyncVar] private Quaternion synGunRotation;
	// Use this for initialization
	[SerializeField] private Transform playerTransform;
	[SerializeField] private Transform gunTransform;
	[SerializeField] private float LerpRate=15.0f;
	void Start () {
		playerTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transmitRotations ();
		LerpRotation ();
	}

	void LerpRotation()
	{
		if (!isLocalPlayer) {
			playerTransform.rotation = Quaternion.Lerp (playerTransform.rotation, syncPlayerRotation, Time.deltaTime * LerpRate);
			gunTransform.rotation = Quaternion.Lerp (gunTransform.rotation,synGunRotation,Time.deltaTime * LerpRate);
		}
	}
	[Command]
	void CmdprovideRotationtoserver(Quaternion playerRot,Quaternion gunRot)
	{

		syncPlayerRotation = playerRot;
		synGunRotation = gunRot;
	}
	[Client]
	void transmitRotations(){
	if (isLocalPlayer) {
			CmdprovideRotationtoserver(playerTransform.rotation,gunTransform.rotation);
		}
	
	}
}
